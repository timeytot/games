# One-click buffs (Buff It 2 The Limit)

The file that matches the zip is [Reproduction.md](./Reproduction.md). The zip's `buffit-current-config.json` has 58 rows. This note is the older writeup. Do not rebuild the JSON from this note.

This note covers one-click buffs only. Wrath Tactics is separate.

Task for a later edit: using the file layout and the current config below, propose target lists and groups to change. Do not recommend deleting a row because the UI shows 0 casts. Zero casts only means the character had not rested, or the spell was not in the spellbook yet. Write the change with the unit ids and hyphenated spell ids from this note.

Snapshot time: 2026-09-27. The game was closed. `buffit-current-config.json` in the same folder is the full config copy from that moment. The file the game actually reads is not in this zip.

## File the game reads

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Mods\BuffIt2TheLimit\UserSettings\bi2tl-7ea3d466491c4249aec2742271c2e71a.json
```

- Mod: Buff It 2 The Limit 1.21.1
- `7ea3d466491c4249aec2742271c2e71a` in the filename is this save's GameId
- Save character: FaN
- Save location: Threshold, in-game date 17 Arodus 4715
- Save file: `Manual_1_Threshold__17_Arodus__VIII__4715__21_23_05.zks`
- The JSON is one line, with no line breaks

Two other saves have configs in that folder. Leave them alone:

- `bi2tl-fea04e92a6f54507a84b86b8444eec8f.json`: Hansen
- `bi2tl-a7c04407c8e142ffa2629983a3c6702d.json`: another save

## The three buttons

| Button | JSON group | Current rows |
|---|---|---|
| Normal Buffs | `Long` | Every row except the three below |
| Quick Buffs | `Quick` | Sickening Infusion, Focused Infusion, Commanding Infusion |
| Important Buffs | `Important` | No rows |

Normal tries to cast every row whose `InGroups` contains `Long`. Quick tries only `Quick`. The three Cruoromancer infusions cost FaN his own hit points, so they stay on Quick.

## Id format

Spell ids and spellbook ids in Buff It are hyphenated GUIDs, 8-4-4-4-12.

Game blueprints and Wrath Tactics use the same id as 32 lowercase hex characters with the hyphens removed.

Example:

- Buff It: `9e1ad5d6-f87d-19e4-d888-3d63a6e35568`
- Without hyphens: `9e1ad5d6f87d19e4d8883d63a6e35568`
- Blueprint name: `MageArmor`

Names come from `Bundles\cheatdata.json` in the game install. Fields are `Name`, `Guid`, and `TypeFullName`. `Guid` has no hyphens.

## Top-level fields

Current values:

| Field | Current value | Meaning |
|---|---|---|
| `Version` | 1 | Config version |
| `VerboseCasting` | false | Do not write a detailed cast log |
| `SkipAnimationsOnCombatStart` | false | Do not skip animations when combat starts |
| `CastAllOnCombatStart` | false | Do not cast every buff when combat starts |
| `AllowInCombat` | false | Do not use the one-click buttons in combat |
| `BypassArcaneSpellFailure` | false | Do not ignore arcane spell failure |
| `OverwriteBuff` | false | Do not overwrite an existing buff of the same kind |
| `GlobalSourcePriority` | 0 | Global source priority. 0 is the default |
| `CasterRanks` | {} | Empty |
| `MountPreference` | empty | No mount preference |
| `FuryWeaponPreference` | empty | Not set |
| `UmdRetries` | 3 | Retries after a Use Magic Device failure |
| `UmdMode` | 1 | Use Magic Device mode. The number is kept as stored |
| `ScrollsEnabled` | true | Scrolls are allowed |
| `PotionsEnabled` | true | Potions are allowed |
| `EquipmentEnabled` | true | Abilities on equipment are allowed |
| `SongsEnabled` | true | Songs are allowed |
| `ActivatablesEnabled` | true | Toggle abilities are allowed |
| `SortByName` | false | The UI is not sorted by name |
| `ShortcutKeys` | {} | No shortcuts |
| `OpenBuffMenuKey` | Key=None, Ctrl/Shift/Alt all false | No key opens the menu |

## One buff row

`Buffs` is an array. Each item is a `Key` plus a `Value`.

```json
{
  "Key": {
    "Guid": "hyphenated blueprint id of the spell or ability",
    "MetamagicMask": 0,
    "Archmage": false
  },
  "Value": {
    "InGroup": 0,
    "InGroups": ["Long"],
    "Blacklisted": false,
    "IgnoreForOverwriteCheck": null,
    "Wanted": ["unit id that should receive the buff"],
    "Casters": [
      {
        "Key": {
          "Name": "caster unit id",
          "Spellbook": "hyphenated spellbook blueprint id, or all zeros",
          "SourceType": 0
        },
        "Value": {
          "Banned": false,
          "Cap": -1,
          "PriorityOverride": null,
          "ShareTransmutation": false,
          "PowerfulChange": false,
          "ReservoirCLBuff": false,
          "UseAzataZippyMagic": false
        }
      }
    ],
    "BaseSpell": "00000000-0000-0000-0000-000000000000",
    "SourcePriorityOverride": -1,
    "UseSpells": true,
    "UseScrolls": true,
    "UsePotions": true,
    "UseEquipment": true,
    "UseExtendRod": false,
    "CastOnCombatStart": false,
    "DeactivateAfterRounds": 0
  }
}
```

Field meanings:

- `Key.Guid`: spell or ability to cast.
- `Key.MetamagicMask`: 0 means no metamagic. All 75 rows were 0.
- `Key.Archmage`: false on every row.
- `InGroups`: which button this row belongs to. Only `Long` and `Quick` were used.
- `InGroup`: old numeric field. Every row is 0. `InGroups` is the field that matters.
- `Blacklisted`: true means do not cast. Every row is false.
- `Wanted`: units that receive the buff. The one-click buttons only buff this list.
- `Casters`: units allowed to cast the row.
- `Casters.Key.Name`: caster unit id.
- `Casters.Key.Spellbook`: which spellbook to use. All zeros means the caster record is not bound to a spellbook.
- `Casters.Key.SourceType`: 0 is a spellbook cast. 1 together with an all-zero spellbook means a scroll or another non-spellbook source. 4 appears on toggle abilities, such as a bard song toggle.
- `Cap`: -1 means no limit on how many times it can be cast.
- `Banned`: true bans that caster from this row.
- `SourcePriorityOverride`: -1 keeps the global source priority.
- `UseSpells` / `UseScrolls` / `UsePotions` / `UseEquipment`: which sources this row may use.
- `UseExtendRod`: whether to use an Extend metamagic rod. Every row is false.
- `CastOnCombatStart`: whether to cast this row on its own when combat starts. Every row is false.
- `DeactivateAfterRounds`: 0 means do not turn it off after a number of rounds.

## Unit ids

These ids come from Buff It `Wanted` and `Casters`, and they match `m_OwnerRef` in the save's `party.json`.

| Unit id | What the save establishes | Spellbook id |
|---|---|---|
| `2c002cb0-2987-4e37-a575-eb5cdd155850` | FaN. Half-elf, Wizard 20, Cruoromancer, Lich mythic class 8, mythic starting class 2, mythic rank 10 total. Has the undead type. | `5a38c9ac-8607-8904-09fc-b8f6342da6f4` |
| `56A0` | Bard, with mythic companion levels. Has the undead type. | `bc04fc15-7a88-01d4-1b87-7ad0d9af03dd` |
| `57A6` | Warpriest, with mythic companion levels. Has the undead type. | `7d7d51be-2948-d254-4b3c-2e1596fd7603` |
| `2805` | Has a spellbook. Has the undead type. The class name was not stored as text next to the unit. | `d731dfb3-9ea2-6754-c89b-58d0969ea9e0` |
| `5568` | Has the undead type. | No bound spellbook |
| `5611` | Has the undead type. | No bound spellbook |
| `5728` | Has the undead type. | No bound spellbook |
| `55FD` | The only one of these eight ids without the undead type. The tactics UI has a Horse slot, and this id is used for that horse. | No bound spellbook |

The undead-type blueprint is `734a29b693e9ec346ba2951b27987e33`, name `UndeadType`. Each of the seven units above has one. `55FD` does not.

The companion page also shows Ciar, Queen Galfrey, Delamere, Staunton Vhane, Kestoglyr, and Skeletal Marksman. The save JSON does not store those display names next to the short ids, so this table does not guess which short id is which name.

## Rows already changed for the lich party

The rows are still present. What changed is `Wanted` and the group.

| Blueprint | Id | Group | Current targets | Reason |
|---|---|---|---|---|
| Virtue | `d3a85238-5ba4-cd74-0992-d1970170301a` | Long | only `55FD` | Positive-energy cantrip. It harms negative-energy affinity |
| DeathWardCast | `e9cc9378-fd68-41f4-8ad5-9384e79e9953` | Long | only `55FD` | Immunity to negative energy blocks negative-energy healing for the lich and undead allies |
| BlessingOfUnlife | `2abf1b69-cec7-60d4-ebc7-3d5ce8d79f0a` | Long | only `55FD` | Temporarily treats a living creature as undead. Units that are already undead do not need it |
| SickeningInfusionAbility | `18929b7e-343c-49ef-aafa-88f798c11be8` | Quick | only FaN | Cruoromancer infusion. Casting it spends his own hit points |
| FocusedInfusionAbility | `5a5d3a4b-cbc5-4ea1-b858-1923373fd992` | Quick | only FaN | Same |
| CommandingInfusionAbility | `6489492a-3499-4d00-926e-8802c3f2b4cf` | Quick | only FaN | Same |

Haste, Heroism, Deny Death, Mage Armor, and similar rows still target the whole list, including FaN.

## Original 75 rows

Column notes:

- Group: `Long` is the Normal button, `Quick` is the Quick button
- Metamagic: `MetamagicMask`
- Targets: `Wanted`
- Casters: `unit/book=spellbook/src=source type`
- Source toggles: whether the row allows spells, scrolls, potions, gear, and an Extend rod

| # | Blueprint | Buff It id | Id without hyphens | Group | Metamagic | Targets | Casters | Source toggles |
|---|---|---|---|---|---|---|---|---|
|---|---|---|---|---|---|---|---|---|

| 1 | Resistance | 7bc8e27c-ba24-f0e4-3ae6-4ed201ad5785 | 7bc8e27cba24f0e43ae64ed201ad5785 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0; 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0; 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0; 2805/book=d731dfb3-9ea2-6754-c89b-58d0969ea9e0/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 2 | MageArmor | 9e1ad5d6-f87d-19e4-d888-3d63a6e35568 | 9e1ad5d6f87d19e4d8883d63a6e35568 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 57A6, 5568, 56A0, 5611, 5728, 2805, 55FD | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0; 2c002cb0-2987-4e37-a575-eb5cdd155850/book=00000000-0000-0000-0000-000000000000/src=1; 5568/book=00000000-0000-0000-0000-000000000000/src=1; 56A0/book=00000000-0000-0000-0000-000000000000/src=1; 5611/book=00000000-0000-0000-0000-000000000000/src=1; 57A6/book=00000000-0000-0000-0000-000000000000/src=1; 5728/book=00000000-0000-0000-0000-000000000000/src=1; 2805/book=00000000-0000-0000-0000-000000000000/src=1 | spells=True scrolls=True potions=True gear=True rod=False |
| 3 | MageShield | ef768022-b078-5eb4-3a18-969903c537c4 | ef768022b0785eb43a18969903c537c4 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 4 | MirrorImage | 3e4ab69a-da40-2d14-5a5e-0ad3ad4b8564 | 3e4ab69ada402d145a5e0ad3ad4b8564 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 56A0, 2805 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0; 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0; 2805/book=d731dfb3-9ea2-6754-c89b-58d0969ea9e0/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 5 | ProtectionFromEvilCommunal | 93f391b0-c5a9-9e04-e83b-bfbe3bb6db64 | 93f391b0c5a99e04e83bbfbe3bb6db64 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0; 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 6 | ProtectionFromArrowsCommunal | 96c9d98b-6a9a-7c24-9b6c-4572e4977157 | 96c9d98b6a9a7c249b6c4572e4977157 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 7 | EyesOfTheBodak | e9c9a61b-81a2-9794-2a32-6c91da2af8ca | e9c9a61b81a297942a326c91da2af8ca | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 8 | VampiricBlade | 81ac91fe-9224-0a84-78b5-d2512c9fbec2 | 81ac91fe92240a8478b5d2512c9fbec2 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 9 | FalseLifeGreater | dc6af3b4-fd14-9f84-1912-d8a3ce0983de | dc6af3b4fd149f841912d8a3ce0983de | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 10 | VampiricShadowShield | a3492103-5f2a-6714-e9be-5ca76c5e34b5 | a34921035f2a6714e9be5ca76c5e34b5 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 11 | MindBlankCommunal | 87a29feb-d010-9934-19f2-a4a9bee11cfc | 87a29febd010993419f2a4a9bee11cfc | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 12 | UnbreakableHeart | dd38f33c-56ad-00a4-da38-6c1afaa49967 | dd38f33c56ad00a4da386c1afaa49967 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 13 | Haste | 486eaff5-8293-f644-1a5c-2759c4872f98 | 486eaff58293f6441a5c2759c4872f98 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0; 2805/book=d731dfb3-9ea2-6754-c89b-58d0969ea9e0/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 14 | Heroism | 5ab0d42f-b68c-9e34-abae-4921822b9d63 | 5ab0d42fb68c9e34abae4921822b9d63 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0; 2805/book=d731dfb3-9ea2-6754-c89b-58d0969ea9e0/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 15 | FreedomOfMovementCast | 0087fc2d-64b6-0954-78bc-7b8d7d512caf | 0087fc2d64b6095478bc7b8d7d512caf | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0; 2805/book=d731dfb3-9ea2-6754-c89b-58d0969ea9e0/src=0; 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 16 | CloakofDreams | 7f71a70d-822a-f944-58dc-1a235507e972 | 7f71a70d822af94458dc1a235507e972 | Long | 0 | 56A0 | 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 17 | Virtue | d3a85238-5ba4-cd74-0992-d1970170301a | d3a852385ba4cd740992d1970170301a | Long | 0 | 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 18 | Guidance | c3a8f317-78c3-9804-98d8-f00c980be5f5 | c3a8f31778c3980498d8f00c980be5f5 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 19 | Prayer | faabd2cc-67ef-a464-6ac5-8c7bb3e40fcc | faabd2cc67efa4646ac58c7bb3e40fcc | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 20 | DivinePower | ef16771c-b05d-1344-9895-19e87f25b3c5 | ef16771cb05d1344989519e87f25b3c5 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 21 | Eaglesoul | 332ad682-73db-9704-ab0e-92518f2efd1c | 332ad68273db9704ab0e92518f2efd1c | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 22 | SlayersAdvanceAbility | 7c7bc929-9a32-08b4-eb89-b3e235af3f36 | 7c7bc9299a3208b4eb89b3e235af3f36 | Long | 0 | 5611 | 5611/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 23 | SickeningInfusionAbility | 18929b7e-343c-49ef-aafa-88f798c11be8 | 18929b7e343c49efaafa88f798c11be8 | Quick | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 24 | DeadlyPerformanceAbility | c182f145-0932-c634-e954-148a9b16618d | c182f1450932c634e954148a9b16618d | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 56A0/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 25 | CavalierLionsCallAbility | 54d608d1-85f0-b9f4-5a56-da7dbd59eb90 | 54d608d185f0b9f45a56da7dbd59eb90 | Long | 0 | 5568 | 5568/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 26 | FocusedInfusionAbility | 5a5d3a4b-cbc5-4ea1-b858-1923373fd992 | 5a5d3a4bcbc54ea1b8581923373fd992 | Quick | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 27 | CommandingInfusionAbility | 6489492a-3499-4d00-926e-8802c3f2b4cf | 6489492a34994d00926e8802c3f2b4cf | Quick | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 28 | CavalierForTheKingAbility | e35e2ea6-a3b6-3894-9baf-78959ef5c5fd | e35e2ea6a3b638949baf78959ef5c5fd | Long | 0 | 5568 | 5568/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 29 | StrengthBlessingMinorAbility | 5bf81563-58e4-48a4-c8b9-ebc347471228 | 5bf8156358e448a4c8b9ebc347471228 | Long | 0 | 57A6 | 57A6/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 30 | SacredWeaponEnchantSwitchAbility | cca63747-a12b-55f4-4ad5-6ef2d840d7f4 | cca63747a12b55f44ad56ef2d840d7f4 | Long | 0 | 57A6 | 57A6/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 31 | EvilBlessingMinorAbility | f5039f03-c9a4-9aa4-0982-48222d3ce451 | f5039f03c9a49aa4098248222d3ce451 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 32 | StrengthBlessingMajorAbility | 0d46406c-fc71-9794-4bd7-5ab76d6abc04 | 0d46406cfc7197944bd75ab76d6abc04 | Long | 0 | 57A6 | 57A6/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 33 | ArcaneWeaponSwitchAbility | 3c89dfc8-2c2a-3f64-6808-ea250eb91b91 | 3c89dfc82c2a3f646808ea250eb91b91 | Long | 0 | 2805 | 2805/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 34 | WarpriestAspectOfWarAbility | 800a5fa9-0c01-b054-0b9a-b9553f744e6e | 800a5fa90c01b0540b9ab9553f744e6e | Long | 0 | 57A6 | 57A6/book=00000000-0000-0000-0000-000000000000/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 35 | InspireCourageToggleAbility | 5250fe10-c377-fdb4-9be4-49dfe050ba70 | 5250fe10c377fdb49be449dfe050ba70 | Long | 0 | 56A0 | 56A0/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 36 | FascinateToggleAbility | 993908ad-3fb8-1f34-ba0e-d168b7c61f58 | 993908ad3fb81f34ba0ed168b7c61f58 | Long | 0 | 56A0 | 56A0/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 37 | InciteRageEnemiesToggleAbility | dbd7c54b-a43e-1d54-592e-037d63117f7b | dbd7c54ba43e1d54592e037d63117f7b | Long | 0 | 56A0 | 56A0/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 38 | InciteRageAlliesToggleAbility | b1d8fdff-d132-bfd4-28a8-045b7b8b363c | b1d8fdffd132bfd428a8045b7b8b363c | Long | 0 | 56A0 | 56A0/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 39 | InciteRageAllToggleAbility | 32d247b6-e6b6-5794-ab47-fc372c444a96 | 32d247b6e6b65794ab47fc372c444a96 | Long | 0 | 56A0 | 56A0/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 40 | StormCallToggleAbility | d5ee8a2e-5bf4-6c54-9988-e9b09a59acd4 | d5ee8a2e5bf46c549988e9b09a59acd4 | Long | 0 | 56A0 | 56A0/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 41 | InspireGreatnessToggleAbility | be36959e-44ac-3364-1ba9-e0204f3d227b | be36959e44ac33641ba9e0204f3d227b | Long | 0 | 56A0 | 56A0/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 42 | InspireHeroicsToggleAbility | a4ce0637-1f09-f504-fa86-fcf6d0e021e4 | a4ce06371f09f504fa86fcf6d0e021e4 | Long | 0 | 56A0 | 56A0/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 43 | DirgeOfDoomToggleAbility | d99d63f8-4e18-0d44-e8f9-2b9a832c609d | d99d63f84e180d44e8f92b9a832c609d | Long | 0 | 2805 | 2805/book=00000000-0000-0000-0000-000000000000/src=4 | spells=True scrolls=True potions=True gear=True rod=False |
| 44 | BoneShield | 0093fc00-98c9-84c4-3ac2-39d1211d1311 | 0093fc0098c984c43ac239d1211d1311 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 45 | FalseGrace | d6b8099f-8c7b-e8f4-492b-14da84dc06d4 | d6b8099f8c7be8f4492b14da84dc06d4 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850 | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 46 | Bless | 90e59f4a-4ada-8724-3b7b-3535a06d0638 | 90e59f4a4ada87243b7b3535a06d0638 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 47 | Aid | 03a96303-94d1-0164-a941-0882d31572f0 | 03a9630394d10164a9410882d31572f0 | Long | 0 | 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 48 | BlessingOfLuckAndResolveCast | 9a7e3cd1-323d-fe34-7a6d-cce357844769 | 9a7e3cd1323dfe347a6dcce357844769 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 49 | DelayPoisonCommunal | 04e820e1-ce3a-66f4-7a50-ad5074d3ae40 | 04e820e1ce3a66f47a50ad5074d3ae40 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 50 | ResistFireCommunal | 832bf989-66e7-2cd4-78ee-cc9f8ba829f5 | 832bf98966e72cd478eecc9f8ba829f5 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 51 | ProtectionFromFireCommunal | 2903d31d-6c83-5654-7aa4-aae5a3e7a655 | 2903d31d6c8356547aa4aae5a3e7a655 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 52 | AngelicAspect | 75a10d5a-6359-8664-1bfb-cceceec87217 | 75a10d5a635986641bfbcceceec87217 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 53 | BurstOfGlory | 1bc83efe-c9f8-c4b4-2a46-162d72cbf494 | 1bc83efec9f8c4b42a46162d72cbf494 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 54 | GeniekindEfreeti | a4864f72-3e17-00d4-785a-c5ad9aefc5f2 | a4864f723e1700d4785ac5ad9aefc5f2 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 55 | RighteousMight | 90810e5c-f53b-f854-293c-bd5ea1066252 | 90810e5cf53bf854293cbd5ea1066252 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 56 | ProfaneNimbus | b56521d5-8f99-6cd4-299d-ab3f38d5fe31 | b56521d58f996cd4299dab3f38d5fe31 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 57 | TrueSeeingCommunal | fa08cb49-ade3-eee4-2b5f-d42bd33cb407 | fa08cb49ade3eee42b5fd42bd33cb407 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 58 | BearsEnduranceMass | f6bcea6d-b14f-0814-d99b-54856e918b92 | f6bcea6db14f0814d99b54856e918b92 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 59 | EaglesSplendorMass | 2caa607e-adda-4ab4-4934-c5c9875e01bc | 2caa607eadda4ab44934c5c9875e01bc | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 60 | BullsStrengthMass | 6a234c6d-cde7-ae94-e94e-9c36fd1163a7 | 6a234c6dcde7ae94e94e9c36fd1163a7 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 61 | BlessingOfLuckAndResolveMass | 462c21ce-bf78-20c4-0a87-f5e4d03e17cf | 462c21cebf7820c40a87f5e4d03e17cf | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 62 | DenyDeath | 1098095d-7a88-c674-7aee-67f8d449fa06 | 1098095d7a88c6747aee67f8d449fa06 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 63 | BlessingOfUnlife | 2abf1b69-cec7-60d4-ebc7-3d5ce8d79f0a | 2abf1b69cec760d4ebc73d5ce8d79f0a | Long | 0 | 55FD | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 64 | HeroicInvocation | 43740dab-0728-6fe4-aa00-a6ee104ce7c1 | 43740dab07286fe4aa00a6ee104ce7c1 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 2c002cb0-2987-4e37-a575-eb5cdd155850/book=5a38c9ac-8607-8904-09fc-b8f6342da6f4/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 65 | ShieldOfDawn | 62888999-1719-21e4-dafb-46de83f4d67d | 62888999171921e4dafb46de83f4d67d | Long | 0 | 56A0 | 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0; 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 66 | HeroismGreater | e15e5e70-45fd-a224-4b98-c8f010adfe31 | e15e5e7045fda2244b98c8f010adfe31 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 67 | BrilliantInspiration | a5c56f0f-699d-aec4-4b7a-edd8b273b08a | a5c56f0f699daec44b7aedd8b273b08a | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 56A0/book=bc04fc15-7a88-01d4-1b87-7ad0d9af03dd/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 68 | DivineFavor | 9d5d2d3f-fdd7-3c64-8af3-eb3e585b1113 | 9d5d2d3ffdd73c648af3eb3e585b1113 | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 69 | ShieldOfFaith | 183d5bb9-1dea-3a14-89a6-db6c9cb64445 | 183d5bb91dea3a1489a6db6c9cb64445 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 70 | EffortlessArmor | e1291272-c8f4-8c14-ab21-2a599ad17aac | e1291272c8f48c14ab212a599ad17aac | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 71 | ArchonsAura | e67efd8c-84f6-9d24-ab47-2c9f546fff7e | e67efd8c84f69d24ab472c9f546fff7e | Long | 0 | 57A6 | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 72 | CrusadersEdgeCast | be5452c4-22a6-ea74-4bf1-037b0a443bb1 | be5452c422a6ea744bf1037b0a443bb1 | Long | 0 | 5568, 57A6, 5728, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 73 | DeathWardCast | e9cc9378-fd68-41f4-8ad5-9384e79e9953 | e9cc9378fd6841f48ad59384e79e9953 | Long | 0 | 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 74 | DisruptingWeaponCast | 46c96cc3-a3ef-3524-3915-ff3452dfacf5 | 46c96cc3a3ef35243915ff3452dfacf5 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 57A6/book=7d7d51be-2948-d254-4b3c-2e1596fd7603/src=0 | spells=True scrolls=True potions=True gear=True rod=False |
| 75 | FeatherStep | f3c0b267-dd17-a2a4-5a40-805e31fe3cd1 | f3c0b267dd17a2a45a40805e31fe3cd1 | Long | 0 | 2c002cb0-2987-4e37-a575-eb5cdd155850, 5568, 56A0, 5611, 57A6, 5728, 2805, 55FD | 2805/book=d731dfb3-9ea2-6754-c89b-58d0969ea9e0/src=0 | spells=True scrolls=True potions=True gear=True rod=False |

## Rules for a later edit

- Do not recommend deleting a row that shows 0 casts. Zero casts means no uses were available then, or the spell was not in the spellbook yet.
- When changing targets, use the unit ids in the table above. Do not guess a display name for a short id.
- When changing a spell, give both the hyphenated id and the id without hyphens.
- Do not put positive-energy healing, Virtue, or Death Ward on the seven units that have the undead type.
- Leave the three infusions on Quick. Do not move them back to Long.
- Freedom of Movement, Death Ward, and Blessing of Unlife on the horse `55FD` do not stop the bludgeoning damage from Hungry Flesh. Blessing of Unlife adds `NegativeEnergyAffinity` to the horse. While that buff is up, Restore Undead fills the horse's hit points. Feather Step was removed from the one-click list. Freedom of Movement already covers it.
- Write suggestions as a JSON edit list: row number, new `Wanted`, new `InGroups`.

## 2026-09-27 21:51, buffs added

Checked known spells for FaN, 56A0, 57A6, and 2805 in the Quick_2 save. Attacks, summons, positive-energy healing, parent spells that still need an energy or alignment choice, and polymorphs were not added. False Life was not added because Greater False Life was already present. Resist Energy, Communal and Protection from Energy, Communal are parent spells. The fire versions were already present.

20 rows were added, all Long. The file then had 95 rows.

| Blueprint | Id | Targets | Casters |
|---|---|---|---|
| WindsOfVengeance | `5d8f1da2-fdc0-b924-2af9-f326f9e507be` | FaN | FaN |
| PowerFromDeath | `9c2c85a3-782a-f804-880c-81c1712e3a7b` | FaN | FaN |
| StunningBarrier | `a5ec7892-fb1c-2f74-598b-3a82f3fd679f` | FaN, 57A6 | FaN, 57A6 |
| ExpeditiousRetreat | `4f8181e7-a7f1-d904-fbae-a64220e83379` | FaN, 2805 | FaN and 2805 wizard books |
| Blur | `14ec7a4e-52e9-0fa4-7a4c-8d63c69fd5c1` | 2805 | 2805 wizard book `c9ff1f4b-3b26-dcb4-7ba7-5b218ccadd23` |
| Displacement | `903092f6-488f-9ce4-5a80-943923576ab3` | 2805 | same |
| Blink | `045351f1-421e-e3f4-49a9-143db701d192` | 2805 | same |
| InvisibilityGreater | `ecaa0def-35b3-8f94-9bd1-976a6c9539e0` | 2805 | same |
| Stoneskin | `c66e8690-5f76-06c4-eaa5-c774f0357b2b` | 2805 | same |
| EnlargePerson | `c60969e7-f264-e6d4-b84a-1499fdcf9039` | 2805 | same |
| MagicWeaponGreater | `0f92caa3-5619-f234-298d-95a4b6dda90d` | 5568, 5611, 57A6, 5728, 2805, 55FD | 57A6, then 2805 if needed |
| MagicalVestment | `2d4263d8-0f51-36b4-296d-6eb43a221d7d` | the 7 units other than FaN | 57A6 |
| OwlsWisdomMass | `9f5ada58-1af3-db44-19b5-4db77f44e430` | all 8 | 57A6 |
| LifeBubble | `265582bc-494c-4b12-b586-0b508a2f89a2` | all | 57A6 |
| SpellResistance | `0a5ddfbc-fb39-8954-3ac7-c936fc256889` | all | 57A6 |
| RemoveFear | `55a037e5-14c0-ee14-a8e3-ed14b47061de` | all | 57A6 |
| JoyfulRapture | `15a04c40-f845-4594-9abe-edef7279751a` | all | 57A6 |
| Grace | `464a7193-5194-29f4-8b4d-190acb753cf0` | 57A6 | 57A6 |
| Firebelly | `b0652310-94a2-1d14-dbf1-c3832f776871` | 57A6 | 57A6 |
| BlessingOfCourageAndLife | `c36c1d11-771b-0584-f8e1-00b92ee5475b` | all | 57A6 |

The game was not running. Backup: `bi2tl-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-2158`. Checksum: `5150221B2200763EAA8EA42E1966B147EACA418C8F02CA0ED933F6CDE82D9CB4`. The three infusions stayed on Quick. Positive-energy healing was not added.

## 2026-09-27 22:03, removed rows that should not auto-cast

The 20 added rows had not been checked for spell slots, competition in the same spell level, number of targets, or a higher-level spell covering a lower one. In Quick_2 the warpriest's levels 1 through 4 were already full of the older buffs. 2805's wizard book had 1 slot at 4th level. FaN's 9 ninth-level slots were 5 Corrupt Magic, Mind Blank, Heroic Invocation, Negative Eruption, and Wail of the Banshee. Winds of Vengeance was not prepared.

18 rows were deleted:

- Winds of Vengeance: 9th level, competes with Heroic Invocation
- Power from Death: useful only with a corpse nearby, so a pre-cast wastes it
- Stunning Barrier: a shield bonus, and it does not beat Mage Shield
- Expeditious Retreat: the same speed bonus type as Haste, and Haste was already queued
- Blur, Displacement, Blink: concealment or miss chance worse than Greater Invisibility
- Stoneskin: competes with Greater Invisibility for 2805's only 4th-level slot
- Greater Magic Weapon and Magic Vestment: one cast per person, too many melee and armored targets, and levels 4 and 3 were already full. Equipped weapons and armor usually already have an enhancement bonus
- Life Bubble and Spell Resistance: touch, one cast per person, not enough 5th-level slots
- Remove Fear: fear is already covered by Unbreakable Heart and heroism-type bonuses
- Joyful Rapture: a condition removal, not a pre-buff, and it is a high-level slot
- Grace: swift and measured in rounds, a poor fit for Normal
- Firebelly: fire resistance does not beat the Protection from Fire already queued
- Blessing of Courage and Life: a morale bonus that does not beat Greater Heroism and Heroic Invocation, and it is one cast per person
- Heroism: the lower morale bonus. Greater Heroism and Heroic Invocation remain and cover it

Three rows stayed. Greater Invisibility only on 2805, using that one 4th-level slot. Enlarge Person only on 2805, one 1st-level slot. Owl's Wisdom, Mass on the party. It is an ally-area spell, so it counts as one cast, and it covers Wisdom, which the mass Strength, Constitution, and Charisma buffs do not.

The three infusions stayed on Quick. The file then had 77 rows. The game was not running. Backup: `bi2tl-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-2207`. Checksum: `20B40A707122B52E680ED4647FF699F75825943DBFACE5200E85EA96F53EA73E`.

## 2026-09-27 22:16, compared with the post-rest one-click result

Quicksave1 was treated as before the button and Quicksave2 as after. Three saves were compared later: Quicksave1 is after resting, and both Quicksave2 and Quicksave3 were buffed from Quicksave1. Quicksave2 is before the config edit. Quicksave3 is after it. The button pressed was Normal (Long), not Quick. The three infusions did not fire, which is correct.

14 rows actually landed and did not stack with a higher buff, so they were removed from Normal:

- Mage Shield: a shield bonus. Bone Shield was already +6
- Bless and Greater Heroism: morale bonuses. Heroic Invocation was already on the party
- Divine Favor: a luck bonus. Divine Power was already on the same character
- Feather Step: Freedom of Movement already covers difficult terrain
- Resist Fire, Communal: Protection from Fire was already on the party
- Deadly Performance, plus Inspire Courage, Fascinate, the three Inspire Rage variants, Call the Storm, and Inspire Greatness: the queen can have only one bardic performance active. Inspire Heroics was already on. Fascinate and Inspire Rage (enemy) are not pre-buffs
- Deadly Performance's caster was also recorded as a spell source with an empty spellbook, so it would not have worked as a performance toggle anyway

Two rows were changed and not deleted:

- Blessing of Luck and Resolve, and the mass version: targets changed to only the horse `55FD`. The log cast it on FaN, marked the target illegal, did not spend the slot, and the horse did not receive it
- Enlarge Person: party potion sources were removed, and potions were turned off for that row. The log showed `CanTarget=false` for every Enlarge Person potion. 2805's spell source remains, so it casts only after the spellbook has it prepared

Not deleted: Cloak of Dreams, Greater Invisibility, Owl's Wisdom Mass, Efreeti Geniekind, and Righteous Might. They did not fire because they were not prepared, not because the row was wrong. Righteous Might was already on 57A6 this time. Mirror Image was also up: 8 images on FaN and 56A0, 5 on 2805.

Crusader's Edge and Disrupting Weapon each had only 1 slot prepared, so only the first person on the list was buffed. Later people are reached only if more slots are prepared.

The file then had 63 rows. The game was not running. Checksum: `C2310E65F53A6FB5CFFD51951A6861A155A34EA7C80CD1DD66BAC443CE60F4CA`.

## 2026-09-28 00:34, Quicksave2 compared with Quicksave3

Both were buffed from Quicksave1. Quicksave3 did not gain any extra buff. Quicksave2 had these and Quicksave3 did not:

- Whole party, including the horse: Bless, Greater Heroism, Resist Fire
- Everyone except the horse: Feather Step
- FaN only: Mage Shield
- 57A6 only: Divine Favor

Mage Shield was still 2/2 on Quicksave3, and Bless was still 3/3. Mirror Image matched on both saves.

The single-target Blessing of Luck and Resolve is a touch spell, blueprint `BlessingOfLuckAndResolveCast`, id `9a7e3cd1-323d-fe34-7a6d-cce357844769`. Quicksave2 cast it on FaN, rejected the target, and kept the slot. Quicksave3 spent the only slot and left the touch charge on the caster. The horse did not have `BlessingOfLuckAndResolveBuff`. That row was removed from Normal.

The mass cast, `BlessingOfLuckAndResolveMass`, id `462c21ce-bf78-20c4-0a87-f5e4d03e17cf`, is a close-range area that applies the buff directly. The target is still only the horse `55FD`. It was not prepared, so it did not fire.

The single-target touch row is deleted. The file then had 62 rows. The game was not running. Checksum: `746D816F8EF29DFDF2E286600D3A0E6CB2B00196B0D0A04BE3D361FCB9C75D06`.

## 2026-09-28 00:45, unprepared spells written into Quicksave3

The rows Quicksave2 had and Quicksave3 lacked were the same bonus type already covered by a higher buff, so they were removed from the one-click list. They were not missed casts:

- Bless and Greater Heroism: morale, and Heroic Invocation is higher
- Mage Shield: shield bonus, and Bone Shield is higher
- Feather Step: Freedom of Movement already includes difficult terrain
- Resist Fire: Protection from Fire is higher
- Divine Favor: luck bonus, and Divine Power is higher

The Quicksave3 spellbook was edited. Only that save was edited. Backup: `Quick_3.zks.bak-20260928-004500` in the same folder.

| Spell | Who | Change |
|---|---|---|
| Enlarge Person `c60969e7-f264-e6d4-b84a-1499fdcf9039` | 2805 wizard book | Already known. The 1st-level slots were empty. The first 1st-level slot now has it prepared |
| Greater Invisibility `ecaa0def-35b3-8f94-9bd1-976a6c9539e0` | 2805 wizard book | The only 4th-level slot was empty. It is now prepared |
| Owl's Wisdom, Mass `9f5ada58-1af3-db44-19b5-4db77f44e430` | 57A6 | On the spell list, with no 6th-level slot. One usable 6th-level slot was added |
| Geniekind `07b608fa-b304-f894-8808-98dc0764e6e5` | 57A6 | Efreeti is a form of this spell. There was no 5th-level slot. One usable 5th-level slot was added and Geniekind was prepared |

Cloak of Dreams `7f71a70d-822a-f944-58dc-1a235507e972` was already in 56A0's bard spellbook at 5th level, with 7 slots left in Quicksave3. Nothing was added. It is a personal aura used to affect nearby enemies.

## 2026-09-28 01:05, Enlarge Person removed

Enlarge Person can target only a living humanoid. The skeletal marksman is undead. The one-click log said CanTarget=false, and the slot was not spent. It was removed from Normal. The 1st-level preparation in Quicksave1 and Quicksave2 was cleared back to an empty slot. The spell remains known. The file then had 61 rows.

## 2026-09-28 01:08, after that pass

Quicksave1 is the rest save. Quicksave2 is after the one-click button. Enlarge Person did not come back. Greater Invisibility, Owl's Wisdom, Mass, and Geniekind were all up. Heroic Invocation was up too.

Cloak of Dreams was removed from Normal. It is a personal aura. Living creatures within 5 feet must make a Will save each round or fall asleep. The horse is the only living member of the party, and standing next to the queen pulls the horse in.

Blessing of Luck and Resolve, Mass did not fire because it was not prepared. It was added to the 6th-level slots in Quicksave1 and Quicksave2. The target is still only the horse.

2805's Mirror Image is now prepared in an empty 2nd-level wizard slot. The file then had 60 rows.

## 2026-09-28 01:20, targets cut to what the red text could actually hit

When there are not enough slots, the target list is cut to the people who can actually be buffed. The red text then stops reporting no available caster.

- Deny Death: horse removed. 7 casts cover 7 undead.
- Shield of Faith: only Ciar, Staunton Vhane, and Kestoglyr. 3 slots prepared.
- Crusader's Edge: only Ciar. 1 slot prepared.
- Disrupting Weapon: only FaN. 1 slot prepared.
- Owl's Wisdom, Mass and Blessing of Luck and Resolve, Mass were removed from the one-click list. The warpriest had no usable 6th-level slot. After the extra slot was spent, the slot disappeared and the horse had no buff.

The file then had 58 rows.

## 2026-09-28 01:56

Vampiric Shadow Shield was removed from Normal. Its duration is in rounds. By the time a save was made after the one-click button, the buff was already gone, and the 5th-level slot was wasted.

Deny Death is still close range and single target. Of the 7 casts this round, Ciar, Queen Galfrey, Delamere, Kestoglyr, Skeletal Marksman, and FaN had it. Staunton Vhane did not. He stays on the target list so the next round hits him if people stand close.

The file then had 57 rows.

## 2026-09-28 02:47

Vampiric Shadow Shield was added back to Normal, only for FaN. Duration is 1 round/level. Caster level 20 is 20 rounds.

## 2026-09-28 02:51

Vampiric Shadow Shield was removed from Normal again. Another test after adding it back: one 5th-level slot was gone, and FaN did not have the buff. The save was about 10 seconds after the button, shorter than 20 rounds. The one-click cast did not leave the buff in place.

This round Staunton Vhane had Deny Death and FaN did not. The target list stays as it is.

## 2026-09-28 03:18

Vampiric Shadow Shield was added back to Normal on request, only for FaN.
