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

On 2026-09-29 the edited save was `Quick_4.zks`. Backup: `Quick_4.zks.bak-20260929-spells` in the same Saved Games folder. Level 6 already had Transformation (`$id` 1940) and True Seeing (`$id` 1941). The two enhancement spells were replaced:

| Slot ref before | Spell | Slot ref after | Spell |
|---|---|---|---|
| 1943 | Bull's Strength, Mass | 1949 | Hellfire Ray |
| 1947 | Bear's Endurance, Mass | 1942 | Chain Lightning |

Mirror Image, Haste, Stoneskin, Enlarge Person, Mass, and Vampiric Shadow Shield were already prepared on their own levels. Load `Quick_4`, then rest, then press Normal.

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

`tactics-current-config.json` in this folder is a copy. The in-game panel is Ctrl+T. `CharacterRules` is keyed by unit id. Only Fan has rules. `TacticsEnabled` is true for the six active party members.

`AbilityId` for a spell is 32 hex characters, no hyphens, plus `@L` and the spell level. Example: Transformation is `27203d62eb3d4184c9aced94f22e1806@L6`. A magus arcana is the ability id with no `@L`.

`HasBuff` uses the buff blueprint, not the ability id. Subject `0` is self. Property `2` is HasBuff. Operator `3` means the buff is absent. Operator `2` means equal. Subject `5`, property `14`, value `true` means a fight is running.

`TickIntervalSeconds` is 1. Every second, each rule checks whether its buff is already on Fan. `CooldownRounds` is 0. There is no 18-second lock and no 6-second poll. A 6-second poll can miss the first round of a short fight. One second is the check. If the buff is missing, the rule may fire.

Fan has one swift action per round. Against a high armor class, ignoring armor, shield, and natural armor matters more than ignoring Dexterity. The swift abilities are therefore in this order:

| Order | Rule | Why this slot |
|---|---|---|
| 1 | Dimension Strike | Attacks target touch AC. This is the first check. |
| 2 | Prescient Attack | The target loses its Dexterity bonus to AC. Used when Dimension Strike is already on Fan. |
| 3 | Arcane Accuracy | Adds the Intelligence modifier as an insight bonus to attack. Used when the two above are already on Fan. |
| 4 | Perfect Strike | Maximizes the weapon damage dice of one attack. Used when the attack is already landing. It does not help a miss. |

If several of those buffs are missing at the same check, only the first missing one spends the swift action. The game then keeps that swift action spent for about 6 seconds. The next rule waits out that window. Transformation and Haste are checked every second, and only when their own buffs are missing. They still need an open memorized slot. The 2026-09-29 logs said `No suitable spell slots` for both on every tick.

Buff ids the rules look for:

| Rule | Buff id |
|---|---|
| Transformation | `287682389d2011b41b5a65195d9cbc84` |
| Haste | `03464790f40c3c24aa684b57155f3280` |
| Dimension Strike | `c25e4bf29c7baa24aa1d6f630a6c1fc3` |
| Prescient Attack | `2544b9d16793e2642a645c8e3aece7d3` |
| Arcane Accuracy | `dd2d0de63be31854794c006dc1077294` |
| Perfect Strike | `e194d672b44eabd418e80f4bd2308a5b` |

The last rule is `Attack`. `Action.Type` is 4. `Target.Type` is 3, the nearest enemy. `CooldownRounds` is 0. It swings after the swift rules.

## Why a swift rule logs unit busy

Wrath Tactics will not start a swift animation while a weapon attack already owns the Standard slot. Two animated commands on one unit cancel each other. The log line is `unit busy — foreign attack running in Standard`. `foreign` means the party AI issued the swing. `still approaching its target` means that attack order is still walking Fan into range. The mod waits there too, because issuing the swift would cancel the walk.

The only gap the mod accepts is a pending attack whose Standard cooldown still has more than 2.5 seconds left. A Sword Saint full attack fills almost the whole round, so a 1-second check does not see that gap. `CooldownRounds` 0 removes the old 18-second lock. The auto-attack still occupies the Standard slot, so the swift rules still wait. The 20:51 log (`wrath-tactics-2026-09-29-204902.log`) was already on a 1-second check and 0 cooldown. None of the four swift rules executed. Every tick was `unit busy`.

The mod asks for another check the moment one of its own commands ends. A party-AI attack ending leaves the next look to the 1-second poll, which lands while the next swing is already running.

## What the 20:11 log recorded

File: `Mods\WrathTactics\Logs\wrath-tactics-2026-09-29-201020.log`. Those rules still had `CooldownRounds` 3, which is 18 seconds.

| Time | What the mod recorded |
|---|---|
| 20:12:38 | Prescient Attack started, acted, and ended Success. The rule then stayed on cooldown for 18 seconds. |
| 20:12:45 | Dimension Strike started, acted, and ended Success, then the same 18-second lock. |
| 20:12:50 | Arcane Accuracy was placed in the Swift slot and never started. |
| 20:13:10 | The game changed Fan's life state (`canAct=false`) and deleted that unstarted command. The combat log is right to omit Arcane Accuracy. |
| after that | Almost every tick was `foreign attack running in Standard`. |

Perfect Strike never logged `EXECUTED`. Each check was `MATCH but action not executable`, with no engine reason on the line before it. The four maximized damage dice in the combat log came from the party AI.

## How the swift rules get to fire

Turn Fan's AI off. Select Fan and click the AI button, the brain icon, on his action bar. The party brain then stops filling the Standard slot with a weapon swing.

With that AI off, the swift rules fire in the order above, one per round. When a swift command ends, the mod checks again at once and the Attack rule swings at the nearest enemy. When that attack ends, it checks again, casts the next missing swift, then attacks.

With Fan's AI still on, the Attack rule waits behind the party AI's swing. The log stays `unit busy`.
