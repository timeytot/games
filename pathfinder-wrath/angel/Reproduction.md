# Reproduce Hansen's angel setup

Read this file for GameId paths, party unit ids, and the Buff It / gear reproduction notes for **this campaign**. Shared Buff It behavior (buttons, JSON fields, personal spells, restore checklist) is documented in [../BuffIt-Guide.md](../BuffIt-Guide.md). The short campaign pointer is [BuffIt-OneClickBuff.md](./BuffIt-OneClickBuff.md).

The game does not read this folder. If notes and JSON disagree, `buffit-current-config.json` wins.

There is no Wrath Tactics file for this GameId in this folder, in the zip, or in the live UserSettings folder. Do not create one.

## Where the bytes are

GameId: `fea04e92a6f54507a84b86b8444eec8f`

| Piece | Where the game would read it | Copy that already exists |
|---|---|---|
| Buff It 2 The Limit | `Mods\BuffIt2TheLimit\UserSettings\bi2tl-fea04e92a6f54507a84b86b8444eec8f.json` | `buffit-current-config.json` |
| Wrath Tactics | No file | None |

Game install:

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure
```

Saves:

```
C:\Users\timeg\AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games
```

On 2026-09-30 the live UserSettings folder does not contain this GameId. Leave it alone.

When a later request says to restore Buff It: close `Wrath.exe`, copy `buffit-current-config.json` onto the live path above, and keep the GameId in the filename. Do not reformat the JSON.

## Party

Ids match `UniqueId` in the save. Hansen is spontaneous. Angel spells are merged into the Oracle book. Lann and the wolf have no spellbook and only receive buffs.

| Character | Unit id | Spellbook |
|---|---|---|
| Hansen | `360c7122-3094-4ab4-9706-04ae85f7715a` | Oracle `6c033647-12b4-1594-1a98-f74522a81273` |
| Lann | `e437d264-30d0-4f82-b498-10d5779735e1` | None |
| Nenio | `a362b4fa-464a-43df-99cf-48216117e70b` | Wizard `5a38c9ac-8607-8904-09fc-b8f6342da6f4` |
| Sosiel | `3e1e0b22-78e6-475f-b09c-e4beac1bbca1` | Cleric `4673d19a-0cf2-fab4-f885-cc4d1353da33` |
| Arueshalae | `166F1D` | Master Spy `12bfcf91-d541-6b04-7a2a-9110ff8968c5` |
| Galfrey | `5A6856` | Paladin `bce4989b-070c-e924-b986-bf346f59e885` |
| Wolf | `47CDA1` | None |

## Save on disk

`Manual_8_Threshold__5_Abadius__I__4717__15_49_23.zks` is this GameId.

| Header field | Value |
|---|---|
| `Name` | `Threshold -5 Abadius (I) 4717 -15:49:23` |
| `PlayerCharacterName` | Hansen |
| `GameId` | `fea04e92a6f54507a84b86b8444eec8f` |
| `GameTotalTime` | `8.09:40:26.2060000` |
| `Area` | `9044849df0db4e6f9572f0d89c17bfcc` |

`ForImport_1.zks` is also named Hansen, and its GameId is `cd14e1db75594fff95cf52e3e3d50a27`. Do not point this Buff It file at that save.

The later quicksave is `Quick_7.zks`, header name `Quicksave1 1`, in-game total time `8.09:49:36.0960000`. Daeran and Sosiel were equipped in that file on 2026-09-30. The assignment, the priority order, and how a slot is linked to an item are in [Gear.md](./Gear.md).

## Buff It

Field meanings, button groups, `SourceType` values, and restore steps: [../BuffIt-Guide.md](../BuffIt-Guide.md).

Authoritative row list: [`buffit-current-config.json`](./buffit-current-config.json). Campaign pointer: [BuffIt-OneClickBuff.md](./BuffIt-OneClickBuff.md).

Current snapshot policy for this GameId: **all rows on Normal (`Long`)**; Quick and Important empty. Remap `Wanted` / `Casters` whenever the active party changes. Personal-range spells require each Wanted unit to self-cast.

Older party tables below (Lann / Nenio / Sosiel era) are historical id references only. Prefer unit ids from the latest save’s `party.json`.

## Leave these as they are

- Do not create a Wrath Tactics file for this GameId.
- Do not copy this Buff It file onto another campaign’s GameId (including the sword saint save or `ForImport_1.zks`).
- Prefer fixing `Wanted` / preparation over deleting rows that show zero casts.
