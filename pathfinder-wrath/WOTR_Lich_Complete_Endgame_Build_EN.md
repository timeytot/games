# WotR Natural Lich Build: Exploiter Wizard 20 / Lich MR10

This document gives one natural level-1-to-20 progression for an Exploiter Wizard 20 / Lich MR10. It does not assume a later respec, Hilor retraining, or a prerequisite bypass. The same prepared endgame spellbook can handle Boss and solo-PvP encounters; adjust daily preparation only when the encounter is known.

The point is not to treat Lich as a one-cast Absolute Death machine. The system is:

1. Establish CL30, DC, Spell Penetration, Mind Blank, Foresight, mirror image/displacement, and temporary hit points before combat;
2. Use Corrupt Magic during combat to dismantle buffs;
3. Open the limited Deadly Magic window to ignore SR; test any Spell Immunity interaction in the current tooltip/log, because external scripts and special immunities are not guaranteed to be bypassed;
4. Finish a long fight with SR-free Lich spells, control, summons, and negative-energy sustain;
5. If a line fails, retain summons, area control, Negative Eruption, Siphon Life, and ordinary Wizard spells as backup options.

## Rules scope

- Vanilla WotR, no mods.
- Character level 20, MR10, with Lich selected and the Arcane/Lich spellbooks merged.
- If the same save has completed Inevitable Excess, Inevitable Fate is available as a once-per-day self-buff lasting about 10 minutes. Current Mythic Paths data lists MR10 as **+5 DC and +5 to rolls to overcome SR**; if the current tooltip differs, use the value shown by the game.
- Pre-buffs, long-duration spells, Trick Fate, summons, equipment swaps, Greater Quicken Rod, Grandmaster's Rod, and endgame consumables are allowed.
- This document uses one natural level-by-level progression. It does not assume a later respec, Hilor retraining, or a prerequisite bypass.
- AI exploits, terrain exploits, combat resets, bugs, and infinite resource loops are prohibited.
- Pre-combat summons may use normal spell slots and finite resources; do not treat infinitely duplicated Skeletons, infinite Swarm duplication, or scripted resurrection as the result of a single fight.
- The primary version is the Boss version; PvP uses substitutions in spell preparation and a few equipment slots.

---

# 1. Complete character-creation choices

## Race

**Dhampir**

### Heritage / subrace

**Vetala-Born (Ajibachana)**

Effects:

- +2 Dexterity
- +2 Intelligence
- -2 Wisdom
- Bonuses to Stealth and Use Magic Device
- Negative Energy Affinity
- Advantages related to resistance/immunity to Energy Drain
- Note: some versions apply -1 caster level in consecrated/hallowed/holy areas; against extremely high-SR bosses, Basic Elf is a possible alternative

Why choose it:

- Wizard needs Intelligence;
- Dexterity improves AC, Reflex, and initiative;
- -2 Wisdom has little impact on a pure Arcane Wizard;
- Negative Energy Affinity matches Lich's late-game negative-energy system;
- Because this build does not use Cruoromancer, it has no class restriction beyond the normal Dhampir limitations.

If you value positive-energy healing convenience from the prologue through Chapter 5 more highly, use **Kindred-Raised Half-Elf** instead: choose +2 Intelligence and receive an additional +2 Charisma. Half-Elf is more comfortable in the early game, but its endgame spell penetration and Dhampir negative-energy synergy are slightly lower than Vetala-Born.

## Background

**Pickpocket**

- +2 Initiative
- Provides Trickery/Stealth-related skills
- Has practical value for both bosses and PvP

If you do not want to play a thief, use **Scholar — Arcane** instead:

- Knowledge (Arcana)
- Use Magic Device
- Convenience related to Scribe Scroll

However, this build is already a Wizard, so Pickpocket's initiative is usually more valuable.

## Alignment

**Neutral Evil or Lawful Evil**

Neutral Evil is recommended:

- It fits Lich's evil requirement;
- It does not force specific Lawful-only play patterns;
- It has no negative impact on Wizard spells or Exploiter abilities.

If you already became Lawful Evil during the main campaign, you do not need to rebuild.

## Deity

**Urgathoa**

Deity does not directly increase Exploiter Wizard spell DC or the merged spellbook. Choose Urgathoa because:

- The alignment and Lich theme match;
- Negative energy, death, and undead themes fit the character background;
- There is no need to change the build for a Wizard-domain benefit that does not actually exist.

If you prefer the character background, choose Nethys; the mechanical ranking is essentially unchanged.

## Class

**Exploiter Wizard 20**

Do not add Crossblooded Sorcerer, Loremaster, Eldritch Knight, or Cruoromancer. The unified version uses pure Wizard 20 because it:

- Preserves full Wizard spell progression;
- Reaches CL30 after merging with Lich;
- Gives the complete 9th-level Wizard list and 10th-level Lich spells;
- Gives Exploiter Potent Magic, Dimensional Slide, and defensive Exploits such as Spell Resistance/Greater Spell Resistance;
- Makes prepared casting more suitable than Sorcerer's known-spell model for unknown bosses and unknown PvP opponents;
- Does not lose a caster level;
- Does not depend on an Arcane School, so Exploiter is not incorrectly treated as Necromancy specialization.

### Exploiter limitations

Exploiter Wizard:

- Cannot select an Arcane School;
- Does not gain an Arcane Bond;
- Gains Exploiter Exploit slots at levels 1, 5, 9, 13, and 17;
- Level 13 provides both a normal Exploit slot and a Greater Exploit slot. The normal slot must satisfy prerequisites before the Greater slot refreshes;
- Has an Arcane Reservoir;
- Can spend Reservoir charges while casting to increase the next spell's caster level or DC;
- Potent Magic increases that adjustment to +2.

This trades away Arcane School/Arcane Bond for Reservoir amplification, teleportation, and defensive tools. For a solo character that must handle four bosses, unknown PvP builds, and Inevitable Excess, this is more complete than a fixed Necromancy specialization.

---

# 2. Ability scores and skills

## 25-point buy

Use the following starting values:

| Ability | Base value | After Dhampir modifier |
|---|---:|---:|
| STR | 7 | 7 |
| DEX | 14 | 16 |
| CON | 14 | 14 |
| INT | 17 | 19 |
| WIS | 11 | 9 |
| CHA | 14 | 14 |

Put every normal level-up point into **INT**:

- Lv4: INT +1
- Lv8: INT +1
- Lv12: INT +1
- Lv16: INT +1
- Lv20: INT +1

Endgame values before equipment:

- STR 7
- DEX 16
- CON 14
- INT 24
- WIS 9
- CHA 14

After entering the full Lich form, apply the current version's undead-stat handling; CHA becomes more important for life and defense. Endgame equipment with +8 Mental Perfection also fills out CHA. If you choose Kindred-Raised Half-Elf, late-game CHA will be higher.

Do not put ability points into STR for early melee. This build gets its main damage, control, dispelling, and survivability from spells.

## Skills

Priority at every level:

1. Knowledge (Arcana)
2. Knowledge (World)
3. Use Magic Device
4. Perception
5. Persuasion
6. Lore (Religion)
7. Lore (Nature)

Skill purposes:

- **Knowledge (Arcana):** spells, equipment, magic checks, and endgame knowledge checks.
- **Knowledge (World):** important endgame knowledge abilities and some additional checks.
- **Use Magic Device:** scrolls, wands, and supplementary Cleric/Oracle spells.
- **Perception:** hidden objects, traps, concealed equipment, and initiative information.
- **Persuasion:** dialogue, intimidation, and parts of the Lich/fear package.
- **Lore (Religion):** undead, deities, and endgame-area checks.
- **Lore (Nature):** additional endgame knowledge and some scroll requirements.

If you use Scholar — Arcane, early pressure on UMD and Arcana is reduced; if you use Pickpocket, invest manually in the order above.

---

# 3. Complete ordinary feat order

Exploiter Wizard gains Wizard bonus feats at levels 1, 5, 10, 15, and 20. Scribe Scroll is a Wizard base feature; do not spend a key endgame choice on it.

| Character level | Ordinary feat | Wizard bonus feat |
|---:|---|---|
| 1 | Spell Focus: Conjuration | Spell Focus: Necromancy |
| 3 | Improved Initiative | — |
| 5 | Selective Spell | Greater Spell Focus: Necromancy |
| 7 | Spell Penetration | — |
| 9 | Greater Spell Penetration | — |
| 10 | — | Heighten Spell |
| 11 | Persistent Spell | — |
| 13 | Quicken Spell | — |
| 15 | Bolster Spell | Extend Spell |
| 17 | Spell Specialization — **Domain of the Hungry Flesh** | — |
| 19 | Greater Spell Focus: Conjuration | — |
| 20 | — | Spell Specialization — **Feast of Blood** |

## Why take both Conjuration and Necromancy

- Conjuration provides reliable early and endgame control through Grease, Web, Create Pit, Sirocco, Chains of Light, and similar spells;
- Necromancy provides Lich's Exsanguinate, Feast of Blood, Negative Eruption, Embrace of Death, and Absolute Death;
- The extreme defenses of ND/ID require control, SR-free damage, dispelling, and death-magic routes at the same time; do not bet on one school;
- This does not depend on Expanded Arsenal cross-school stacking bugs or disputed version behavior.

## Spell Specialization

The current merged-book UI shown in your screenshots accepts Lich spells. Keep the two selections you made:

- **Spell Specialization: Domain of the Hungry Flesh** (ordinary feat at character level 17);
- **Spell Specialization: Feast of Blood** (Wizard bonus feat at level 20).

The two slots are mechanically interchangeable; this order matches the level-20 UI in your screenshot.

Spell Specialization adds caster level to the selected spell; it does **not** add spell DC. Feast of Blood is the best general single-target/area damage-and-temporary-hit-point choice in this build, while Domain of the Hungry Flesh supplies SR-free control and ability damage. If a different game version refuses a Lich spell in this menu, use **Enervation** or another Wizard spell that the current UI accepts as the fallback target, then keep the Lich spells themselves in the merged spellbook.

## Feat substitutions

If your playstyle is more PvP-oriented:

- Keep Improved Initiative at level 3 so Mythic Improved Initiative is legal when its natural mythic rank arrives;
- If you specifically want melee concealment rerolls, Blind Fight can replace the level-19 Spell Specialization, but it is not a good default for this pure caster because its reroll is for melee attacks;
- If you already own many Metamagic Rods, the level-15 Extend Spell slot can be replaced with Empower Spell;
- If you do not want to use an Extend Rod, keep Extend Spell;
- For Nahyndrian Darkness concealment, use True Seeing, Echolocation, Circle of Clarity, or Umbral Strike; Clashing Rocks does not remove concealment, but its own ranged-touch attack ignores concealment. Blind Fight does not solve ranged spell concealment.

