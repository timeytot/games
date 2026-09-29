# Reproduce FaN's lich setup

Read this file first. It describes the Buff It and Wrath Tactics copies that are already stored. Do not edit those JSON files, and do not copy them into the game, until a later request says to change them.

The game does not read this folder. `WrathTactics.md` and `BuffIt-OneClickBuff.md` are older notes. Where they disagree with the zip, the zip wins. Those notes still say FaN has 8 tactics rules and the buff list has 75 rows. The zip has 28 tactics rules across 8 units and 58 buff rows.

## Where the bytes are

GameId: `7ea3d466491c4249aec2742271c2e71a`

| Piece | Where the game would read it | Copy that already exists |
|---|---|---|
| Buff It 2 The Limit | `Mods\BuffIt2TheLimit\UserSettings\bi2tl-7ea3d466491c4249aec2742271c2e71a.json` | `WrathModsConfiguration.zip` member `buffit-current-config.json` |
| Wrath Tactics | `Mods\WrathTactics\UserSettings\tactics-7ea3d466491c4249aec2742271c2e71a.json` | `WrathModsConfiguration.zip` member `tactics-current-config.json` |
| Parsed save snapshot | Not a file the game loads | `current/` |

Game install:

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure
```

Saves:

```
C:\Users\timeg\AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games
```

On 2026-09-30 the live UserSettings folder does not contain these two GameId files. The sword saint files in that folder are a different GameId. Leave both folders alone.

When a later request says to restore the mod files: close `Wrath.exe`, extract the two zip members onto the paths above, and keep the GameId in the filename. Do not reformat the JSON. Do not rebuild the files from the older markdown.

## Units named by the config

These eight ids are the keys in Wrath Tactics and the ids in Buff It. Display names come from `current/Current_Report.md`.

| Character | Unit id | What the snapshot says |
|---|---|---|
| FaN | `2c002cb0-2987-4e37-a575-eb5cdd155850` | Wizard 20, Lich mythic. Undead. Negative energy heals him |
| Ciar | `5568` | Cavalier 20, mythic companion 10. Alive in the snapshot |
| Galfrey | `56A0` | Bard 20. Dead in the snapshot. Rules and buff rows stay |
| Delamere | `5611` | Slayer 20. Alive in the snapshot |
| Staunton | `57A6` | Warpriest 20. Alive in the snapshot |
| Kestoglyr | `5728` | Stalwart Defender 10, Fighter 9, Witch 1. Alive in the snapshot |
| Marksman | `2805` | Undead skeletal bard/magus. Dead in the snapshot. Rules and buff rows stay |
| Horse | `55FD` | Ciar's animal companion. Dead in the snapshot. Rules and buff rows stay |

Spellbooks stored on Buff It caster rows:

| Spellbook | Guid |
|---|---|
| Wizard, FaN | `5a38c9ac-8607-8904-09fc-b8f6342da6f4` |
| Warpriest, Staunton | `7d7d51be-2948-d254-4b3c-2e1596fd7603` |
| Bard, Galfrey | `bc04fc15-7a88-01d4-1b87-7ad0d9af03dd` |
| Skeletal Bard, Marksman | `d731dfb3-9ea2-6754-c89b-58d0969ea9e0` |
| Skeletal Magus, Marksman | `c9ff1f4b-3b26-dcb4-7ba7-5b218ccadd23` |

`CasterRanks`, `MountPreference`, and `FuryWeaponPreference` are empty.

## Save snapshot

`current/Current_Save.json` was read from `Quick_7.zks` on 2026-09-29. That quicksave is no longer in the Saved Games folder.

| Field | Recorded value |
|---|---|
| Header name | `Quicksave3` |
| Player | FaN |
| GameId | `7ea3d466491c4249aec2742271c2e71a` |
| In-game total time | `07:55:16.5800000` |
| SHA-256 | `2a66fa7e82a14047e850e526138af85f4c49281e0a08de7e55187308eb7c84fb` |

Do not treat a save named Quicksave3 as FaN unless the player and GameId match. On 2026-09-30, `Quick_6.zks` is also named Quicksave3, and that file is Fan the sword saint.

FaN saves still on disk that day:

| File | Header name | In-game total time | Area |
|---|---|---|---|
| `Quick_1.zks` | Quicksave1 | `07:54:17.8530000` | `9044849df0db4e6f9572f0d89c17bfcc` |
| `Manual_7_Iz__22_Arodus__VIII__4715__22_34_12.zks` | Iz -22 Arodus (VIII) 4715 -22:34:12 | `07:51:06.0920000` | `b562abee3cd34a749da4c2822fa76728` |

`current/Current_Report.md` is the parsed party, equipment, and toggles from the missing Quick_7 snapshot. Build notes in `Kestoglyr_High_AC_Build.md` and `Ciar_Horse_Bulwark_Build.md` are the plan. When a build note and `current/` disagree, `current/` wins. Do not edit the save or `current/` from this file.

## Buff It

`Version` is 1. The same global flags as the sword saint file: verbose casting, skip animations, cast on combat start, allow in combat, bypass arcane failure, and overwrite are all false. Source priority is 0. Use Magic Device retries are 3 and mode is 1. Scrolls, potions, equipment, songs, and activatables are enabled. Sort by name is false. There is no menu hotkey.

| Button | `InGroups` | Rows |
|---|---|---|
| Normal | `Long` | 55 |
| Quick | `Quick` | 3: Sickening Infusion, Focused Infusion, Commanding Infusion |
| Important | `Important` | 0 |

Every row has `UseSpells`, `UseScrolls`, `UsePotions`, and `UseEquipment` true. `UseExtendRod` and `CastOnCombatStart` are false. `Blacklisted` is false. `Cap` is -1.

`SourceType` on a caster entry:

| Value | Meaning in this file |
|---|---|
| 0 | Spellbook. The spellbook guid is set |
| 1 | Scroll. Spellbook is all zeros |
| 2 | Potion. Spellbook is all zeros |
| 4 | Activatable. Used by Inspire Heroics and Dirge of Doom |

Caster order in the table is the order in the JSON. The first caster is tried first. The JSON is the authority. Do not rebuild a row from this table if you still have the zip.

BUFF_TABLE_HERE

## Wrath Tactics

Ctrl+T opens the panel. `GlobalRules` is empty. `TacticsEnabled` is true for all eight unit ids. `ShowPortraitToggles` is true. `TickIntervalSeconds` is 3. `OutOfCombatTickIntervalSeconds` is 2. `DebugLogging` is false. `RecentBuffGuids` is empty. Do not change the tick to 1 to match the sword saint file.

Each tick runs global rules first, then that character's rules from top to bottom. `PresetId` is null on these rules, so the rule body is what runs.

Enum numbers stored in the JSON:

| Field | Value |
|---|---|
| Action 0 | CastSpell |
| Action 3 | ToggleActivatable |
| Action 4 | AttackTarget |
| Action 5 | Heal |
| Toggle mode 0 | On |
| Toggle mode 1 | Off. Staunton's Power Attack rule uses this |
| Target 0 | Self |
| Target 4 | Nearest enemy |
| Target 5 | Lowest-HP enemy |
| Target 17 | The unit that matched the condition |
| Target 21 | A point toward the matched unit |
| Target 22 | A specific ally. The unit id is `Target.Filter` |
| Target 23 | The enemy with the most enemy neighbors |
| Subject 0 | Self |
| Subject 1 | An ally |
| Subject 4 | Enemy count |
| Subject 5 | Combat |
| Subject 18 | Highest-HD enemy |
| Subject 20 | Ally pinned by `Value2` |
| Subject 21 | Nearest enemy |
| Property 0 | HP percent, 0 to 100 |
| Property 2 | Has buff. The value is the buff id, not the spell id |
| Property 7 | Creature type |
| Property 8 | Combat rounds |
| Property 14 | Is in combat |
| Property 16 | Spell DC minus the target's save |
| Property 18 | Within range. `Long` is at most 40 meters. `Melee` is at most 2 meters |
| Property 25 | Enemy HD minus party level |
| Operator 0 | Less than |
| Operator 1 | Greater than |
| Operator 2 | Equal |
| Operator 3 | Not equal |
| Operator 4 | Greater or equal |
| Operator 5 | Less or equal |

For an enemy-count condition, `Value2` is the count and `CountOperator` 4 means the count is greater than or equal to that number. A spell id is 32 hex characters, no hyphens, then `@L` and the level. `#256` on Hungry Flesh is the metamagic mask. Keep it.

