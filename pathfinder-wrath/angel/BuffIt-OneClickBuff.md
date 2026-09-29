# Hansen Angel One-Click Buffs

Spell guids, scroll and potion entries, and the save header are in [Reproduction.md](./Reproduction.md). There is no Wrath Tactics file for this save. Do not edit `buffit-current-config.json` until a later request says to change Buff It.

Buff It 2 The Limit configuration for Hansen's Inevitable Excess save. FaN's lich configuration is in `../lich/`. Each save has its own GameId, and the game loads the matching file.

Written on 2026-09-29. The game was closed.

## Live file

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Mods\BuffIt2TheLimit\UserSettings\bi2tl-fea04e92a6f54507a84b86b8444eec8f.json
```

- Mod: Buff It 2 The Limit 1.21.1
- GameId: `fea04e92a6f54507a84b86b8444eec8f`
- Save: Hansen, Inevitable Excess, Threshold, 5 Abadius (I) 4717
- Save file: `Manual_8_Threshold__5_Abadius__I__4717__15_49_23.zks`
- `.bak-20260929-angel` in that folder is the previous 134-entry list, which had every row in Normal

`buffit-current-config.json` in this folder is a copy. The game does not read the repository or the zip.

## The three buttons

Hansen's Oracle spellbook does not have Enduring Spells or Greater Enduring Spells. Round-per-level spells stay out of Normal.

| Button | JSON | Rows | When to press it |
|---|---|---|---|
| Normal | `Long` | 56 | After entering a new area, or after resting. These last minutes or hours |
| Quick | `Quick` | 9 | Before each fight. These last rounds |
| Important | `Important` | 4 | Hard fights. Fortress of the Faithful, Sun Form, Avenger's Blessing, and Holy Aura stay off ordinary encounters |

The three buttons do not include each other. Normal does not cast the Quick or Important rows.

## Party

Six characters plus Arueshalae's wolf. The ids match `UniqueId` in the save's `party.json`.

| Character | Unit id | Classes | Spellbook |
|---|---|---|---|
| Hansen | `360c7122-3094-4ab4-9706-04ae85f7715a` | Oracle 20, Angel mythic 10. Spontaneous. Angel spells are merged into the Oracle book | Oracle `6c033647-12b4-1594-1a98-f74522a81273` |
| Lann | `e437d264-30d0-4f82-b498-10d5779735e1` | Monk 20 | No spellbook. Receives buffs only |
| Nenio | `a362b4fa-464a-43df-99cf-48216117e70b` | Wizard 20. Prepared | Wizard `5a38c9ac-8607-8904-09fc-b8f6342da6f4` |
| Sosiel | `3e1e0b22-78e6-475f-b09c-e4beac1bbca1` | Cleric 20. Prepared | Cleric `4673d19a-0cf2-fab4-f885-cc4d1353da33` |
| Arueshalae | `166F1D` | Ranger 20, Master Spy. Prepared | Master Spy `12bfcf91-d541-6b04-7a2a-9110ff8968c5` |
| Galfrey | `5A6856` | Paladin 20. Prepared | Paladin `bce4989b-070c-e924-b986-bf346f59e885` |
| Wolf | `47CDA1` | Animal companion 20 | No spellbook. Receives buffs only |

Hansen is spontaneous, so he casts the Angel spells and most divine buffs without a prepared list. Later names on the same row are backups.

Personal spells stay on the caster. Examples: Nenio's Foresight, Galfrey's Angelic Aspect, Greater, and Sosiel's Divine Power. One click does not polymorph Hansen, and it does not put Greater Magic Weapon on the wolf's natural attacks.

## Normal

| Spell | Targets | Casters, in order |
|---|---|---|
| Guidance | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Sosiel, Hansen |
| Resistance | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Nenio, Sosiel, Hansen |
| Virtue | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Sosiel, Galfrey, Hansen |
| Shield of Faith | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Remove Fear | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Effortless Armor | Hansen, Sosiel, Arueshalae, Galfrey | Hansen, Sosiel, Galfrey, Arueshalae |
| Barkskin | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Arueshalae, Hansen |
| Protection from Evil, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Protection from Chaos, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Delay Poison, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel, Galfrey, Arueshalae |
| Archon's Aura | Hansen, Sosiel, Galfrey | Hansen, Sosiel, Galfrey |
| Shield from Demonkind | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Protection from Acid, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Protection from Cold, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Protection from Electricity, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Protection from Fire, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Protection from Sonic, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Magic Vestment, Armor | Hansen, Sosiel, Arueshalae, Galfrey | Hansen, Sosiel |
| Magic Vestment, Shield | Sosiel, Galfrey | Hansen, Sosiel |
| Crusader's Edge | Hansen, Lann, Sosiel, Arueshalae, Galfrey | Hansen, Sosiel, Galfrey |
| Death Ward | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Freedom of Movement | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Arueshalae, Sosiel |
| Greater Magic Weapon, primary | Hansen, Lann, Sosiel, Arueshalae, Galfrey | Hansen, Sosiel, Galfrey, Nenio |
| Spell Resistance | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Life Bubble | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Arueshalae, Sosiel |
| Aegis of the Faithful | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Eagle's Splendor, Mass | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Sosiel, Hansen |
| Bear's Endurance, Mass | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Sosiel, Hansen |
| Bull's Strength, Mass | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Sosiel, Hansen |
| Owl's Wisdom, Mass | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Sosiel, Hansen |
| Cat's Grace, Mass | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Nenio |
| Sun Marked | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Ward against Weakness, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Ward against Harm, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Ward against Disease, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Ward against Impurity, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Pure Form | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Blade of the Sun | Hansen, Lann, Sosiel, Arueshalae, Galfrey | Hansen |
| True Seeing, Communal | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Nenio, Sosiel, Hansen |
| Heroic Invocation | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Nenio |
| Foresight | Nenio | Nenio |
| Seamantle | Nenio | Nenio |
| Mirror Image | Nenio | Nenio |
| Mage Armor | Lann, Nenio, Wolf | Nenio |
| Stoneskin | Lann, Arueshalae, Galfrey, Wolf | Nenio |
| Longstrider, Greater | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Arueshalae |
| Hurricane Bow | Lann, Arueshalae | Arueshalae |
| Aspect of the Falcon | Arueshalae | Arueshalae |
| Animal Growth | Wolf | Arueshalae |
| Magic Fang, Greater | Wolf | Arueshalae |
| Angelic Aspect, Greater | Galfrey | Galfrey |
| Veil of Heaven | Galfrey | Galfrey |
| Veil of Positive Energy | Galfrey | Galfrey |
| Bless Weapon | Galfrey | Galfrey |
| Aura of Greater Courage | Galfrey | Galfrey |
| Bestow Grace | Hansen | Galfrey |

## Quick

| Spell | Targets | Casters, in order |
|---|---|---|
| Haste | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Nenio |
| Prayer | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Sosiel, Galfrey, Hansen |
| Divine Power | Sosiel | Sosiel |
| Righteous Might | Sosiel | Sosiel |
| Eaglesoul | Sosiel, Galfrey | Galfrey, Sosiel |
| Holy Hymn | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Circle of Clarity | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen, Sosiel |
| Displacement | Nenio | Nenio |
| Bestow Grace of the Champion | Hansen, Galfrey | Galfrey |

## Important

| Spell | Targets | Casters, in order |
|---|---|---|
| Fortress of the Faithful | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Sun Form | Hansen | Hansen |
| Avenger's Blessing | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Hansen |
| Holy Aura | Hansen, Lann, Nenio, Sosiel, Arueshalae, Galfrey, Wolf | Sosiel, Hansen |

## Spells that must be prepared

Hansen does not prepare spells. The characters below are prepared casters. A row does not fire if that spell is not prepared. Divine spells that list Hansen as a backup can stay unprepared on the other caster.

Nenio prepares: Heroic Invocation, Haste, Cat's Grace, Mass, True Seeing, Communal, Stoneskin, Foresight, Seamantle, Mirror Image, Displacement, Mage Armor.

Arueshalae prepares: Longstrider, Greater, Hurricane Bow, Aspect of the Falcon, Animal Growth, Magic Fang, Greater. If Barkskin is not prepared, Hansen casts it. Hansen casts Freedom of Movement first.

Galfrey prepares: Bestow Grace, Bestow Grace of the Champion, Bless Weapon, Veil of Heaven, Veil of Positive Energy, Aura of Greater Courage, Angelic Aspect, Greater, Eaglesoul.

Sosiel prepares: Divine Power, Righteous Might, Eaglesoul. If the mass ability scores, Death Ward, Holy Aura, or Prayer are not prepared, Hansen casts them.

## Removed from the old list

The previous file had 134 rows, all in Normal. These were not kept:

- Evil and chaos auras: Unholy Aura, Cloak of Chaos. This is an Angel party.
- Forms: all four Geniekind elements, Shapechange forms, Ice Body, Fiery Body, Frightful Aspect, Transformation, Winds of Vengeance, and every polymorph except Sun Form. Sun Form stays in Important, and only on Hansen, for a hard fight.
- Spells that are not buffs: Cave Fangs, Army of Heaven, Phoenix Gift, Jolting Portent, True Strike.
- Mythic abilities and toggles: the Trickster first ascension ability, Angel Minor, and the Madness domain greater ability.
- Weak or conflicting spells: Protection from Good, Protection from Law, Align Weapon for chaos or evil, the single-target wards that already have communal versions, and Bless and Aid, which share a morale bonus with Heroic Invocation.
- Greater Invisibility cast on the whole party, and Greater Magic Weapon on the off hand.

Energy protection uses the communal absorption spells. The communal resistance spells are not also queued. Shield of Law is omitted because Nenio is chaotic.