---
# 4. Exploiter Exploit order

| Exploiter level | Recommended Exploit | Purpose |
|---:|---|---|
| 1 | Potent Magic | Spend Arcane Reservoir to give a key spell +2 DC or +2 CL |
| 5 | Dimensional Slide | Short-range teleport as a move action; escape melee, grabs, terrain, and lockdown |
| 9 | Spell Resistance | Take this early so the level-13 Greater Exploit prerequisite is already satisfied |
| 13 (normal slot) | Arcane Barrier | The ordinary defensive Exploit; Shadow Veil is an alternative |
| 13 (Greater slot) | Greater Spell Resistance | Available because Spell Resistance was already active before level 13 |
| 17 | Wooden Flesh | The most reliable long-fight defense: natural AC and slashing DR; Shadow Veil is the PvP/anti-hit alternative |

The natural level-up route is **Spell Resistance at level 9 → Arcane Barrier (normal slot) + Greater Spell Resistance (Greater slot) at level 13 → Shadow Veil or Wooden Flesh at level 17**. Pick Spell Resistance before level 13 so the greater exploit is available when the greater slot appears; this document does not assume a later respec.

Wooden Flesh's natural-armor bonus does not stack with the larger natural-armor bonus from Frightful Aspect; its slashing DR is still useful. Shadow Veil is preferable only when the enemy lacks True Seeing and its short duration can be maintained.

Do not spend this short Exploit progression on the Hellfire Ray exploit for the main build. The exploit requires **Flame Arc** first, while the Wizard spellbook already provides the normal Hellfire Ray spell at Wizard level 6; Flame Arc → Hellfire Ray costs two exploit choices and is still an attack-roll/SR route. It is an optional theme variant, not the reliable Inevitable Darkness package.

## Arcane Reservoir priority

1. Absolute Death
2. Corrupt Magic dispel/CL checks
3. Negative Eruption
4. Greater Dispel Magic
5. Feast of Blood
6. Critical control spells

Potent Magic can raise DC or CL while casting. For Absolute Death, normally prioritize DC; for Dispel/Spell Penetration-related spells, prioritize CL.

---

# 5. Lich mythic progression

## Important: the correct source of Deadly Magic

After obtaining the Zacharius-related **Phylactery** at the end of the game, you can normally obtain:

- Deadly Magic (provided by the Phylactery as its base ability);
- If you already selected Lich Deadly Magic, the Phylactery grants an additional +2 uses;
- Low-health/death-related story or item effects.

For the Boss 9.6 version, MR3 defaults to Indestructible Bones. The Solo PvP 9.4 variant changes MR3 to Deadly Magic, using the Phylactery's extra +2 rounds.

If you did not obtain a valid Phylactery, Deadly Magic remains a valid MR3 choice, but you do not get the Phylactery's extra +2 uses.

Deadly Magic is not an Enduring Spell and cannot be kept active as a permanent pre-buff. It is a limited combat ability:

- A limited number of uses per day;
- Lasts approximately 3 rounds;
- Spells cast during the window ignore SR. Spell Immunity bypass is tooltip/patch-dependent and must be tested in the current save; it does not guarantee bypassing external scripts or every effect immunity;
- Affected targets may be unable to cast spells for 1d3+1 rounds;
- It does not guarantee bypassing external crystals, scripted immunities, or every non-standard immunity tag.

## Lich Power choices

### MR3: Indestructible Bones (Boss default)

- Its DR and attack penalty against attackers are stable long-fight gains that are not dependent on immunity or SR;
- When Nahyndrian/Inevitable Darkness applies heavy physical pressure, it is more reliable than putting all survivability into one Deadly Magic window.

**PvP variant: Deadly Magic.** If Phylactery is equipped, actively selecting it can raise the base 3 rounds to usually 5 rounds; without Phylactery, MR3 Deadly Magic has only its base duration.

### MR6: Withering Life

Recommended long-fight Boss choice:

- Adds ability damage when spells hit living targets;
- Over a long fight it gradually reduces a living Boss's physical and mental capabilities; do not treat it as primary damage against undead, constructs, or targets immune to ability damage;
- Does not depend on one successful Save-or-Die;
- More stable against PD, ID, and Areelu, which require several rounds of handling.

PvP alternative:

- Magic Devourer: if the target fails to penetrate your SR, your next spell or kinetic blast can gain a Quickened effect;
- It depends on the opponent's SR check, so it is less stable than Withering Life against an unknown opponent.

### MR9: Eclipse Chill

Boss default:

- During its duration, spell hits call for a Fortitude save;
- Failure blinds the target and adds cold damage;
- The target is placed under greater cold/negative-energy pressure;
- Works well with Feast of Blood, Negative Eruption, and other negative-energy spells.

If you are playing PvP only and expect many enemy casters, Magic Devourer is a possible MR9 replacement.

## Other innate Lich abilities: priority

These are path progression features, not three additional Lich Power selections:

- Danse Macabre
- Negative Energy Insight
- Merged Lich/Wizard spellbook
- Skeletal Champion
- Lord Beyond the Grave
- Skeleton upgrades
- Dark Rites
- Final undead attributes and Lich defenses

## First Ascension: select Danse Macabre

At Mythic Rank 1 the path-specific **First Ascension** screen is separate from the normal Mythic Ability slot. For this Lich, choose **Danse Macabre**. It is the Lich-linked option in the menu shown in your screenshot and gives a usable negative-energy channel that scales with Mythic Rank. It does not replace the normal MR1 Mythic Ability: take **Abundant Casting** in the ordinary MR1 slot as listed below.

Do not select Close to the Abyss, Close to the Heavens, Force Reality, Instrument of Freedom, or Bit of Fun for this build. Those are different path-linked choices and do not improve the merged Lich caster package.

## Skeletal Champion and skeleton upgrades

- **MR3 Skeletal Champion:** select **Skeletal Marksman**. It is the best default for a solo back-line caster because it contributes ranged damage while staying out of melee. The screenshot selection is correct.
- **MR4 first skeleton upgrade:** select **Skeletal Fighter I**. It gives the Marksman the most reliable unconditional combat progression and a bonus combat feat.
- **MR8 second upgrade:** select **Skeletal Cleric I** for channel-negative-energy healing and broad cleric utility.
- **MR10 third upgrade:** select **Skeletal Bard I** for Dirge of Doom and performance support. Do not select Skeletal Inquisitor I in this natural solo route; its teamwork-feat requirement is party-dependent.

## Recommended mythic ability/feat package

Because the mythic UI distinguishes Mythic Abilities, Mythic Feats, and path-specific choices, the following is listed by endgame priority:

### Required priority

1. Abundant Casting
2. Improved Abundant Casting
3. Mythic Spell Penetration
4. Enduring Spells
5. Greater Enduring Spells
6. Mythic Improved Initiative
7. Improved Abundant Casting
8. Archmage Armor
9. Greater Abundant Casting
10. Last Stand or Mythic Resolve

### Recommended endgame arrangement

| Mythic stage | Default choice | Explanation |
|---|---|---|
| MR1 | Abundant Casting (Mythic Ability) | More 1st–3rd-level resources |
| MR2 | Mythic Spell Focus: Necromancy (Mythic Feat) | The ordinary Necromancy focus is already taken at level 1 |
| MR3 | Enduring Spells + Lich MR3/merged spellbook + Skeletal Marksman | Long-duration defense, merged spellbook, and the ranged skeleton |
| MR4 | Mythic Spell Penetration (Mythic Feat) | Normal Spell Penetration is already taken at level 7 |
| MR5 | Greater Enduring Spells | Normally extends spells lasting at least 1 minute/level to 24 hours |
| MR6 | Mythic Improved Initiative (Mythic Feat) + Lich MR6 | Improved Initiative is already taken at level 3; Withering Life |
| MR7 | Improved Abundant Casting (Mythic Ability) | More 4th–6th-level resources |
| MR8 | Extra Mythic Ability → Archmage Armor | Obtain armor through a legal extra-ability slot |
| MR9 | Greater Abundant Casting (Mythic Ability) + Lich MR9 | More 7th–9th-level resources; Eclipse Chill for Bosses |
| MR10 | Extra Mythic Ability → Last Stand or Mythic Resolve | Boss safety or saves/health; keep the skeleton upgrade separate from this ordinary mythic slot |

This order deliberately places Mythic Spell Penetration after ordinary Spell Penetration and Mythic Improved Initiative after ordinary Improved Initiative, so every prerequisite is present when the natural mythic rank arrives.

### Choices not recommended as dependencies

- Expanded Arsenal cross-school stacking: disputed across versions and implementations;
- Treating Sorcerous Reflex as a Trick Fate Swift action: a pure Wizard/Lich does not have the Trickster rank issue, but Sorcerous Reflex is only suitable for spells at least two levels below your highest spell level;
- Repeated Deadly Magic selections: if you already use Phylactery, extra-use and stacking behavior depends on version;
- Infinite summons, infinite clones, or combat-reset refreshes.

---

# 6. Phylactery choice

At endgame, do not destroy your relationship with Zacharius merely to save money. Preserve the legal Phylactery whenever possible.

## Recommended sacrifice order

1. **Engraved Lucky Bracers:** replace them with the wrist-slot Phylactery, avoiding the head, neck, and weapon slots if possible;
2. Purple Stone Knife;
3. Radiance;
4. Only then consider the gold option.

## Reasons

- The wrist slot is usually easier to give up than head, neck, or weapon slots;
- Keep Flawless Headband of Mental Perfection;
- Keep Heartstone, Glass Amulet, or a high-stat neck item;
- Keep Sin Mage's Staff/Quarterstaff;
- Gain Deadly Magic; the extra +2 uses apply only if you have already selected Lich Deadly Magic;
- Phylactery's story resurrection is not counted as a condition for winning a single Boss/PvP match.

If you challenge and destroy Zacharius during the quest, you may lose the normal Phylactery. Use the “no Phylactery” branch instead and select Deadly Magic directly at MR3.

---

# 7. Endgame equipment

Everything cannot be worn simultaneously. The following gives the main set and swap slots by objective.

## General Boss main set

