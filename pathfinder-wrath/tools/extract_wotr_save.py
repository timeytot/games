"""Read-only extractor for the newest WotR save copy.

Writes current/*.json and Current_Report.md. Does not touch the original .zks.
"""
import argparse
import datetime as dt
import json
import os
import zipfile

KNOWN = [
    ("2c002cb0-2987-4e37-a575-eb5cdd155850", "FaN"),
    ("5728", "Kestoglyr"),
    ("5568", "Ciar"),
    ("55FD", "Horse"),
    ("57A6", "Staunton Vhane"),
    ("56A0", "Queen Galfrey"),
    ("5611", "Delamere"),
    ("2805", "Skeletal Marksman"),
]
ABILITY_STATS = (
    "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma",
)
EXTRA_STATS = ("HitPoints", "AC", "Initiative", "SaveFortitude", "SaveReflex", "SaveWill")


def load_names(cheat_path):
    names = {}
    paths = {}
    if not cheat_path or not os.path.exists(cheat_path):
        return names, paths
    data = json.load(open(cheat_path, encoding="utf-8"))
    for entry in data.get("Entries") or []:
        guid = (entry.get("Guid") or "").replace("-", "").lower()
        if not guid:
            continue
        names[guid] = entry.get("Name") or guid
        paths[guid] = (entry.get("Path") or "").replace("\\", "/")
    return names, paths


def gname(names, guid):
    if not isinstance(guid, str) or not guid:
        return None
    return names.get(guid.replace("-", "").lower())


def index_ids(obj, ids):
    if isinstance(obj, dict):
        i = obj.get("$id")
        if isinstance(i, str):
            ids[i] = obj
        for value in obj.values():
            index_ids(value, ids)
    elif isinstance(obj, list):
        for value in obj:
            index_ids(value, ids)


def resolve(obj, ids, depth=0):
    if depth > 12 or not isinstance(obj, dict) or set(obj) != {"$ref"}:
        return obj
    return resolve(ids.get(obj["$ref"], obj), ids, depth + 1)


def known_name(uid):
    uid = str(uid or "")
    for key, name in KNOWN:
        if uid == key or uid.endswith(key):
            return name
    return None


def is_party_unit(unit, ids):
    if known_name(unit.get("UniqueId")):
        return True
    parts = resolve(unit.get("Parts") or {}, ids)
    for part in (parts.get("m_Parts") or []) if isinstance(parts, dict) else []:
        part = resolve(part, ids)
        if not isinstance(part, dict):
            continue
        type_name = part.get("$type") or ""
        if "UnitPartCompanion" in type_name or "UnitPartPet" in type_name:
            return True
    return False


def stat_pair(stats, ids, key):
    raw = stats.get(key) if isinstance(stats, dict) else None
    obj = resolve(raw, ids) if isinstance(raw, dict) else None
    if not isinstance(obj, dict):
        return None
    return {"base": obj.get("m_BaseValue"), "permanent": obj.get("PermanentValue")}


def fact_rows(unit, ids, names, paths):
    facts = resolve(unit.get("Facts") or {}, ids)
    rows = []
    if not isinstance(facts, dict):
        return rows
    for fact in facts.get("m_Facts") or []:
        fact = resolve(fact, ids)
        if not isinstance(fact, dict):
            continue
        guid = fact.get("Blueprint")
        name = gname(names, guid) if isinstance(guid, str) else None
        path = paths.get(guid.replace("-", "").lower(), "") if isinstance(guid, str) else ""
        kind = "feature"
        if "/Feats/" in path or path.startswith("Feats/"):
            kind = "feat"
        elif "/Mythic/" in path or path.startswith("Mythic/"):
            kind = "mythic"
        type_name = (fact.get("$type") or "").split(".")[-1].split(",")[0]
        if "Buff" in type_name:
            kind = "buff"
        elif "Activatable" in type_name:
            kind = "toggle"
        row = {
            "name": name,
            "guid": guid,
            "kind": kind,
            "type": type_name,
            "active": fact.get("IsActive"),
        }
        if "m_IsOn" in fact:
            row["is_on"] = fact.get("m_IsOn")
        rows.append(row)
    return rows


def class_order(unit, names):
    order = (unit.get("Descriptor") or {}).get("Progression", {}).get("m_ClassesOrder") or []
    return [gname(names, g) or g for g in order]


