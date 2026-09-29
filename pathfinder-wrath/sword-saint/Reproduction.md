# Reproduce Fan's party setup

Read this file first. It matches the live mod files and the Quicksave2 save on 2026-09-30. The game does not read this repository. Copying the repository does not change the game, and loading a save does not change Buff It or Wrath Tactics.

## Three places

| Piece | Where the game reads it | Copy in this folder |
|---|---|---|
| Buff It 2 The Limit | `Mods\BuffIt2TheLimit\UserSettings\bi2tl-8dd97a37ca674651afefb4dd19e06967.json` | `buffit-current-config.json` |
| Wrath Tactics | `Mods\WrathTactics\UserSettings\tactics-8dd97a37ca674651afefb4dd19e06967.json` | `tactics-current-config.json` |
| Spellbook, arcane pool, autocast, toggles | `Saved Games\Quick_5.zks` while its header name is `Quicksave2` | Not in git |

Game install:

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure
```

Saves:

```
C:\Users\timeg\AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games
```

Both mod files are chosen by GameId `8dd97a37ca674651afefb4dd19e06967`. Every save of this campaign uses them, including Quicksave2. They are not stored inside the `.zks`.

Write a live JSON file only while `Wrath.exe` is closed. If the buff screen or the Ctrl+T panel is open, closing it writes the in-memory copy back over the file.

To put the repository copies back into the game, copy the two JSON files onto the live paths above. Keep the GameId in the filename.

## Who is in the party

Ids are `UniqueId` in `party.json`. Active order is Fan, Seelah, Arueshalae, Ember, Daeran, Camellia.

| Character | Unit id | Spellbook in Buff It |
|---|---|---|
| Fan | `6078761c-2271-48a8-bfe2-e82f88a8f041` | Sword Saint `682545e1-1e53-06c4-5b14-ca78bcbe3e62`, Trickster `2ff51e05-31ed-8e54-5ab4-cb35c32d40f4` |
| Seelah | `615A` | Paladin `bce4989b-070c-e924-b986-bf346f59e885` |
| Arueshalae | `6224` | Master Spy `12bfcf91-d541-6b04-7a2a-9110ff8968c5` |
| Ember | `5AC2` | Witch `b897fe09-47e4-b804-082b-1a687c21e6e2` |
| Daeran | `5A2C` | Oracle `6c033647-12b4-1594-1a98-f74522a81273` |
| Camellia | `60D5` | Shaman `44f16931-dabd-ff64-3bfe-2a48138e769f` |

Inside a save, spellbook ids have no hyphens. Buff It stores the same ids with hyphens. Sword Saint in the save is `682545e11e5306c45b14ca78bcbe3e62`. Trickster in the save is `2ff51e0531ed8e545ab4cb35c32d40f4`.

## What "all six" means

Wrath Tactics has a `CharacterRules` entry for each of the six unit ids. `TacticsEnabled` is true for all six. `TickIntervalSeconds` is `1.0`. Every rule has `CooldownRounds` 0. A rule with no `IsInCombat == false` condition runs in combat only. Fan's two spell rules also contain an explicit combat condition.

Buff It is one list of 40 rows, not six files. Every row's `Wanted` array contains all six unit ids, so all six receive the buff. Caster entries exist for Fan, Seelah, Arueshalae, Ember, and Daeran. Camellia is on every `Wanted` list and has no caster entry. Her shaman spellbook does not appear in the file. Her class abilities are the four Wrath Tactics rules below.

## Buff It

`Version` is 1. Global flags:

| Field | Value |
|---|---|
| `VerboseCasting` | false |
| `SkipAnimationsOnCombatStart` | false |
| `CastAllOnCombatStart` | false |
| `AllowInCombat` | false |
| `BypassArcaneSpellFailure` | false |
| `OverwriteBuff` | false |
| `GlobalSourcePriority` | 0 |
| `UmdRetries` | 3 |
| `UmdMode` | 1 |
| `ScrollsEnabled`, `PotionsEnabled`, `EquipmentEnabled`, `SongsEnabled`, `ActivatablesEnabled` | true |
| `SortByName` | false |

The left button is Normal, which is `InGroups: ["Long"]`. Quick and Important are empty. All 40 rows use spells only: `UseSpells` true, and `UseScrolls`, `UsePotions`, `UseEquipment`, `UseExtendRod`, and `CastOnCombatStart` false. Press Normal after a rest. It does not fire by itself at combat start.

`Key.Guid` uses hyphens. Caster order in the table is the order in `Casters`. The first caster is tried first. Targets are all six on every row.

| Spell | Guid | Casters, in order |
|---|---|---|
| Angelic Aspect, Greater | `b1c7576b-d068-12b4-2bda-3f09ab202f14` | Seelah, Daeran |
| Archon's Aura | `e67efd8c-84f6-9d24-ab47-2c9f546fff7e` | Seelah |
| Aspect of the Falcon | `7bdb6a9f-b6b3-7614-e96f-155748ae50c6` | Arueshalae |
| Aura of Greater Courage | `acb787cf-9f76-e924-a9a9-3bbd011af040` | Seelah |
| Barkskin | `5b77d7cc-65b8-ab74-688e-74a37fc2f553` | Arueshalae |
| Blessing of Courage and Life | `c36c1d11-771b-0584-f8e1-00b92ee5475b` | Seelah |
| Blessing of Luck and Resolve, Mass | `462c21ce-bf78-20c4-0a87-f5e4d03e17cf` | Seelah, Daeran |
| Blessing of the Salamander | `9256a86a-ec14-ad14-e949-7f6b60e26f3f` | Arueshalae |
| Burst of Glory | `1bc83efe-c9f8-c4b4-2a46-162d72cbf494` | Seelah, Daeran |
| Chameleon Stride, Greater | `7ec0ffdd-8779-c344-f853-37109af0c6c5` | Fan Trickster, Arueshalae |
| Displacement | `903092f6-488f-9ce4-5a80-943923576ab3` | Fan Sword Saint, Fan Trickster |
| Eaglesoul | `332ad682-73db-9704-ab0e-92518f2efd1c` | Seelah |
| Effortless Armor | `e1291272-c8f4-8c14-ab21-2a599ad17aac` | Seelah, Arueshalae |
| Enlarge Person, Mass | `66dc49bf-1548-6314-8bd2-17287079245e` | Fan Sword Saint |
| Firebelly | `b0652310-94a2-1d14-dbf1-c3832f776871` | Seelah |
| Frightful Aspect | `e788b02f-8d21-0144-8806-7bdd3ba7b325` | Ember |
| Grace | `464a7193-5194-29f4-8b4d-190acb753cf0` | Seelah |
| Haste | `486eaff5-8293-f644-1a5c-2759c4872f98` | Fan Sword Saint |
| Heroic Invocation | `43740dab-0728-6fe4-aa00-a6ee104ce7c1` | Ember, Daeran |
| Holy Whisper | `5f1ca17b-e3ba-4494-9be4-27f18e696d9b` | Seelah |
| Hurricane Bow | `3e9d1119-d43d-07c4-c8ba-9ebfd1671952` | Arueshalae |
| Invisibility, Greater | `ecaa0def-35b3-8f94-9bd1-976a6c9539e0` | Fan Sword Saint, Fan Trickster |
| Lead Blades | `77917991-2e6c-6fe4-58fa-4cfb90d96e10` | Arueshalae |
| Life Bubble | `265582bc-494c-4b12-b586-0b508a2f89a2` | Arueshalae |
| Longstrider, Greater | `e80a4d6c-0efa-5774-cbd5-15e3e37095b0` | Arueshalae |
| Mage Armor | `9e1ad5d6-f87d-19e4-d888-3d63a6e35568` | Ember |
| Mirror Image | `3e4ab69a-da40-2d14-5a5e-0ad3ad4b8564` | Fan Sword Saint |
| Remove Sickness | `f6f95242-abdf-ac34-6bef-d6f4f6222140` | Daeran |
| Resounding Blow | `9047cb17-9763-9924-487e-c0ad566a3fea` | Seelah |
| Sacred Nimbus | `bf74b3b5-4c21-a934-4afe-9947546e036f` | Seelah |
| Sense Vitals | `82962a82-0ebc-0e74-08b8-582fdc3f4c0c` | Arueshalae |
| Stoneskin | `c66e8690-5f76-06c4-eaa5-c774f0357b2b` | Fan Sword Saint |
| Stunning Barrier | `a5ec7892-fb1c-2f74-598b-3a82f3fd679f` | Seelah |
| Transformation | `27203d62-eb3d-4184-c9ac-ed94f22e1806` | Fan Sword Saint |
| Vampiric Shadow Shield | `a3492103-5f2a-6714-e9be-5ca76c5e34b5` | Fan Sword Saint |
| Veil of Heaven | `72d9f5ad-da63-87a4-0a63-c49d7781bbbf` | Seelah |
| Veil of Positive Energy | `6bb0533c-d457-d1f4-eacc-c73ab7680fb2` | Seelah |
| True Seeing | `4cf3d0fa-e323-9ec4-78f5-1e86f49161cb` | Fan Sword Saint |
| Prayer | `faabd2cc-67ef-a464-6ac5-8c7bb3e40fcc` | Daeran, Seelah |
| Delay Poison, Communal | `04e820e1-ce3a-66f4-7a50-ad5074d3ae40` | Daeran, Seelah, Arueshalae |

Haste on this button and Haste in Wrath Tactics are both kept. The button is the manual cast after a rest. The tactics rule recasts it in combat when the buff is missing.

## Wrath Tactics

Ctrl+T opens the panel. Enum values below are the numeric values stored in the JSON.

| Field | Value |
|---|---|
| Action type 0 | `CastSpell` |
| Action type 1 | `CastAbility` |
| Action type 3 | `ToggleActivatable` |
| Toggle mode 0 | On. If the ability is already on, the rule does not turn it off. |
| Target 0 | Self |
| Target 1 | Lowest-HP ally |
| Target 17 | The unit that matched the condition |
| Subject 0 | Self |
| Subject 1 | An ally, skipping the owner |
| Subject 5 | Combat |
| Subject 13 | Highest-AC enemy |
| Property 0 | HP percent, as a fraction from 0 to 1 |
| Property 2 | HasBuff. The value is the buff blueprint, not the ability id. |
| Property 13 | Alignment |
| Property 14 | IsInCombat |
| Operator 0 | Less than |
| Operator 2 | Equal |
| Operator 3 | Not equal |

A spell `AbilityId` is 32 hex characters, no hyphens, then `@L` and the spell level. A class ability has no `@L`. HasBuff checks the buff the blueprint actually applies. Two earlier ids were wrong and are corrected in `tactics-current-config.json`:

| Rule | Use this buff id |
|---|---|
| Seelah, Brilliant Energy | `dc60f7ff4d985054a9f746aad585558d` |
| Ember, Vulnerability Curse | `6f3da77a44fa7304fac61c07a01964a5` |

`dc60f8100cd9f6749bf071c930eb287d` is not the Brilliant Energy buff. `6f3da77a44fa7304fac61c07a6187d4118` is not the Vulnerability Curse buff. The curse id is the fact listed in `AbilityTargetHasFact` on `WitchHexVulnerabilityCurseAbility.jbp`.

### Fan

| Order | Rule | Action | Ability id | Buff id | Target |
|---|---|---|---|---|---|
| 1 | Transformation | CastSpell | `27203d62eb3d4184c9aced94f22e1806@L6` | `287682389d2011b41b5a65195d9cbc84` | Self |
| 2 | Haste | CastSpell | `486eaff58293f6441a5c2759c4872f98@L3` | `03464790f40c3c24aa684b57155f3280` | Self |

Both require combat and a missing buff. Dimension Strike, Prescient Attack, Arcane Accuracy, Perfect Strike, and Attack are not rules. Dimension Strike is the game's right-click autocast. Perfect Strike and the critical-hit toggle stay on in the save and do not use a swift action.

### Ember

She has one standard action. Each hex stops once its buff is present. She does not have Evil Eye or Cackle.

| Order | Rule | Action | Ability id | Buff id | When |
|---|---|---|---|---|---|
| 1 | Protective Luck | CastAbility | `e7ecd11651b4df34897f33271a8d1cfc` | `1ba3d3a0942d080448ce6aa865bbbd65` | Ally missing it |
| 2 | Vulnerability Curse | CastAbility | `8f0eb58c2d6aeab4e8523ec85b4b2bc7` | `6f3da77a44fa7304fac61c07a01964a5` | Highest-AC enemy missing it |
| 3 | Fortune | CastAbility | `eaf7077a8ff35644883df6d4f7b2084c` | `d03be82c4ffd14840a89e600e910ae7d` | Ally missing it |
| 4 | Ward | CastAbility | `5adb5a0650f5b2049bab1afe822bd3bd` | `da49e3ca7424a4741953ecc4f2fe11bb` | Ally missing it |
| 5 | Agony | CastAbility | `0d38e470e350ce34f869c20002d45763` | `73921d85ed0d684408c5b5f23b6f4360` | Highest-AC enemy missing it |
| 6 | Major Healing | CastAbility | `3408c351753aa9049af25af31ebef624` | none | An ally is under half HP. Target the lowest-HP ally. |
| 7 | Healing | CastAbility | `ed4fbfcdb0f5dcb41b76d27ed00701af` | none | Same gate, if Major Healing did not fire. |

Slumber `630ea63a` and Restless Slumber `a69fb167` are excluded. A dragon is immune, the buff never sticks, and the rule would spend her standard action every round.

### Camellia

| Order | Rule | Action | Ability id | Buff id |
|---|---|---|---|---|
| 1 | Battle Spirit | Toggle on | `7eda685d53423de4281d8bc0f1197442` | `d1de312279a95be49b3de1ea66473cde` |
| 2 | Ghost Touch | Toggle on | `7c96a5203b397744b9429ea3fd010728` | `7e9fd35cd52a072408b94ec31122139d` |
| 3 | True Battle Spirit | CastAbility | `3e1a13fdca87e9c49b2fac4556e5a948` | `4f139d125bb602f48bfaec3d3e1937cb` |
| 4 | Spirit Weapon | CastAbility | `a1799c1abdf619147b4774bb433f76ad` | `caf254364965b604195fdea6717aa027` |

All four target herself and fire while the buff is missing. Greater Battle Spirit is a variant list. Ameliorating is a menu. Neither is a rule.

### Daeran

| Order | Rule | Action | Ability id | When |
|---|---|---|---|---|
| 1 | Halo | Toggle on | `248bbb747c273684d9fdf2ed38935def` | Halo buff `0b1c9d2964b042e4aadf1616f653eb95` is missing |
| 2 | Channel | CastAbility | `b9eca127dd82f554fb2ccd804de86cf6` | An ally is under half HP. The burst is centered on Daeran. |

Channel Harm `ab0635df6b4674e4e96809bd718cab89` damages living allies. Glitterdust can blind the party. Both are excluded.

### Seelah

Weapon-bond properties are one group. Only Brilliant Energy stays on. Holy, Speed, Keen, Axiomatic, Disruption, Flaming, and Flaming Burst stay off.

| Order | Rule | Action | Ability id | When |
|---|---|---|---|---|
| 1 | Brilliant Energy | Toggle on | `f1eec5cc68099384cbfc6964049b24fa` | Buff `dc60f7ff4d985054a9f746aad585558d` is missing |
| 2 | Weapon Bond | CastAbility | `7ff088ab58c69854b82ea95c2b0e35b4` | Enchantment buff `bf570774501886f47b395a4bfe75eeb2` is missing |
| 3 | Smite Evil | CastAbility | `7bb9eb2042e67bf489ccd1374423cdec` | Seelah is missing buff `b6570b8cbb32eaf4ca8255d0ec3310b0`, and the highest-AC enemy is evil |
| 4 | Aura of Justice | CastAbility | `7a4f0c48829952e47bb1fd1e4e9da83a` | Buff `ac3c66782859eb84692a8782320ffd2c` is missing |
| 5 | Lay on Hands, self | CastAbility | `8d6073201e5395d458b8251386d72df1` | Seelah is under half HP |
| 6 | Lay on Hands | CastAbility | `caae1dc6fcf7b37408686971ee27db13` | An ally is under half HP. Target the lowest-HP ally. |
| 7 | Channel Energy | CastAbility | `6670f0f21a1d7f04db2b8b115e8e6abf` | Same health gate. The burst is centered on Seelah. |

Vital Strike replaces a full attack. Channel Harm damages living allies. Mark of Justice is not a rule.

### Arueshalae

| Order | Rule | Action | Ability id | Buff id |
|---|---|---|---|---|
| 1 | Point-Blank Shot | Toggle on | `371bb8b465e90bd46aa3446eb9792017` | `de5b285a0a8e1e745a0cc9bf02045123` |
| 2 | Rapid Shot | Toggle on | `90a77bfe25ec2e14caf8bd5cde9febf2` | `0f310c1e709e15e4fa693db15a4baeb4` |
| 3 | Deadly Aim | Toggle on | `ccde5ab6edb84f346a74c17ea3e3a70c` | `6aaf11aa06ae0e7499a71b79725828df` |
| 4 | Staggering Critical | Toggle on | `4909b2de27feaa948927e5e638f160f0` | `f766db0dcd17aaa44b76181bdf85fee9` |
| 5 | Hunter's Bond | CastAbility | `cd80ea8a7a07a9d4cb1a54e67a9390a5` | `2f93cad6b132aac4e80728d7fa03a8aa` |
| 6 | Quarry | CastAbility | `e93dfca6f025e6d4e9583e688c147aca` | `b44184c7ca33c6a41bc11cc5ed07addb` on the highest-AC enemy |
| 7 | Master Spy | CastAbility | `0f63708586ba7ef45b78f4205e2109f7` | `f80bdf69ef8bc3743a9b18667ba9684e` |

Vampiric Touch pulls her into melee and is excluded. Fight Defensively is not a rule for anyone.

## Quicksave2

Identify the save by `header.json`, not by the `Quick_N` filename. The game rotates quicksave slots.

On 2026-09-30 the pre-fight test save is `Quick_5.zks`:

| Header field | Value |
|---|---|
| `Name` | `Quicksave2` |
| `PlayerCharacterName` | Fan |
| `GameId` | `8dd97a37ca674651afefb4dd19e06967` |
| `Type` | Quick |
| `QuickSaveNumber` | 3 |
| `Area` | `3548a466f112454090231662c305420a` (Artisan's Tower) |
| `GameTotalTime` | `01:25:40.0790000` |
| `GameSaveTime` | `12:04:09.7660000` |

`Quicksave2 1` is a different save. It was `Quick_4.zks` and was not edited. If `Quick_5.zks` no longer has this header, search the Saved Games folder for `Name=Quicksave2` and `GameTotalTime` starting with `01:25:40`. Do not edit a later save.

Backup of the file from before the toggle edit: `Quick_5.zks.bak-20260930-quicksave2`.

`Quick_3.zks.bak-20260929-l6` is the backup from before an older level-6 slot edit. It is not the edited spellbook, and that quicksave slot has been rotated away.

### Already in Quicksave2 before the toggle edit

Fan's arcane pool `effc3e386331f864e9e06d19dc218b37` is 17. `Brain.m_AutoUseAbility` is Dimension Strike `cf7c4eaa2b47d7242b2c734df567cefb`. Perfect Strike `5a169c57935dc3343836c027e35d65b3` and the critical toggle `c6559839738a7fc479aadc263ff9ffff` are on. Trickster spontaneous slots are `[0, 5, 5, 5, 5, 5, 4, 3, 0, 0, 0]`.

Sword Saint prepared slots, all `Available: true`:

| Level | Spells |
|---|---|
| 1 | Shield, True Strike, Grease, Shocking Grasp, Vanish |
| 2 | Blur, Mirror Image, Cat's Grace, Invisibility, Frigid Touch |
| 3 | Haste, Displacement, Greater Magic Weapon, Dispel Magic, Blink |
| 4 | Invisibility, Greater, Stoneskin, Dimension Door, Enlarge Person, Mass |
| 5 | Vampiric Shadow Shield, Baleful Polymorph, Cone of Cold, Acidic Spray |
| 6 | Transformation, True Seeing, Hellfire Ray `700cfcbd0cb2975419bcab7dbb8c6210`, Chain Lightning `645558d63604747428d55f0dd3a4cb58` |

A known spell with a spent prepared copy logs `No suitable spell slots`. Adding the spell to `m_KnownSpells` does not fix that. The memorized slot's `Spell.$ref` has to point at that known `$id`, and `Available` has to be true. Omitted `Available` means spent.

### Toggles written into this save

These were off. Each one is now on, using the same shape as Rapid Shot fact `6896` and its nested buff `6897`.

| Character | Ability fact | New buff `$id` | UniqueId | Buff blueprint |
|---|---|---|---|---|
| Daeran Halo | `2261` | `7301` | `7F01` | `0b1c9d2964b042e4aadf1616f653eb95` |
| Camellia Ghost Touch | `6105` | `7302` | `7F02` | `7e9fd35cd52a072408b94ec31122139d` |
| Camellia Battle Spirit | `6113` | `7303` | `7F03` | `d1de312279a95be49b3de1ea66473cde` |
| Seelah Brilliant Energy | `6499` | `7304` | `7F04` | `dc60f7ff4d985054a9f746aad585558d` |
| Arueshalae Point-Blank Shot | `6839` | `7305` | `7F05` | `de5b285a0a8e1e745a0cc9bf02045123` |

Component key stored as null, matching other on toggles in this save:

| Toggle | Component key |
|---|---|
| Halo | `$SavingThrowBonusAgainstDescriptor$65e9f9f9-f719-4a22-8af5-37419a59992e` |
| Ghost Touch | `$AddBondProperty$31d790f6-bf58-474e-b90a-34a156afbecf` |
| Battle Spirit | `$AddAreaEffect$32c620c4-5eae-4ee4-a829-c52e0c83c68a` |
| Brilliant Energy | `$AddBondProperty$31d790f6-bf58-474e-b90a-34a156afbecf` |
| Point-Blank Shot | `$AddMechanicsFeature$764bd5f4-5ee2-4512-8415-8e4e5a4aa123` |

Seelah's Holy `ce0ece459ebed9941bb096f559f36fa8` and Speed `ed1ef581af9d9014fa1386216b31cdae` were left without `m_IsOn`. Rapid Shot, Deadly Aim, and Staggering Critical were already on.

Setting `m_IsOn` alone does not apply the effect. An on toggle in this save has all of the following:

1. `m_AppliedBuff` nested inside the ability, with its own `$id`, `m_Context.AssociatedBlueprint` set to the buff, `ParentContext.AssociatedBlueprint` set to the ability, `m_OwnerRef` set to the unit id, `IsNotDispelable` true, `IsActive` true, and `Components` containing the blueprint component key with value null.
2. `m_IsOn` true, `m_TurnOnTime` set, and `IsStarted` true on the ability.
3. `{"$ref":"<buff $id>"}` in that unit's `Facts.m_Facts`, beside the existing `{"$ref":"<ability fact id>"}`.

`m_TurnOnTime` used here is `01:25:40.0790000`. Buff `AttachTime` is `12:04:09.7660000`. `TickTime` and `NextTickTime` are `10675199.02:48:05.4775807`.

To redo the edit: close the game, confirm the header, back up the zip, edit `party.json` as text, and repack with `ZIP_DEFLATED`. Copy the other zip members through their original `ZipInfo`. Leave `checksums` unchanged. Do not run the whole `party.json` through a formatter. After writing, parse the JSON and check `m_IsOn`, the buff blueprint, and the facts `$ref`.

## Leave these out

- Do not change `TickIntervalSeconds` to 6. One second is the setting.
- Do not add Dimension Strike, Prescient Attack, Arcane Accuracy, Perfect Strike, or an attack rule to Wrath Tactics.
- Do not turn Holy or Speed on together with Brilliant Energy.
- Do not add Channel Harm, Glitterdust, Slumber, Restless Slumber, Vital Strike, Fight Defensively, or Arueshalae's Vampiric Touch.
- Do not add Camellia as a Buff It caster unless her shaman book actually has that spell prepared. The live file does not list her as a caster.
- Do not edit `Quicksave2 1` when the task is the pre-fight test. Load the save whose header name is `Quicksave2` and whose in-game time is 1 hour 25 minutes.