| Slot | Main item | Purpose |
|---|---|---|
| Head | Flawless Headband of Mental Perfection +8 | INT/WIS/CHA, mind immunity, DC, and survivability |
| Eyes | Goggles of Pure Sight | Critical Dispel/Corrupt Magic checks; one-use item |
| Body | Robe of Seven Sins | +3 CL, +1 all spell DC, +5 to caster-level checks against SR |
| Wrists | Phylactery (if Engraved Lucky Bracers are sacrificed; choose it instead of Flawless Bracers +9) | Deadly Magic; if Lich Deadly Magic is already selected, +2 uses |
| Hands | Gloves of Enduring Wizard | Temporary hit points after high-level spells |
| Neck | Heartstone of Night Hag Queen | +3 all spell DC, SR38, +5 natural AC (some community databases list +7; use the current game tooltip) |
| Cloak | Flawless Cloak of Resistance +7 | Saves and protection against ability damage/level drain |
| Belt | Flawless Belt of Physical Perfection +8 | DEX and physical defense |
| Boots | Boots of Perfect Grounding | Protection from electricity, stunned, and staggered |
| Ring 1 | Ring of Triumphant Advance | Improves morale bonuses |
| Ring 2 | Magician's Ring or a high-defense ring | Control DC or defense |
| Weapon | Sin Mage's Staff | Endgame spell CL/DC |
| Weapon swap | Quarterstaff of the War Mage | SR checks and general spell DC |
| Consumable | Greater Quicken Rod | Quicken spells of 9th level and below |
| Consumable | Grandmaster's Rod | Maximized/Empowered effects and version-specific effects for key spells; verify the current tooltip and do not treat it as universal immunity penetration |

## Necromancy-specific swap

- **Soulless Command Haramaki:** +2 Necromancy DC, suitable for Feast of Blood, Negative Eruption, and Absolute Death;
- It occupies the same body slot as Robe of Seven Sins;
- Wear Robe against SR/dispel pressure;
- Swap to Soulless Command when the target has no SR or when you only want maximum Necromancy DC.

## Head-slot swap

- Flawless Headband: general Boss/PvP default;
- Horns of Naraga: Lich-only, True Seeing, acid immunity, half positive-energy damage, and a negative-energy/temporary-hit-point rider on successful attacks or spells that require an attack roll;
- Horns lose the Headband's +8 mental attributes, so a pure caster keeps the Headband by default and swaps only for temporary hit points or melee/ray accuracy.

## Matchup swaps

- **ND/high SR:** Robe of Seven Sins + Quarterstaff of the War Mage + Goggles of Pure Sight.
- **Low SR / maximum Necromancy DC:** Soulless Command + Sin Mage's Staff.
- **PvP versus a caster:** Flawless Headband, Flawless Cloak, Deadly Magic Phylactery, Ring of Triumphant Advance.
- **Long fight:** Gloves of Enduring Wizard, Siphon Life, False Grace, Bone Shield.
- **Pure temporary-hit-point/ray route:** Horns of Naraga, at the cost of the Headband's attributes.

---

# 8. Complete pre-combat buff list

Pre-buffing is allowed, so separate long-duration and short-duration effects.

## 24-hour/long-duration preparation

When the CL25+, Enduring/Greater Enduring, and Extend conditions are met, prioritize making these effects long-duration:

- Mage Armor
- Shield
- False Life/Greater False Life
- Mind Blank
- True Seeing
- Freedom of Movement
- Death Ward
- Protection from Energy
- Resist Energy
- Echolocation
- Foresight
- Greater Heroism/Heroic Invocation
- Seamantle
- Frightful Aspect
- Bone Shield
- Blessing of Unlife
- Deny Death
- Vampiric Blade (if preparing the melee/temporary-hit-point route)

## Short-duration preparation before entering a Boss fight

Within the preparation window before the Boss:

- False Grace
- Greater Invisibility
- Displacement
- Power from Death
- Siphon Life (combat opener only; it requires a valid creature target and is not a self-buff)
- Bone Shield
- Phylactery equipped
- If desired, pre-cast a finite summon with its normal duration; do not treat summons as 24-hour buffs or use infinite duplication
- Choose Headband/Staff/Robe for the target
- Trick Fate is not a spell in this Lich build; do not write Trickster's TF into the Lich setup.

## PvP defense package

Against an unknown player build, keep by default:

- Mind Blank
- True Seeing
- Foresight
- Freedom of Movement
- Death Ward
- Protection from Spells
- Greater Invisibility or Displacement
- Seamantle
- Bone Shield
- False Grace
- Deny Death

Do not abandon Mind Blank for a single assumed mind-control matchup; do not assume a targeted weapon swap based on the opponent's identity.

---

# 9. Endgame spell preparation

Wizard is a prepared caster, so the entire list does not need to be fixed permanently. The two spells chosen during a level-up are only the immediate additions. You can scribe the other Wizard spells from scrolls later, and the merged Lich spellbook supplies its own spells automatically. The lists below therefore distinguish **ordinary Wizard picks** from **automatic Lich spells**.

## 1st level

- Grease
- Snowball
- Mage Armor
- Protection from Evil
- True Strike
- Vanish
- Magic Missile
- Enlarge Person/Reduce Person
- Shield (if not obtained from equipment or another source)

## 2nd level

- Mirror Image
- Web
- Glitterdust
- Scorching Ray
- Resist Energy
- False Life
- See Invisibility
- Blur

## 3rd level

- Haste
- Dispel Magic
- Heroism
- Stinking Cloud
- Slow
- Vampiric Touch
- Protection from Energy
- Selective Grease/Web

### Automatic Lich 3rd-level spells

These are granted by the merged Lich book and do **not** consume the two ordinary Wizard choices:

- Corrupted Blood
- Mastery of Flesh
- Power from Death

## 4th level

- Greater Invisibility
- Dimension Door
- Enervation
- Stoneskin
- Communal Protection from Energy
- Phantasmal Killer
- Shadow Conjuration or another reliable control spell

### Automatic Lich 4th-level spells

- Consume Undead
- Eyes of the Bodak
- Vampiric Blade

## 5th level

- Echolocation
- Break Enchantment
- Icy Prison
- Feeblemind
- Cloudkill
- Mind Fog

### Automatic Lich 5th-level spells

- Bone Explosion
- Deny Death
- Exsanguinate
- Repurpose

**Level-up recommendation:** Echolocation + Break Enchantment. Greater Dispel Magic is not a 5th-level spell, and Overland Flight is not part of the vanilla WotR Wizard list shown by the current spellbook.

## 6th level

- Greater Dispel Magic
- True Seeing
- Hellfire Ray (the normal Wizard spell; the separate Exploiter Hellfire Ray exploit still requires Flame Arc)
- Chain Lightning
- Sirocco
- Mass Cat's Grace
- Mass Fox's Cunning
- Create Undead

**Level-up recommendation:** Greater Dispel Magic + True Seeing.

### Automatic Lich 6th-level spells

After the Lich spellbook merges, these appear on the Lich/merged tab and do not compete with the two ordinary Wizard picks:

- Bone Shield
- False Grace
- Siphon Life
- Siphon Time

Siphon Life is a ranged-touch combat spell that grants temporary hit points after it hits a valid creature; it is not a self-target buff. Use it as a combat opener or on a permitted finite summon, not as a 24-hour self-buff.

## 7th level

- Communal True Seeing
- Circle of Clarity
- Waves of Exhaustion
- Umbral Strike
- Finger of Death
- Legendary Proportions
- Power Word Blind
- Plague Storm
- Walk through Space
- Mass Invisibility
- Hold Person, Mass

**Level-up recommendation:** Communal True Seeing + Circle of Clarity. Circle of Clarity is the dedicated anti-concealment answer for Nahyndrian Darkness; if you prefer an offensive ranged touch, replace it with Umbral Strike. Keep Waves of Exhaustion as a secondary/scroll option because it is SR-dependent and less reliable against undead or construct targets. Legendary Proportions remains a strong size/physical-stat buff when you have its material component; it is not deleted from the final target table.

### Automatic Lich 7th-level spells

- Blessing of Unlife
- Feast of Blood
- Restore Undead

## 8th level

- Mind Blank
- Protection from Spells
- Frightful Aspect
- Seamantle
- Greater Angelic Aspect
- Polar Ray
- Iron Body
- Horrid Wilting
- Create Greater Undead
- Rift of Ruin
- Scintillating Pattern
- Stormbolts
- Sunburst
- Summon Monster VIII

**Level-up recommendation:** Mind Blank + Protection from Spells. Prepare Seamantle and Frightful Aspect as needed, and scribe the offensive alternatives from scrolls.

### Automatic Lich 8th-level spells

- Domain of the Hungry Flesh
- Embrace of Death

Your Domain of the Hungry Flesh Spell Specialization selection is therefore valid; it is an automatic Lich spell and a legal specialization target in the UI shown in your screenshots.

## 9th level

- Foresight
- Fiery Body
- Clashing Rocks
- Symbol of Vulnerability
- Mass Icy Prison
- Weird
- Shapechange
- Tsunami
- Meteor Swarm
- Power Word Kill
- Mass Hold Monster
- Energy Drain
- Mind Blank, Communal
- Overwhelming Presence
- Dominate Monster
- Heroic Invocation
- Shades
- Wail of the Banshee
- Summon Monster IX

**Level-up recommendation:** Foresight + Symbol of Vulnerability for the prepared Boss route. Symbol of Vulnerability has no SR/save and reduces the target's SR and saves while suppressing relevant DR/resistances. If you need a direct ranged-touch fallback instead, take Clashing Rocks; it does not remove concealment, so use Circle of Clarity/True Seeing first, but its own attack ignores concealment.

### Automatic Lich 9th-level spells

- Corrupt Magic
- Flay for Purpose
- Negative Eruption

Greater Dispel Magic belongs to level 6 and must be removed from the level-9 list. Corrupt Magic is the Lich 9th-level dispel; it is not a replacement Wizard pick.

## Lich 10th level

- Absolute Death
- Doom to Servitude
- Pit of Despair
- Death's Realm (shown in some current DLC/patch spellbooks; keep it if the unmodded UI grants it)

All Lich 10th-level spells are granted by the merged Lich book; they do not consume ordinary Wizard level-up selections.

<!-- The old mixed Wizard/Lich list is intentionally replaced above. Keep all remaining spellbook entries available through scrolls. -->
<!--
- Frightful Aspect
- Seamantle
- Mind Blank
- Protection from Spells
- Create Greater Undead
- Horrid Wilting or another high-damage alternative
-->

## Screenshot audit: final spell choices by level

The screenshots are from a valid merged-book character. The long lists in the spellbook are not limited to the two level-up picks: spells can be added later from scrolls, while the Lich entries below are granted automatically. Therefore, do **not** delete the spells already learned merely because they are not the two recommended level-up picks.

