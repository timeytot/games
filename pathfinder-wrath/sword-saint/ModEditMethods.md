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

`TickIntervalSeconds` is 1. `CooldownRounds` is 0. Fan's rules are Transformation, Haste, and Attack. The three one-round magus arcanas are not in this list.

## One swift action, so one arcana

Dimension Strike, Prescient Attack, and Arcane Accuracy each last 1 round and each spend the swift action. A round can hold one of them. The buffs do not stack.

| Arcana | Pool | What it changes on a high-AC target |
|---|---:|---|
| Dimension Strike `cf7c4eaa2b47d7242b2c734df567cefb` | 2 | Every melee attack that round is a touch attack. Armor, shield, and natural armor are ignored. |
| Prescient Attack `fa12d155c229c134dbbbebf0d7b980f0` | 1 | The target loses its Dexterity bonus to AC. |
| Arcane Accuracy `1b7fb8120390ca24c9da98ce87780b7f` | 1 | Adds the Intelligence modifier as an insight bonus to attack. On Fan that is about +7. |

Dimension Strike is the one to keep on. A dragon's natural armor is much larger than its Dexterity bonus, and larger than +7 to hit. Right-click the ability. The game puts its icon at the lower left of the action bar and uses it each round. That is `Brain.m_AutoUseAbility` in the save. In `Quick_4.zks` at 21:20 that field is already Dimension Strike, and `TemporarilyDisabled` is false.

Wrath Tactics does not cast it. A tactics swift fires while the weapon swing owns the Standard slot, the log says `unit busy`, and the ability misses its window. The game's own autocast runs at the start of the round, before that swing.

## Perfect Strike stays on

Perfect Strike `5a169c57935dc3343836c027e35d65b3` is an activatable toggle, not a one-round cast. `SpendType` is `AttackHit`: while the toggle is on, a hit spends 1 arcane pool point and maximizes the weapon's base damage dice. It does not spend the swift action, so it runs alongside Dimension Strike. Leave it on. There is no tactics rule for it.

The critical-hit toggle `c6559839738a7fc479aadc263ff9ffff` is the same kind of switch. A confirmed critical spends 1 more point and raises the multiplier by 1. In the 21:20 save both toggles are already on (`m_IsOn` true).

## What the 21:20 save still needs

`Quick_4.zks`, saved 2026-09-29 21:20. Fan's `m_AiEnabled` is false. Arcane pool resource `effc3e386331f864e9e06d19dc218b37` has `Amount` 0. Dimension Strike costs 2 and Perfect Strike costs 1 per hit, so neither can spend until Fan rests.

Sword Saint prepared slots: only Shield (`ef768022b0785eb43a18969903c537c4`, level 1) still has `Available` true. Haste and Transformation are prepared and already spent. That is why tactics logged `No suitable spell slots`. Rest refills the pool and those slots.

Level 6 is prepared as Transformation, True Seeing, Bull's Strength, Mass, Bear's Endurance, Mass. The Mass enhancement spells do not raise Fan's Strength or Constitution. Hellfire Ray and Chain Lightning are not in those slots.

Trickster spellbook `2ff51e0531ed8e545ab4cb35c32d40f4` is spontaneous. `m_SpontaneousSlots` is `[0, 5, 5, 0, 0, 5, 4, 3, 0, 0, 0]`. Level 3 and level 4 have no casts left today. Rest restores them.

The Attack rule stays. `Action.Type` is 4, `Target.Type` is 3, the nearest enemy. With Fan's AI off, that rule is what orders the swing. Transformation and Haste still fire only when their buff is missing and a memorized slot is open.

Buff ids for those two rules:

| Rule | Buff id |
|---|---|
| Transformation | `287682389d2011b41b5a65195d9cbc84` |
| Haste | `03464790f40c3c24aa684b57155f3280` |
