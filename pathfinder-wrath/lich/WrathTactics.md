# Wrath Tactics current configuration



This note matches the 8 rules after the 2026-09-27 edit. One-click buffs are in `BuffIt-OneClickBuff.md`.



The snapshot is the local file after the game was closed. `tactics-current-config.json` is a copy. The game reads:



```

D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure\Mods\WrathTactics\UserSettings\tactics-7ea3d466491c4249aec2742271c2e71a.json

```



- Mod: Wrath Tactics 1.32.1, author Gh05d

- Installed file version: `1.32.1+95dc9d7c5f57917e9b85f1a9eee537cf2b626fed`

- `7ea3d466491c4249aec2742271c2e71a` in the filename is the GameId of FaN's save

- In-game panel: Ctrl+T

- `Presets` in the same folder is the preset library. Every current rule has `PresetId` null, so the file body is what runs

- Backup from before the edit: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1310` in the same folder



## Evaluation order



Each tick runs `GlobalRules` first, then that character's `CharacterRules`. Global rules have higher priority.



`GlobalRules` is currently an empty array. Only FaN has rules. Earlier rules in the list are tested first. After one rule spends the standard action, later rules in the same tick do not spend that same action.



Rules are evaluated only when `TacticsEnabled` is true. All 8 units are true, but only FaN has `CharacterRules`.



## Top-level fields



| Field | Current value | Meaning |

|---|---|---|

| `GlobalRules` | `[]` | Global rules. None right now |

| `CharacterRules` | only FaN's key | The key is the unit id. The value is the rule array |

| `TacticsEnabled` | true for all 8 units | Whether tactics run |

| `ShowPortraitToggles` | true | Show the tactics toggle on portraits |

| `TickIntervalSeconds` | 3.0 | Seconds between checks in combat |

| `OutOfCombatTickIntervalSeconds` | 2.0 | Seconds between checks out of combat |

| `DebugLogging` | false | Do not write a debug log |

| `RecentBuffGuids` | `[]` | Empty |



A character-rule key must equal `Unit.UniqueId`. FaN uses the full GUID. Other units use 4-character short ids. Do not guess a companion's display name from a short id.



## Units



The same ids as the one-click buffs.



| Unit id | What the save establishes |

|---|---|

| `2c002cb0-2987-4e37-a575-eb5cdd155850` | FaN. Half-elf, Wizard 20, Cruoromancer, Lich mythic class 8, mythic starting class 2, mythic rank 10 total. Has the undead type. Negative energy heals him. Positive energy hurts him |

| `56A0` | Bard, with mythic companion levels. Has the undead type |

| `57A6` | Warpriest, with mythic companion levels. Has the undead type |

| `2805` | Has a spellbook. Has the undead type. The class name was not stored as text next to the unit |

| `5568` | Has the undead type |

| `5611` | Has the undead type |

| `5728` | Has the undead type |

| `55FD` | The only one of these eight ids without the undead type. The tactics UI has a Horse slot, and this id is used for that horse |



The UI also shows Ciar, Queen Galfrey, Delamere, Staunton Vhane, Kestoglyr, and Skeletal Marksman. The save does not store those display names next to the short ids.



## One rule



```json

{

  "Id": "the rule's own id",

  "Name": "name shown in the UI",

  "Enabled": true,

  "CooldownRounds": 1,

  "ConditionGroups": [

    {

      "Conditions": [

        {

          "Subject": 0,

          "Property": 0,

          "Operator": 0,

          "CountOperator": 4,

          "Value": "25",

          "Value2": ""

        }

      ]

    }

  ],

  "Action": {

    "Type": 0,

    "AbilityId": "spell key",

    "FallbackAbilityIds": [],

    "HealMode": 0,

    "HealSources": 7,

    "HealEnergy": 0,

    "Sources": 1,

    "SplashMode": 0,

    "ToggleMode": 0,

    "MetamagicRod": null,

    "WeaponSetIndex": 0,

    "MoveWithin": 0

  },

  "Target": { "Type": 0, "Filter": "" },

  "PresetId": null,

  "PackId": null

}

```



- `ConditionGroups` are OR. `Conditions` inside one group are AND.

- When `PresetId` is null, this file's conditions and action are used. A preset id replaces them with the preset body.

- `CooldownRounds`: rounds of cooldown after a successful cast.

- When `Enabled` is false the rule stays in the file and does not run. Hungry Flesh is in that state in the early snapshot.



## Spell keys



`AbilityId` is not a bare GUID. Format:



```