| Spell tier | Two ordinary Wizard picks to prioritize | Automatic Lich entries | Screenshot correction |
|---|---|---|---|
| 1 | **Grease + Shield**. Use Mage Armor instead of Shield only when no armor item/bonus supplies it. | None | Your Expeditious Retreat, Magic Missile, True Strike, Mage Armor, Reduce Person, Protection from Alignment, and Vanish are legal utility spells. Keep them if you use them; Grease is the missing control priority. |
| 2 | **Mirror Image + Web**; Glitterdust is the best swap when concealment or invisible targets are expected. | None | False Life, Glitterdust, Mirror Image, and Web are all valid. Add Resist Energy, Blur, and See Invisibility from scrolls when available. |
| 3 | **Haste + Dispel Magic** | Corrupted Blood, Mastery of Flesh, Power from Death | The three red/green Lich entries in your screenshot are automatic and should not be counted against Wizard picks. Heroism and Slow are legal alternatives. |
| 4 | **Greater Invisibility + Enervation**; Dimension Door is the best utility swap. | Consume Undead, Eyes of the Bodak, Vampiric Blade | Your Dimension Door, Greater Invisibility, Stoneskin, Enervation, and Vampiric Blade are valid; the three Lich entries are automatic. |
| 5 | **Echolocation + Break Enchantment**; Feeblemind or Cloudkill is the normal swap. | Bone Explosion, Deny Death, Exsanguinate, Repurpose | Your Bone Explosion, Deny Death, Exsanguinate, and Repurpose are automatic Lich spells. Greater Dispel is **6th level**, not 5th. There is no vanilla Overland Flight entry in the current Wizard list. |
| 6 | **Greater Dispel Magic + True Seeing** | Bone Shield, False Grace, Siphon Life, Siphon Time | Your six Lich/ordinary entries are legal. Hellfire Ray is a normal Wizard 6 spell; only the separate Exploiter Hellfire Ray exploit requires Flame Arc. Siphon Life is a ranged-touch combat spell, not a self-target buff. |
| 7 | **Communal True Seeing + Circle of Clarity** for Bosses; Legendary Proportions is the general-purpose physical-stat buff when its component is available. | Blessing of Unlife, Feast of Blood, Restore Undead | Waves of Exhaustion and Joyful Rapture are legal. Bone Spear is a Lich mythic-book entry in some current DLC/patch UIs; keep it if your unmodded game grants it, but do not count it as a Wizard pick. Material-dependent spells stay in the target plan; omit only the individual cast when the component is unavailable. |
| 8 | **Mind Blank + Protection from Spells**; Seamantle or Frightful Aspect is the defensive swap. | Domain of the Hungry Flesh, Embrace of Death | Your Greater Bestow Curse, Create Greater Undead, Frightful Aspect, Horrid Wilting, Prediction of Failure, and Seamantle are legal scroll/pick options. Domain of the Hungry Flesh is automatic and remains a valid Spell Specialization target. |
| 9 | **Foresight + Symbol of Vulnerability** for the prepared Boss route; Clashing Rocks is the ranged-touch fallback. | Corrupt Magic, Flay for Purpose, Negative Eruption | Your list is valid. Add **Summon Monster IX** if it is not already present. Corrupt Magic is the Lich spell, not a replacement Wizard pick. Clashing Rocks does not remove concealment; use Circle of Clarity/True Seeing first, although its own attack ignores concealment. |
| 10 | No ordinary Wizard selection; use every Lich spell shown. | Absolute Death, Doom to Servitude, Pit of Despair; Death's Realm in some current UIs | Your four displayed entries are retained when granted by the current unmodded version. Ordinary Wizard 10 does not exist; this tier comes from the merged Lich book. |

### What to change before using the final preset

1. Scribe the missing ordinary Wizard spells from scrolls before resting into the final grid: **Resist Energy, Blur, Stinking Cloud, Communal Protection from Energy, Echolocation, Icy Prison, Greater Dispel Magic, Hellfire Ray, and Circle of Clarity** (where the current unmodded UI accepts the spell).
2. Keep **Communal True Seeing, Legendary Proportions, and Stoneskin** in the target plan. They are not forbidden; if their material component is unavailable on a particular rest, simply do not add that copy to the grid.
3. Keep **Feast of Blood** and **Domain of the Hungry Flesh** as your two Spell Specialization choices.
4. Keep every automatic Lich spell. The current screenshots are not “wrong” because they show both ordinary Wizard spells and automatically granted Lich spells together.

The source spell tables list Greater Dispel Magic under Wizard 6, list Circle of Clarity and Communal True Seeing under Wizard 7, and list Summon Monster IX among Wizard 9 options. The merged Lich table lists the automatic 3rd–10th-level Lich entries separately. See [GameFAQs Wizard spells](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/wizard-spells) and [GameFAQs Lich spells](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/lich).

## Key spell notes

### Corrupt Magic

- Primarily a Boss-opening dispel;
- Removes layers such as Barkskin, Shield, Frightful Aspect, Seamantle, and Displacement;
- Every removed layer further lowers the target's attack, damage, saves, and AC;
- It does not rely on SR or a normal saving throw and is central to the Boss package.

### Absolute Death

- 10th-level Standard Action;
- SR N/A;
- Will partial;
- Failure causes death;
- Success deals high damage based on CL;
- Do not call it an automatic kill: Will saves and special Boss mechanics still matter.

### Negative Eruption

- Large-area negative-energy damage;
- Synergizes with buffs/temporary hit points for allied undead;
- A long-fight clearing and sustain tool after Deadly Magic is spent against targets that are not immune to negative energy;
- Use Selective Spell to avoid affecting legal summons/allies.

### Feast of Blood

- An SR-free route;
- Behaves like Exsanguinate and provides temporary hit points; use the current tooltip/combat log for the exact damage type;
- Important against Bosses that cannot reliably be penetrated through SR;
- A good Spell Specialization target;
- Current patches changed its target eligibility: it does not affect undead and constructs. Check the target tooltip in IE; against those targets use Corrupt/Greater Dispel, Domain if accepted, Clashing Rocks, non-negative elemental Wizard spells, or summons instead. Negative Eruption heals undead rather than damaging them.

### Siphon Life

- Ranged touch attack;
- Does not use a normal AC attack roll;
- Drains life and provides temporary hit points;
- A core recovery tool when a valid enemy or finite summon can be targeted; it cannot be cast on the Lich himself.

### Embrace of Death

- Will partial;
- Failure causes paralysis and Constitution drain;
- Very strong against targets that can be affected by mind/negative effects;
- Do not use it as the only control against every Boss.

### Domain of Hungry Flesh

- Selective control/area spell;
- Works well with summons and prepared terrain;
- Do not exploit terrain or rely on AI pathing errors.

---

# 10. Complete Exploiter Wizard combat flow

## Ordinary long fight

1. Before entering combat, maintain Mind Blank, True Seeing, Foresight, Bone Shield, and defensive layers; reserve Siphon Life for a valid combat target;
2. Use Dimensional Slide to maintain distance;
3. Start with Greater Dispel or Corrupt Magic to remove the highest-value buffs;
4. Against one target use Feast of Blood, Siphon Life, Enervation, and Embrace of Death;
5. Against groups use Selective Domain of Hungry Flesh, Negative Eruption, and normal Sirocco;
6. Use Potent Magic to raise key DC or CL;
7. Wizard is a prepared caster: before a long fight, prepare multiple scrolls/spell slots for the enemy type; do not treat Quick Study as an Exploit in the original game;
8. Maintain temporary hit points with False Grace, Feast of Blood, and Bone Shield; use Siphon Life when a valid target is available;
9. Keep summons limited and purposeful; do not spend every high-level spell slot merely to have summons.

## Against Nahyndrian Darkness

1. A pure caster normally attacks from range; if necessary, switch to a Phantasmal Guide or another Ghost Touch staff as a touch backup (low BAB, worse damage than a Gish);
2. Equip Robe of Seven Sins, Quarterstaff of the War Mage, and Goggles of Pure Sight;
3. Deal with the left and right crystals and additional waves first;
4. Use Corrupt Magic to remove ordinary buffs;
5. Open the Deadly Magic window;
6. Test Absolute Death, Negative Eruption, Feast of Blood, and Siphon Life only against targets whose current tooltip permits their damage/effect types;
7. If the crystals are treated as external scripted Spell Immunity, switch to Clashing Rocks, summons, and physical/ghost-touch backup;
8. Do not interpret “Deadly Magic ignores Spell Immunity” as a guarantee that it bypasses crystal scripts.

## Against Inevitable Darkness

1. Maintain Mind Blank, True Seeing, Bone Shield, and Deny Death in advance; use Siphon Life only after a valid target is present;
2. Corrupt Magic;
3. Deadly Magic;
4. Absolute Death or Embrace of Death only as a test after checking the current immunity tooltip;
5. If death/negative-energy effects are rejected, use Domain's no-save/no-SR ability-damage component if accepted, Clashing Rocks, fire/electricity/sonic Wizard spells during Deadly Magic, and summons;
6. If the opponent is silenced from casting, use the non-negative fallback package and summons to finish the long fight.

## Against Playful Darkness

1. High AC is not the only issue; prioritize concealment, Displacement, summons, and area effects;
2. Greater Dispel/Corrupt Magic;
3. Normal Sirocco, Negative Eruption, and Feast of Blood when the target tooltip permits their damage types; treat Selective Sirocco as version/UI-dependent and do not rely on it under a no-bug rule;
4. Use summons to absorb attacks;
5. If Swarmbane exists, it matters specifically for the Swarm build; ordinary Lich is not affected by that item's physical flag.

## Against Areelu Vorlesh

1. Mind Blank, True Seeing, Protection from Spells, and Foresight;
2. Start with Corrupt Magic;
3. When the target has special death/mind immunity, do not use only Absolute Death;
4. Use Domain of Hungry Flesh, selective control, Negative Eruption, and Siphon Life when the target tooltip permits them;
5. Keep Dimensional Slide available so being engaged in melee does not remove your casting space.

---

## 10.1 Memorized-spell loadout for the screenshot spellbook

The spell list on the right side of the spellbook is the list of spells learned. The grid at the lower left is the list of spells available after the next rest. Those are different things. The screenshots show the following actual daily-slot counts for this character:

- Levels 1–4: **11** visible daily slots each;
- Levels 5–8: **10** visible daily slots each;
- Level 9: **9** visible daily slots;
- Level 10: **3** visible daily slots;
- Automatic Lich spells are learned automatically, but they still use the same daily slots when memorized. They are not extra casts.

If a patch, item, or a different Intelligence total changes the number shown in the lower-left grid, keep the priorities and fill every extra slot with another copy of a non-component spell from that row. If a listed component is unavailable, simply leave that individual spell out for that rest.