### FaN

| Order | Rule | On | Cooldown rounds | What the JSON does |
|---|---|---|---|---|
| 1 | Boss Corrupt Magic | yes | 1 | Cast `6fd7bdd6dfa9dd943b36d65faf97ac41@L9` at the highest-HD enemy when that enemy's HD is at least party level minus 3, the enemy is missing buff `9f1252226cde84040859bbf1cfbcf0bb`, and the enemy is within long range |
| 2 | Boss Absolute Death | yes | 1 | Cast `7d721be6d74f07f4d952ee8d6f8f44a0@L10` at that same kind of enemy when the Corrupt Magic buff is already there and spell DC minus save is at least 0 |
| 3 | Boss Embrace of Death | yes | 1 | Cast `41e229444616fc045a9da02f19e47f76@L8` when Corrupt Magic is present, spell DC minus save is at least 0, and the enemy is missing both `03e56d7d819a3ce40a3b00847ff00ea6` and `ac6909637864d194ea197ba4c9823fc9` |
| 4 | Restore Undead | yes | 1 | Cast `a9dbff7a630003d4eafa6c9dd203cb7e@L7`. The target field is self. The condition looks for an undead ally under 30 percent HP within long range |
| 5 | Negative Self-Heal | yes | 1 | Heal action, strongest spell, negative energy, when FaN is under 25 percent HP. `HealMode` 1, `HealSources` 1, `HealEnergy` 2 |
| 6 | Animate Dead Screen | no | 2 | Cast `4b76d32feb089ad4499c3a1ce8e1ac27@L3` at a point toward the match. It would require combat, fewer than 2 combat rounds, and at least 3 living enemies. Leave it disabled |
| 7 | Hungry Flesh | yes | 0 | Cast `0d820abda7693a9418546a47eea62ea2@L8#256` at a point toward the match during combat when at least 3 enemies are alive and the nearest is within long range |
| 8 | Swarm Feast | yes | 1 | Cast `edf6e91ca5a468849b8326bcc9c569b2@L7` at the nearest enemy when that enemy is a swarm |
| 9 | Finger of Death | yes | 1 | Cast `6f1dcf6cfa92d1948a740195707c0dbe@L7` at the nearest enemy when that enemy is above 40 percent HP and spell DC minus save is at least 0 |
| 10 | Feast of Blood | yes | 1 | Cast the same Feast of Blood spell at the nearest enemy when that enemy is above 0 percent HP |
| 11 | Pit of Despair | no | 0 | Cast `cc74245ba989480488925214dd925100@L10` at the nearest enemy during combat. Leave it disabled |

