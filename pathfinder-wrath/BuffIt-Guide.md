# Buff It 2 The Limit — generic guide

This guide applies to **any** Wrath of the Righteous campaign. Playthrough folders (`angel/`, `lich/`, `sword-saint/`, …) keep only GameId paths and config copies. Edit rules and troubleshooting live here.

Mod: **Buff It 2 The Limit** (verified with 1.21.1). The game never reads this repository.

## What the mod does

Buff It stores a per-campaign JSON and exposes three one-click buttons. Each button casts every non-blacklisted row whose `InGroups` contains that button’s group. The UI progress `N/M` is the sum of successful casts over the sum of `Wanted` targets across those rows — not “number of spell names.”

| Button (UI) | JSON `InGroups` value |
|---|---|
| Normal | `Long` |
| Quick | `Quick` |
| Important | `Important` |

Buttons do **not** nest. Pressing Normal never casts Quick or Important rows.

## Live file location

```
<GameInstall>\Mods\BuffIt2TheLimit\UserSettings\bi2tl-<GameId>.json
```

- `<GameId>` comes from the save header (`header.json` → `GameId`). One GameId is shared by every save of that campaign (manual, auto, quick).
- Different campaigns use different GameId files. Do not overwrite another campaign’s file.
- Close `Wrath.exe` before replacing the live JSON, or reopen the Buff It window after an in-place edit so the UI reloads.
- A repo file named `buffit-current-config.json` under a playthrough folder is only a backup. Copy it onto the live path when restoring; keep the `bi2tl-<GameId>.json` filename.

Find GameId: unzip a `.zks`, read `header.json`, or compare existing `bi2tl-*.json` names after loading that save once with the mod installed.

## Id formats

| Place | Format | Example |
|---|---|---|
| Buff It `Key.Guid`, spellbook ids | Hyphenated UUID | `e1291272-c8f4-8c14-ab21-2a599ad17aac` |
| Game blueprints / `cheatdata.json` | 32 hex, no hyphens | `e1291272c8f48c14ab212a599ad17aac` |
| Unit ids in `Wanted` / `Casters` | Full UUID **or** short id from the save | Matches `UniqueId` in `party.json` |

Resolve blueprint names from `<GameInstall>\Bundles\cheatdata.json` (`Name`, `Guid`, `TypeFullName`).

## One buff row

`Buffs` is an array of `{ Key, Value }`.

**Key**

| Field | Meaning |
|---|---|
| `Guid` | Spell or ability blueprint |
| `MetamagicMask` | `0` = no metamagic |
| `Archmage` | Usually `false` |

**Value (important fields)**

| Field | Meaning |
|---|---|
| `InGroups` | Which button(s) include this row (`Long` / `Quick` / `Important`) |
| `InGroup` | Legacy numeric field; ignore for editing — use `InGroups` |
| `Blacklisted` | `true` = skip forever |
| `Wanted` | Unit ids that should receive the buff |
| `Casters` | Who may cast; order is try-order |
| `Casters.Key.Name` | Caster unit id |
| `Casters.Key.Spellbook` | Spellbook blueprint id, or all zeros if unbound |
| `Casters.Key.SourceType` | `0` spellbook, `1` scroll (often zero spellbook), `2` potion, `4` toggle/activatable (e.g. song) |
| `Casters.Value.Banned` | Ban that caster on this row |
| `Casters.Value.Cap` | `-1` = no cast cap |
| `UseSpells` / `UseScrolls` / `UsePotions` / `UseEquipment` | Allowed sources for this row |
| `UseExtendRod` | Extend metamagic rod |
| `CastOnCombatStart` | Auto-cast when combat starts |
| `OverwriteBuff` (global) / row ignore fields | Whether replacing an existing same buff is allowed |

Prepared casters still need the spell memorized. Spontaneous casters need known spells and remaining slots. Listing a caster who does not know the spell does not make them cast it.

## Designing `Wanted` and `Casters`