Your screenshot shows the intended end state at **caster level 30**, with **Spell Penetration +46**, **Concentration +44**, and the merged Wizard/Lich book. Rest once after changing the grid and confirm the final count in your own UI, because Abundant Casting, Intelligence items, and patch-specific bonuses can add slots.

### Final scroll-upgraded optimal preset: one target grid

This is the single target table to use after scribing the missing spells from scrolls. It follows the slot counts visible in your screenshots: 11 slots at levels 1–4, 10 at levels 5–8, 9 at level 9, and 3 at level 10. Material-component spells are kept in the target plan; when a component is unavailable on a particular rest, omit only that copy rather than deleting the spell from the build.

| Spell level | Daily memorization after scroll upgrades | Purpose / component note |
|---:|---|---|
| 1 (11) | Grease x3; Shield x2; Mage Armor x1; Protection from Alignment x1; Vanish x1; Magic Missile x1; True Strike x1; Expeditious Retreat x1 | Core control, defense, and movement. |
| 2 (11) | Mirror Image x4; Web x2; Glitterdust x2; False Life x1; Resist Energy x1; Blur x1 | Mirror Image is the main solo defense; Web/Glitterdust cover groups and concealment. |
| 3 (11) | Haste x3; Dispel Magic x2; Slow x1; Stinking Cloud x1; Heroism x1; Corrupted Blood x1; Mastery of Flesh x1; Power from Death x1 | Haste/Dispel are the default combat pair; Stinking Cloud is the scroll-scribed control fallback. |
| 4 (11) | Greater Invisibility x3; Enervation x2; Dimension Door x1; Stoneskin x1; Communal Protection from Energy x1; Consume Undead x1; Eyes of the Bodak x1; Vampiric Blade x1 | Keep Stoneskin in the plan; if its component is unavailable, omit that copy for the rest. |
| 5 (10) | Echolocation x1; Break Enchantment x2; Feeblemind x1; Icy Prison x1; Cloudkill x1; Bone Explosion x1; Deny Death x1; Exsanguinate x1; Repurpose x1 | Echolocation is the anti-concealment priority; Icy Prison is the single-target control line. |
| 6 (10) | Greater Dispel Magic x2; True Seeing x2; Sirocco x1; Hellfire Ray x1; Bone Shield x1; False Grace x1; Siphon Life x1; Siphon Time x1 | Greater Dispel backs up Corrupt Magic; Hellfire Ray is the ranged-touch damage option. |
| 7 (10) | Communal True Seeing x2; Circle of Clarity x2; Legendary Proportions x1; Feast of Blood x2; Blessing of Unlife x1; Restore Undead x1; Bone Spear x1 | The anti-concealment and physical-stat package. Communal True Seeing and Legendary Proportions stay in the plan; omit those individual copies if their material components are unavailable. |
| 8 (10) | Mind Blank x1; Protection from Spells x1; Seamantle x1; Frightful Aspect x1; Horrid Wilting x1; Domain of the Hungry Flesh x2; Embrace of Death x1; Greater Bestow Curse x1; Create Greater Undead x1 | Defensive core plus no-save Domain control and a small number of kill/control spells. |
| 9 (9) | Corrupt Magic x2; Foresight x1; Symbol of Vulnerability x1; Negative Eruption x1; Flay for Purpose x1; Clashing Rocks x1; Mass Icy Prison x1; Summon Monster IX x1 | Open Bosses with Corrupt Magic; use Symbol before the pull when the arena allows it. |
| 10 (3) | Absolute Death x1; Pit of Despair x1; Death's Realm x1 | Absolute Death is a Will-gated finisher; the other two cover control and encounter-specific utility. |

Before resting into this table, scribe the missing ordinary Wizard spells shown in the table (especially Echolocation, Icy Prison, Greater Dispel Magic, Hellfire Ray, Resist Energy, Blur, Stinking Cloud, Communal Protection from Energy, and Circle of Clarity) wherever the current unmodded UI accepts them. This is the one final scroll-upgraded preset; there is no second “current-book” table.

### Metamagic: what to prepare and what to cast with a rod

Metamagic versions are separate prepared entries. Do not fill every slot with expensive metamagic; keep normal copies for a long fight.

WotR does not allow every metamagic shape on every spell. The spellbook icon is authoritative: if the metamagic button is greyed out for a spell in your current patch, use the normal copy or a different spell rather than assuming the tabletop combination works.

| Metamagic | Use in this build | Practical rule |
|---|---|---|
| Extend / Greater Enduring | Mage Armor, Shield, False Life, Mind Blank, True Seeing, Echolocation, Foresight, Bone Shield, False Grace, Seamantle, Frightful Aspect | Apply before entering. Use an Extend Rod when possible so combat slots remain normal. |
| Quicken | Greater Dispel, Corrupt Magic, Domain, Feast, Negative Eruption, Siphon Life, Sirocco | Prefer **Greater Quicken Rod** for a key round. It quickens spells of level 9 or lower; it cannot quicken Absolute Death (Lich level 10). |
| Persistent (Favorite Metamagic, optional) | Embrace of Death, Mass Icy Prison, Overwhelming Presence, Feast of Blood | This is optional; do not replace core Lich survivability or Spell Penetration mythic picks just to obtain it. If you have it, Persistent is +1 spell level in the normal WotR implementation: Feast of Blood is level 7→8 and Embrace of Death is level 8→9. Do not spend Persistent on Corrupt Magic or Domain: they have no saving throw, so repeating the save is wasted. Persistent Absolute Death is still above the level-10 ceiling. |
| Selective | Domain, Negative Eruption | Use when a finite skeleton or summon is on the field. Treat Selective Sirocco as version/UI-dependent and do not rely on it under a no-bug rule. |
| Heighten | Embrace of Death, Feast of Blood, Mass Icy Prison | Use one Heightened copy when a save DC matters more than preserving the top slot. Heightening Domain does not improve its no-save control. |
| Bolster / Empower / Maximize | Feast of Blood, Negative Eruption, Hellfire Ray | Prefer a rod for damage amplification; these do not solve SR or scripted immunity. |

### Concrete metamagic substitutions

Use these only when the metamagic icon is available for that spell in your current UI; each one replaces a normal slot of the resulting level:

- **Selective Domain of the Hungry Flesh:** level 8 spell prepared in a level-9 slot, when a summon is standing in the area and the current UI advertises Selective;
- **Persistent Feast of Blood:** level 7 spell in a level-8 slot, when the target is eligible and a second save is useful;
- **Selective Negative Eruption:** level 9 spell prepared in a level-10 slot, only when the current UI accepts Selective and the target is not immune to negative energy;
- **Persistent Embrace of Death:** level 8 spell in a level-9 slot, for targets that can be affected by its Will save;
- **Do not prepare Quickened Absolute Death:** level 10 plus Quicken is above the merged book's level-10 ceiling.

If you do not have Favorite Metamagic, keep the normal spell copies and use a rod; do not force a Persistent copy into the daily grid. Favorite Selective is an alternative for a Domain-heavy summon plan, but only use it if the current unmodded spellbook exposes the metamagic icon for Domain.

Potent Magic is strongest on the spell whose tooltip actually shows the +2 DC or +2 caster-level change. Merged-book interaction is version/UI-sensitive, so hover the spell after activating the Exploit and verify the final DC/CL before spending the reservoir.

### The practical two-action round

1. Activate the Greater Quicken Rod and cast **Corrupt Magic** or Greater Dispel as the swift action.
2. Use the standard action for **Absolute Death**, Domain of the Hungry Flesh, Feast of Blood, Clashing Rocks, or another normal spell.
3. Absolute Death is level 10, so it cannot be quickened by the Greater Quicken Rod. The Quicken feat would require a slot above the merged book's ceiling.
4. Siphon Life is a standard-action ranged-touch spell. It cannot target the Lich himself; use it on a valid enemy or permitted finite summon.

## 10.2 IE Unfair high-difficulty combat playbook

### Preparation before entering the arena

With Greater Enduring/Enduring available, pre-cast Mind Blank, Foresight, True Seeing, Echolocation, Protection from Spells, Freedom of Movement, Death Ward, Protection from Energy, Bone Shield, False Grace, Seamantle, Frightful Aspect, and Greater Invisibility/Displacement as appropriate. Equip the Phylactery and keep a Greater Quicken Rod, a Grandmaster's Rod, a Synchronization scroll, and finite summons on the hotbar.

Do not use a summon to exploit pathing or to create infinite resources. A finite summon is a normal extra target and buys the caster time to dispel and control.

### Inevitable Darkness

Inevitable Darkness has high AC, touch AC, SR, and broad immunity tags. Inspect its current in-game statistics instead of copying Core-mode numbers from a guide; exact values vary by mode and patch.

1. Use **Synchronization/Total Synchronization** on the Darkness according to the scroll tooltip before directly targeting it. This ends the Anomaly Distortion interaction; directly clicking a spell first can cause Anomaly Shift to place the boss beside the Lich.
2. Let the finite summon take the first physical pressure. Use Greater Quicken Rod + Potent Magic on **Corrupt Magic** to remove ordinary buffs, then use the standard action for **Absolute Death** or Domain. Absolute Death has no Death descriptor in the spell entry, so the statblock's Death immunity does not automatically invalidate it; the Will save still applies.
3. Activate **Deadly Magic** only for the limited 3–5-round window when you need a Wizard spell that normally checks SR, or when you want the caster-silence rider. Corrupt Magic, Domain, Feast, Negative Eruption, and Absolute Death already list SR N/A; Deadly Magic is not required for their SR checks and is not a promise to bypass external scripts or every immunity tag.
4. Inevitable Darkness is commonly listed with immunity to death effects, negative energy, negative levels, movement impairment, prone, acid, and cold. Do not use Negative Eruption as damage: it is a negative-energy/Harm-style spell and the target may be immune. Feast of Blood may work because the boss is living, but check the current tooltip/combat log. Grease/Sirocco should not be your prone plan. Test Domain for its no-save ability-damage component, then shift to Corrupt/Greater Dispel, Symbol of Vulnerability when accepted, Clashing Rocks, fire/electricity/sonic Wizard spells during Deadly Magic, and finite summons.
5. Keep one Corrupt Magic and one defensive/control option in reserve. Use Dimensional Slide to keep distance; if the boss is silenced or unable to cast, let non-negative damage and summons win the resource race.

### Nahyndrian Darkness and its crystals

