# Snapshot Metadata

- Character: Kestoglyr
- Save: Auto_1.zks
- Save time: 2026-09-28 23:14:28
- Unit identifier: ends with 5728
- Character alive in save: yes
- Source: save/log/blueprint read-only diagnostic
- Original diagnostic package: C:\Users\timeg\Desktop\Kestoglyr_Diagnostic.zip

# Kestoglyr diagnostic

Read-only extract. Source save copy: `Auto_1.zks`. Original file was not modified.

Save wall time: 2026-09-28 23:14:28. Header `SystemSaveTime` 2026-09-28T23:14:27. In-game `GameSaveTime` 5.22:24:07. Player FaN. Kestoglyr unit id ends with `5728`. He is alive in this save (`m_Damage` null, no Dead life state).

Quick_4.zks (23:05:36) is an earlier wall-clock save from the same evening. In that file the same build exists and Kestoglyr is Dead with `m_Damage` 364. That is the post-fight save. This report uses Auto_1 because it is the newest file and he is alive.

## A. Identity and classes

SOURCE: SAVE `Progression.m_ClassesOrder` and `Classes`.

- Race blueprint on the companion unit: Human. SOURCE: GAME BLUEPRINT `Kestoglyr_Companion` race `HumanRace`. The save class list does not restate race separately in this extract.
- Alignment on the companion blueprint: LawfulEvil. SOURCE: GAME BLUEPRINT.
- Creature: `UndeadType`, `UndeadImmunities`, `NegativeEnergyAffinity` are active features. SOURCE: SAVE facts.
- Character level 20. Class totals: Fighter 9, Witch 1, Stalwart Defender 10, Mythic Companion 10.

Level order from the save:

| Level | Class |
|---:|---|
| 1–3 | Fighter |
| 4 | Witch (spellbook `AccursedWitchSpellbook`; English UI name Stigmatized Witch) |
| 5–8 | Fighter |
| 9–10 | Stalwart Defender |
| 11 | Fighter |
| 12–19 | Stalwart Defender |
| 20 | Fighter |
| mythic 1–10 | Mythic Companion, stored as order entries 21–30 |

This matches Fighter 9 / Stigmatized Witch 1 / Stalwart Defender 10. SOURCE: SAVE.

## B. Attributes

SOURCE: SAVE stat objects. These objects store base and permanent only. They do not store the character-sheet total of 34.

| Stat | m_BaseValue | PermanentValue |
|---|---:|---:|
| STR | 20 | 20 |
| DEX | 18 | 20 |
| CON | 10 | 10 |
| INT | 7 | 7 |
| WIS | 10 | 10 |
| CHA | 14 | 14 |

The companion blueprint starts at STR 15, DEX 18, CON 10, INT 7, WIS 10, CHA 14. SOURCE: GAME BLUEPRINT `Kestoglyr_Companion`.

STR base 20 in the save is the level-up result: 15 + five +1 increases. DEX permanent 20 versus base 18 means two of those increases, or an equivalent permanent +2, landed on DEX before the rest went to STR. The save does not store a separate "level-up log" beyond base versus permanent.

The sheet totals STR 34 and DEX 34 are not stored on these stat objects. SOURCE: SAVE absence. Those totals are runtime sums of item and buff modifiers. This extract did not find a serialized STR 34.

## C. Skills

SOURCE: SAVE skill stats. `m_BaseValue` is ranks. `PermanentValue` includes permanent bonuses and is not the rank.

| Skill | Ranks (base) | PermanentValue |
|---|---:|---:|
| Mobility | 5 | 13 |
| Athletics | 11 | 19 |
| Perception | 20 | 23 |
| Persuasion | 5 | 10 |
| Thievery | none | 5 |
| Stealth | none | 5 |
| Use Magic Device | none | 2 |
| Knowledge Arcana | none | -2 |
| Knowledge World | none | -2 |

Mobility ranks are 5. The Crane Style check needs 3. The extra 2 ranks are real spent ranks, not a display bonus. SOURCE: SAVE.

Mobility is not a Fighter or Witch class skill. Guard background adds Perception as a class skill, not Mobility. SOURCE: GAME BLUEPRINT.

## D. Feats present