1. **Range matters.** Personal spells only affect the caster. Touch / single-target need enough slots for every Wanted unit. Communal / mass usually need one cast for the group.
2. **Personal spells:** put each eligible unit in **both** `Wanted` and `Casters`, and only units that know (or can scroll) the spell. Someone who cannot self-cast will show as a permanent red `k/(k+1)` gap.
3. **Do not use display names** in JSON — only unit ids from the save.
4. **Remap when the party changes.** Old companion ids left in `Wanted`/`Casters` fail silently or waste slots. Rebuild ids from the current `party.json`.
5. **Match spellbook GUID to the book that actually contains the spell** on that character (class / mythic / merged books differ by character).
6. **Zero available casts ≠ delete the row.** It usually means no rest, not prepared, wrong spellbook, or `CanTarget=false`. Fix preparation or `Wanted` first.
7. **Hostile or wrong-affinity effects** (positive energy on undead, sleep auras next to living mounts, etc.) need narrowed `Wanted`, not blind party-wide lists.
8. **Short-duration (rounds)** spells are poor Normal candidates unless you accept burning slots for brief uptime. Prefer Quick/Important or cast manually.

## Reading the UI and Player.log

- Green progress on a row: casts succeeded for that row’s Wanted list.
- Red `a/b`: at least one Wanted target was not buffed (no credits, unreachable target, personal-only, illegal target, …).
- Mod log lines in `Player.log` look like: `no caster for '<Spell>': <Name> Spell credits=…` or `CanTarget=false`.
- After editing JSON, reopen Buff It (or restart) before judging results.

## Suggested button policy (generic)

| Button | Typical use |
|---|---|
| Normal (`Long`) | Long-duration pre-buffs after rest / on entering a dungeon |
| Quick (`Quick`) | Short buffs, HP-cost abilities, or “battle opener” casts |
| Important (`Important`) | Rare high-cost or situational long buffs you do not want every time |

A campaign may put **everything on Normal** and leave Quick/Important empty. That is valid if every row is safe to cast together after a rest.

## Common spellbook blueprint ids

These are class books, not character ids. Confirm against `cheatdata.json` if a DLC or mythic merge differs.

| Name | Guid (no hyphens) |
|---|---|
| OracleSpellbook | `6c03364712b415941a98f74522a81273` |
| ClericSpellbook | `4673d19a0cf2fab4f885cc4d1353da33` |
| WizardSpellbook | `5a38c9ac8607890409fcb8f6342da6f4` |
| PaladinSpellbook | `bce4989b070ce924b986bf346f59e885` |
| ShamanSpellbook | `44f16931dabdff643bfe2a48138e769f` |
| RangerSpellbook | `762858a4a28eaaf43aa00f50441d7027` |
| HunterSpellbook | `885cd422aa357e2409146b38bb1fec51` |
| WarpriestSpellbook | `7d7d51be2948d2544b3c2e1596fd7603` |
| SwordSaintSpellbook | `682545e11e5306c45b14ca78bcbe3e62` |

## Restore checklist

1. Confirm GameId from the save header.
2. Quit Wrath (or accept that you must reload the Buff It UI).
3. Back up the existing `bi2tl-<GameId>.json`.
4. Copy the playthrough `buffit-current-config.json` to the live filename.
5. Load the save → Spellbook → Buff It → verify group counts → press the intended button.
6. If a row stays red: check Personal range, known/prepared spells, slots, and whether each Wanted id is still in the party.

## Playthrough indexes

| Folder | Role |
|---|---|
| [angel/BuffIt-OneClickBuff.md](./angel/BuffIt-OneClickBuff.md) | Angel campaign pointer + config copy |
| [lich/BuffIt-OneClickBuff.md](./lich/BuffIt-OneClickBuff.md) | Lich campaign pointer + config copy |
| [sword-saint/BuffIt-OneClickBuff.md](./sword-saint/BuffIt-OneClickBuff.md) | Sword Saint campaign pointer + config copy |

Historical edit diaries (if present) stay under that playthrough as `BuffIt-ChangeLog.md` and are not required to operate the mod.