1. Cast Echolocation/True Seeing and Circle of Clarity before attacking; Circle is the most direct concealment answer.
2. Dispel ordinary buffs first. The crystals can use special/scripted Spell Immunity, so neither a high DC nor Deadly Magic is a guaranteed crystal bypass.
3. Remove the crystals and waves according to the encounter script. If a crystal rejects direct spells, switch immediately to Clashing Rocks (ranged touch, no SR, ignores concealment for its own attack), Domain's ability-damage component if accepted, summons, and physical/ghost-touch backup. Feast of Blood and Negative Eruption are conditional on the current target's damage-type immunities.
4. Do not spend every level-10 slot on repeated save-or-die attempts. Absolute Death is a finisher after defenses and scripts have been tested, not the whole strategy.

### Playful Darkness

Use Circle of Clarity, Echolocation, True Seeing, and Greater Dispel/Corrupt Magic first. Then use Clashing Rocks, Domain, normal Sirocco, Feast of Blood, Negative Eruption, and summons only when the target tooltip allows those damage types. The goal is to remove concealment and force a long fight where SR-free Lich spells and temporary hit points matter. Treat Selective Sirocco as version/UI-dependent rather than a default prepared line.

### Areelu Vorlesh

Keep Mind Blank, Protection from Spells, Foresight, Death Ward, and Freedom of Movement. Open with Corrupt Magic, then use Domain, Clashing Rocks, Negative Eruption, Feast of Blood, and summons when the target tooltip permits them. If a death/mind-affecting line is blocked, shift to the no-SR/area/control package and keep Dimensional Slide available.

### General IE elite enemies

Identify the gate, then change spell families: Greater Dispel/Corrupt for buffs, Circle/True Seeing/Echolocation for concealment, Deadly Magic for a limited SR/Spell Immunity test, Domain/Negative Eruption/Feast/Clashing Rocks for reliable fallback pressure, and summons for action denial. This remains stable after an Absolute Death save, a failed dispel, or a scripted crystal immunity.

# 11. Solo PvP preparation and matchup strategy

## Unified preparation against an unknown opponent

Do not swap equipment based on the opponent. Use:

- Flawless Headband of Mental Perfection
- Robe of Seven Sins
- Phylactery
- Flawless Cloak
- Heartstone or a general high-save neck item
- Sin Mage's Staff
- Ring of Triumphant Advance
- Greater Quicken Rod
- Grandmaster's Rod

## Opening plan

Do not write the PvP plan as “Quickened Corrupt Magic followed by guaranteed Absolute Death.” The correct long-fight plan is:

1. Maintain Mind Blank, True Seeing, Foresight, Displacement, and Bone Shield;
2. Observe whether the opponent depends on buffs;
3. Use Corrupt Magic when there are many buffs;
4. Against a caster, activate Deadly Magic and use spell denial/control;
5. Against a physical build, maintain distance and use Domain of Hungry Flesh, Sirocco, Feast of Blood, Enervation, and Negative Eruption;
6. Against high Will, shift to SR-free effects, sustained damage, summons, and dispelling;
7. Do not count Phylactery story resurrection as the opponent having already lost a match.

## Relations with major builds

- **Trickster Sword Saint:** first try Corrupt Magic (or a targeted Greater Dispel follow-up) to remove Trick Fate. If it remains, do not stand and wait in melee: keep beyond the Sword Saint's displayed charge range (a 30-ft base speed is usually 60 ft with Haste; a clear charge can cover roughly twice that), use Move/Dimensional Slide to preserve the gap, and spend R1–R3 on no-save effects, summons, or defensive actions. Attack or hard-control on R4. If the fight starts in melee, Slide/teleport or layer defenses; a safe three-round kite is not available.
- **Angel Oracle:** Corrupt Magic first, then Deadly Magic/spell denial; Angel's Heal, Aegis, and high saves are a long-fight threat.
- **Legend SS/MW:** maintain distance and use area control and summons; do not let it reach you and sustain a Full Attack without control.
- **Aeon:** if it is a chaotic opponent, it gains alignment-based advantages; maintain non-chaotic Lich control and dispel lines, and handle Edict/Freezing Nothingness through movement and immunities.
- **Demon:** account for Socothbenoth's weaker saves and Coloxus's action economy; use Mind Blank, Death Ward, and Deadly Magic.
- **Kineticist:** avoid standing in pre-laid areas; Dimensional Slide, flight/movement, and SR-free spells are the main tools.
- **Swarm:** do not use a purely physical fallback; use Magic/Deadly Magic, SR-free AoE, control, summons, and Swarmbane when available.

---

# 12. Why not Sorcerer, Cruoromancer, or an old Witch/Loremaster hybrid

## Sorcerer 20

Pure Arcane Bloodline Sorcerer 20 + Lich, possibly adding Undead Bloodline, can exceed this build against a known Boss on a pure DC/health route. However, it gives up Wizard's prepared-caster flexibility against unknown opponents, so it is not the unified main line in this document.

Advantages:

- Charisma casting matches Lich's late-game health system;
- Spontaneous casting;
- Kindred-Raised Half-Elf can reach very high CHA.

Disadvantages:

- Known-spell limitation;
- Against an unknown Boss/PvP opponent it cannot always prepare the complete dispel, control, SR-free, and defensive package;
- Greater reliance on scrolls and Rods;
- Suitable for pure DC or a fixed script, but not the unified first choice for “all Bosses + unknown PvP.”

## Cruoromancer 20

Advantages:

- Dhampir-only;
- Necromancy specialization;
- Focused Infusion can increase some Necromancy DCs;
- Very strong pure Necromancy theme.

Disadvantages:

- Opposition schools and specialization cost general defense/control;
- Corrupt Magic is Abjuration and cannot simply use Necromancy Infusion;
- Compared with Exploiter Wizard, it loses flexible Potent Magic, Dimensional Slide, and defensive Exploits.

## Stigmatized Witch/Loremaster/Crossblooded hybrid

Advantages:

- Hexes, Charisma casting, Loremaster secrets, and bloodline abilities;
- Common in community builds and comfortable in the early/mid game.

Disadvantages:

- May lose full CL20 and high-level spell resources;
- Rules interactions among multiple sources, bloodlines, and spellbooks must be checked version by version;
- Not the preferred unified endgame choice for Bosses and PvP in this analysis.

If you want a pure-CHA Lich, use this document as a second option: Stigmatized Witch 10 / Loremaster 10. That is a “Hex/DC variant,” not the unified Boss/PvP main build here.

---

## INT Lich versus CHA Lich in Solo PvP

For this comparison, **INT Lich** means the recommended Exploiter Wizard 20 / Lich MR10, while the strongest general **CHA Lich** means **Overwhelming Mage Sorcerer 20 / Lich MR10 with Arcane bloodline**. A plain Arcane Sorcerer is the simpler baseline and Crossblooded is a narrower known-target variant. The assumptions are full preparation, best legal equipment, no opponent-specific gear swap, no first-round ranking, and no knowledge of the opponent's build before the duel.

| Route | Solo PvP score | Best at | Main weakness |
|---|---:|---|---|
| **INT Exploiter Wizard 20 → Lich MR10** | **9.5/10** | Unknown-opponent adaptation, Corrupt Magic/Greater Dispel, broad control and defense, switching between SR-free and save-based lines | Must prepare the right spell pages; Potent Magic is a finite resource |
| **CHA Overwhelming Mage 20 → Lich MR10 (Arcane bloodline)** | **9.3/10** | Fixed 1v1 pressure: up to +4 SR checks from the archetype and up to +3 DC on the next spell after sacrificing a spell slot, while retaining Arcane bloodline DC tools | Loses Sorcerer bonus-feat flexibility; Overwhelming Spell consumes a high-level slot and does not improve Corrupt Magic's dispel checks |
| **CHA Arcane Sorcerer 20 → Lich MR10** | **9.2/10** | Spontaneous casting, a fixed Necromancy/DC plan, more same-level spontaneous slots, and Charisma serving both casting and the Lich's late-game undead durability/HP system | Spells-known limit; cannot replace a missing counterspell or protection after the duel starts; no Exploiter defensive package |
| **CHA Crossblooded Sorcerer → Lich** | **8.9–9.2/10** | A known-target bloodline package and specialist DC | Reduced spells known makes unknown-build matchups less stable; it does not get Overwhelming Mage's SR/DC package |
| **CHA Stigmatized Witch/Loremaster variant** | **8.7–9.1/10** | Hexes, curses, and a prepared/CHA hybrid script | Exact split determines CL, spell access, and whether it loses too many high-level slots |

### Why INT wins the general PvP ranking

At full casting progression both Wizard 20 and Sorcerer 20 enter the merged Lich book at the same base caster level. The Lich path does not give the Wizard a permanent extra CL because it uses INT. The difference is the complete prepared spellbook and Exploiter tools:

- **Potent Magic** can add +2 DC or +2 CL to the one cast that matters, such as Corrupt Magic, Greater Dispel, a control spell, or Absolute Death;
- Wizard can prepare different answers before the match begins: Mind Blank, True Seeing/Echolocation, Circle of Clarity, Symbol of Vulnerability, SR-free Lich spells, and multiple control schools;
- the prepared book makes it easier to carry both anti-caster and anti-martial lines without relying on scrolls during the duel;
- Dimensional Slide, Spell Resistance, Greater Spell Resistance, Arcane Barrier, and Wooden Flesh provide a broader defensive floor than a pure Sorcerer chassis.

The CHA Sorcerer remains dangerous. It casts from Charisma, has strong spontaneous slot economy, and can build a very high fixed Necromancy DC. Lich's undead conversion also makes Charisma relevant to the late-game durability/HP system, so CHA has a real long-fight and error-tolerance advantage that INT does not automatically reproduce. Against a **known** opponent with a predictable Will profile, that specialist can equal or exceed one Exploiter Absolute Death attempt. That advantage is narrower in an unknown-opponent Solo PvP ladder because the Sorcerer cannot learn the missing answer between matchups. Crossblooded Sorcerer improves a chosen bloodline package but pays for it with even fewer known spells.

Both routes have access to the merged Lich tools **Deadly Magic, Corrupt Magic, Absolute Death, Feast of Blood, Negative Eruption,** and **Domain of the Hungry Flesh** when their spellbook and mythic progression provide them. INT does not make Absolute Death automatically succeed, and CHA does not make it automatically fail; high Will, natural 20s, effect immunities, and Deadly Magic's limited uses still matter. INT is preferred because it can change the surrounding plan when that save-or-die line is resisted.

### Direct head-to-head: the strongest CHA Lich versus the strongest INT Lich

The strongest Charisma specialist for this comparison is **Overwhelming Mage Sorcerer 20 with Arcane bloodline**, not generic Crossblooded Sorcerer. Overwhelming Mage keeps a standard bloodline, gains escalating caster-level bonuses to overcome SR, and can sacrifice a spell slot to raise the next spell's DC by up to +3. Crossblooded can be stronger in a deliberately scripted, known-target build, but its reduced spells-known list and lack of Overwhelming Mage's SR package make it less reliable as the default champion.