SOURCE: SAVE facts. The save does not store the character level that granted each feat. Level placement below is INFERENCE from `m_ClassesOrder` plus the feat existing.

Present and active:

- Toughness
- Dodge
- Endurance
- Armor Focus (Medium) `ArmorFocusMedium`
- Shield Focus
- Greater Shield Focus `ShieldFocusGreater`
- Improved Unarmed Strike
- Crane Style `CraneStyleFeat`
- Missile Shield
- Blind Fight
- Power Attack
- Two-Weapon Fighting
- Double Slice
- TwoWeaponFightingBasicMechanics

Locked levels 1–3 are Fighter. The save still has Two-Weapon Fighting, Double Slice, and Power Attack. Those match the pre-retrain fighter package that normal retrain cannot remove. SOURCE: SAVE facts. Exact level inside 1–3 is not stored.

Improved Initiative as a non-mythic feat name was not in the filtered key-fact list. Mythic Improved Initiative `ImprovedInitiativeMythicFeat` is present. If the base feat is required by the mythic feat, it should exist; this extract did not print a separate `ImprovedInitiative` feature. Treat base Improved Initiative as unconfirmed until the character sheet is checked. SOURCE: SAVE fact scan.

## E. Fighter

SOURCE: SAVE facts.

- `WeaponTrainingHeavyBlades` active. Blueprint attack bonus on that feature is +1, descriptor Weapon Training. SOURCE: GAME BLUEPRINT. Higher fighter weapon-training ranks can raise it at runtime; the save does not store the current displayed bonus.
- `TrainedInitiative` active. It is a Weapon Training option. SOURCE: SAVE. The save does not store the initiative number it currently adds.

Armor Training rank is not a separate named fact in the filtered list. Fighter 7 is included in the level order (levels 5–8 are Fighter, so fighter level reaches 7 before Stalwart). Armor Training increments at fighter 3 and 7. INFERENCE: two increments. Not a stored integer.

## F. Stalwart Defender

SOURCE: SAVE facts unless noted.

Present:

- Internal Fortitude
- Fearless Defense
- Increased Damage Reduction (feature present once; the feature asset `Ranks` is 2, so a second rank can exist inside one fact)
- Renewed Defense, plus `RenewedDefenseAbility`
- Uncanny Dodge and `UncannyDodgeChecker`
- Improved Uncanny Dodge

Not present: Roused Defense, Smash.

Automatic class features from the progression blueprint, not extra picks: AC bonus at defender levels 1, 4, 7, 10 (dodge, rank = those steps, so +4 at level 10). Damage reduction feature levels at 5, 7, 10. SOURCE: GAME BLUEPRINT `StalwartDefenderProgression`. The save does not store "DR 10" as a number on the class feature.

Defensive Stance toggle exists. `m_IsOn` is null in this save, so the stance is not on. SOURCE: SAVE.

AC from Stalwart while the stance is off: the +4 dodge class bonus if it is applied as a passive fact. The extra +2 dodge from the stance itself is off. This extract did not find those numbers inside the saved AC modifier list (see J).

Internal Fortitude grants immunity to Sickened and Nauseated. SOURCE: GAME BLUEPRINT. `UndeadImmunities` on this character already includes both conditions. SOURCE: GAME BLUEPRINT `UndeadImmunities.jbp`. So Internal Fortitude does not add a new immunity.

## G. Stigmatized Witch

SOURCE: SAVE.

- Spellbook: `AccursedWitchSpellbook`, internal level 1.
- Hare Familiar bond and `HareFamiliarAbility` active. Hare bond is Initiative +4, descriptor None, and Perception +2. SOURCE: GAME BLUEPRINT `HareFamiliarBondFeature`.
- Hex: `WitchHexIceplantFeature`. Iceplant is Natural Armor +2. SOURCE: GAME BLUEPRINT.
- Curse: `HellboundCurseProgression` with feature levels 1, 5, 10, and 15. There is no Plagued feature. The curse in this save is Hellbound, not Plagued.
- Hellbound level 10 is the usual fire-immunity step of that curse. The feature is present. This extract did not re-read the level-10 component text in this pass. Fire immunity "from Hellbound" is INFERENCE from the feature level being present, matching the character sheet the user already saw.
- Known level-1 spells: `UnbreakableHeart`, `InflictLightWoundsCast`.
- Cantrips present include Daze, Guidance, Light (`MageLight`), Touch of Fatigue, Dismiss, Stabilize, plus Divine Zap and Resistance.
- Arcane spell failure 55% is not stored as a number in the extracted stat block. INFERENCE from wearing armor and a shield. Witch level stays 1.

