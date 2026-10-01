# Hansen Equipment Manager

Advisor Mode lists what each active character can wear and can equip one chosen item.
**Equip Profile** previews and applies the matching profile’s Ready rules.

Equip uses `CanInsertItem`, then `RemoveItem`, then `InsertItem`, then checks that the blueprint is in the slot.
It does not edit `party.json` or any `.zks` save, and it does not copy weapon sets.

## Profiles

Profile JSON files load at startup from `Profiles/`.

| Profile | Match | Role |
|---|---|---|
| `Angel_Oracle_IE.json` | Oracle + Angel main | Full IE Angel party loadout rules (Hansen + companions). See `Docs/Angel_IE_Loadout.md`. |
| `SwordSaint_Trickster_IE.json` | Sword Saint / Trickster | Match only; no item rules yet. |
| `Lich_Wizard_IE.json` | Wizard / Lich | Match only; no item rules yet. |

### Profile rule fields

- `character` / `unitId` — target party member
- `slot` — equipment slot (`PrimaryHand`, `SecondaryHand`, `Armor`, `Shirt`, `Head`, `Glasses`, `Neck`, `Ring1`, `Ring2`, `Gloves`, `Wrist`, `Feet`, `Belt`, `Cloak`)
- `blueprint` — item blueprint name, or `__UNEQUIP__` / `none` / empty to clear the slot
- `donor` / `donorUnitId` — optional source character when the item is currently worn elsewhere

`Scan Party` names a matching profile for the main character. It does not equip anything by itself.

## Buttons

1. **Scan Party** — detect party, builds, matching profile
2. **Generate Equipment List** — Advisor list for selected character/slot
3. **Equip Selected Item** — equip one Advisor pick
4. **Equip Profile** — preview matching profile rules, equip Ready plans only
5. **Export Report** — overwrite `report.txt`

## Recommendation / BuildRules

`BuildRules/*.json` holds match tags and weights for Advisor scoring.
Covered builds include Angel Oracle, Zen Archer, Sword Saint Trickster, Wizard Lich, Scrollmaster, and Master Spy.
Advisor Mode uses them for match and factual tags; it does not auto-equip from BuildRules alone.

## Report

Export Report overwrites `Mods/HansenEquipmentManager/report.txt`.
Header includes `Version: Advisor Mode` and a build id (for example `Oracle_Angel` shown as Oracle Angel).
Each character section lists UniqueId, class/archetype/mythic, then every slot with Current and Available items.

## Angel IE party docs

Full English slot audits, KEEP/CHANGE rationale, donors, and unequip notes:

- [`Docs/Angel_IE_Loadout.md`](Docs/Angel_IE_Loadout.md)

## Build on this machine

`Build.ps1` uses Visual Studio Build Tools `csc.exe` and the local WotR assemblies.

```powershell
.\Build.ps1
# or, if the game is on D:
.\Build.ps1 -GameDir "D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure"
```

The old `HansenRuntimeEquipFix` mod is disabled by renaming its `Info.json`, so both mods do not load.