### Galfrey `56A0`

| Order | Rule | On | Cooldown rounds | What the JSON does |
|---|---|---|---|---|
| 1 | Inspire Heroics | yes | 0 | Toggle on `a4ce06371f09f504fa86fcf6d0e021e4` during combat |
| 2 | Slow | yes | 3 | Cast `f492622e473d34747806bdb39356eb89@L3` at the enemy with the most enemy neighbors, during combat, when at least 3 enemies are alive |
| 3 | Mirror Image | yes | 1 | Cast `3e4ab69ada402d145a5e0ad3ad4b8564@L2` on herself during combat when buff `98dc7e7cc6ef59f4abe20c65708ac623` is missing |

### Marksman `2805`

| Order | Rule | On | Cooldown rounds | What the JSON does |
|---|---|---|---|---|
| 1 | Freedom of Movement | yes | 1 | Cast `0087fc2d64b6095478bc7b8d7d512caf@L4` on FaN. `Target.Filter` and the ally condition `Value2` are `2c002cb0-2987-4e37-a575-eb5cdd155850`. It fires during combat when FaN is missing buff `1533e782fca42b84ea370fc1dcbf4fc1` |
| 2 | Focus lowest HP | yes | 1 | Attack the lowest-HP enemy during combat |

### Delamere `5611`

One rule: attack the lowest-HP enemy during combat. Cooldown 1 round. It is enabled.

### Staunton `57A6`

| Order | Rule | On | Cooldown rounds | What the JSON does |
|---|---|---|---|---|
| 1 | Power Attack Off | yes | 0 | Toggle off `a7b339e4f6ff93a4697df5d7a87ff619` during combat. `ToggleMode` is 1 |
| 2 | Prayer | yes | 1 | Cast `faabd2cc67efa4646ac58c7bb3e40fcc@L3` on himself during combat when buff `789bae3802e7b6b4c8097aaf566a1cf5` is missing |
| 3 | Focus adjacent | yes | 1 | Attack the nearest enemy during combat when that enemy is within melee range |

### Kestoglyr `5728`

All four are enabled and require combat.

| Order | Rule | Cooldown rounds | What the JSON does |
|---|---|---|---|
| 1 | Crane Style | 0 | Toggle on `31af823f7cfbe0b4e8c063019f3b88e2` |
| 2 | Fighting Defensively | 0 | Toggle on `09d742e8b50b0214fb71acfc99cc00b3` |
| 3 | Defensive Stance | 0 | Toggle on `be68c660b41bc9247bcab727b10d2cd1` |
| 4 | Focus adjacent | 1 | Attack the nearest enemy within melee range |

### Ciar `5568`

One rule: attack the nearest enemy within melee range during combat. Cooldown 1 round. It is enabled.

### Horse `55FD`

All three are enabled and require combat.

| Order | Rule | Cooldown rounds | What the JSON does |
|---|---|---|---|
| 1 | Crane Style | 0 | Toggle on `31af823f7cfbe0b4e8c063019f3b88e2` |
| 2 | Fighting Defensively | 0 | Toggle on `09d742e8b50b0214fb71acfc99cc00b3` |
| 3 | Focus adjacent | 1 | Attack the nearest enemy within melee range |

## Leave these as they are

- Do not enable Animate Dead Screen or Pit of Despair.
- Do not delete Galfrey, Marksman, or Horse rules because the snapshot shows them dead.
- Do not change `TickIntervalSeconds` from 3 or `OutOfCombatTickIntervalSeconds` from 2.
- Do not add the living companion roster from `current/Current_Report.md` into `CharacterRules`. Daeran, Ember, Greybor, Lann, Nenio, Regill, Sosiel, Wenduag, Woljif, Camellia, and Arueshalae are in that snapshot and have no tactics rules.
- Do not copy this GameId's JSON over the sword saint files.