## H. Mythic features present

SOURCE: SAVE facts. The save does not label them M1 through M10 in order. Presence only:

| Feature in save | Blueprint effect already read |
|---|---|
| Last Stand | feature + `LastStandBuff` active |
| Improved Initiative (Mythic) | present |
| Ever Ready | present |
| Mythic Armor Focus (Medium) Var2 | this is the Endurance variant: while armor category is Medium, add half of armor AC. Buff and sub-buff are active |
| Dodge (Mythic) | permanent Dodge +1, plus `DodgeMythicBuff` |
| Unrelenting Assault | present |
| Toughness (Mythic) | present |
| Unstoppable | present |
| Shield Focus (Mythic) | present |
| Mythic Bypass Epic DR | present |

Rupture Restraints was not found in the fact list. SOURCE: SAVE absence.

`DodgeMythicBuff` is active. Its bonus is a rank-based dodge bonus, and an attack-roll trigger removes that buff. SOURCE: GAME BLUEPRINT. So the large dodge number applies until the first attack roll against him each round, then drops off. The permanent piece is only +1.

## I. Equipment currently wielded

SOURCE: SAVE items with `m_WielderRef` 5728.

| Slot | Blueprint name | GUID |
|---|---|---|
| Main hand | DawnflowersKiss_Basic_Scimitar | 4ca4986b49b01954997f37c24c98d1f3 |
| Off hand | AssertionOfDominanceShieldItem | 2ad512d4b7d1438c97b48fe232fcceb5 |
| Armor | ScalemailStandard | d7963e1fcf260c148877afd3252dbc91 |
| Belt | BeltOfBloodlustItem | c63859f821f7b414492580b638b009fb |
| Head | RuggedHelmetItem | 9b422adf4bdb9994a9690ac20ca74370 |
| Feet | BootsOfOutbreakItem | e55f0210859bb3b4883958e41c155490 |
| Gloves | GlovesOfDuelingNormalItem | c8f949c03b92f714b83edd610f3e9348 |
| Neck | AmuletOfNaturalArmor5 | 11f435140501db84e8e787bf8792fac2 |
| Ring | RingOfProtection5 | 2d576daea5f62ae489028bce40469285 |
| Shoulders | CloakOfResistance5 | a34cd0f80d04ec647af741d924a3e2a3 |

No mithral full plate is equipped.

Assertion of Dominance, from the save and blueprint:

- The armor-slot AC object records Shield +2 and ShieldEnhancement +5 from the shield item. SOURCE: SAVE.
- While HP percent equals 100, it applies `AssertionOfDominanceBuffResist`. That buff is `AddPhysicalImmunity` for Piercing and Slashing. It does not include Bludgeoning. SOURCE: GAME BLUEPRINT.
- Both the gate buff and the resist buff are active in this save, so at save time he was at full HP and the immunity was on. SOURCE: SAVE.

## J. AC math that is actually stored

SOURCE: SAVE, the scalemail item's dexterity limiter target. Base AC 10. Dexterity bonus applied from armor: +5 (limiter value 5, source Armor). Modifiers on that object:

| Descriptor | Value | Item |
|---|---:|---|
| DexterityBonus | +5 | armor limiter |
| Size | 0 | |
| Shield | +2 | Assertion of Dominance |
| ShieldEnhancement | +5 | Assertion of Dominance |
| Armor | +5 | Scalemail |
| ArmorEnhancement | 0 | Scalemail |

Sum of that partial list: 10+5+2+5+5 = 27. This is not the character-sheet total. Dodge, deflection, natural armor, Stalwart, mythic endurance, and mythic dodge are active features but are not in this modifier list.

What can be separated without pretending the sheet total lives in the file:

- Always in this stored fragment: base 10, dex capped at +5 by the worn armor, scalemail armor +5, shield +2, shield enhancement +5.
- Mythic Medium Endurance sub-buff is active, and the armor type of scalemail is medium, so the feat is running. The +3 the user saw on the sheet is not repeated as its own line in this stored list. SOURCE: SAVE buff presence. The +3 figure is from the user's screenshot, not recomputed here.
- Mythic Dodge +1 is permanent. `DodgeMythicBuff` is active, so the once-per-round rank bonus is currently applied and will be removed on the next attack roll against him. SOURCE: GAME BLUEPRINT. If the sheet total is 62 and that bonus is +10, the rest of the sheet is 52. That subtraction is INFERENCE from the user's screenshot plus the blueprint, not a total stored in the save.
- Defensive Stance is off, so its +2 dodge is not in the current total.
- Fighting Defensively toggle `m_IsOn` is true, but that bonus still waits until he completes an attack. Crane Style toggle is on.

Do not treat 62 as the AC of every hit.

## K. Initiative

SOURCE: SAVE does not store a total of +38.

Pieces that are definitely present:

- DEX permanent 20 is a +5 modifier if no further dex bonus is applied. The sheet dex of 34 is not stored, so the dex portion of the displayed initiative may be higher than +5. INFERENCE.
- Hare Familiar: +4 initiative. SOURCE: GAME BLUEPRINT.
- Improved Initiative (Mythic): present. SOURCE: SAVE. Amount is mythic rank added to initiative if that is this feat's effect. Rank 10 would be +10. The exact formula was not re-read in this pass. Mark as INFERENCE if added as +10.
- Trained Initiative: present. SOURCE: SAVE. Amount not stored.
- Inspirational Leader was previously found on Galfrey, not on this unit. It is not re-checked in Auto_1 in this pass.

The save cannot be forced to add up to +38 from stored numbers alone.

## L. Other defense

- HP `m_BaseValue` 182. SOURCE: SAVE. A sheet total of 371 is not this field.
- Fortitude base 11. Reflex base 6, permanent 11. Will base 10. SOURCE: SAVE. These are not the fully buffed sheet totals.
- `UndeadImmunities` includes Nauseated, Sickened, Exhausted, Fatigued, Paralyzed. SOURCE: GAME BLUEPRINT.
- Negative energy affinity feature is active. SOURCE: SAVE.
- Last Stand buff is active. SOURCE: SAVE.
- Rupture Restraints feature was not found.
- Unstoppable feature is present.
- Hellbound curse features through level 15 are present.

## M. Toggles

SOURCE: SAVE `m_IsOn` on the activatable facts.

| Ability | Kind | m_IsOn in this save |
|---|---|---|
| Crane Style | toggle | true |
| Fighting Defensively | toggle | true |
| Defensive Stance | toggle | null (off) |
| Power Attack | toggle | null (off) |
| Hare Familiar | toggle | true |

Crane Style and Iceplant and the curse are also passive features. The AC change from Crane Style still depends on Fighting Defensively, and that bonus starts after an attack.

## Contradictions with the expected sheet

1. Curse is Hellbound, including level 10 and 15 features. It is not Plagued. SOURCE: SAVE.
2. Rupture Restraints is not in the fact list. Mythic Bypass Epic DR is. SOURCE: SAVE.
3. STR 34 / DEX 34 / AC 62 / Initiative +38 / HP 371 are not stored as totals. Stored bases are STR 20, DEX permanent 20, HP 182. SOURCE: SAVE.
4. Armor is `ScalemailStandard`, not mithral full plate. Medium endurance buff is active on that medium armor. SOURCE: SAVE.
5. Defensive Stance is off in this save. Crane Style and Fighting Defensively are on. SOURCE: SAVE.
6. Internal Fortitude does not add Nauseated immunity beyond `UndeadImmunities`, which already lists Nauseated. SOURCE: GAME BLUEPRINT.

## Logs

See `Logs_Relevant.txt`. `combatLog.txt` is 0 bytes as of 23:10:18, so the smilodon fight has no per-hit transcript left. `game-history.txt` is missing. Fight deaths are in Quick_4 history, summarized in that log note.
