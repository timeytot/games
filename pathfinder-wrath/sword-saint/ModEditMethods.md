# How Fan's spellbook, Buff It, and Wrath Tactics are edited

The game does not read this folder. Edit the live files below only while `Wrath.exe` is closed. If the buff screen or the tactics screen is open, closing it writes the in-memory copy back over the file.

Game install:

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure
```

Fan's GameId is `8dd97a37ca674651afefb4dd19e06967`. Unit id is `6078761c-2271-48a8-bfe2-e82f88a8f041`. Sword Saint spellbook blueprint is `682545e11e5306c45b14ca78bcbe3e62` inside the save, and `682545e1-1e53-06c4-5b14-ca78bcbe3e62` in Buff It.

## Spellbook

A `.zks` save is a zip. Prepared spells are not a separate text file. They live in `party.json`, on Fan's descriptor, in `m_Spellbooks`, in the Sword Saint book.

| List | Meaning |
|---|---|
| `m_KnownSpells[level]` | Spells in the spellbook. Each entry has `$id` and `Blueprint` (32 hex characters, no hyphens). |
| `m_MemorizedSpells[level]` | Prepared slots. Each slot's `Spell.$ref` points at a known spell `$id`. |

`SlottedSpell not available` with `Spell credits=1` means the spell is known, and one slot of that level is still free, but this spell's prepared copy is already spent. Putting the name in the known list again does not fix that. The prepared slot has to reference that spell, and the character has to rest before a newly prepared spell can be cast.

On 2026-09-29 the edited save is `Quick_3.zks`, the save before `Quick_4`. `Quick_4.zks` was not written. Backup: `Quick_3.zks.bak-20260929-l6` in the same Saved Games folder. Level 6 already had Transformation (`$id` 1857) and True Seeing (`$id` 1858) in the known list, and Hellfire Ray (`$id` 1866) and Chain Lightning (`$id` 1859) were already known. The two prepared enhancement slots were pointed at those known spells, with `Available` set true:

| Slot | Before | After |
|---|---|---|
| `$id` 1893 | Bull's Strength, Mass `$ref` 1860 | Hellfire Ray `$ref` 1866 |
| `$id` 1894 | Bear's Endurance, Mass `$ref` 1864 | Chain Lightning `$ref` 1859 |

Mirror Image, Haste, Stoneskin, Enlarge Person, Mass, and Vampiric Shadow Shield were already prepared on their own levels. Load `Quick_3`, then rest, then press Normal.

Blueprint names are resolved from `blueprints.zip` in the game folder. `AssetId` in a `.jbp` file is the same id as `Blueprint` in the save.

## Buff It

Live file:

```
Mods\BuffIt2TheLimit\UserSettings\bi2tl-8dd97a37ca674651afefb4dd19e06967.json
```

`buffit-current-config.json` in this folder is a copy. The left-hand list in the spellbook screen is every buff the party can see. On 2026-09-29 that scan was 171 entries. Only rows whose `InGroups` contains `Long` are on the left button.

| Button | `InGroups` value |
|---|---|
| Normal, the left button | `Long` |
| Quick | `Quick` |
| Important | `Important` |

The left button is the 40 spells that remain after the coverage rules below. Quick and Important are empty. The spellbook screen can list well over 100 entries. That list is every buff, ability, and toggle the UI can see. It is not the button.

A lower spell is left off when a higher spell on the button already gives the same bonus. Other spells are left off when they do not help this party.

| Left off | Why |
|---|---|
| Bear's Endurance, Bull's Strength, Cat's Grace, Eagle's Splendor, Owl's Wisdom, and the Mass versions | Enhancement bonuses. Belts and headbands on this party are already +6 or +8. |
| Heroism, Heroism, Greater | Morale bonuses. Heroic Invocation already gives the higher morale bonus. |
| Bless | Morale +1. Covered by Heroic Invocation. Prayer stays, because Prayer is a luck bonus. |
| Invisibility, Invisibility, Mass | Break on attack. Greater Invisibility stays. |
| Blur, Blink, Shield, Shield of Dawn | Miss chance or a shield bonus. Displacement and Vampiric Shadow Shield are the higher versions. |
| Enlarge Person | Covered by Enlarge Person, Mass. |
| Longstrider, Chameleon Stride, Angelic Aspect | Covered by the Greater versions. |
| Guidance, Resistance, Virtue, Light | Too small at this level, or not a combat buff. |
| Unbreakable Heart, Remove Fear | Fear immunity is already on Heroic Invocation. |
| Divine Favor | Luck bonus. Prayer is the party luck buff. |
| All Cure spells, Heal, Mass, Inspiring Recovery | Heals. They are not pre-fight buffs. |
| Aspect of the Bear, Aspect of the Wolf, Animal Growth, Magic Fang, Acid Maw | No animal companion in this party. Aspect of the Falcon stays for Arueshalae. |
| Shield of Faith | Deflection. Fan's ring is already deflection +6. |

Death Ward and Freedom of Movement are not in any of the six spellbooks in `Quick_4.zks`, so they cannot be added.

`Key.Guid` is the spell or ability id, with hyphens. `Wanted` is who receives it. `Casters` is who is allowed to cast it, first entry first. `UseSpells`, `UseScrolls`, `UsePotions`, and `UseEquipment` choose the source. A prepared magus spell is cast only when that spell is still in an unspent memorized slot.

Corrections after the black-dragon fight:

| Row | Change |
|---|---|
| Bless Weapon `831e9428-64e9-2484-6a30-d2e0678e438b` | Caster is Seelah only. Potions, scrolls, and equipment are off. The previous list drank the last Bless Weapon potion, then stopped. |
| Angelic Aspect, Greater `b1c7576b-d068-12b4-2bda-3f09ab202f14` | Caster and target are Seelah. The spell cannot be cast on someone else. |
| Frightful Aspect `e788b02f-8d21-0144-8806-7bdd3ba7b325` | Casters are Daeran, then Camellia. Ember had no spell slot of that level. |

Shield of Faith stays off Fan. His ring is already a +6 deflection bonus. Bull's Strength, Bear's Endurance, and Cat's Grace stay off Fan. Those scores are already +8 enhancement.

## Wrath Tactics

Live file:

```
Mods\WrathTactics\UserSettings\tactics-8dd97a37ca674651afefb4dd19e06967.json
```

`tactics-current-config.json` in this folder is a copy. The in-game panel is Ctrl+T. `CharacterRules` is keyed by unit id. Fan is `6078761c-2271-48a8-bfe2-e82f88a8f041`. Ember is `5AC2`. Camellia is `60D5`. Daeran is `5A2C`. Seelah is `615A`. Arueshalae is `6224`. `TacticsEnabled` is true for the six active party members.

`AbilityId` for a spell is 32 hex characters, no hyphens, plus `@L` and the spell level. Example: Transformation is `27203d62eb3d4184c9aced94f22e1806@L6`. A magus arcana is the ability id with no `@L`.

`HasBuff` uses the buff blueprint, not the ability id. Subject `0` is self. Property `2` is HasBuff. Operator `3` means the buff is absent. Operator `2` means equal. Subject `5`, property `14`, value `true` means a fight is running.

`TickIntervalSeconds` is 1. `CooldownRounds` is 0. Fan's rules are Transformation and Haste. Dimension Strike, Prescient Attack, Arcane Accuracy, Perfect Strike, and Attack are not in this list.

## One swift action, so one arcana

Dimension Strike, Prescient Attack, and Arcane Accuracy each last 1 round and each spend the swift action. A round can hold one of them. The buffs do not stack.

| Arcana | Pool | What it changes on a high-AC target |
|---|---:|---|
| Dimension Strike `cf7c4eaa2b47d7242b2c734df567cefb` | 2 | Every melee attack that round is a touch attack. Armor, shield, and natural armor are ignored. |
| Prescient Attack `fa12d155c229c134dbbbebf0d7b980f0` | 1 | The target loses its Dexterity bonus to AC. |
| Arcane Accuracy `1b7fb8120390ca24c9da98ce87780b7f` | 1 | Adds the Intelligence modifier as an insight bonus to attack. On Fan that is about +7. |

Dimension Strike is the one to keep on. A dragon's natural armor is much larger than its Dexterity bonus, and larger than +7 to hit.

Turn on the game's own autocast. Select Fan, find Dimension Strike on his action bar, and right-click that icon once. A copy of the icon sticks out at the left end of the bar. That is the autocast marker. The game uses the ability at the start of each round, then Fan still makes his weapon attacks, because the ability is a swift action. Right-click the same icon again to clear it. Wrath Tactics does not cast it and does not order the weapon attack.

That marker is `Brain.m_AutoUseAbility` in the save. In `Quick_4.zks` at 21:20 the field is already Dimension Strike, and `TemporarilyDisabled` is false. `Quick_3.zks` has no autocast. After loading `Quick_3`, right-click Dimension Strike once. The ability spends 2 arcane pool points. With the pool at 0 it does not fire.

## Perfect Strike stays on

Perfect Strike `5a169c57935dc3343836c027e35d65b3` is an activatable toggle, not a one-round cast. `SpendType` is `AttackHit`: while the toggle is on, a hit spends 1 arcane pool point and maximizes the weapon's base damage dice. It does not spend the swift action, so it runs alongside Dimension Strike. Leave it on. There is no tactics rule for it.

The critical-hit toggle `c6559839738a7fc479aadc263ff9ffff` is the same kind of switch. A confirmed critical spends 1 more point and raises the multiplier by 1. In the 21:20 save both toggles are already on (`m_IsOn` true).

## What the 21:20 save still needs

`Quick_4.zks`, saved 2026-09-29 21:20. Fan's `m_AiEnabled` is false. Arcane pool resource `effc3e386331f864e9e06d19dc218b37` has `Amount` 0. Dimension Strike costs 2 and Perfect Strike costs 1 per hit, so neither can spend until Fan rests.

Sword Saint prepared slots: only Shield (`ef768022b0785eb43a18969903c537c4`, level 1) still has `Available` true. Haste and Transformation are prepared and already spent. That is why tactics logged `No suitable spell slots`. Rest refills the pool and those slots.

In `Quick_4.zks` level 6 is still Transformation, True Seeing, Bull's Strength, Mass, Bear's Endurance, Mass. That file was left unchanged. The same two slots in `Quick_3.zks` now prepare Hellfire Ray and Chain Lightning.

Trickster spellbook `2ff51e0531ed8e545ab4cb35c32d40f4` is spontaneous. `m_SpontaneousSlots` is `[0, 5, 5, 0, 0, 5, 4, 3, 0, 0, 0]`. Level 3 and level 4 have no casts left today. Rest restores them.

Transformation and Haste still fire only when their buff is missing and a memorized slot is open. There is no Attack rule.

Buff ids for those two rules:

| Rule | Buff id |
|---|---|
| Transformation | `287682389d2011b41b5a65195d9cbc84` |
| Haste | `03464790f40c3c24aa684b57155f3280` |

## Ember

Ember's unit id is `5AC2`. This character does not have Evil Eye or Cackle. She has one standard action per round. The rules fire in this order, and each one stops matching once its buff is already on the target:

| Order | Hex | Target |
|---|---|---|
| 1 | Protective Luck | An ally who does not have it |
| 2 | Vulnerability Curse | The highest-AC enemy who does not have it |
| 3 | Fortune | An ally who does not have it |
| 4 | Ward | An ally who does not have it |
| 5 | Agony | The highest-AC enemy who does not have it |
| 6 | Major Healing | The lowest-HP ally, when an ally is under half |
| 7 | Healing | The same, if Major Healing did not fire |

Slumber and Restless Slumber are not in the list. A dragon is immune to sleep, the buff never sticks, and those rules would spend her standard action every round.

## Camellia

Camellia's unit id is `60D5`. She is a Spirit Hunter. Each rule fires only while its own buff is missing.

| Order | Ability | What it does |
|---|---|---|
| 1 | Battle Spirit | Toggle. Stays on and spends its resource at the start of each round. |
| 2 | Ghost Touch | Toggle. The spirit-weapon property selected on her rapier. |
| 3 | True Battle Spirit | Standard action. Lasts minutes. |
| 4 | Spirit Weapon | Swift action. Puts the selected weapon property on her weapon for minutes. |

Greater Battle Spirit is a list of variants, not one ability to leave on, so it is not in the rules. Ameliorating is a condition-removal menu. Skill checks and Fight Defensively are not in the rules.

## Daeran

Daeran's unit id is `5A2C`.

| Order | Ability | What it does |
|---|---|---|
| 1 | Halo | Aasimar toggle. Stays on while the halo buff is missing. |
| 2 | Channel | Standard action, centered on Daeran. Fires when an ally is under half health. |

Channel Harm is negative energy. It damages living allies in the burst, so it is not automatic. Glitterdust is a standard-action area spell that can blind the party, so it is not automatic. Skill checks and Fight Defensively are not in the rules.

## Seelah

Seelah's unit id is `615A`. Weapon Bond properties share one slot, so only one can stay on. The selected property is Brilliant Energy, because her attacks were missing the dragon's armor class of 80 and this property makes those attacks touch attacks.

| Order | Ability | What it does |
|---|---|---|
| 1 | Brilliant Energy | Toggle. Selects the weapon-bond property. |
| 2 | Weapon Bond | Standard action. Puts that property on the weapon for minutes, when the enchantment buff is missing. |
| 3 | Smite Evil | Swift action. Targets the highest-AC evil enemy, when Seelah does not already have Smite active. |
| 4 | Aura of Justice | Swift action. Lasts minutes. Fires when that aura is missing. |
| 5 | Lay on Hands, self | Swift action. When Seelah is under half health. |
| 6 | Lay on Hands | Standard action. The lowest-HP ally, when an ally is under half. |
| 7 | Channel Energy | Standard action, centered on Seelah. Same health gate, if Lay on Hands did not fire. |

Holy, Keen, Speed, Axiomatic, Disruption, Flaming, and Flaming Burst are the other weapon-bond choices. They are not on at the same time. Vital Strike replaces a full attack with one swing, so it is not automatic. Channel Harm damages living allies, so it is not automatic.

## Arueshalae

Arueshalae's unit id is `6224`. Toggles fire only while their buff is missing. Rapid Shot, Deadly Aim, and Staggering Critical were already on in `Quick_6.zks`. Point-Blank Shot was off.

| Order | Ability | What it does |
|---|---|---|
| 1 | Point-Blank Shot | Toggle. +1 attack and damage inside 30 feet. |
| 2 | Rapid Shot | Toggle. An extra shot, with a penalty to attack. |
| 3 | Deadly Aim | Toggle. More damage, with a penalty to attack. |
| 4 | Staggering Critical | Toggle. Stays on for critical hits. |
| 5 | Hunter's Bond | Move action. Shares favored enemy while that buff is missing. |
| 6 | Quarry | Standard action. Marks the highest-AC enemy who is not already her quarry. |
| 7 | Master Spy | Standard action. Lasts hours. Fires when that buff is missing. |

Deadly Aim and Rapid Shot both lower her attack bonus. Against armor class 80 that is why shots miss. Vampiric Touch would pull her into melee, so it is not automatic. Fight Defensively is not in the rules.