guid[@Llevel][>Vvariant guid][~Aaction type][#metamagic mask]

```



Example: `1098095d7a88c6747aee67f8d449fa06@L5` is 5th-level Deny Death.



A 32-character GUID without `@Llevel` does not match the dropdown, and the UI shows it as `[L0] Acid Splash`.



The `Value` of `HasBuff` is a buff blueprint id, not a spell id.



Buff It uses hyphenated GUIDs. Wrath Tactics uses 32 lowercase hex characters with no hyphens. Removing the hyphens is the same id.



## Condition subject `Subject`



| Number | Name |

|---|---|

| 0 | Self |

| 1 | Ally |

| 2 | AllyCount |

| 3 | Enemy |

| 4 | EnemyCount |

| 5 | Combat |

| 6 | EnemyBiggestThreat |

| 7 | EnemyLowestThreat |

| 8 | EnemyHighestHp |

| 9 | EnemyLowestHp |

| 10 | EnemyLowestAC |

| 11 | EnemyHighestAC |

| 12 | EnemyLowestFort |

| 13 | EnemyHighestFort |

| 14 | EnemyLowestReflex |

| 15 | EnemyHighestReflex |

| 16 | EnemyLowestWill |

| 17 | EnemyHighestWill |

| 18 | EnemyHighestHD |

| 19 | EnemyLowestHD |

| 20 | AllyByName |

| 21 | EnemyNearest |



Count conditions use `EnemyCount` (4) or `AllyCount` (2). `CountOperator` 4 is greater than or equal. `Value2` of `"2"` means the count is at least 2.



## Condition property `Property`



| Number | Name |

|---|---|

| 0 | HpPercent |

| 1 | AC |

| 2 | HasBuff |

| 3 | HasCondition |

| 4 | SpellSlotsAtLevel |

| 5 | SpellSlotsAboveLevel |

| 6 | Resource |

| 7 | CreatureType |

| 8 | CombatRounds |

| 9 | IsDead |

| 10 | SaveFortitude |

| 11 | SaveReflex |

| 12 | SaveWill |

| 13 | Alignment |

| 14 | IsInCombat |

| 15 | HitDice |

| 16 | SpellDCMinusSave |

| 17 | HasClass |

| 18 | WithinRange |

| 19 | ABMinusAC |

| 20 | IsTargetingSelf |

| 21 | IsTargetingAlly |

| 22 | IsTargetedByAlly |

| 23 | IsTargetedByEnemy |

| 24 | IsSummon |

| 25 | EnemyHDMinusPartyLevel |

| 26 | IsPet |

| 27 | IsFlanked |

| 28 | AdjacentEnemyCount |

| 29 | HasDescriptorEffect |

| 30 | ImmuneToEnergy |

| 31 | AbilityDamage |

| 32 | NegativeLevels |

| 33 | HpFlat |

| 34 | WieldsRangedWeapon |



`HasBuff` with `Operator` 3 means the buff is absent.



`SpellDCMinusSave` (16) is computed by `ComputeDCMinusSave` in the 1.32.1 commit `95dc9d7`. It reads this rule's `Action.AbilityId`, takes that spell blueprint's save type, and computes spell DC minus the matching save. It does not hard-code Will or Fortitude. If the spell has no save, or the spell cannot be found, the result is invalid and the condition fails. It does not look at `FallbackAbilityIds`.



## Comparison operators



| Number | Name |

|---|---|

| 0 | LessThan |

| 1 | GreaterThan |

| 2 | Equal |

| 3 | NotEqual |

| 4 | GreaterOrEqual |

| 5 | LessOrEqual |



## Action `Type`



| Number | Name |

|---|---|

| 0 | CastSpell |

| 1 | CastAbility |

| 2 | UseItem |

| 3 | ToggleActivatable |

| 4 | AttackTarget |

| 5 | Heal |

| 6 | DoNothing |

| 7 | ThrowSplash |

| 8 | SwitchWeaponSet |

| 9 | MoveToTarget |



`Sources` and `HealSources`: 1 is the caster's own spells, 2 is scrolls, 4 is potions, 7 is all. Current attack and heal rules use 1.



`HealEnergy`: 0 Auto, 1 Positive, 2 Negative. FaN's self-heal is 2. `HealMode`: 0 Any, 1 Strongest, 2 Weakest. The self-heal is 1.



## Target `Type`



| Number | Name |

|---|---|

| 0 | Self |

| 4 | EnemyNearest |

| 15 | EnemyHighestThreat |

| 17 | ConditionTarget |

| 21 | PointAtConditionTarget |

| 23 | EnemyMostEnemyNeighbors |



The full enum also has 1–3, 5–14, 16, 18–20, 22, and 24: ally hit points, individual saves, creature type, HD, the caster's own point, and a named ally. Enabled rules use 0, 17, and 21. Hungry Flesh is still 21, but disabled in the early snapshot. No rule still uses 15.



`PointAtConditionTarget` (21) places the effect about 1.5 meters from the unit matched by this rule's condition, facing the caster.



Target 15 picks the highest-threat enemy on the field again, which can be a different creature from the one the condition matched. On 2026-09-27 the two death spells were changed to target 17 (ConditionTarget). Whoever passes the hit-point and DC-minus-save checks is the one who gets the spell.



## Selective metamagic



This install's `cheatdata.json` has the feat `SelectiveSpellFeat`, id `85f3340093d144dd944fff9a9adfd2f2`. FaN's unit has that feat. A selective spell can exclude chosen creatures from an area.



This save's `party.json` and `player.json` do not contain these three rods:



- `MetamagicRodLesserSelective` `b1728ccecbb54c939575dfeb866c1e9f`

- `MetamagicRodNormalSelective` `c256be263e99480da5b7cf2a1da1ef17`

- `MetamagicRodGreaterSelective` `5db66b14642642eaa1c623ed0daa5813`



Wrath Tactics `MetamagicRod` is for an equipped metamagic rod. Having the feat does not automatically put Selective on a rule. All 8 rules have `MetamagicRod` null.



## Ids used by the current rules



| Use | 32-character id | Key in the config | Blueprint |

|---|---|---|---|

| Deny Death buff | `632cad6b7c66b8449a300c6476fd5e1b` | bare GUID | DenyDeathBuff |

| Deny Death spell | `1098095d7a88c6747aee67f8d449fa06` | `...@L5` | DenyDeath |

| Mirror Image buff | `98dc7e7cc6ef59f4abe20c65708ac623` | bare GUID | MirrorImageBuff |

| Mirror Image spell | `3e4ab69ada402d145a5e0ad3ad4b8564` | `...@L2` | MirrorImage |

| Swarms and the ordinary area attack | `edf6e91ca5a468849b8326bcc9c569b2` | `...@L7` | FeastOfBlood |

| Absolute Death | `7d721be6d74f07f4d952ee8d6f8f44a0` | `...@L10` | AbsoluteDeath |

| Finger of Death | `6f1dcf6cfa92d1948a740195707c0dbe` | `...@L7` | FingerOfDeath |

| Hungry Flesh, disabled | `0d820abda7693a9418546a47eea62ea2` | `...@L8` | DomainOfTheHungryFlesh |



## Current 8 rules, in evaluation order



### 1. fan-negative-heal



FaN Negative Self-Heal. Enabled.



Own hit-point percent is below 25. Action Heal, Strongest, Negative, HealSources 1. Target self.



### 2. fan-deny-death



FaN Deny Death. Enabled.



When he lacks buff `632cad6b7c66b8449a300c6476fd5e1b`, cast `1098095d7a88c6747aee67f8d449fa06@L5`. Target self. Sources 1.



This refills the buff in combat if it was dispelled or the one-click buffs were not pressed. Do not delete it because Buff It already has Deny Death.



### 3. fan-mirror-image



FaN Mirror Image. Enabled.



When he lacks buff `98dc7e7cc6ef59f4abe20c65708ac623`, cast `3e4ab69ada402d145a5e0ad3ad4b8564@L2`. Target self. Sources 1.



### 4. fan-swarm-missile



The name is now FaN Swarm Feast. The id is still `fan-swarm-missile`. Enabled.



Enemy creature type equals `Swarm`. Cast `edf6e91ca5a468849b8326bcc9c569b2@L7`. No fallback. Target 21.



Magic Missile and Acid Splash are no longer used. It still fires when only one swarm is present. This is a separate rule from the Feast that requires at least two enemies. Do not merge them.



### 5. fan-absolute-death



FaN Absolute Death. Enabled. Two conditions in the same group, AND:



- Subject 6, hit-point percent greater than 40

- Subject 6, SpellDCMinusSave greater than or equal to 0



Cast `7d721be6d74f07f4d952ee8d6f8f44a0@L10`. No fallback. Target 17. Sources 1.



FaN Finger of Death. Enabled. The condition shape matches the previous rule, but `DC minus save` is computed from Finger of Death itself.



Cast `6f1dcf6cfa92d1948a740195707c0dbe@L7`. No fallback. Target 17. Sources 1.



### 7. fan-feast-of-blood



FaN Feast of Blood. Enabled. Two conditions in the same group, AND:



- Enemy count, hit-point percent greater than 0, count at least 2

- Highest-threat enemy, hit-point percent greater than 0



Cast `edf6e91ca5a468849b8326bcc9c569b2@L7`. Target 21. Sources 1.



### 8. fan-hungry-flesh



FaN Hungry Flesh. `Enabled` is false. The body is kept.



The spell is still `0d820abda7693a9418546a47eea62ea2@L8`, target 21. It does not auto-cast. On 2026-09-27 the local blueprint and `Assembly-CSharp.dll` confirmed the normal version hits allies. See the current conclusion at the end.



## Spells checked and not yet added to tactics



"Slots prepared" came from the 2026-04-11 manual save `Manual_1_Threshold`. Do not treat that as the 2026-09-27 spellbook. Names and ids come from the local `Bundles\cheatdata.json`. Restore Undead's area and healing were checked in `blueprints.zip`. See the end of this note.



| Spell | Blueprint Name | 32-character GUID | Level | Spellbook | Save type |

|---|---|---|---|---|---|

| Corrupt Magic | CorruptMagic | `6fd7bdd6dfa9dd943b36d65faf97ac41` | 9 | yes | known, 5 slots prepared |

| Exsanguinate | Exsanguinate | `291524731e8b8f440b44915be833ae07` | 5 | yes | known, not prepared in this save |

| Siphon Life | SiphonLife | `7bd52a86498c7854ebe99bc3cfb85bfe` | 6 | yes | known, not prepared in this save |

| Consume Undead | ConsumeUndead | `0e633cc133207a849915e4d15dec8410` | 4 | yes | known, not prepared in this save |

| Restore Undead | RestoreUndead | `a9dbff7a630003d4eafa6c9dd203cb7e` | 7 | yes | known, not prepared in this save |

| Negative Eruption | NegativeEruption | `5c377ad96e3fc4f4d9b74eba9d38f4f8` | 9 | yes | known, 1 slot prepared |



To write one into tactics, the key is `32-character GUID@Llevel`. Do not auto-add Negative Eruption unless the local blueprint proves it does not heal enemy undead.



## Rules for a later edit



- Spell keys must include `@Llevel`.

- `HasBuff` uses the buff id, not the spell id.

- Do not change FaN's healing to positive energy.

- Do not delete a rule because one check showed 0 uses.

- Do not add `CharacterRules` for any unit other than FaN.

- Leave Hungry Flesh disabled. Do not change it to `#256`. Do not enable it because the horse took 0 damage once.

- Leave Corrupt Magic manual.

- Do not edit Buff It from this note.



## 2026-09-27 check: Tabletop Tweaks and Restore Undead



The local `Mods` folder contains only BuffIt2TheLimit, PuzzleSkip, RespecWrath, ToyBox, and WrathTactics. There is no TabletopTweaks-Base, TabletopTweaks-Core, or any other mod with Tweaks in the name. The `SelectiveMetamagicNonInstantaneous` fix is therefore not present.



`fan-hungry-flesh` stays disabled. AbilityId is still the normal `0d820abda7693a9418546a47eea62ea2@L8`, not `#256`. The area filter was later confirmed from the blueprint and the assembly. See the end of this note.



In 1.32.1, an Ally condition in `EvaluateAllyBucket` requires the same ally to pass every non-count condition in the group. `GetAllPartyMembers` uses `PartyAndPets`, but the non-count Ally loop skips the rule owner. FaN's own hit points cannot satisfy `Subject = Ally`. If the horse is not undead, it cannot combine with a different undead ally's low hit points to pass once.



## 2026-09-27 in-game feat text



The Selective Spell text the player opened says only an area spell whose duration is instantaneous can exclude targets when cast. A spell with no area, or a duration that is not instantaneous, does not benefit. The spell level increases by 1.



Domain of the Hungry Flesh lasts 1 round/level. It is not instantaneous. By that text, Selective Hungry Flesh cannot be used to guarantee allies are safe. `fan-hungry-flesh` stays disabled, and its AbilityId is not changed to a selective `#256` version.



Persistent Spell on the same screen requires a saving throw and adds 2 spell levels. Hungry Flesh has no save, so Persistent does nothing for it.



On the 8th-level spellbook page, Domain of the Hungry Flesh and Horrid Wilting each have an entry marked 8. Restore Undead is visible in the 7th-level known list. That is the known-spells page, not memorized slot counts.



## 2026-09-27 15:28 combat screenshot



The on-screen combat log had one line: FaN casts Domain of the Hungry Flesh. No Selective text, and no horse damage, trip, entangle, or ability damage. The horse was standing in the green area. `combatLog.txt` for that session was still 0 bytes, and the engine log did not contain the cast line. That frame does not prove later rounds spare allies.



## 2026-09-27 15:37 player observation



The player reported the horse stood in Domain of the Hungry Flesh for more than 3 rounds with no incident. The on-screen log was only "FaN casts Domain of the Hungry Flesh." There was no Selective text and no horse damage, trip, entangle, or ability-damage line. `combatLog.txt` was still 0 bytes, and GameLog had no cast line. The automatic rule `fan-hungry-flesh` stays disabled. This observation had no enemy as a positive control, so it does not overturn the assembly conclusion below.



## 2026-09-27 16:10 current conclusion



The game config was not changed. This pass updated the note only.



| File | Size | SHA256 |

|---|---|---|

| Live Buff It | 59,648 | `BE754048475AB0F892BF27257CFD4291C5A1ACC486A1FCA0487414F6B2770AA1` |

| Live Wrath Tactics | 9,420 | `DFFA124A8138169B972538B52D7D45AD1759E19E2EE0458B716B4BA720300EFD` |



The two JSON files in the zip are copies of those files. `GlobalRules` is still an empty array. FaN's 8 rules are still there. `fan-hungry-flesh` `Enabled` is still false. There is no Corrupt Magic rule. Buff It was rewritten at 17:01 on 2026-09-27 and was still 75 rows. Virtue, Aid, Blessing of Unlife, and Death Ward still target only the horse. The three infusions are still on Quick.



That day's spellbook follows the later `Quick_1.zks`, not the 2026-04-11 manual save.



### Hungry Flesh



Sources are `DomainOfTheHungryFlesh.jbp` and `DomainOfTheHungryFleshArea.jbp` in the local `blueprints.zip`, plus `AreaEffectEntityData.IsSuitableTargetType` and `CheckSelective` in `Assembly-CSharp.dll`.



Area id `6df8ed6ff8ac4974aba16eca1b7b5cbe`. Target type `Any` (0 in this enum). `AffectEnemies` is true. Radius 20 feet. Duration in rounds equals caster level. Each round, units inside the area get, in order:



- A trip attempt using the spellcasting ability and caster level

- Entangle on a failed Reflex save, buff `16ed1bf618c6e364b9c0aca9ce8cb54a`

- `2d6 + caster level` bludgeoning, no save, no spell resistance

- A random `1d4` Strength, Dexterity, or Constitution ability damage, no save



A normal cast hits the caster, allies, animal companions, and allied summons, and also hits enemies and neutral units. `m_CanAffectAllies` defaults to true. Only a cast that carries Selective (metamagic bit 256) sets that field to false. The feat text says instantaneous, but `AddMetamagic` and the feat blueprint do not enforce that duration limit. The normal version stays off. The real Selective exclusion is in the 16:33 addendum. Persistent is not used on Hungry Flesh.



The horse taking no damage for more than 3 rounds does not match this implementation. ToyBox `toggleNoFriendlyFireForAOE` is currently false. Freedom of Movement can block entangle. It does not block the bludgeoning. Feather Step only blocks difficult terrain. Death Ward blocks negative energy and energy drain. Blessing of Unlife's 5 damage reduction is penetrated by bludgeoning. At caster level 20 each tick is at least about 22 bludgeoning. 0 hit points of damage looks like the horse was not inside the real cylinder, not like the spell hits only enemies.



Do not run a second control test of the normal version, and do not automate it. The horse's one 0-damage result is not ally filtering.



### Restore Undead



Blueprint `a9dbff7a630003d4eafa6c9dd203cb7e`, 7th level, key `a9dbff7a630003d4eafa6c9dd203cb7e@L7`. Personal range, standard action, no material component, no extra resource pool. The cast target can only be self, so the area center is FaN. `AbilityTargetsAround` then takes living units within 100 feet that have line of sight.



`Ally` uses `IsAlly`. When FaN is in the player faction, himself, player-faction allies, and the horse stay on the list. Healing also requires the fact `NegativeEnergyAffinity` (`d5ee498e19722854198439629c1841a5`). A unit with that fact is healed to full current hit points. Corpses are not included.



Undead immunities grant that fact, and the undead type grants undead immunities. The lich body feature gives FaN the undead type, so FaN himself is filled. Allies who are already undead are filled too. An ordinary horse does not have the fact, so the heal action is empty. If the horse has Blessing of Unlife, or the owner has an undead mount active, the horse gains the fact and is then filled as well.



Wrath Tactics `Target.Type` uses 0 (Self). The trigger requires the same ally to be undead and below 30% hit points. The horse being low on its own does not trigger it. Once cast, every ally within 100 feet and line of sight who has the fact is filled. Do not set `Enabled` to true until today's preparation of the spell is confirmed. The rule is not in the tactics file yet.



If today's preparation is confirmed, the future order puts Restore Undead ahead of the negative-energy self-heal. The reason and the gap are in the 16:33 addendum. The rule is still not written.



### Persistent Finger of Death and Corrupt Magic



The existing `fan-finger-of-death` keeps the normal key `6f1dcf6cfa92d1948a740195707c0dbe@L7`, target 17, and the conditions hit points above 40% and `DC minus save >= 0`. There is no 2026-09-27 spellbook on disk, so this note cannot report whether a Persistent version exists, its real key, or its real spell level. Do not build a key from the metamagic enum. Persistent's install enum value is 128, for comparison only. It is not an AbilityId that exists.



Corrupt Magic (`6fd7bdd6dfa9dd943b36d65faf97ac41`, 9th level) stays manual. 1.32.1 has no condition for number of dispellable buffs, any buff, or boss.



Persistent versions of Horrid Wilting, Embrace of Death, Greater Bestow Curse, Feast of Blood, and Absolute Death are not being looked up yet. Absolute Death is already 10th level. Persistent would add 2 levels and could not be cast.



## 2026-09-27 16:33 Selective path



`m_CanAffectAllies` is written in only two constructors and in `CheckSelective`. The runtime constructor sets it true, then immediately calls `CheckSelective`. The only later read is `IsSuitableTargetType`. Round processing does not rewrite it.



`CheckSelective` takes the area context root, casts it to `AbilityExecutionContext`, and checks `HasMetamagic(256)` on that cast. That is the Selective bit, not a requirement that the whole mask equal 256. If the root context is not a spell context, or the cast does not have the bit, the field stays true.



The Hungry Flesh area's `Any` allows both the enemy and ally branches, and the blueprint has no `ContextConditionIsAlly`. When the Selective bit is present, the field is set false and stays on that area object.



Each round's trip, entangle, bludgeoning, and ability damage are in the same `Round` action list, with no separate faction condition. `OnRound` only walks units already in `InGameUnitsInside`. A unit enters that list only by passing `ShouldUnitBeInside`, which includes `IsSuitableTargetType`. A unit that walks in later takes the same check. The ally branch fails while the field is false, so the unit never enters and none of the four effects run.



Excluded: the caster, player-faction allies, the player-faction horse, and allied summons whose faction is not Neutral.



Not excluded: enemies, and units whose faction has `Neutral` true. Selective does not protect the neutral faction.



`SelectiveSpellFeat` only has `AddMetamagicFeat`, and the metamagic is Selective. `MetamagicBuilder.AddMetamagic` does not check whether the duration is instantaneous. Hungry Flesh `AvailableMetamagic` includes Selective. The feat description is not a gate on this code path.



The other constructor, used on load, sets the field back to true and does not call `CheckSelective`. In a normal fight with no load, the field stays as it was spawned until the area ends.



Before enabling it, still run one Selective test: an enemy inside the real area keeps taking the effects, the horse and undead allies do not, and an ally who walks into the existing area after round 2 also does not. Do not write the tactic until that passes.



The 2026-09-27 16:44 manual save is `Manual_5_AI_CHECK_20260927.zks`. `GameId` is `7ea3d466491c4249aec2742271c2e71a`, the character is FaN, unit `2c002cb0-2987-4e37-a575-eb5cdd155850`. Spellbook blueprint `5a38c9ac8607890409fcb8f6342da6f4`, type Mythic.



The only metamagic spells in the whole save are two: Selective Domain of the Hungry Flesh, and Selective Horrid Wilting. No Persistent.



Selective Hungry Flesh's known custom entry is 8th level, `MetamagicMask` `Selective`. The memorized bar has 7 slots, every `SpellLevel` is 8, and all 7 `Available` values are true. Normal Hungry Flesh is in the known 8th-level list and is not memorized. The Wrath Tactics key from this save is `0d820abda7693a9418546a47eea62ea2@L8#256`. Still do not write the rule. Run the Selective test first.



Restore Undead is known at 7th level, from the mythic spell list, with no metamagic version, and 0 memorized slots. It was not prepared today.



Finger of Death is known at 7th level, with no metamagic version, and 0 memorized slots. Persistent Finger of Death does not exist.



Putting Restore Undead ahead of the negative-energy self-heal is reasonable: the ally condition does not include FaN, so Restore fires only when another undead is below 30%, and it fills FaN as a side effect. If no such ally exists, the self-heal is next. The gap is that the condition does not check 100 feet or line of sight. If the trigger is out of range, the 7th-level spell still fires and does not reach that person. The self-heal line is 25%. If FaN is between 25% and 30% and no other undead is below 30%, neither rule fires.



## 2026-09-27 16:53 combat log



`Quick_2.zks` is the quicksave after this fight. In `combatLog.txt`, Domain of the Hungry Flesh Reflex saves and `2d6+32` bludgeoning appear only on enemies: Kalavakus 8 times, two succubi 2 times each. Every save succeeded, so there is no entangle record. Trip was recorded twice, both against the Kalavakus, and both failed. The horse, FaN, and the other allies do not appear in those records.



FaN has the mythic ability Favorite Metamagic — Selective, blueprint `3cdc012185334b7da4ed42c6fcc948cf`. It lowers the spell-level cost of Selective by 1, minimum 0. Selective Hungry Flesh therefore still uses an 8th-level slot, not 9th. The save's `MetamagicMask` is `Selective`, and the tactics key is still `0d820abda7693a9418546a47eea62ea2@L8#256`. Staying at 8th level with the same slot count does not prove Selective was not cast. The rule is still not written.



## 2026-09-27 17:03 Quicksave1 spellbook



File `Quick_1.zks`, character FaN, GameId `7ea3d466491c4249aec2742271c2e71a`. The mythic spellbook below is `5a38c9ac8607890409fcb8f6342da6f4`. The whole save has no Persistent spell. The only metamagic is two casts: Selective Hungry Flesh and Selective Horrid Wilting. Persistent is not a Favorite, so it is still +2 levels.



| Spell | GUID | Known level | Save | Prepared |

|---|---|---|---|---|

| Restore Undead | `a9dbff7a630003d4eafa6c9dd203cb7e` | 7 | none | not prepared |

| Absolute Death | `7d721be6d74f07f4d952ee8d6f8f44a0` | 10 | Will | 1 slot, already used |

| Corrupt Magic | `6fd7bdd6dfa9dd943b36d65faf97ac41` | 9 | none | 5 slots available |

| Feast of Blood | `edf6e91ca5a468849b8326bcc9c569b2` | 7 | Fortitude | 3 slots available |

| Finger of Death | `6f1dcf6cfa92d1948a740195707c0dbe` | 7 | Fortitude | not prepared |

| Negative Eruption | `5c377ad96e3fc4f4d9b74eba9d38f4f8` | 9 | Will | 1 slot available |

| Hungry Flesh Selective | `0d820abda7693a9418546a47eea62ea2` | 8 | none; the area also has Reflex | 7 slots available, key `@L8#256` |

| Embrace of Death | `41e229444616fc045a9da02f19e47f76` | 8 | Will | 1 slot available |

| Exsanguinate | `291524731e8b8f440b44915be833ae07` | 5 | Fortitude | not prepared |

| Siphon Life | `7bd52a86498c7854ebe99bc3cfb85bfe` | 6 | none | not prepared |

| Siphon Time | `e346cc550c5bfdf428faa7cdb4849d8e` | 6 | Will | not prepared |

| Bone Shield | `0093fc0098c984c43ac239d1211d1311` | 6 | none | 2 slots available |

| Deny Death | `1098095d7a88c6747aee67f8d449fa06` | 5 | none | 6 slots available, plus 1 already used |

| Mirror Image | `3e4ab69ada402d145a5e0ad3ad4b8564` | 2 | none | 8 slots available |

| Bestow Curse, Greater | `6101d0f0720927e4ca413de7b3c4b7e5` | 8 | blueprint has no save field | not prepared |

| Horrid Wilting Selective | `08323922485f7e246acb3d2276515526` | 8 | Fortitude | 1 slot available, key `@L8#256` |

| Consume Undead | `0e633cc133207a849915e4d15dec8410` | 4 | none | not prepared |

| Power Word Kill | `2f8a67c483dfa0f439b293e094ca9e3c` | 9 | none | not prepared |

| Wail of the Banshee | `b24583190f36a8442b212e45226c54fc` | 9 | Fortitude | not prepared |

| Weird | `870af83be6572594d84d276d7fc583e0` | 9 | Will, and also Fortitude | not prepared |

| Hold Monster, Mass | `7f4b66a2b1fdab142904a263c7866d46` | 9 | Will | not prepared |



Feast of Blood's area target is Enemy, and it skips undead and constructs. Siphon Time has a Will save, 30 feet, target type Any, and the blueprint has both Haste and Slow. Negative Eruption is 30 feet, target Any, and splits on whether the target has NegativeEnergyAffinity. Wail of the Banshee and Horrid Wilting also use area type Any. They skip undead and constructs. A living horse can still be hit.



## 2026-09-27 WithinRange, Embrace, and loading a save



The `Value` of `WithinRange` (property 18) is not a number of feet. It uses `Enum.TryParse` on `RangeBracket`: `Melee`, `Cone`, `Short`, `Medium`, `Long`, `Far`. `LessOrEqual` (5) means the distance is within that bracket's maximum. `Long` tops out at 30 meters, about 98.4 feet, slightly shorter than Restore Undead's 100 feet. `Far` is 40 meters and would also count allies the spell cannot reach. There is no line-of-sight condition. The same Ally condition group puts all three checks on the same ally. `Undead` is compared after lowercasing.



Embrace of Death `41e229444616fc045a9da02f19e47f76` is 8th level, medium range, enemies only, no spell resistance, Will save. Success does nothing. Failure applies `03e56d7d819a3ce40a3b00847ff00ea6` for a number of rounds equal to caster level. That buff applies helplessness and prone, 1d6 Constitution drain each round, then another Will save. Success on the later save removes it and applies 1 round of `ac6909637864d194ea197ba4c9823fc9` (EmbraceOfDeathBuffStagger). `SpellDCMinusSave` reads that cast's Will save. `HasBuff` with operator 3 and the main buff id prevents casting it again.



The area file in `Quick_1.zks` still contains a Hungry Flesh area. The parent spell is `0d820abda7693a9418546a47eea62ea2`, `Metamagic` is `Selective`, `SpellLevel` is 8, and `m_CanAffectAllies` is stored as false. The load constructor first sets the field to true, but the current save format writes the field, duration, and coordinates in the same record, and loading writes false back. `OnPostLoad` does not change it and does not call `CheckSelective` again.



## 2026-09-27 17:36, 9 rules written



The game was not running. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1736`. The new Wrath Tactics checksum is `7660468B820D24D8FB3E9EEBD98861FEE1C9FD71D9113B1E20EE414D64A2890F`. Buff It was not changed. Its checksum is still `BE754048475AB0F892BF27257CFD4291C5A1ACC486A1FCA0487414F6B2770AA1`. That differs from the earlier `6A7B0F69...` because Buff It had already been rewritten at 17:01. This pass did not touch it.



`Target.Type` 23 is `GetEnemyMostEnemyNeighbors`. Among visible enemies it finds the one with the densest pack inside a 5 meter radius. The area is centered on that enemy, not on empty ground between two groups.



FaN's order:



1. `fan-negative-heal`

2. `fan-deny-death`

3. `fan-mirror-image`

4. `fan-swarm-missile`

5. `fan-absolute-death`, target still 17

6. `fan-embrace-of-death`, new rule, `41e229444616fc045a9da02f19e47f76@L8`, target 17. Highest threat above 40% hit points, `SpellDCMinusSave` at least 0, and neither main buff `03e56d7d819a3ce40a3b00847ff00ea6` nor `ac6909637864d194ea197ba4c9823fc9`

7. `fan-finger-of-death`, target still 17

8. `fan-hungry-flesh`, now enabled. Key `0d820abda7693a9418546a47eea62ea2@L8#256`. Enemy count at least 3, combat round at most 2, highest threat above 50% hit points. Target 23. Cooldown 3

9. `fan-feast-of-blood`



The other 7 old rules were not changed. `GlobalRules` is still empty. No other character has rules. Persistent was not added.



## 2026-09-27 17:46 Restore Undead inserted first



`Quick_1.zks` was written at 17:43, in-game date 18 Arodus. FaN's mythic spellbook has 1 Restore Undead slot available. The same book has 1 Finger of Death slot and 2 Feast of Blood slots. Written after the game closed. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1746`. New Wrath Tactics checksum: `2E4E910E9EBC1AAF46FB59A76BD950E1644ECB39E7E712E9D805838CA380F9C7`. Buff It was not changed.



`fan-restore-undead` is rule 1, enabled, cooldown 1, target 0. The same ally must be type `Undead`, below 30% hit points, and inside the `Long` range bracket. Spell key `a9dbff7a630003d4eafa6c9dd203cb7e@L7`. The following 9 rules were not edited. They only moved down.



## 2026-09-27 18:02 priority change



Hungry Flesh never fired in the test. It was behind the buff refill and the single-target attacks, so the standard action was already spent, and the condition also required the combat round to be 2 or less. Corrupt Magic was moved first for the highest difficulty. Deny Death and Mirror Image are already in Buff It, so those tactics rules were deleted. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1802`. New checksum: `17EAF79EED881C2FAF99718725B77F0E072D875306D7A51EA6C3EAC51796C0B1`. Buff It was not changed.



Current order:



1. `fan-corrupt-magic`. Any enemy that does not yet have buff `9f1252226cde84040859bbf1cfbcf0bb`, target 17. Cooldown 1. Several enemies are cast one by one, and it casts again after the debuff drops. Key `6fd7bdd6dfa9dd943b36d65faf97ac41@L9`

2. `fan-restore-undead`

3. `fan-negative-heal`

4. `fan-hungry-flesh`. The combat-round limit was removed. Selective `@L8#256`, target 23. Cooldown 30, so it does not lay another area while the old one is still up. At 18:07 on 2026-09-27 the "at least 3 enemies" check was also removed. It fires on 1 enemy if the highest threat is above 50% hit points. Feast of Blood also lost "at least 2 enemies" and fires while the highest threat is alive. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1807`. Checksum: `4D134E5900B07FF18654F385C9250052F2EE0F89FD60DF2C5E1D6EF547B1C206`

5. `fan-swarm-missile`

6. `fan-absolute-death`

7. `fan-embrace-of-death`

8. `fan-finger-of-death`

9. `fan-feast-of-blood`



## 2026-09-27 18:11 Hungry Flesh no longer checks hit points



"Do not cast again while a hostile target is still inside the Selective Hungry Flesh area; cast again after they walk out" cannot be done. Wrath Tactics 1.32.1 has no condition for "is this unit standing in that area" and no condition for "is this Hungry Flesh still up." `HasDescriptorEffect` only sees spell descriptors already on the unit. The area does not put a buff on everyone standing in it. Entangle buff `16ed1bf618c6e364b9c0aca9ce8cb54a` appears only on a failed Reflex save and is removed on leaving the area. Last fight every Reflex save succeeded, so people standing in the area had no buff. It cannot stand in for "still inside the area."



"Highest threat above 50% hit points" was removed. The rule now only requires combat: subject 5, property 14 (`IsInCombat`), operator 2, value `true`. The key is still `0d820abda7693a9418546a47eea62ea2@L8#256`, target 23, cooldown 30. The cooldown roughly covers a duration of caster-level rounds, so it should not lay another area while the old one is still up.



What it cannot do: if enemies walk out early, the rule cannot see that and waits for the 30-round cooldown before casting again. A shorter cooldown refills sooner, and it also casts another layer while people are still in the old area.



The game was not running. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1811`. Checksum: `418A4A12142773F69A50324DAF3757BCEA66ABFFE864C040759C117211BEABAF`. The other 8 rules were not changed. Buff It was not changed.



## 2026-09-27 18:16 Hungry Flesh moved to second



Corrupt Magic is still rule 1. Hungry Flesh moved from rule 4 to rule 2. Condition, spell key, target, and cooldown are unchanged: cast while in combat, key `0d820abda7693a9418546a47eea62ea2@L8#256`, target 23, cooldown 30.



While an enemy still lacks Corrupt Magic, that cast still goes first this round. Hungry Flesh uses the next free standard action. On rounds where it is on cooldown, the later heals and single-target spells are tested as usual. If both a heal and Hungry Flesh can fire in the same round, Hungry Flesh goes first and the heal waits.



Current order:



1. `fan-corrupt-magic`

2. `fan-hungry-flesh`

3. `fan-restore-undead`

4. `fan-negative-heal`

5. `fan-swarm-missile`

6. `fan-absolute-death`

7. `fan-embrace-of-death`

8. `fan-finger-of-death`

9. `fan-feast-of-blood`



Rule bodies were not changed. Only the order changed. The game was not running. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1816`. Checksum: `D25D067627D58B8902606982FFDEF7CBF3CB7769F12DEB463C75571A7CE47B62`. Buff It was not changed.



## 2026-09-27 18:39 Hungry Flesh keeps casting until it is out of slots



The player chose "keep casting, then do other things once it is empty." Corrupt Magic is still rule 1. Hungry Flesh is still rule 2. The condition is still "in combat." The key is still `0d820abda7693a9418546a47eea62ea2@L8#256`. The target is still 23. Cooldown changed from 30 to 0. Zero times 6 seconds is still 0, so every round that still has a standard action lays another area. Old areas are not cleared, and the damage stacks per area.



When the spell has no uses left, the rule fails and the same round continues with the later rules. It does not freeze the turn. Restore Undead, the negative-energy self-heal, and the later single-target spells all come after Hungry Flesh is out of slots.



The order was not changed. The other 8 rule bodies were not changed. The game was not running. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1840`. Checksum: `FA0B1588A0B13331EAC9FD766266F05400CB3BE4E725E9BEA93C5DDA208F2487`. Buff It was not changed.



## 2026-09-27 19:39 attack spells retargeted to the nearest enemy



In the test the main character ran off to cast. Corrupt Magic targeted the first enemy without the buff, Hungry Flesh targeted the densest cluster, and the single-target conditions looked at the highest-threat enemy. Any of those can be far away.



Attack-spell targets were changed to type 4, the nearest visible enemy to FaN. The condition subjects for Corrupt Magic, Absolute Death, Embrace of Death, Finger of Death, Feast of Blood, and the swarm rule changed from "any enemy" or "highest threat" to 21 (nearest enemy). If the nearest person already has Corrupt Magic, the rule fails and does not chase someone farther away. If the nearest person's save is too high, the single-target spells also do not chase someone farther away. Hungry Flesh still fires in combat with cooldown 0. Only the landing point moved to the nearest enemy.



Restore Undead and the negative-energy self-heal were not changed. Their target is still self. The order was not changed. The game was not running. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-1944`. Checksum: `45DD3388FCA301A9565B20F34E109B15C0B7EEED7F030FC577501BBED31807C2`. Buff It was not changed.



## 2026-09-27 21:40 three 10th-level spells after Hungry Flesh



After Hungry Flesh is out of slots, cast these three, then return to the old heals and single-target spells. The game was not running.



Ally damage follows the blueprint target type, not the description text. Death's Realm `AbilityTargetsAround` is `Enemy`, radius 80 feet, centered on the caster. Hit-point damage is applied only on a failed Fortitude save, and it skips undead and constructs. The `1d4` permanent negative level is outside the save, so an enemy who saves still takes it. Spell resistance can stop the whole spell. Allies and the horse are not targets.



Doom to Servitude can target only one non-undead, non-construct enemy. `CanTargetFriends` is false. Curse buff `b7043130aeffe094285c8c74cd0ff576` is applied first. The opening unholy damage happens only on a failed Fortitude save. The buff deals unholy damage again each round, and death applies two more buffs. No spell resistance.



Pit of Despair's area type is `Any`, radius 20 feet. Anyone standing in it falls in. Falling damage ignores faction. The climb DC is 25. Each round's negative-energy damage hits only creatures without NegativeEnergyAffinity. The horse takes that damage. Undead allies do not take that negative energy, but they still fall in. The nightshade is the caster's summon. Of the three spells, only this one hits friendlies.



Order:



3. `fan-deaths-realm`. Cooldown 0, target self. In combat, and the nearest enemy is within `Long`. Key `16c3fe873538010459a8a3fd61304825@L10`

4. `fan-doom-to-servitude`. Cooldown 0, target the nearest enemy. That person is not undead, not a construct, does not have the curse yet, and is within `Medium`. Key `24067ba8e0e69a14e83ff397826f6c6d@L10`

5. `fan-pit-of-despair`. Cooldown 30, target the nearest enemy, and that person is within `Medium`. Cast once, so it does not fire again while the pit is still there. Key `cc74245ba989480488925214dd925100@L10`



Corrupt Magic and Hungry Flesh are still the first two rules, unchanged. Heals and the later single-target spells moved down as a block, unchanged. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-2145`. Checksum: `813E985A12A29ED253D1B389F96062026951BDB28B39C36C49CC3A0890616A44`. Buff It was not changed.



The Buff It copy in this snapshot was replaced with the live file from the game folder. Checksum: `96C1EF3F4E76817E94DDA2EA1795B2D447D7A31A40B3BE6D4AEA405A9FD17088`. Mage Armor gained the horse `55FD` as a source. The other 75 rows are still there. This pass did not change Buff It's contents.



## 2026-09-27 22:02 Death's Realm and Doom to Servitude removed



`fan-deaths-realm` and `fan-doom-to-servitude` were deleted from tactics. `fan-pit-of-despair` remains, still after Hungry Flesh, cooldown 30, target the nearest enemy, key `cc74245ba989480488925214dd925100@L10`.



After Hungry Flesh is out of slots, the next attack spell is Pit of Despair. While it is on cooldown, Restore Undead, the negative-energy self-heal, and the later single-target spells get their turn. The other rule bodies were not changed. The game was not running. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-2202`. Checksum: `F2E8B0813A391A887D4E21A7B2CFFBBF2179B847FFB0FED8709C3B7811BB1980`. Buff It was not changed.



## 2026-09-27 22:08 Pit of Despair casts continuously



`fan-pit-of-despair` cooldown changed from 30 to 0. The condition now only checks whether combat is active, same as Hungry Flesh. The target is still type 4, the nearest enemy. The key is still `cc74245ba989480488925214dd925100@L10`.



After Hungry Flesh is out of slots, every round that still has a standard action casts Pit of Despair until that spell is also out of slots. When it has no slots, the same round moves on to heals and the later single-target spells. Other rules were not changed. The game was not running. Backup: `tactics-7ea3d466491c4249aec2742271c2e71a.json.bak-20260927-2209`. Checksum: `4798A6329118471278DEA467218873AD70C03B6A621CAADC3B98BF6D413CC0C0`. Buff It was not changed.



## 2026-09-29 Unfair tactics after Quick_3

The baseline save is `Quick_3.zks` from 2026-09-28 23:58:17. This pass changes only Wrath Tactics. No respec, no gear changes, no Buff It changes, and no save edits.

The ordinary meat shield is only Animate Dead, blueprint `4b76d32feb089ad4499c3a1ce8e1ac27`. Prefer `4b76d32feb089ad4499c3a1ce8e1ac27@L3`, and fall back to `@L4` when no 3rd-level slot is left. It is a standard action and summons 1d4+2 Skeletal Champions. Do not use Summon Monster IX, a Ravener Dragon, a Nightshade Nightcrawler, an Ecorche, or another high-level single summon as this tactic's meat shield.

[Manual steps for this known fight]

Before the pull, FaN manually casts Animate Dead once. Put the skeletons about 5 to 10 meters in front of Kest, on the Smilodon's straight charge path if possible. The line is: summons, then Kest, then Ciar plus Horse, then Staunton, then Galfrey, FaN, Delamere, and Marksman. The first Pounce should hit the skeletons.

Wrath Tactics can reliably see only enemies that have already entered combat, so `fan-animate-dead-screen` only adds a second wave of meat shields after combat starts. It cannot be relied on to eat the first-round Pounce.

[Manual pre-fight check]

Ciar must already be mounted on Horse. Do that by hand. Wrath Tactics 1.32.1 ToggleActivatable cannot reliably "start Mount, wait for a target, then click Horse." Do not automate mounting.

[Required]

In the latest Quick_3, FaN already knows Absolute Death, but no usable 10th-level slot is prepared. Before the next test, prepare at least 1 Absolute Death in the spellbook, then rest. The save will not be edited. The rule exists, but with no slot it does not fire and falls through to Embrace of Death.

[Manual steps]

1. Before the fight, confirm Ciar is mounted on Horse.
2. FaN manually casts Animate Dead once.
3. Place the 1d4+2 skeletons about 5 to 10 meters in front of Kest, blocking the Smilodon's Pounce.
4. Kest stands behind the skeletons and is the first real line.
5. Ciar plus Horse stand behind Kest.
6. Staunton is the next layer back.
7. Galfrey, FaN, Delamere, and Marksman stay in the back.
8. Start the fight.
9. If several enemies are there at the start, tactics adds Animate Dead, Galfrey uses Inspire Heroics and Slow, and FaN casts Selective Hungry Flesh after the boss chain.
10. After the CR22 Keketar appears, FaN prefers Corrupt Magic, then Absolute Death, then Embrace of Death.
11. Pit of Despair is not automatic. Cast it manually when the terrain suits it.

Pit of Despair is manual only. The area affects Any, so the horse and the front line can fall in. `fan-pit-of-despair` Enabled is false. The rule is kept.

Power from Death is not automatic. The Keketar window is short, and spending a standard action on it delays Corrupt Magic and Absolute Death. Cast it manually when it is needed.

### Effective level difference

Wrath Tactics 1.32.1 `EnemyHDMinusPartyLevel` is the enemy's effective HD minus the highest effective HD in the party. Effective HD is character level plus mythic rank. This party's highest is character 20 plus mythic 10, which is 30.

Class levels actually read from the Quick_3 area:

- 9 `DLC1_SmilodonElite`: Outsider 17. Difference -13.
- 4 `Marhevok`: Bloodrager 19. Difference -11. These four are Marhevok in the save, not the Half-Fiend Guardian Minotaur blueprint.
- `CR22_ProteanKeketarMelee`: Outsider 23 plus Fighter 4, total 27. Difference -3.

The boss gate is therefore `EnemyHDMinusPartyLevel >= -3`, not `>= 3`. `>= 3` requires effective HD of at least 33. This keketar is 27, so that rule would never fire. `-3` lets this keketar through and still blocks the level 17 cats and the level 19 Marhevoks.

### Current automatic order

FaN: `fan-corrupt-magic`, `fan-absolute-death`, `fan-embrace-of-death`, `fan-restore-undead`, `fan-negative-heal`, `fan-animate-dead-screen`, `fan-hungry-flesh`, `fan-swarm-missile`, `fan-finger-of-death`, `fan-feast-of-blood`, `fan-pit-of-despair` (disabled).

Galfrey: `galfrey-inspire-heroics`, `galfrey-slow` (at least 3 living enemies), `galfrey-mirror-image`.

Staunton：`staunton-power-attack-off`，`staunton-prayer`，`staunton-focus-adjacent`。

Horse：`horse-crane-style`，`horse-fight-defensively`，`horse-focus-adjacent`。

The original rules for Kestoglyr, Ciar, Delamere, and Skeletal Marksman were not changed.


## 2026-09-29 automatic Animate Dead turned off

`fan-animate-dead-screen` is still in the file, with Enabled set to false. In the real fight it spent FaN's combat action and still could not stop the Smilodon's first-round Pounce.

Before the fight, still cast Animate Dead once by hand and put the skeletons in front of Kest. That instruction stays.

`fan-corrupt-magic`, `fan-absolute-death`, `fan-embrace-of-death`, and `fan-hungry-flesh` were not changed. Pit of Despair is still manual.