def class_levels(unit, names):
    classes = (unit.get("Descriptor") or {}).get("Progression", {}).get("Classes") or []
    out = []
    for item in classes:
        if not isinstance(item, dict):
            continue
        out.append({
            "class": gname(names, item.get("CharacterClass")) or item.get("CharacterClass"),
            "level": item.get("Level"),
        })
    return out


def equipment(unit, ids, names):
    uid = str(unit.get("UniqueId") or "")
    inv = resolve((unit.get("Descriptor") or {}).get("m_Inventory") or {}, ids)
    worn = []
    if not isinstance(inv, dict):
        return worn
    for item in inv.get("m_Items") or []:
        item = resolve(item, ids)
        if not isinstance(item, dict):
            continue
        wielder = str(item.get("m_WielderRef") or "")
        if wielder != uid and not (wielder and uid.endswith(wielder)):
            continue
        slot = resolve(item.get("HoldingSlot") or {}, ids)
        slot_type = ""
        if isinstance(slot, dict):
            slot_type = (slot.get("$type") or "").split(",")[0].split(".")[-1]
        guid = item.get("m_Blueprint")
        worn.append({
            "slot_type": slot_type,
            "name": gname(names, guid) if isinstance(guid, str) else None,
            "guid": guid,
            "unique_id": item.get("UniqueId"),
            "dex_limit": (resolve(item.get("m_DexBonusLimeterAC") or {}, ids) or {}).get("Value")
            if isinstance(item.get("m_DexBonusLimeterAC"), dict) else None,
        })
    return worn


def ac_fragment(unit, ids):
    uid = str(unit.get("UniqueId") or "")
    inv = resolve((unit.get("Descriptor") or {}).get("m_Inventory") or {}, ids)
    if not isinstance(inv, dict):
        return None
    for item in inv.get("m_Items") or []:
        item = resolve(item, ids)
        if not isinstance(item, dict) or "m_DexBonusLimeterAC" not in item:
            continue
        wielder = str(item.get("m_WielderRef") or "")
        if wielder != uid and not uid.endswith(wielder):
            continue
        limiter = resolve(item.get("m_DexBonusLimeterAC") or {}, ids)
        if not isinstance(limiter, dict):
            continue
        applied = resolve(limiter.get("AppliedTo") or {}, ids)
        if not isinstance(applied, dict):
            continue
        mods = []
        for mod in applied.get("PersistentModifierList") or []:
            mod = resolve(mod, ids)
            if not isinstance(mod, dict):
                continue
            src = resolve(mod.get("ItemSource") or {}, ids)
            src_guid = src.get("m_Blueprint") if isinstance(src, dict) else None
            mods.append({
                "descriptor": mod.get("ModDescriptor"),
                "value": mod.get("ModValue"),
                "item_guid": src_guid,
            })
        return {
            "base": applied.get("m_BaseValue"),
            "dex_limit": limiter.get("Value"),
            "modifiers": mods,
        }
    return None


def spells(unit, ids, names):
    books = []
    for book in (unit.get("Descriptor") or {}).get("m_Spellbooks") or []:
        if not isinstance(book, dict):
            continue
        value = book.get("Value") or {}
        known = []
        for level, entries in enumerate(value.get("m_KnownSpells") or []):
            level_names = []
            for spell in entries or []:
                spell = resolve(spell, ids)
                if isinstance(spell, dict):
                    level_names.append(gname(names, spell.get("Blueprint")) or spell.get("Blueprint"))
            if level_names:
                known.append({"level": level, "spells": level_names})
        if value:
            books.append({
                "blueprint": gname(names, value.get("Blueprint")) if isinstance(value.get("Blueprint"), str) else value.get("Blueprint"),
                "level": value.get("m_BaseLevelInternal"),
                "known": known,
            })
    return books


def life(unit):
    state = (unit.get("Descriptor") or {}).get("State") or {}
    if not isinstance(state, dict):
        state = {}
    dead = state.get("LifeState") == "Dead" or state.get("IsFinallyDead") is True
    return {
        "life_state": state.get("LifeState"),
        "finally_dead": state.get("IsFinallyDead"),
        "damage": (unit.get("Descriptor") or {}).get("m_Damage"),
        "alive": not dead,
    }