| Match conditions | Winner | Reason |
|---|---|---|
| Your stated PvP rule: opponent build is not known in advance; generic best gear and preparation | **Exploiter Wizard Lich, narrowly** | Prepared spell coverage, Potent Magic (+2 DC or +2 CL), stronger Corrupt Magic/Greater Dispel checks, and Exploits such as Dimensional Slide and Greater Spell Resistance give more answers over a series of matchups. Estimated practical edge: about 55/45, not a guaranteed win. |
| A single known 1v1 where both players can tailor spell preparation to the other | **Overwhelming Mage Arcane Lich, narrowly on peak pressure** | +4 SR penetration at the high end, Arcane School Power, and up to +3 temporary DC make a fixed save/control script harder to resist; Charisma also supports the Lich's late-game durability system. Estimated edge: about 55/45, not an automatic counter. |

In both cases the fight is decided by dispelling and defensive sequencing rather than one guaranteed spell. Overwhelming Mage's bonuses do **not** improve the caster-level checks inside Corrupt Magic; Exploiter's Potent Magic can. Conversely, Exploiter does not permanently match Overwhelming Mage's +3 DC sacrifice plus Arcane school bonus. That is why the answer changes with the information rule instead of producing one unconditional winner.

**If you want one direct answer for the rules you previously specified:** choose **Exploiter Wizard Lich** for the higher overall Solo PvP win rate against an unknown opponent. If you are building specifically to fight this one Wizard and can tailor the duel, choose **Overwhelming Mage Arcane Lich** for the higher peak 1v1 ceiling. The archetype mechanics are listed in [GameFAQs' Sorcerer guide](https://gamefaqs.gamespot.com/pc/365391-pathfinder-wrath-of-the-righteous-through-the-ashes/faqs/80843/sorcerer), and the high-difficulty caster comparison is summarized by [Neoseeker's caster guide](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Casters).

