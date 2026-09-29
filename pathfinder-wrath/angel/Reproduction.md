# Reproduce Hansen's angel setup

Read this file first. It describes the Buff It copy that is already stored. Do not edit that JSON, and do not copy it into the game, until a later request says to change it.

The game does not read this folder. `BuffIt-OneClickBuff.md` names the same rows. This file adds the spell guids and the scroll and potion caster entries that the older table left out. If the two disagree, `buffit-current-config.json` wins. That loose file is identical to the `buffit-current-config.json` member inside `WrathModsConfiguration.zip`.

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

`Version` is 1. Verbose casting, skip animations, cast on combat start, allow in combat, bypass arcane failure, and overwrite are all false. Source priority is 0. Use Magic Device retries are 3 and mode is 1. Scrolls, potions, equipment, songs, and activatables are enabled. Sort by name is false. There is no menu hotkey. `CasterRanks`, `MountPreference`, and `FuryWeaponPreference` are empty.

Hansen's Oracle book does not have Enduring Spells or Greater Enduring Spells. Round-per-level spells are on Quick or Important, not Normal.

| Button | `InGroups` | Rows |
|---|---|---|
| Normal | `Long` | 56 |
| Quick | `Quick` | 9 |
| Important | `Important` | 4 |

The three buttons do not include each other. Normal does not cast Quick or Important.

Every row has `UseSpells`, `UseScrolls`, `UsePotions`, and `UseEquipment` true. `UseExtendRod` and `CastOnCombatStart` are false. `Blacklisted` is false.

`SourceType` 0 is a spellbook. `SourceType` 1 is a scroll, with an all-zero spellbook. `SourceType` 2 is a potion, with an all-zero spellbook. Caster order is the order in the JSON. The first caster is tried first.

Prepared casters still need the spell memorized. Hansen does not. If a backup caster is listed, the row can still fire from that backup when the first caster has no slot.

Nenio prepares Heroic Invocation, Haste, Cat's Grace Mass, True Seeing Communal, Stoneskin, Foresight, Seamantle, Mirror Image, Displacement, and Mage Armor.

Arueshalae prepares Longstrider Greater, Hurricane Bow, Aspect of the Falcon, Animal Growth, and Magic Fang Greater. Barkskin lists her first and Hansen second.

Galfrey prepares Bestow Grace, Bestow Grace of the Champion, Bless Weapon, Veil of Heaven, Veil of Positive Energy, Aura of Greater Courage, Angelic Aspect Greater, and Eaglesoul.

Sosiel prepares Divine Power, Righteous Might, and Eaglesoul. Mass ability scores, Death Ward, Holy Aura, and Prayer list him and also list Hansen or another backup.

BUFF_TABLE_HERE

## Leave these as they are

- Do not create a Wrath Tactics file for this GameId.
- Do not put round-per-level spells onto Normal. Haste, Prayer, Divine Power, Righteous Might, Eaglesoul, Holy Hymn, Circle of Clarity, Displacement, and Bestow Grace of the Champion stay on Quick. Fortress of the Faithful, Sun Form, Avenger's Blessing, and Holy Aura stay on Important.
- Do not add the spells the older note removed: Unholy Aura, Cloak of Chaos, the genie forms, Shapechange, Ice Body, Fiery Body, Frightful Aspect, Transformation, Winds of Vengeance, Cave Fangs, Army of Heaven, Phoenix Gift, Jolting Portent, True Strike, Bless, Aid, Shield of Law, or Greater Magic Weapon on the off hand.
- Sun Form stays on Hansen only.
- Do not copy this file onto the sword saint GameId or onto `ForImport_1.zks`.