def extract_unit(unit, ids, names, paths):
    uid = unit.get("UniqueId")
    stats = (unit.get("Descriptor") or {}).get("Stats") or {}
    abilities = {key: stat_pair(stats, ids, key) for key in ABILITY_STATS}
    extra = {key: stat_pair(stats, ids, key) for key in EXTRA_STATS}
    skills = {}
    for key, value in stats.items():
        if key.startswith("Skill"):
            skills[key] = stat_pair(stats, ids, key)
    rows = fact_rows(unit, ids, names, paths)
    return {
        "unit_id": uid,
        "name": known_name(uid) or gname(names, (unit.get("Descriptor") or {}).get("Blueprint")),
        "blueprint": (unit.get("Descriptor") or {}).get("Blueprint"),
        "life": life(unit),
        "class_levels": class_levels(unit, names),
        "class_order": class_order(unit, names),
        "abilities": abilities,
        "stats": extra,
        "skills": skills,
        "facts": rows,
        "equipment": equipment(unit, ids, names),
        "ac_fragment": ac_fragment(unit, ids),
        "spellbooks": spells(unit, ids, names),
    }


def names_of(rows, kind=None):
    out = []
    for row in rows:
        if kind and row.get("kind") != kind:
            continue
        if row.get("name"):
            out.append(row["name"])
    return out


def toggles(unit_doc):
    return [
        {"name": row["name"], "is_on": row.get("is_on"), "guid": row.get("guid")}
        for row in unit_doc["facts"]
        if row.get("kind") == "toggle" or "is_on" in row
    ]


def slim_character(unit_doc):
    return {
        "unit_id": unit_doc["unit_id"],
        "name": unit_doc["name"],
        "alive": unit_doc["life"]["alive"],
        "life": unit_doc["life"],
        "class_levels": unit_doc["class_levels"],
        "class_order": unit_doc["class_order"],
        "abilities": unit_doc["abilities"],
        "skills": {
            k: unit_doc["skills"].get(k)
            for k in ("SkillMobility", "SkillAthletics", "SkillPerception", "SkillPersuasion")
        },
        "feats": names_of(unit_doc["facts"], "feat"),
        "mythic": names_of(unit_doc["facts"], "mythic"),
        "feature_names": names_of(unit_doc["facts"], "feature"),
        "buffs": names_of(unit_doc["facts"], "buff"),
        "equipment": unit_doc["equipment"],
        "ac_fragment": unit_doc["ac_fragment"],
        "toggles": toggles(unit_doc),
        "spellbooks": unit_doc["spellbooks"],
        "immunities": [n for n in names_of(unit_doc["facts"]) if n and "Immun" in n],
    }


def find_named(party, name):
    for unit in party:
        if unit.get("name") == name:
            return unit
    return None


def diff_lines(old, new, label):
    lines = []
    if not old or not new:
        return lines
    old_armor = next((e.get("name") for e in old.get("equipment") or [] if e.get("slot_type") == "ArmorSlot"), None)
    new_armor = next((e.get("name") for e in new.get("equipment") or [] if e.get("slot_type") == "ArmorSlot"), None)
    if old_armor != new_armor:
        lines.append(f"- {label} armor: {old_armor} -> {new_armor}")
    old_feats = set(old.get("feats") or [])
    new_feats = set(new.get("feats") or [])
    for feat in sorted(new_feats - old_feats):
        lines.append(f"- {label} feat added: {feat}")
    for feat in sorted(old_feats - new_feats):
        lines.append(f"- {label} feat removed: {feat}")
    if old.get("alive") != new.get("alive"):
        lines.append(f"- {label} alive: {old.get('alive')} -> {new.get('alive')}")
    if old.get("class_levels") != new.get("class_levels"):
        lines.append(f"- {label} classes changed")
    return lines