**Verdict:** there is no unconditional winner because the arena weighting changes the answer. Under this document's default no-foreknowledge weighting, **INT Exploiter Wizard Lich wins narrowly over Overwhelming Mage Arcane Lich (9.5 vs 9.3)**. If raw HP, long-fight durability, and fixed-script DC pressure receive the greatest weight, **Overwhelming Mage can tie or edge it**; if preparation breadth, dispelling, and unknown-build adaptation receive the greatest weight, INT wins. The prepared-versus-spontaneous distinction, the Overwhelming Mage mechanics, and the Lich Charisma durability interaction are consistent with [GameFAQs' Wizard rules](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/wizard), [GameFAQs' Sorcerer guide](https://gamefaqs.gamespot.com/pc/365391-pathfinder-wrath-of-the-righteous-through-the-ashes/faqs/80843/sorcerer), and the merged [Lich spell table](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous-through-the-ashes/faqs/80843/lich).

# 13. Final conclusion

This **Dhampir Vetala-Born / Exploiter Wizard 20 / Lich MR10** is the version I recommend for an actual playthrough.

Its endgame position:

- Boss ranking: the fully prepared Lich 9.6 version;
- Solo PvP: the general prepared Lich 9.4 version;
- Main strengths: CL30, a fully prepared spellbook, Potent Magic, Corrupt Magic, SR-free spells, control, and negative-energy sustain; the PvP variant adds Deadly Magic's extra rounds;
- Main weaknesses: Deadly Magic is limited, Absolute Death can fail against Will, and ND crystals/scripted immunities are not guaranteed to be bypassed by ordinary Spell Immunity penetration;
- Endgame default: Boss uses MR3 Indestructible Bones, MR6 Withering Life, and MR9 Eclipse Chill; PvP uses MR3 Deadly Magic, MR6 Magic Devourer, and MR9 Eclipse Chill;
- PvP substitution: one of MR6 or MR9 can be changed to Magic Devourer, but Withering Life/Eclipse Chill are more general against unknown opponents.

---

# 14. Focused comparison of the three Lich caster routes

This section compares the three routes requested for a prepared, solo, vanilla Unfair/Inevitable Excess endgame. It does **not** create three full character sheets. The only full build in this document remains the recommended Exploiter Wizard 20 / Lich MR10 build above; the other routes are evaluated as compact alternatives.

## Comparison assumptions

- Level 20, MR10, Lich, merged arcane/Lich spellbook where the game permits it;
- 25-point buy, best legal endgame equipment, long-duration pre-buffs, summons, rods, and consumables;
- no mods, bugs, AI exploits, terrain exploits, combat resets, or opponent-specific equipment swaps;
- the table evaluates full fights rather than a first-round kill;
- the Wizard/Loremaster row means **plain Wizard 10 / Loremaster 10**. An Exploiter 10 / Loremaster 10 hybrid is discussed separately because it keeps Potent Magic but loses the late Exploits and much of the Reservoir capacity.

## Final comparison table

| Route | Boss score | PvP score | DC profile | CL profile | Spell coverage | Stability | Overall assessment |
|---|---:|---:|---|---|---:|---:|---|
| **Exploiter Wizard 20 → Lich MR10** | **9.6** | **9.4** | Same common DC; **+2 DC on a selected cast** with Potent Magic | **Book CL30**; normally effective CL32 with Dark Rites; about CL34 on a Potent-Magic CL check | **10/10** prepared Wizard + Lich list | **9.6/10** | Best all-purpose Boss and unknown-opponent route |
| Wizard 10 / Loremaster 10 → Lich MR10 | 9.4 | 9.3 | Same common DC; no Potent Magic bonus | **Book CL30**; normally effective CL32 with Dark Rites | **9.8/10** with five cross-list Secrets | 9.2/10 | Best utility variant; gives up peak checks for tools |
| Arcane Sorcerer 20 or Arcane-primary Crossblooded Sorcerer → Lich MR10 | 9.3 | 9.2 | **+2 Necromancy DC** from School Power; **+1 more** when a non-Heighten metamagic bonus actually applies | **Book CL30**; normally effective CL32 with Dark Rites | 8.0–8.5/10 known-spell list plus bloodline spells | 8.7/10 | Highest fixed-school DC; least flexible solo route |

The scores are mechanics-based aggregate estimates, not measured win-rate data and not a claim that the Sorcerer loses every individual DC contest. Against a known Will-save target, an Arcane Sorcerer can match or exceed an Exploiter's single Absolute Death DC. The Exploiter wins the broader test because it keeps the full prepared list, reliable Corrupt Magic checks, more Wizard bonus feats, and defensive Exploits.

## Caster level: what actually changes

All three routes are full arcane casters at character level 20. Loremaster has full caster-level progression, so Wizard 10 / Loremaster 10 does not lose a caster level. At MR10, the merged Lich book therefore has:

```text
base merged spellbook CL = 20 class casting levels + 10 mythic ranks = CL30
Dark Rites (if active and shown by the current tooltip) = about CL32 for checks/duration
Robe of Seven Sins (+3 CL if shown by the current tooltip) = about CL35
Sin Mage's Staff (+3 CL if shown by the current tooltip) = about CL38 with both common CL items
Spell Specialization (+2 CL to its selected spell, where applicable) = +2 to that spell's relevant CL check
Exploiter Potent Magic (+2 CL to one selected cast) = +2 to that cast's relevant CL check
```

The rows after Dark Rites are additive examples only when the current tooltip confirms that the bonuses stack for that check; do not blindly add every row to every spell. These numbers describe effective caster-level checks, duration, penetration, or spell damage where the relevant spell allows the bonus. They do not raise the underlying merged spellbook progression above CL30 or automatically add more spell levels. The exact final number should be read from the current in-game tooltip because item and DLC versions have changed.

The important correction is that Exploiter Wizard does **not** have a permanently higher base CL than the other two routes. Its advantage is a limited, selectable **+2 CL or +2 DC** on a key cast. Potent Magic is therefore most valuable on Greater Dispel/Corrupt Magic checks, a critical Spell Penetration check, or a save-or-die attempt—not as a permanent character-sheet bonus.

Potent Magic is also a finite resource. The current Exploiter rules list Arcane Reservoir at a maximum of class level + 3, with a normal post-rest refill of roughly half the class level + 3 before any refill or pool-extending mythic choices. That means a pure Exploiter 20 starts around 13 points after rest (maximum 23), while an Exploiter 10 / Loremaster 10 starts around 8 (maximum 13). Full Reservoir or Abundant Arcane Pool can change those numbers. This is why the pure Exploiter route has a better long-fight floor than a hybrid even when both can make the same single Potent cast.

## DC and Absolute Death calculation

For a normal spell, use:

```text
spell DC = 10 + spell level + casting-ability modifier + feat/item/path bonuses
```

The three routes share the same level-10 Lich Absolute Death: standard action, no SR, Will partial; failure kills, while a successful save takes 10 damage per caster level. The spell description confirms that its DC is a saving-throw DC, while caster level affects the damage fallback rather than the DC itself. See the [GameFAQs Lich spell table](https://gamefaqs.gamespot.com/switch/392088-pathfinder-wrath-of-the-righteous-inevitable-excess/faqs/80843/lich).

If Inevitable Fate is available and pre-buffed, its MR10 +5 DC is shared by all three routes. It moves the entire Absolute Death table upward; it does not create a route-specific advantage. Exploiter Potent Magic can then add a further +2 DC to one selected cast, while Sorcerer's School Power remains a permanent +2 to the chosen school.

For a target with Will bonus `S` and Absolute Death DC `D`, the approximate chance that the target fails the save is:

```text
P(kill) = clamp((D - S - 1) / 20, 0.05, 0.95)
```

This assumes the normal natural-1 automatic failure and natural-20 automatic success rules. For illustration, against the Inevitable Darkness **Core** Will bonus +39 (Unfair is higher and patch scaling must be checked in-game):

| Absolute Death DC | Save-failure chance against Will +39 |
|---:|---:|
| 50 | 50% |
| 52 | 60% |
| 54 | 70% |
| 56 | 80% |
| 58 | 90% |
| 60 or higher | 95% cap |

Therefore:

- Exploiter Potent Magic adds **+2 DC** to the selected cast, normally moving the table by 10 percentage points until the natural-20 cap;
- Arcane School Power also adds **+2 DC** to Necromancy, including Absolute Death, if Arcane is the primary Sorcerer bloodline;
- Arcane Bloodline's +1 metamagic DC applies only when the spell is actually affected by a qualifying non-Heighten metamagic effect. Do not automatically add it to an unmodified Absolute Death;
- Wizard 10 / Loremaster 10 has the same normal DC if it uses the same casting-stat bonus, feats, and equipment. A Loremaster Secret can add a feat, but spending a Secret on a spell or utility option does not directly raise DC;
- no route makes Absolute Death an automatic kill. High Will, natural 20, final-effect immunity, and special Boss scripting remain relevant.

## Corrupt Magic stability

Corrupt Magic is shared by all three routes. It is a level-9 targeted dispel with standard-action casting, no saving throw, and no SR. It can remove multiple buffs, starting with the highest-level effect, and each removed effect applies a -1 penalty to the target's attack, damage, saves, and AC. The [GameFAQs Lich spell entry](https://gamefaqs.gamespot.com/switch/392088-pathfinder-wrath-of-the-righteous-inevitable-excess/faqs/80843/lich) and [WotRDB Dispel Magic formula](https://wotrdb.wiki/feats/dispel-magic) provide the rule basis.

The check is a caster-level check against each buff's dispel DC. It is not a spell-save DC, so School Power does not improve it. Exploiter Potent Magic can add +2 CL to the selected dispel cast. That is a real, finite advantage: it raises a d20 check by two points, usually a 10-percentage-point improvement before the check caps. Loremaster's extra spells do not reproduce the multi-buff behavior of Corrupt Magic; a stolen Greater Dispel is a useful backup, not an equivalent replacement.

For the no-bug comparison, assume the listed spell behavior and ordinary per-effect dispel checks. Do not award a route extra points for a patch-specific implementation that strips every buff without rolling the intended checks.

## Boss comparison

### Inevitable Darkness

This is the clearest case for Exploiter Wizard 20. Inevitable Darkness has extreme SR, mind/death/negative-level defenses, high saves, and a large defensive-buff stack. A prepared Wizard can use Corrupt Magic, Potent Magic on the relevant check, Deadly Magic during its limited window, SR-free Lich spells, control, summons, and non-save damage. Absolute Death remains a save-gated option rather than the entire plan.

Wizard 10 / Loremaster 10 is close. Five Secrets can add cross-list tools such as Greater Dispel, Creeping Doom, Foresight, or other version-available Cleric/Druid spells. Those options improve long-fight coverage, but the route loses Potent Magic and several late Wizard bonus-feat/Exploiter benefits. Its floor is good; its peak checks are lower.

Arcane Sorcerer can produce the highest Necromancy DC on a fixed target, but Inevitable Darkness is a poor place to rely on a single school or a short known-spell list. Crossblooded Sorcerer adds bloodline Arcanas and spells while reducing known spells at every level. Do not import the tabletop Crossblooded -2 Will penalty into the current WotR implementation; the practical WotR cost is the reduced spell-known list and narrower preparation. That trade is especially costly in solo PvP and against a Boss whose defenses force several different spell schools and fallback actions.

**Most reliable Inevitable Darkness route: Exploiter Wizard 20.** Loremaster is a credible second choice when its stolen utility spells are deliberately selected. Sorcerer is the best specialist option when the target's save profile and the exact Necromancy plan are already known.

### Nahyndrian Darkness and the crystals

Nahyndrian Darkness is a different test. The Unfair guide documents 153 buffed AC, non-dispellable 50% concealment, non-dispellable incorporeality, and a special Spell Immunity layer; physical attacks also need Ghost Touch to avoid half damage. See [Neoseeker's Nahyndrian Darkness guide](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/DLC/Nahydrian_Darkness).

Community reports describe focus-crystal objectives and extra waves, but those crystal/script mechanics are version-sensitive and are not the same as ordinary Spell Immunity. Do not claim that Deadly Magic automatically bypasses them. No one of the three caster routes solves the crystals by DC alone.

Exploiter Wizard has the best full package for this encounter because it can prepare Ghost Touch support, True Seeing/Echolocation, SR-free damage and control, summons, and physical or weapon backups while still retaining Potent Magic for dispel checks. Loremaster can improve the utility package, but the lost Exploiter peak is noticeable. Sorcerer can reach a higher Necromancy DC, yet its known-spell restriction makes the crystal, concealment, incorporeal, and backup requirements harder to cover simultaneously.

**Best crystal/special-mechanic handling: Exploiter Wizard 20 by coverage, with no guaranteed route-specific shortcut.**

## Solo PvP comparison

- **Exploiter Wizard 20:** best against an unknown Angel, Trickster Sword Saint, Legend, or Aeon because it can prepare defenses and choose different control/dispel/anti-caster lines after seeing the battlefield. Potent Magic can be saved for Corrupt Magic, a key control spell, or a decisive SR check.
- **Wizard 10 / Loremaster 10:** strongest utility adaptation. Stolen Cleric/Druid spells can supply missing protections, condition-removal tools, or an alternate control type. Positive-energy Heal is not a Lich self-heal; select off-list spells with the current UI in mind. The price is lower peak dispel/DC performance and fewer class-specific defenses.
- **Arcane/Crossblooded Sorcerer:** strongest fixed Necromancy DC and Charisma-based undead durability. It can be excellent against a known save-based opponent. Against an unknown opponent, the reduced spell-known list creates more dead matchups; the route cannot prepare a new answer after the duel begins.

The PvP conclusion is therefore the same as the Boss conclusion under the user's unknown-opponent rule: **Exploiter Wizard 20 remains the recommended first place**, with Arcane Sorcerer able to win the narrow “known target, Necromancy DC contest” and Loremaster able to win the narrow “maximum cross-list utility” contest.

### Overwhelming Mage caveat

An Arcane-primary Overwhelming Mage Sorcerer can be a strong fixed Inevitable Darkness specialist: the archetype provides escalating SR-check bonuses and a temporary DC increase after sacrificing a spell slot. It gives up several feats and consumes a high-level slot, so it is a specialist variant rather than a better universal route for four Bosses plus unknown PvP. No full Overwhelming Mage sheet is maintained here because the requested final detailed build is the strongest general route.

## Is Loremaster worth giving up Exploits?

For this exact goal, normally no.

- Pure Wizard 10 / Loremaster 10 gives five Secrets and full CL, but no Potent Magic, no late Exploits, and fewer Wizard bonus feats than Wizard 20;
- Exploiter 10 / Loremaster 10 keeps Potent Magic and the early Exploits, but loses the level-13/17 Exploit choices and has a smaller Reservoir. It is a compromise rather than an upgrade;
- Exploiter Wizard 20 already has the complete Wizard list, Lich list, Corrupt Magic, SR-free fallback spells, and the tools needed for the four Bosses;
- Loremaster is worth considering when you specifically want a fixed cross-list package such as Greater Dispel/Creeping Doom/Foresight and accept lower peak dispel/DC checks. It is not worth replacing the main build solely for a theoretical higher spell count.

## Final route decisions

1. **Strongest Boss Lich route:** Dhampir Vetala-Born **Exploiter Wizard 20 → Lich MR10**.
2. **Strongest prepared Solo PvP route against unknown builds:** **Exploiter Wizard 20 → Lich MR10**.
3. **Best specialist alternative:** Arcane-primary Sorcerer 20 if the target is known and the plan is centered on Necromancy DC; do not choose Crossblooded solely for a larger theoretical bloodline package.
4. **Best utility alternative:** Wizard 10 / Loremaster 10 if you value five carefully selected cross-list Secrets over Potent Magic and late Exploits.
5. **Most recommended new start:** use the complete Exploiter Wizard 20 build in this document. The other two routes do not justify maintaining additional full build sheets for this Boss/PvP objective.

---

# References

- [GameFAQs: Wizard and Exploiter Wizard](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/wizard)
- [GameFAQs: Lich](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/lich)
- [GameFAQs: Lich — Inevitable Excess](https://gamefaqs.gamespot.com/switch/392088-pathfinder-wrath-of-the-righteous-inevitable-excess/faqs/80843/lich)
- [GameFAQs: Merged spellbooks and mythic paths](https://gamefaqs.gamespot.com/pc/365391-pathfinder-wrath-of-the-righteous-through-the-ashes/faqs/80843/mythic-paths)
- [GameFAQs: Endgame equipment](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/items)
- [GameFAQs: Inevitable Excess equipment](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/items-inevitable-excess)
- [GameFAQs: Character creation, races, backgrounds, and deities](https://gamefaqs.gamespot.com/pc/365391-pathfinder-wrath-of-the-righteous-through-the-ashes/faqs/80843/character-creation)
- [GameFAQs: Arcanist and Exploiter mechanics](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/arcanist)
- [GameFAQs: Prestige classes and Loremaster Secrets](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/prestige-classes)
- [GameFAQs: Sorcerer and Crossblooded mechanics](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/sorcerer)
- [Neoseeker: Lich Choices](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Lich_choices)
- [Neoseeker: Mythic Choices](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Mythic_choices)
- [Neoseeker: Casters](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Casters)
- [Neoseeker: Nahyndrian Darkness](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/DLC/Nahyndrian_Darkness)
- [WotRDB: Dispel Magic formula](https://wotrdb.wiki/feats/dispel-magic)
- [WotRDB: Mythic paths and merged spellbooks](https://wotrdb.wiki/mythic-paths)
- [Pathfinder Wiki: Dhampir](https://pathfinderkingmaker.fandom.com/wiki/Dhampir)
- [Pathfinder Wiki: Horns of Naraga](https://pathfinderkingmaker.fandom.com/wiki/Horns_of_Naraga)
- [Pathfinder Wiki: Greater Quicken Metamagic Rod](https://pathfinderkingmaker.fandom.com/wiki/Greater_Quicken_Metamagic_Rod_%286-charges%29)
- [Pathfinder Wiki: Grandmaster's Rod](https://pathfinderkingmaker.fandom.com/wiki/Grandmaster%27s_Rod)
- [GameFAQs: Feats and metamagic adjustments](https://gamefaqs.gamespot.com/pc/428936-pathfinder-wrath-of-the-righteous-lord-of-nothing/faqs/80843/feats)
- [WotRDB: per-spell metamagic acceptance](https://wotrdb.wiki/guides/spell-shape)
- [GameFAQs: Inevitable Excess postlude and Inevitable Darkness mechanics](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/postlude-inevitable-excess)
- [GOG release notes: Feast of Blood target restriction](https://www.gogdb.org/product/1207187357/releasenotes)
- [Reddit: Lich Corrupt Magic/Deadly Magic testing](https://www.reddit.com/r/Pathfinder_Kingmaker/comments/1f2rei4)
- [Reddit: High-difficulty Lich build discussion](https://www.reddit.com/r/Pathfinder_Kingmaker/comments/1w4xy29)