def write_report(path, meta, party, kest, horse, differences):
    def equip_line(unit):
        if not unit:
            return "- not found"
        lines = []
        for item in unit.get("equipment") or []:
            lines.append(f"- {item.get('slot_type')}: {item.get('name')}")
        return "\n".join(lines) or "- none"

    def toggle_line(unit):
        if not unit:
            return "- not found"
        lines = []
        for item in unit.get("toggles") or []:
            lines.append(f"- {item.get('name')}: is_on={item.get('is_on')}")
        return "\n".join(lines) or "- none"

    party_lines = []
    for unit in party:
        levels = ", ".join(f"{c['class']} {c['level']}" for c in unit.get("class_levels") or [])
        party_lines.append(f"- {unit.get('name')} id={unit.get('unit_id')} alive={unit.get('alive')} classes={levels}")

    diff = "\n".join(differences) if differences else "- no previous current snapshot"

    text = f"""# Current WotR Snapshot

- Save: {meta['file_name']}
- Save timestamp: {meta['last_write_time']}
- SHA-256: {meta['sha256']}
- Generated: {meta['generated_at']}
- Source: read-only save/log extraction

## Party

{chr(10).join(party_lines)}

## Kestoglyr

- alive: {None if not kest else kest.get('alive')}
- classes: {None if not kest else kest.get('class_levels')}
- STR/DEX permanent: {None if not kest else (kest.get('abilities') or {}).get('Strength')} / {None if not kest else (kest.get('abilities') or {}).get('Dexterity')}
- Mobility ranks: {None if not kest else (kest.get('skills') or {}).get('SkillMobility')}
- armor: {next((e.get('name') for e in (kest or {}).get('equipment') or [] if e.get('slot_type') == 'ArmorSlot'), None)}

## Ciar Horse

- found: {horse is not None}
- alive: {None if not horse else horse.get('alive')}
- classes: {None if not horse else horse.get('class_levels')}
- feats: {None if not horse else horse.get('feats')}

## Current Equipment

### Kestoglyr
{equip_line(kest)}

### Horse
{equip_line(horse)}

## Combat Toggles

### Kestoglyr
{toggle_line(kest)}

### Horse
{toggle_line(horse)}

## Differences From Previous Snapshot

{diff}
"""
    open(path, "w", encoding="utf-8", newline="\n").write(text)


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--save", required=True)
    parser.add_argument("--cheatdata", required=True)
    parser.add_argument("--outdir", required=True)
    parser.add_argument("--sha256", required=True)
    parser.add_argument("--source-file", required=True)
    parser.add_argument("--last-write-time", required=True)
    parser.add_argument("--size", type=int, required=True)
    args = parser.parse_args()

    os.makedirs(args.outdir, exist_ok=True)
    previous_party_path = os.path.join(args.outdir, "Party_Current.json")
    previous_save_path = os.path.join(args.outdir, "Current_Save.json")
    previous_party = None
    previous_save = None
    if os.path.exists(previous_party_path):
        previous_party = json.load(open(previous_party_path, encoding="utf-8"))
    if os.path.exists(previous_save_path):
        previous_save = json.load(open(previous_save_path, encoding="utf-8"))

    names, paths = load_names(args.cheatdata)
    with zipfile.ZipFile(args.save) as zf:
        party_json = json.loads(zf.read("party.json"))
        header = json.loads(zf.read("header.json")) if "header.json" in zf.namelist() else {}

    ids = {}
    index_ids(party_json, ids)
    units = []
    for entity in party_json.get("m_EntityData") or []:
        if is_party_unit(entity, ids):
            units.append(extract_unit(entity, ids, names, paths))
    party = [slim_character(unit) for unit in units]
    kest = find_named(party, "Kestoglyr")
    horse = find_named(party, "Horse")

    generated = dt.datetime.now().astimezone().isoformat(timespec="seconds")
    meta = {
        "source_file": args.source_file,
        "file_name": os.path.basename(args.source_file),
        "last_write_time": args.last_write_time,
        "size": args.size,
        "sha256": args.sha256,
        "game_save_directory": os.path.dirname(args.source_file),
        "generated_at": generated,
        "header_name": header.get("Name"),
        "system_save_time": header.get("SystemSaveTime"),
        "game_save_time": header.get("GameSaveTime"),
        "game_total_time": header.get("GameTotalTime"),
        "player_character_name": header.get("PlayerCharacterName"),
    }

    differences = []
    if previous_save and previous_save.get("file_name") != meta["file_name"]:
        differences.append(f"- save changed: {previous_save.get('file_name')} -> {meta['file_name']}")
    if previous_party:
        old_by_name = {u.get("name"): u for u in previous_party}
        for unit in party:
            differences.extend(diff_lines(old_by_name.get(unit.get("name")), unit, unit.get("name")))

    dump = lambda name, obj: open(os.path.join(args.outdir, name), "w", encoding="utf-8", newline="\n").write(
        json.dumps(obj, ensure_ascii=False, indent=2) + "\n"
    )
    dump("Current_Save.json", meta)
    dump("Party_Current.json", party)
    dump("Kestoglyr_Current.json", kest)
    dump("Horse_Current.json", horse)
    open(os.path.join(args.outdir, "Current_Save.sha256"), "w", encoding="utf-8", newline="\n").write(args.sha256 + "\n")
    write_report(os.path.join(args.outdir, "Current_Report.md"), meta, party, kest, horse, differences)
    print(json.dumps({"units": len(party), "kest": kest is not None, "horse": horse is not None, "sha256": args.sha256}))


if __name__ == "__main__":
    main()
