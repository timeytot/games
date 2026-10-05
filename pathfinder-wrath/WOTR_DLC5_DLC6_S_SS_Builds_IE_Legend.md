# Pathfinder: Wrath of the Righteous
# DLC5 + DLC6 Archetypes, Full Ratings, and IE Build Plans

Prepared for characters and parties in **Inevitable Excess (IE)**.
This document covers every DLC5 and DLC6 archetype in the current Neoseeker ranking snapshot, then separates those archetype grades from the strongest full-game IE systems.

## Scope, ranking source, and IE environment

The ranking source uses this Unfair/min-max scale:

| Rating | Meaning |
|---|---|
| **SS** | Far above the power curve; close to balance-breaking |
| **S** | Clearly above the power curve |
| **A / A+ / A−** | Top-tier, with the sign showing relative placement inside the tier |
| **B / B+ / B−** | Average to above-average, but not a defining endgame engine |
| **C / C+** | Below average or highly conditional |
| **D** | Clearly weak in the current min-max environment |

Primary ranking source: [Neoseeker — Class Rankings](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Class_Rankings). The dedicated archetype pages are older snapshots, so their individual labels can differ from the maintained general ranking page.

### Full DLC6 ranking — A Dance of Masks

| Rating | Archetype | Class | Practical IE reading |
|---|---|---|---|
| **SS** | Inciter | Skald | Best party-wide melee multiplier and control support |
| **SS** | Kinetic Sharpshooter | Kineticist | Best self-contained ranged blast finisher |
| **S** | Sable Company Marine | Ranger | Excellent one-level flying mount and terrain-ignoring dip |
| **A−** | Drunken Master | Monk | Strong pure high-level martial; wants defensive support |
| **A−** | Titan Fighter | Fighter | Good large-weapon martial package; less flexible than Mutation Warrior |
| **B+** | Bloodseeker | Slayer | Solid martial and bleed package, but not a top IE engine |
| **B+** | Mantis Zealot | Warpriest | Useful divine martial hybrid with narrower support ceiling |
| **B** | Magic Deceiver | Arcanist | Flexible spell tricks, but lower sustained output than top casters |
| **C+** | Bladebound | Magus | Playable spellblade, but weaker than established Magus cores |
| **C** | Chelaxian Diva | Bard | Niche social/control bard with a lower combat ceiling |
| **C** | Living Grimoire | Inquisitor | Flavorful divine caster, but outperformed by stronger Inquisitor shells |

DLC6 contains 11 archetypes; see [Owlcat’s official DLC6 announcement](https://wrath.owlcat.games/news/78).

### Full DLC5 ranking — The Lord of Nothing

| Rating | Archetype | Class | Practical IE reading |
|---|---|---|---|
| **S** | Ghost Rider | Cavalier | Best one-level tether/mount utility and a strong mounted hybrid core |
| **S** | Weretouched | Shifter | Strong natural-attack bruiser when the build does not depend on Demon-only tricks |
| **S** | Geomancer | Sorcerer | Strong fire-ray and area-damage caster shell |
| **A+** | Winter Child | Shaman | Excellent cold/nature caster with strong control and support options |
| **A+** | Shadowcaster | Wizard | Strong shadow/illusion control with a high tactical ceiling |
| **A+** | Dual-Cursed Oracle | Oracle | Excellent curse/control Oracle; especially strong with Angel support |
| **A−** | Tandem Executioner | Ranger | Reliable two-character focus-fire package, but party-dependent |
| **B+** | Hag of Gyronna | Witch | Useful curse and debuff tools with a narrower build path |
| **B** | Dark Lurker | Rogue | Sneak-attack stealth package that needs more support than top martials |
| **B−** | Hag-Riven | Oracle | Functional hybrid witch, but less focused than Shadowcaster |
| **B−** | Tortured Crusader | Paladin | Defensive paladin variant with lower damage specialization |
| **C+** | Prophet of Pestilence | Cleric | Disease/control theme with inconsistent high-end reliability |
| **C** | Reanimator | Alchemist | Summon and undead package below stronger alchemist shells |
| **C** | Flesheater | Barbarian | Fun mutation bruiser, but weaker than established barbarian cores |
| **D** | Separatist | Cleric | Flexible domain access, but a poor primary endgame chassis |

DLC5 contains 15 archetypes; see [Owlcat’s official DLC5 announcement](https://wrath.owlcat.games/news/75). The [Burning Ember](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Burning_Ember_%28DLC5%29), [Demonic Shifter](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Demonic_Shifter), and [Riding Vivi](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Riding_Vivi_Mercenary) pages are useful build references, but their main-campaign mythic assumptions still need to be removed for a fresh IE Legend.
No complete level-by-level progression is implied for the A–D entries; this file keeps full build progressions for the six S/SS archetypes and gives the lower tiers a practical role summary. Prima Games publishes a separate editorial order—[Bladebound, Magic Deceiver, Chelaxian Diva, Living Grimoire, Bloodseeker, Drunken Master, Sable Company Marine, Kinetic Sharpshooter, Mantis Zealot, Inciter and Titan Fighter](https://primagames.com/gaming/best-new-archetypes-in-pathfinder-wotr-dance-of-masks-ranked)—because it measures novelty and general appeal rather than Unfair/min-max combat ceiling.

### Machine-readable tier map

```yaml
DLC6:
  SS: [Inciter, Kinetic Sharpshooter]
  S: [Sable Company Marine]
  A-: [Drunken Master, Titan Fighter]
  B+: [Bloodseeker, Mantis Zealot]
  B: [Magic Deceiver]
  C+: [Bladebound]
  C: [Chelaxian Diva, Living Grimoire]
DLC5:
  S: [Ghost Rider, Weretouched, Geomancer]
  A+: [Winter Child, Shadowcaster, Dual-Cursed Oracle]
  A-: [Tandem Executioner]
  B+: [Hag of Gyronna]
  B: [Dark Lurker]
  B-: [Hag-Riven, Tortured Crusader]
  C+: [Prophet of Pestilence]
  C: [Reanimator, Flesheater]
  D: [Separatist]
```

**Do not treat these two tables as a whole-game IE class ranking.** They rate DLC archetypes inside their own source category. Angel Oracle, Lich caster, Trickster Sword Saint, Brown-Fur Transmuter and Mutation Warrior are separate full-game systems and are compared below.


**Rating-version note:** Neoseeker’s dedicated DLC review pages are older snapshots and can show a lower label (for example, A+ for some DLC5 archetypes or S for Kinetic Sharpshooter). The inclusion filter here uses the current general Class Rankings page, and the dedicated pages are linked under each build for mechanical commentary.

Official DLC context:

- [Owlcat — The Lord of Nothing DLC5](https://wrath.owlcat.games/news/75): DLC5 adds 15 archetypes, new spells, and new feats, and makes them available in the main campaign for new characters or retraining.
- [Owlcat — A Dance of Masks DLC6](https://wrath.owlcat.games/news/78): DLC6 adds 11 character archetypes.

### IE Legend facts used in this document

A fresh IE character can select **Legend at Mythic Rank 3**. This is different from the main campaign, where Legend is normally a late Mythic Rank 8 transition. A fresh IE Legend therefore does **not** receive the normal Mythic Rank 4–10 path progression, and it does not receive a merged Angel/Lich spellbook.

Sources:

- [Steam discussion — IE Legend is available at Mythic Rank 3 and cannot be taken later after another path](https://steamcommunity.com/app/1184370/discussions/0/3177859849531059867/)
- [GameFAQs — Legend mechanics and loss of later Mythic ranks/spellbook](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/other-mythic-paths)

The cited Neoseeker builds are ordinary level-20 builds written for the main campaign. Their Mythic Rank 4–10 lines are retained below as **source reference only**. Each section then gives an **IE Legend adaptation**. The adaptation is my recommendation, not a claim made by the original build author.

## IE final-build scope

This guide evaluates **Inevitable Excess only**. It does not use the main-campaign route “take Trickster/Angel/Lich first, then change to Legend at Mythic Rank 8.” In IE, the two build modes are separate:

1. **IE Mythic entry: level 20 / MR10:** continue with a mythic path at the IE mythic entry. The finished build is 20 class levels plus the selected mythic route (the guide's “30-step” format).
2. **IE Legend MR3 → character level 40:** select Legend at MR3 immediately. The finished build is a 40-level class split; later MR4–10 path features are unavailable.

IE MR8 Swarm-that-Walks and Gold Dragon are listed as future IE candidates below. They are tracked only for an IE save that actually exposes MR8 progression; they are not fresh IE MR10/Legend entry builds, and their full builds are not claimed until separately written.

### Combined IE final-build matrix

Every row below is a finished build format, not a bare “level 20 Mutation Warrior” entry. `DLC tier` is the source archetype tier; `whole-game` is this guide's strategic priority and is not a new Neoseeker rating. The MR10 column is a **30-step end state**: 20 class levels plus Mythic Rank 10. `N/A` means fresh IE Legend cannot legally select that mythic path; `—` means a complete 40-Legend version has not been selected yet.

| Scope / tier | Final build | IE Mythic entry: level 20 / MR10 (30-step end state) | IE Legend entry: MR3 → 40 class levels | Combat identity |
|---|---|---|---|---|
| DLC6 SS | Inciter | Inciter Skald 20 / Trickster MR10 | Inciter Skald 20 / Mutation Warrior 20 | Raging Song, shared sneak attack, Beast Totem and control |
| DLC6 SS | Kinetic Sharpshooter | Kinetic Sharpshooter 20 / Trickster MR10 | Kinetic Sharpshooter 20 / Mutation Warrior 20 | Kinetic Quiver and one charged blast per round |
| DLC6 S | Sable Company Marine | Sable Company Marine 1 / Paladin 13 / Sohei 1 / Mutation Warrior 5 / Trickster MR10 | Sable Company Marine 1 / Paladin 20 / Sohei 1 / Mutation Warrior 18 | Hippogriff Flying Attack and mounted full-round attacks |
| DLC5 S | Ghost Rider | Ghost Rider 1 / Sacred Huntsmaster 8 / Vivisectionist 8 / Sohei 2 / Demonslayer 1 / Trickster MR10 | Ghost Rider 1 / Sacred Huntsmaster 8 / Vivisectionist 12 / Sohei 6 / Demonslayer 1 / Mutation Warrior 12 | Etheric Tether, mount safety and sneak-attack charges |
| DLC5 S | Weretouched | Shifter (Weretouched) 17 / Stigmatized Witch 1 / Fighter 1 / Demonslayer 1 / Trickster MR10 | Shifter (Weretouched) 20 / Stigmatized Witch 1 / Fighter 18 / Demonslayer 1 | Shifting, aspects, pounce and natural attacks |
| DLC5 S | Geomancer | Stigmatized Witch 10 / Geomancer Sorcerer 1 / Loremaster 9 / Azata MR10 | Stigmatized Witch 20 / Geomancer Sorcerer 1 / Loremaster 19 | Fire rays, geomancy and selective area control |
| DLC5 A+ | Dual-Cursed Oracle | Dual-Cursed Oracle 20 / Angel MR10 | — | Curses, revelations and Angel divine casting |
| DLC6 A− | Drunken Master | Drunken Master 20 / Trickster MR10 | — | Unarmed flurry, drunken ki and defensive mobility |
| DLC6 A− | Titan Fighter | Titan Fighter 20 / Trickster MR10 | — | Oversized weapon reach and full attacks |
| DLC6 B+ | Bloodseeker | Bloodseeker 20 / Trickster MR10 | — | Slayer sneak attack, bleed and focus fire |
| DLC6 B+ | Mantis Zealot | Mantis Zealot 20 / Angel MR10 | — | Warpriest self-buffs, crit pressure and divine support |
| DLC6 B | Magic Deceiver | Magic Deceiver 20 / Azata MR10 | — | Spell theft, flexible control and setup-dependent casting |
| DLC6 C+ | Bladebound | Bladebound 20 / Trickster MR10 | — | Black Blade, spellstrike and arcane weapon pressure |
| DLC6 C | Chelaxian Diva | Chelaxian Diva 20 / Azata MR10 | — | Support song, enchantment and social control |
| DLC6 C | Living Grimoire | Living Grimoire 20 / Angel MR10 | — | Judgment, divine support and weapon attacks |
| DLC5 A+ | Winter Child | Winter Child 20 / Azata MR10 | — | Cold damage, nature control and familiar support |
| DLC5 A+ | Shadowcaster | Shadowcaster 20 / Lich MR10 | — | Shadow spells, illusion DCs and battlefield control |
| DLC5 A− | Tandem Executioner | Tandem Executioner 20 / Trickster MR10 | — | Teamwork attacks, companion positioning and focus fire |
| DLC5 B+ | Hag of Gyronna | Hag of Gyronna 20 / Lich MR10 | — | Hexes, curses and save-based debuffs |
| DLC5 B | Dark Lurker | Dark Lurker 20 / Trickster MR10 | — | Stealth, concealment and precision damage |
| DLC5 B− | Hag-Riven | Hag-Riven 20 / Angel MR10 | — | Oracle curse package and limited divine support |
| DLC5 B− | Tortured Crusader | Tortured Crusader 20 / Angel MR10 | — | Paladin auras, defenses and martial attacks |
| DLC5 C+ | Prophet of Pestilence | Prophet of Pestilence 20 / Angel MR10 | — | Disease, curses and condition pressure |
| DLC5 C | Reanimator | Reanimator 20 / Lich MR10 | — | Mutagens, extracts and undead summons |
| DLC5 C | Flesheater | Flesheater 20 / Trickster MR10 | — | Rage, mutations and natural-attack pressure |
| DLC5 D | Separatist | Separatist 20 / Angel MR10 | — | Domain flexibility with a lower endgame ceiling |
| Whole-game top | Angel Oracle | Seeker Oracle 16 / Scaled Fist Monk 1 / Paladin 2 / Hellknight 1 / Angel MR10 | N/A — fresh IE Legend cannot select Angel | Merged Angel spellbook, buffs, healing and bolts |
| Whole-game top | Lich caster | Stigmatized Witch 10 / Loremaster 9 / Crossblooded Sorcerer 1 / Lich MR10 | N/A — fresh IE Legend cannot select Lich | Merged Lich spellbook, Corrupt Magic and negative damage |
| Whole-game top | Trickster Sword Saint | Sword Saint 20 / Trickster MR10 | N/A — fresh IE Legend cannot select Trickster | Perception critical feats, Dimension Strike and Trick Fate |
| Whole-game support | Brown-Fur Transmuter | Brown-Fur Transmuter 20 / Azata MR10 | — | Shared transformations, Haste and weapon buffs |
| Whole-game martial | Mutation Warrior / Demonslayer | Mutation Warrior 19 / Demonslayer Ranger 1 / Trickster MR10 | Mutation Warrior 20 / Demonslayer Ranger 20 | Complete martial route; the KSS/Inciter rows use the same chassis as an extension |

The A–D rows are complete IE MR10 reference builds (20 class levels plus the listed mythic route), but they do not yet have a recommended 40-Legend extension. The SS/S rows and the whole-game rows carry the fully written 40-Legend adaptations where the route is legal.

Pure 20-class rows such as Sword Saint 20 and Brown-Fur Transmuter 20 are intentional capstone builds because their class progression is the payoff; they are still complete builds because the MR10 mythic route is written beside them.

### IE MR8 future candidates

These are included in the IE scope but are not yet final build entries: **Kinetic Sharpshooter 20 / Swarm-that-Walks MR8+** and **Sword Saint 20 / Gold Dragon MR8+**. They must be researched as IE MR8-capable mythic-route builds; neither is a fresh IE MR10/Legend entry or a main-campaign path-to-Legend conversion.

### IE party shells

**IE Mythic entry: level 20 / MR10 party:**

1. Main character: Seeker Oracle 16 / Scaled Fist Monk 1 / Paladin 2 / Hellknight 1 / Angel, Stigmatized Witch 10 / Loremaster 9 / Crossblooded Sorcerer 1 / Lich, Sword Saint 20 / Trickster or KSS 20 / Trickster.
2. Inciter Skald 20 as a mercenary; use Mythic Companion unless the Inciter is the commander.
3. Brown-Fur Transmuter 20 as a mercenary; use Mythic Companion unless the BFT is the commander.
4. Cleric/Oracle buffer for Guarded Hearth, communal defenses, Death Ward and condition removal.
5. Sable Company Marine 1 / Paladin 13 / Sohei 1 / Mutation Warrior 5 mounted shell or Mutation Warrior 20 / Trickster front line.
6. Ember, Nenio, Arueshalae or Wenduag for ranged pressure, hexes and control.

**IE Legend MR3 → level 40 party:**

1. Kinetic Sharpshooter 20/Mutation Warrior 20 as the ranged finisher.
2. Inciter Skald 20/Mutation Warrior 20 as the party engine.
3. Brown-Fur Transmuter or Arcanist support; keep casters out of Inspired Rage before Hit a Nerve.
4. Sosiel or Daeran for divine defenses, healing and Guarded Hearth.
5. Sable Company Marine 1 / Paladin 20 / Sohei 1 / Mutation Warrior 18 mounted front line.
6. Ember, Nenio, Arueshalae or Wenduag for ranged pressure, hexes and control.

Do not stack competing rage songs. Use one Inciter, keep KSS at range, and let the remaining slots cover transmutation, divine defense and a second front line.

### Operational playbooks

These sequences describe the normal combat loop. Exact names can vary with patches, mods and respec choices; the combat log takes priority when an interaction is known to be patch-sensitive.

#### Kinetic Sharpshooter

**Before combat:** cast Greater Magic Weapon, Haste, Heroic Invocation/Greater Heroism, True Seeing, communal defenses and the needed transmutations. Create **Kinetic Quiver** with 1 Burn and keep charges available. Prepare the Heavy Crossbow, Fire → Fire → Air element line and the intended infusion.

**Opening turn:** let the Inciter start Raging Song, then select the target. Use **Blue Flame + Rending Arrows** against a target without problematic spell resistance. Use **Pure-Flame** when SR is the problem. If the current patch accepts the interaction, combine Rending and Pure-Flame through Over-Infused Blasts. Against a line or clustered group, use unaltered Blue Flame + Chain Arrows.

Blue Flame is the energy/touch-AC line; physical Air blasts use normal AC. Rending is for stacking the AC penalty after a hit, while Honed is the DR answer.

Keep **Enveloping Winds** active against ranged pressure. Swap to **Honed Infusion** when damage reduction is the problem; do not spend a burn on it when the target has no relevant DR.

**Boss sequence:** cast Trick Fate immediately before the decisive shot, use The Bigger They Are when its attack bonus matters, then fire the single charged blast. **Metakinesis — Empowered** is the reliable sustained default. Test Quicken on an empty target after a patch: keep it only if the combat log shows two Charged Ammunition entries and the expected extra Quiver cost; otherwise use Empowered. Refresh Kinetic Quiver before charges run out. Never use Gather Power; KSS cannot use it.

**Do not waste actions on:** Exploding Arrows as the default single-target line, Rapid Shot/Manyshot as a way to create extra KSS blasts, or Deadly Earth/Kinetic Blade/Eruption, which KSS cannot use.

#### Inciter Skald

**Before combat:** cast Greater Heroism, Good Hope, Haste, Freedom of Movement, Echolocation and defensive images. Put the Inciter in a safe position with a Dagger of the Betrayer or another finesse weapon if available.

**Opening turn:** activate **Raging Song**. Use Accept Rage on melee and thrown-weapon allies; leave it off for casters when the song would restrict spellcasting. Turn on Lethal Stance and Beast Totem/Greater Beast Totem for the attackers. Use Come and Get Me only when the front line can survive the incoming attacks.

Before level 20, activate Lingering Performance and then end the song when you need to preserve the three-round effect without forcing casters to accept rage. At level 20, test Hit a Nerve before treating the song as caster-safe; the Inciter does not automatically gain the base Skald's separate Haste capstone.

**First attack:** make a qualifying weapon sneak attack to trigger **Dispelling Attack**. Then let the two melee characters flank and full-attack. Use Selective Confusion, Song of Discord or Overwhelming Presence after the song and positioning are established. Persuasion I–III is the combat-control line: demoralize, paralyze and finish failed-save enemies.

**Sustained loop:** keep the song active, make weapon attacks when a dispel is valuable, and spend later actions on selective control or emergency buffs. At level 20 test Hit a Nerve; allies should be able to cast without the song’s normal AC penalty. If the platform still blocks casting, turn the song off for caster rounds.

#### Sable Company Marine

**Before combat:** mount the hippogriff, apply Divine Favor, Greater Magic Weapon, defensive paladin buffs and the needed shield/armor setup. Mark or Smite the priority enemy before the charge when action economy allows.

**Opening turn:** use the hippogriff's **Flying Attack** with the mounted pair. The rider attacks the chosen target as a full-round action; terrain bypass and the flat-footed target help create the first flank. Follow with Outflank/Seize the Moment attacks when allies threaten the target.

**Sustained loop:** maintain the mount, rotate Smite Evil/Mark of Justice on major targets, and use Lay on Hands or mercies only when they prevent a lost full-attack round. Treat the flying attack as a positioning tool, not as the only source of damage.

#### Ghost Rider / Riding Vivisectionist

**Before combat:** mount up, apply the Vivisectionist’s mutagen and defensive extracts, then use Greater Magic Weapon, Haste, Legendary Proportions and concealment. Enable Etheric Tether between rider and ghost mount before initiative if possible.

**Opening turn:** activate **Etheric Tether** between the rider and ghost mount, then charge the isolated target with the mount and rider. Use the rider’s sneak-attack/full-attack package while the mount blocks movement and protects the back line.

**Sustained loop:** keep Etheric Tether active between rider and mount, refresh mutagen/extract defenses between encounters, and use ranged attacks, dispels or support extracts only when a full attack is impossible.

#### Weretouched

**Before combat:** choose the aspect and natural-attack form, apply Greater Magic Fang, Barkskin, Haste, Legendary Proportions or other party transmutations, then position for a charge. Do not plan around Demon/Kalavakus tricks in fresh IE Legend.

**Opening turn:** charge or pounce the priority target and make the full natural-attack sequence. Use the Stigmatized Witch/Loremaster support spell or hex only when moving into melee would lose more damage than the control effect gains.

**Sustained loop:** remain in the chosen form, maintain flank/Outflank positioning and use defensive transformations before attacking again.

#### Geomancer

**Before combat:** apply Haste, True Seeing, Greater Invisibility or concealment, communal defenses and Spell Resistance as needed. Prepare the ray metamagic; Geomancy is a free-action toggle for the next spell, not a persistent precombat buff.

**Opening turn:** remove or reduce enemy defenses with Dispel Magic when necessary, then cast the strongest available fire ray (Scorching Ray or Hellfire Ray) at the priority target. Use Bolstered/Empowered/Maximized versions according to spell slots and metamagic.

**Sustained loop:** continue ray volleys against single targets; use selective area control when enemies cluster. Enable the desired Geomancy effect immediately before the next creature-targeting spell; that spell consumes the toggle and deals +1d8 damage to you, so verify the terrain effect in the icon/log before committing metamagic. Keep the caster out of melee and let the front line create flat-footed or flanked targets.

#### Angel Oracle

**Before combat:** use the merged spellbook for long-duration communal defenses, Freedom of Movement, Death Ward, True Seeing, Greater Angelic Aspect and other enduring buffs. Apply Sword of Heaven before the encounter.

**Opening turn:** against one boss, use the strongest Angel bolt/ray sequence after any required debuff; against a group, use Storm of Justice or the highest available Angel area spell. Use Quickened buffs only when they preserve the main casting action.

**Sustained loop:** alternate Angel damage with Heal, dispels and emergency defenses. Do not spend the first combat round on small heals when an Angel spell can remove the encounter’s main threat.

#### Lich caster

**Before combat:** apply long-duration arcane defenses, Mind Blank/True Seeing, Greater Invisibility or concealment and the Lich defensive package. Keep a quickened defensive spell available.

**Opening turn:** use Corrupt Magic or another major debuff on the boss, then follow with Exsanguinate, Negative Eruption or the strongest save-based Lich spell that matches the encounter.

**Sustained loop:** maintain control on the most dangerous enemy, use negative-energy damage against groups and preserve Repurpose/defensive tools for encounters where a new undead ally or immunity matters.

#### Trickster Sword Saint

**Before combat:** enhance the weapon with Arcane Pool, cast long-duration defensive wizard spells and prepare Dimension Strike, Prescient Attack and Trick Fate.

**Opening turn:** activate Prescient Attack or Dimension Strike on the priority target, use Trick Fate for a decisive crit sequence, then full-attack. Perception II’s Trickster critical feats are the payoff for the route.

**Sustained loop:** alternate Arcane Pool/Dimension Strike full attacks with Bladed Dash or defensive repositioning. Save spell slots for defensive layers and boss accuracy rather than low-DC control.

#### Brown-Fur Transmuter

**Before combat:** cast the party package in this order: Greater Magic Weapon → Legendary Proportions or Transformation → Haste → Echolocation/True Seeing → communal defenses and condition immunity. Use Share Transmutation on the characters who actually attack.

**Opening turn:** begin with a preselected buff or a quickened control spell only if the party was not fully prebuffed. The BFT’s first job is to make KSS, Inciter and the front line hit; offensive casting is secondary.

Choose **Powerful Change** for the BFT's stronger personal transmutation or **Shared Transmutation** to convert a personal spell for an ally; do not try to apply both to the same cast.

**Sustained loop:** maintain dispels, emergency Greater Invisibility and targeted transformations. Do not overwrite a better size or Dexterity buff with a weaker late spell.

#### Mutation Warrior

**Before combat:** activate Mutagen, equip the weapon from your chosen weapon-training group and apply long-duration martial buffs. Set Outflank/Seize the Moment positioning before initiative.

**Opening turn:** charge or full-attack the target already marked by the Inciter/KSS control package. Use the bonus feats and weapon training to keep attacking instead of spending turns on small utility actions.

**Sustained loop:** maintain mutagen, use Combat Reflexes opportunity attacks and keep the selected weapon-training group active. Change the group only outside combat or through a planned respec/equipment plan.

## Combined evaluation

| Priority | Build | What it is best at | IE Legend value | Main limitation |
|---:|---|---|---|---|
| 1 | **Inciter Skald (SS)** | Party-wide melee damage, rage powers, enchantment control | Excellent if the party has several melee attackers | The rage song is less attractive in a caster-heavy party; source recommends hiring at level 20 |
| 2 | **Kinetic Sharpshooter (SS)** | Independent ranged damage with Quiver, Rending, Chain and Exploding Arrows; Bowling is an Earth-element alternative | Excellent; almost path-independent and has no spellbook to lose | The build is a ranged kineticist, not a normal bow archer; extra Legend levels do not increase Kineticist level past 20 |
| 3 | **Ghost Rider (S)** | Mount/tether safety and mounted Vivisectionist support | Excellent as a one-level Ghost Rider dip; strong as a mounted hybrid | The source’s late Mythic sequence and any path-dependent bonuses do not apply to a fresh IE Legend |
| 4 | **Geomancer (S)** | Fire ray damage plus AoE; Hellfire Ray and Geomancy | Very good; the core ray plan survives IE Legend | The source is an Ember companion build and leaves race, deity, alignment and background implicit |
| 5 | **Weretouched (S)** | Natural-attack tank/damage dealer with pounce, claws and aspect choices | Good after removing Demon-only assumptions | The source’s Demon/Kalavakus trip loop is unavailable when Legend is selected at IE MR3; shapeshifting gear also has known compatibility issues |
| 6 | **Sable Company Marine (S)** | One-level dip for a Flying Attack hippogriff: full-round mounted attack, terrain bypass and a flat-footed target | Excellent dip; strong mounted Paladin shell | The flying attack can be janky/bugged; the source build is a mounted Paladin and needs a pet |

### My combined recommendation

- **Best all-purpose IE Legend damage dealer:** Kinetic Sharpshooter.
- **Best party multiplier:** Inciter Skald.
- **Best mounted frontliner:** Sable Company Marine plus the DLC6 Paladin shell.
- **Best one-level utility dip:** Ghost Rider.
- **Best caster:** Geomancer.
- **Best natural-attack bruiser:** Weretouched, provided you do not plan around the unavailable Demon path.

---

# DLC6 — Inciter Skald (SS)

**Source build:** [InEffect’s Instigator Skald Mercenary](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Skald_Mercenary_%28DLC6%29)  
**Rank source:** [Neoseeker Class Rankings](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Class_Rankings)

## Evaluation

Inciter is the strongest support archetype in this list. It keeps the Skald’s party engine and adds more damage to the rage-song package. It is best as a level-20 hire in a melee-heavy party. For a fresh normal IE character, the strongest control and crit-support route is **Inciter 20 / Trickster**; Azata is a valid caster-heavy alternative when Favorable Magic and Zippy Magic matter more than Trickster’s skill and critical tricks. For a fresh IE Legend main character, use the class core but do not assume Mythic Rank 4–10 support choices survive the Legend start.

The Inciter song shares sneak-attack dice, Lethal Stance and Beast Totem with allies. Inciter’s Sneaky Tricks also makes selected rogue talents shareable. At level 14, the strongest party-support talent is **Advanced Rogue Talent: Dispelling Attack** with Dispel Focus and Greater Dispel Focus; at level 19 use **Petrifying Strike** or **Weakening Wound**. If the current patch still shows the old dispel bug, use Petrifying Strike as the reliable fallback. The underlying class progression is documented in the [GameFAQs Skald guide](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/skald) and the [Rogue advanced-talent rules](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/rogue).

## Creation

| Field | Recommendation |
|---|---|
| Race | Half-Elf (Kindred) |
| Alignment | Any |
| Deity | Any; the source does not specify one and Skald does not require a deity |
| Background | Pickpocket |
| Skills | Max Persuasion and Perception; keep Mobility high; put 1 rank in Use Magic Device and add Trickery or Stealth only if the party lacks it. Do not spend core ranks on Lore (Nature). |
| Role | Party support, enchantment control, rage-power support |
| Starting stats | Source mercenary spread: STR 7, DEX 14, CON 14, INT 12, WIS 7, CHA 21 → 26. For a 25-point-buy IE main character use STR 7, DEX 14, CON 14, INT 12, WIS 10, CHA 22 → 27; put every normal level-up point into CHA. |
| Hire timing | Level 20 is preferred by the source |
| Key gear | Call to Violence; White Dragon; Mindmaster Eyes; Ring of Chaotic Fascination; Bracers of Mind Break; Twisted Temptation |
| Endgame gear | Headband of Perfection +8; Mindmaster Eyes; Cloak of Reflections; Ring of Chaotic Fascination; Ring of Evasion; Bracers of Mind Break; Glass Amulet of Clarity; White Dragon; Wandering Conman; Twisted Temptation; Dagger of the Betrayer (optional if available from imported/main-campaign inventory; otherwise any +5 finesse stat-stick dagger or rapier); Assertion of Dominance; Persistent Rods |

## Class

**Skald (Inciter) 20**

## Level-by-level feats and abilities

| Level | Take |
|---:|---|
| 1 | Lingering Performance; Spell Focus: Enchantment |
| 2 | Skald |
| 3 | Greater Spell Focus: Enchantment; Lethal Stance |
| 4 | Combat feat: Improved Initiative |
| 5 | Spell Penetration |
| 6 | Beast Totem (Lesser) |
| 7 | Greater Spell Penetration |
| 8 | Skald |
| 9 | **Dispel Focus**; Canny Observer |
| 10 | Skald |
| 11 | Extra Rage Power: Beast Totem |
| 12 | Greater Beast Totem; Sneaky Tricks unlocks shareable rogue talents |
| 13 | **Greater Dispel Focus** |
| 14 | Skald Talent: **Advanced Rogue Talent — Dispelling Attack** |
| 15 | Extra Rage Power: Come and Get Me, or Ambuscading Spell |
| 16 | Skald |
| 17 | Extra Rage Power: Deadly Accuracy |
| 18 | Lethal Accuracy |
| 19 | **Selective Spell**; Skald Talent: **Advanced Rogue Talent — Petrifying Strike** (Weakening Wound or Crippling Strike are alternatives) |
| 20 | Master Skald; **Hit a Nerve** capstone |

### Strongest Inciter talent overlay

The table above is the optimized level-20 route. The old source’s level-19 Improved Elven Immunities is omitted because Kindred-Raised Half-Elf may not retain that prerequisite; use Selective Spell plus an advanced rogue talent instead. **Dispelling Attack** is a targeted Dispel on every shared sneak attack, with caster level equal to the character level. Use a weapon sneak attack (the source’s Dagger of the Betrayer, a rapier or a throwing weapon) to proc it; do not assume a spell ray will trigger the shared dispel on every patch. **Petrifying Strike** lowers enemy Dexterity and therefore AC; use **Weakening Wound** when removing DR is more valuable. If Dispelling Attack does not actually dispel on your current patch, use Petrifying Strike at level 14 and Weakening Wound at level 19. At Inciter 20, verify that **Hit a Nerve** lets an ally cast while the song is active and removes the song’s AC penalty; if your platform still blocks casting, treat that as a patch bug and turn the song off for caster rounds.

## Sample level-20 spellbook

| Spell level | Spells |
|---:|---|
| 1 | Vanish; Unbreakable Heart; Remove Fear; Grease; Cure Light Wounds; Expeditious Retreat |
| 2 | Mirror Image; Cacophonous Call; Cure Moderate Wounds; Glitterdust; Invisibility; Summon Monster II |
| 3 | Good Hope; Haste; Confusion; Crushing Despair; Mass Feather Step; Purging Finale |
| 4 | Freedom of Movement; Greater Invisibility; Echolocation; Dimension Door; Cure Critical Wounds; Summon Monster IV |
| 5 | Greater Heroism; Mass Cacophonous Call; Song of Discord; Mind Fog; Summon Monster V |
| 6 | Overwhelming Presence; Waves of Ecstasy; Brilliant Inspiration; Greater Song of Discord; Summon Monster VI |

### Recommended IE Mythic route: Inciter 20 / Trickster MR10

For an IE mythic-entry character at level 20/MR10, take Trickster if the goal is the strongest party control package. Keep the source’s generic mythic feats and use the separate Trickster trick slots in this order:

| Mythic rank | Generic choice | Trickster choice |
|---:|---|---|
| 1 | Last Stand | — |
| 2 | Extra Mythic Ability: Abundant Casting | — |
| 3 | Improved Abundant Casting | Perception I |
| 4 | Extra Mythic Ability: Mythic Inspiration | Perception II; Knowledge (World) I |
| 5 | Enforced Vigor | Persuasion I |
| 6 | Mythic Spell Penetration | Persuasion II; Knowledge (Arcana) I |
| 7 | Favorite Metamagic: Selective | Persuasion III; Infuse Magic Device |
| 8 | Mythic Spell Focus: Enchantment | Knowledge (World) II |
| 9 | Inspirational Leader | Perception III or Lore (Religion) I |
| 10 | Extra Mythic Ability: Rupture Restraints | Greater Trick utility (Mobility or Knowledge) |

Perception II supplies the critical line for the melee attackers, while Persuasion I–III is the Inciter’s control finisher. If your party already has a stronger Persuasion controller, use the MR9–10 trick slots for Mobility or Lore (Religion) instead. Azata is the alternative for a caster-heavy team: take Favorable Magic, Zippy Magic, Life-Bonding Friendship and Incredible Might, then keep Spell Focus: Enchantment and Selective Spell as the core.

## IE MR10 mythic sequence

1. Last Stand  
2. Extra Mythic Ability: Abundant Casting  
3. Improved Abundant Casting  
4. Extra Mythic Ability: Mythic Inspiration  
5. Enforced Vigor  
6. Mythic Spell Penetration  
7. Favorite Metamagic: Selective  
8. Mythic Spell Focus: Enchantment  
9. Inspirational Leader  
10. Extra Mythic Ability: Rupture Restraints (or Mythic Improved Initiative)

## IE Legend adaptation

At fresh IE Legend, retain only the first two Mythic Hero choices. Do not plan on Mythic Inspiration, Enforced Vigor, Mythic Spell Penetration, or Mythic Spell Focus from later ranks.

For a level-40 Legend extension, use:

**Skald (Inciter) 20 / Mutation Warrior 20** — this is an adaptation, not the Neoseeker source. Keep the Skald spellbook and song as the core; use the extra Fighter levels for bonus feats, mutagen and weapon training. Recommended extra feat priorities are Outflank, Dazzling Display, Shatter Defenses, Improved Critical for the chosen weapon, Weapon Focus, Weapon Specialization, Combat Reflexes, Seize the Moment, Blind Fight and Toughness. Do not expect Trickster Persuasion or later Inciter mythic feats after taking fresh IE Legend.

### Inciter party configuration

Use Inciter as the first-round party engine, not as a solo damage dealer:

1. **Inciter 20 (Trickster):** activate Raging Song with Accept Rage on the melee attackers, Lethal Stance and Beast Totem. Open with Greater Heroism, Good Hope and Haste; use Selective Confusion, Song of Discord and Overwhelming Presence only after the party is in position.
2. **Kinetic Sharpshooter 20:** the ranged finisher. It benefits from the song’s shared sneak dice and the Inciter’s enemy AC/Will penalties while staying outside melee.
3. **Brown-Fur Transmuter or other Arcanist:** Greater Magic Weapon, Legendary Proportions or Transformation, Echolocation and emergency Displacement/Greater Invisibility.
4. **Cleric/Oracle buffer:** Guarded Hearth, communal True Seeing, Death Ward, Protection from Energy and Remove Fear; this slot keeps the song user from spending turns on defensive cleanup.
5. **Full-BAB frontliner:** Mutation Warrior, Demonslayer or Sohei with Outflank/Seize the Moment to turn shared sneak dice into reliable melee damage.
6. **Flexible control/heal slot:** a Divine Hound, Witch or Loremaster for Frightful Aspect, dispels, heal and condition removal. A concrete companion shell is **Seelah + Regill + Ulbrig + Arueshalae/Wenduag**; replace one slot with **Sosiel or Daeran** when you need a dedicated divine buffer.

Before a boss: apply party buffs, position the two melee attackers for flanks, turn on the song, then use Inciter’s Dispel/Selective control while KSS and the frontliners spend their turns attacking. If the party is caster-heavy, replace the second frontliner with an Azata-compatible controller and use Favorable Magic; the Inciter core remains unchanged.

---

# DLC6 — Kinetic Sharpshooter (SS)

**Absolute strongest IE Mythic route:** Kinetic Sharpshooter 20 / Trickster MR10, with a Heavy Crossbow.
**Legend-only route:** Kinetic Sharpshooter 20 / Mutation Warrior 20, documented below as the 1–40 alternative.

The current [Neoseeker class-ranking page](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Class_Rankings) rates Kinetic Sharpshooter SS. The established DLC6 source is [InEffect's Kinetic Archer Wenduag](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Kinetic_Archer_Wenduag_%28DLC6%29), which is Fighter 1 / Kinetic Sharpshooter 19 because Wenduag already has Fighter 1.

KSS Charged Ammunition uses the equipped ranged weapon's attack, enhancement/applicable weapon properties and critical profile; community testing reports that base weapon dice and STR/composite damage are ignored; see the [KSS comprehensive test thread](https://www.reddit.com/r/Pathfinder_Kingmaker/comments/1vnrrjs/pathfinder_wrath_of_the_righteous_comprehensive/). It delivers only one kinetic blast per turn. It cannot Gather Power or use Deadly Earth. These rules are documented in the [GameFAQs Kineticist guide](https://gamefaqs.gamespot.com/pc/354971-pathfinder-wrath-of-the-righteous-inevitable-excess/faqs/80843/kineticist#Kinetic%20Sharpshooter) and the [LUDO KSS guide](https://origin.ludo.guide/guide/pathfinder-wrath-of-the-righteous/kinetic-sharpshooter).

Fresh IE has two mutually exclusive starting structures. The mythic entry is class level 20/MR10; the Legend entry is level 40/MR3 and does not continue through MR4–10. See the [IE postlude](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/postlude-inevitable-excess), [Legend mechanics](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/other-mythic-paths) and the [IE path discussion](https://steamcommunity.com/app/1184370/discussions/0/4031346570751578331/).

## Creation

| Field | Choice |
|---|---|
| Race | Human |
| Background | Pickpocket: +2 initiative and Stealth/Trickery as class skills; see [background data](https://pathfinderkingmaker.fandom.com/wiki/Background) |
| Alignment | Chaotic Neutral; Kinetic Sharpshooter and Mutation Warrior have no alignment requirement. Change to Chaotic Evil or Neutral Evil only if you want a stricter Lamashtu roleplay. |
| Deity | Lamashtu (source-compatible and valid for CN/CE/NE); deity has no required KSS damage interaction. |
| Weapon | Heavy Crossbow. Weapon Focus and Improved Critical apply to the weapon used for Charged Ammunition; Kinetic Blast weapon focus does not. |
| Role | Single-target ranged damage, with optional line/AoE infusions. |
| Starting abilities | 25-point buy before racial bonus: STR 12, DEX 16, CON 16, INT 14, WIS 12, CHA 7. Human +2 goes to DEX, so level-1 DEX is 18. Put every normal level-up point into DEX at character levels 4, 8, 12, 16, 20, 24, 28, 32, 36 and 40 for the maximum charged-blast attack bonus. Put Grand Mutagen's largest physical-stat bonus on DEX for charged-blast accuracy; use gear and secondary mutagen bonuses for CON. Move the last two level-up points to CON only if you prefer survivability over hit chance.
| Skills | Max Perception, Stealth, Use Magic Device and Persuasion first. Your screenshot shows Persuasion only +4 while Mobility is already +32; move later ranks from Mobility into Persuasion if you intend to use Persuasion II/III. Use Trickery, Lore (Nature) or Knowledge (World) after those four priorities. Human + INT 14 supports this plan. |
| Spellbook | None. This build is not a caster. Use party buffs/scrolls: Greater Magic Weapon, Haste, Heroic Invocation, True Seeing, communal defenses and Transformation from a support caster. |

## Absolute strongest IE Mythic route: Kinetic Sharpshooter 20 / Trickster MR10

Use this route for a new IE character when your only criterion is the highest current KSS ceiling. It starts at level 20/MR10, so there is no level-1-to-40 campaign inside IE. KSS20 keeps the full blast progression, Infusion Specialization rank 6 and the live Critical Overdrive capstone; see the [KSS feature reference](https://pathfinderkingmaker.fandom.com/wiki/Kinetic_Sharpshooter). Older tests reported an x4 overwrite, but your current screenshot shows **18–20 and x5** with Mythic Improved Critical Heavy Crossbow active. Keep that feat on your current patch and recheck the combat log after a major game update.

### Primary creation and level plan

Use Human, Pickpocket, Lamashtu, Chaotic Neutral, Heavy Crossbow, the legal 25-point-buy spread above, and level-up DEX at 4/8/12/16/20. Max Perception, Stealth, Mobility and Use Magic Device; place spare ranks into Persuasion.

| Character level | Class | Feat | KSS element, infusion or feature |
|---:|---|---|---|
| 1 | KSS 1 | Point-Blank Shot; Human bonus Precise Shot | Fire; Charged Ammunition |
| 2 | KSS 2 | — | Fire's Fury |
| 3 | KSS 3 | Weapon Focus: Heavy Crossbow | Kinetic Quiver; select Burning Infusion |
| 4 | KSS 4 | — | Elemental Whispers: Hare |
| 5 | KSS 5 | Spell Penetration | Empowered Metakinesis; select Fan of Flames; Infusion Specialization rank 1 |
| 6 | KSS 6 | — | Heat Adaptation |
| 7 | KSS 7 | Deadly Aim | Expanded Element: Fire again; unlock Blue Flame |
| 8 | KSS 8 | — | Infusion Specialization rank 2; Skill Focus: Perception |
| 9 | KSS 9 | Greater Spell Penetration | Maximized Metakinesis; select Detonation; Torrent is the line alternative |
| 10 | KSS 10 | — | **Kineticist Bonus Feat — Fire → Iron Will** (the strongest combat choice for this utility slot) |
| 11 | KSS 11 | Improved Critical: Heavy Crossbow | Rending Arrows; Wall is the form alternative; Infusion Specialization rank 3 |
| 12 | KSS 12 | — | Kinetic Restoration |
| 13 | KSS 13 | Improved Improved Critical: Heavy Crossbow after Trickster Perception II | Honed Infusion; it ignores DR |
| 14 | KSS 14 | — | Infusion Specialization rank 4; **Skill Focus → Persuasion** |
| 15 | KSS 15 | Improved Improved Improved Critical: Heavy Crossbow | **Expanded Element: Air → Air Blast**; keep Electric Blast as the Touch-AC alternative only |
| 16 | KSS 16 | — | Expanded Defense: Air (grants Enveloping Winds) |
| 17 | KSS 17 | Improved Precise Shot | Pure-Flame for Blue Flame; combine with Rending only when Over-Infused Blasts works; Infusion Specialization rank 5 |
| 18 | KSS 18 | — | Aerial Evasion, which requires Enveloping Winds |
| 19 | KSS 19 | Improved Initiative or Blind-Fight | Chain Arrows; **Metakinetic Master — Empowered (default)**. Use Quicken only if your combat log proves it creates a second KSS blast. |
| 20 | KSS 20 | — | Celerity; **Critical Overdrive**; Infusion Specialization rank 6 |

**Level-10 exact choice:** select `Kineticist Bonus Feat — Fire`, then select `Iron Will`. Do not select `Skill Focus — Lore (Nature)` for this damage build. `Skilled Kineticist` is a utility alternative: it automatically buffs the skills added by your primary element, including Fire's `Lore (Nature)`, but it does not increase blast attack, damage, crit range or infusion power.

**Level-14 exact choice:** open `Skill Focus` and select **Skill Focus — Persuasion**. This supports the normal Trickster Persuasion I/II route and is the strongest general choice for this build. It is a combat-control investment, not a blast-damage bonus: Persuasion I demoralizes enemies as combat begins, and Persuasion II can paralyze demoralized enemies that fail their Will saves. If your screen still shows Persuasion at 0 ranks, move the 14 Mobility ranks into Persuasion before completing the level-up. `Skill Focus — Stealth` is a defensive/stealth fallback, mainly for the fresh Legend variant that does not continue the normal Trickster trick chain.

**Level-15 exact choice:** select `Expanded Element — Air`, then select **Air Blast**. Air Blast is physical bludgeoning damage with the Kineticist's higher physical-blast damage profile and does not require an SR check. Electric Blast targets Touch AC but is an energy blast that must overcome SR and is frequently resisted or immune in IE. Use Blue Flame for the primary energy-blast line; Air Blast is the physical backup and works with Honed/Rending options.

If Perception II is not visible when you respec, leave the two Trickster critical-feat slots open and select them after unlocking the trick. The final Trickster multiplier feat is deliberately omitted from the primary KSS20 route because current tests report Critical Overdrive hard-setting the blast multiplier at x4; use it only if your own log proves that it stacks.

### Primary mythic and spell plan

### First Ascension: exact click order for KSS

The First Ascension screen has two different choices that appear next to each other:

1. In the **Mythic Hero path-linked slot**, keep **Bit of Fun**. This is the Trickster-linked choice and is the correct selection for the KSS20/Trickster route. It creates three illusionary copies; it is defensive utility, not blast damage.
2. In the separate empty **Mythic Ability** slot (the plus-sign slot), select **Last Stand**. This is the generic Mythic Ability for MR1 and is the choice used by this build for IE boss survival.
3. Leave **Bypass Epic Damage Reduction** unchanged; it is the fixed rank-1 benefit shown on the progression panel.
4. At MR2, the panel is a **Mythic Feat** slot. Select **Extra Mythic Ability**, then select **Ascendant Element: Fire**. Do not look for Ascendant Element directly in the MR2 Mythic Feat list.

`Bit of Fun` does not itself finalize the later path selection. When the IE route presents the path choice, select **Trickster**, then take Perception I and Perception II as specified below.

- MR1: **Last Stand**; keep **Bit of Fun** in the Trickster-linked slot.
- MR2: **Extra Mythic Ability: Ascendant Element: Fire**. MR2 is a Mythic Feat slot, so Ascendant Element must be taken through Extra Mythic Ability.
- MR3: **Over-Infused Blasts**; choose Trickster and take Mythic Trick **Perception I**.
- MR4: **Weapon Focus (Mythic) — Heavy Crossbow**; take Improved Mythic Trick **Perception II** and Mythic Trick **Knowledge (World) I**. Your screenshot has this legal combination.
- MR5: **Rupture Restraints**; take Mythic Trick **Persuasion I**.
- MR6: **Spell Penetration (Mythic)**; take Improved Mythic Trick **Persuasion II** and Mythic Trick **Stealth I**.
- MR7: **Ranging Shots**; take Greater Mythic Trick **Persuasion III** and Mythic Trick **Infuse Magic Device**.
- MR8: **Deadly Aim (Mythic)**; take Improved Mythic Trick **Knowledge (World) II** and Mythic Trick **Lore (Religion) I**.
- MR9: **The Bigger They Are**; take Improved Mythic Trick **Reuse Magic Device** and Mythic Trick **Mobility I**. If you can respec, putting The Bigger They Are at MR7 and Ranging Shots at MR9 gives the earlier attack bonus; your current order is legal.
- MR10: **Improved Critical (Mythic) — Heavy Crossbow**; take Greater Mythic Trick **Knowledge (World) III** and Mythic Trick **Knowledge (Arcana) I**. Your screenshot’s x5 threat profile confirms that this feat is active on your current patch.
- There is no hard feat/ability conflict in the screenshot. The only practical conflict is investment: Persuasion II/III is weak at Persuasion +4 and CHA 7. Move ranks out of Mobility, add Eagle’s Splendor/CHA gear, and keep the tricks only if you want their control effect.
- **Kinetic Overcharge** remains a bad KSS pick: its prerequisite and effect use `Gather Power`, which KSS replaces with Kinetic Quiver.
- Use **Trick Fate** before an IE boss. The [Trickster guide](https://gamefaqs.gamespot.com/ps4/324475-pathfinder-wrath-of-the-righteous/faqs/80843/trickster) documents Perception II, the critical feats and Trick Fate.
- KSS has no class spellbook. Party casters or scrolls provide Greater Magic Weapon, Haste, Heroic Invocation/Greater Heroism, True Seeing, Death Ward, communal defenses and Transformation.

### Trickster spell picks for KSS

The Trickster spellbook is utility for this build; it does not increase Charged Ammunition damage. Prefer no-save self-buffs and movement tools over low-DC offensive spells.

| Mythic rank | Spell level | Exact priority picks |
|---:|---:|---|
| 1 | 1 | **Expeditious Retreat**, **Reduce Person**, **Vanish**. Grease is the spare control slot; Feather Step is the terrain alternative. |
| 2 | 2 | **Blur**, **Mirror Image**, **Invisibility**. Keep Cat’s Grace only when no other caster supplies Dexterity. |
| 3 | 3 | **Displacement**, **Invisibility, Almost Greater**, **Slow**. Hallucinogenic Cloud is the lower-priority control alternative. |
| 4 | 4 | **Greater Invisibility**, **Chameleon Stride, Greater**, **Phantasmal Killer**. Replace the offensive pick with Mass Reduce Person if your DC is poor. |
| 5 | 5 | **Microscopic Proportions**, **Phantasmal Web**, **Mind Fog**. Dominate Person is a single-target alternative; Rain of Halberds is a damage filler. |
| 6 | 6 | **Cat’s Grace, Mass**, **Phantasmal Putrefaction**, **Umbral Strike**. Use Eagle’s Splendor, Mass only for a Persuasion-heavy setup. |
| 7 | 7 | **Trick Fate**, **Mass Invisibility**, **Insanity**. Greater Shadow Conjuration is the safe replacement when Insanity’s save is unreliable. |
| 8–10 | extra slots | No new spell level is required. Add extra casts of **Greater Invisibility**, **Displacement**, **Cat’s Grace, Mass**, **Phantasmal Web/Putrefaction** and **Trick Fate**. |

Keep **Reduce Person** for the strict combat route: it can provide a size-based attack benefit and Dexterity if no stronger Dexterity enhancement or size-changing buff is already active. Use **Feather Step** instead only if you deliberately avoid size changes and value terrain mobility more than attack accuracy. These are Trickster utility spells; they do not increase Charged Ammunition damage.

### Screenshot audit and optimization notes

Your attached level-20 sheet is internally legal: Heavy Crossbow focus, the full Perception critical chain, Spell Penetration (Mythic), Ranging Shots, The Bigger They Are, Deadly Aim (Mythic), Mythic Improved Critical and the three Trickster skill lines can coexist. The sheet also shows **18–20 / x5**, so the old x4 warning does not apply to this save. Keep Mythic Improved Critical Heavy Crossbow unless a future patch changes the combat log.

Your only real weakness is skill allocation. Persuasion is +4 while Mobility is +32, so Persuasion II/III will not reliably paralyze or demoralize high-Will enemies. Move later ranks from Mobility to Persuasion and use Eagle’s Splendor or Charisma gear. If you do not want to respec skills, treat Persuasion as utility and leave the rest of the mythic sequence unchanged.

At KSS19, the screenshot shows Metakinesis — Quicken. For a one-blast-per-turn KSS, **Empowered** is the strongest default because it adds damage without depending on a second blast bug. Keep Quicken only if the combat log visibly records two KSS blasts in one round; otherwise retrain to Empowered.

### Primary combat routine

- Boss without SR: Blue Flame + Rending Arrows.
- Boss with high SR: Blue Flame + Pure-Flame.
- If your patch accepts Over-Infused Blasts, combine Rending Arrows + Pure-Flame on Blue Flame for the strongest single-target line; confirm both Substance effects in the combat log.
- Line/cluster: unaltered Blue Flame + Chain Arrows.
- KSS normally delivers one Charged Ammunition blast per turn. **Metakinesis — Empowered** is the reliable sustained level-19 choice. Keep **Quicken** only when your own combat log shows that it creates a second KSS blast on the current patch; Rapid Shot and Manyshot do not add blasts.
- Create the Quiver with 1 Burn at KSS3 and refresh it when charges run out.
- Avoid Exploding Arrows as the default attack because current reports show inconsistent Quiver/Infusion Specialization discounts.
- KSS cannot use Gather Power, Deadly Earth, Kinetic Blade, Eruption, Blade Whirlwind, Extended Range or Fragmentation.

### KSS party configuration

Run KSS as the ranged finisher in a six-person team:

1. **KSS 20 / Trickster:** Fire → Fire → Air, Blue Flame for SR-resistant targets, Rending/Pure-Flame only when the combat log confirms both substance infusions, and Trick Fate for the boss turn.
2. **Inciter 20 / Trickster:** Accept Rage on the melee attackers, Lethal Stance, Beast Totem and shared sneak dice. The Inciter supplies the party-wide damage multiplier and enemy AC/Will pressure.
3. **Brown-Fur Transmuter or Arcanist:** Greater Magic Weapon, Haste, Heroic Invocation, Legendary Proportions/Transformation, Echolocation and emergency Greater Invisibility.
4. **Cleric/Oracle buffer:** Guarded Hearth, communal True Seeing, Death Ward, Protection from Energy, Freedom of Movement and Remove Fear.
5. **Full-BAB melee striker:** Mutation Warrior, Demonslayer or Sohei with Outflank and Seize the Moment. Keep this character adjacent to the Inciter so the song’s shared sneak dice and flanking trigger consistently.
6. **Control/heal flex:** Witch, Loremaster or Divine Hound for dispels, hexes, Frightful Aspect, Heal and condition removal.

Buff order is: communal defenses and Greater Magic Weapon, transmutations and Haste, Inciter song, then KSS Quiver and boss debuffs. KSS stays at range while the two melee characters create flanks; do not make the KSS spend turns chasing a target just to trigger Ranging Shots.

### Compatibility variant: KSS19 / Fighter1

The established Wenduag source and some older combat-log tests use Fighter1/KSS19 to avoid the current KSS20 blast-multiplier cap. Use the same Fire -> Fire -> Air progression, take Fighter1 first with Point-Blank Shot, Precise Shot and Deadly Aim, and stop KSS at 19. This is a patch-sensitive compatibility variant; the current maximum route is KSS20 because its threat-range bonus and rank-6 infusion discount remain valuable.

### Why Legend is a separate lower-ceiling option

Legend adds ability scores and ordinary class levels, but the KSS blast does not gain iterative attacks from extra BAB. Trickster adds the Perception critical line and Trick Fate, which directly multiply the one-blast-per-turn mechanic. Use the Legend table below only when you specifically want a level-40/MR3 character.

## Legend Mythic setup for fresh IE Legend

Choose Legend immediately at the IE Mythic Rank 3 setup. Do not plan a later Rank 4–10 path. Use the two retained Mythic Hero choices as follows:

1. **Mythic Rank 1 — Last Stand** for survival against IE boss burst.
2. **Mythic Rank 2 — Extra Mythic Ability: Ascendant Element: Fire** so Fire and Blue Flame are not stopped by fire resistance or immunity.

Prioritize Ascendant Element: Fire at the fresh Legend start because Blue Flame must ignore IE fire resistance and immunity. Mythic Improved Critical: Heavy Crossbow is already legal at character level 40, but it is a later/optional trade-off because KSS20 Critical Overdrive can overwrite the multiplier on some patches. Do not build around normal-campaign choices such as Over-Infused Blasts, Mythic Spell Penetration or later path abilities; they are not available after a fresh IE Legend start.

## Legend levels 1–40: Kinetic Sharpshooter 20 / Mutation Warrior 20

Fresh IE Legend is already character level 40 / Mythic Rank 3. This is a strict respec blueprint that places Mutation Warrior 1 first, then Kinetic Sharpshooter 1–20, then Mutation Warrior 2–20. That order gives the early full-BAB/bonus-feat benefit and makes Improved Critical legal at character level 11. It is a planning table, not a claim that a fresh IE Legend will literally play through forty campaign levels.

Use the legal 25-point-buy spread above. Put every level-up point into DEX at character levels 4, 8, 12, 16, 20, 24, 28, 32, 36 and 40 for maximum charged-blast accuracy. Put Grand Mutagen's largest physical-stat bonus on DEX for charged-blast accuracy; use gear and secondary mutagen bonuses for CON. Move the last two level-up points to CON only for a survivability trade-off.

| Character level | Class level | Normal feat / bonus feat | Infusion, element or class feature |
|---:|---|---|---|
| 1 | Mutation Warrior 1 | Normal: Point-Blank Shot; Human bonus: Precise Shot; MW bonus: Deadly Aim | Heavy Crossbow; Fighter proficiencies and bonus feat |
| 2 | KSS 1 | — | Fire; Charged Ammunition |
| 3 | KSS 2 | Weapon Focus: Heavy Crossbow | Fire's Fury |
| 4 | KSS 3 | — | Kinetic Quiver; select Burning Infusion |
| 5 | KSS 4 | Spell Penetration | Elemental Whispers: Hare |
| 6 | KSS 5 | — | Empowered Metakinesis; select Fan of Flames; Infusion Specialization rank 1 |
| 7 | KSS 6 | Greater Spell Penetration | Heat Adaptation |
| 8 | KSS 7 | — | Expanded Element: Fire again; unlock Blue Flame |
| 9 | KSS 8 | Improved Initiative | Infusion Specialization rank 2; Skill Focus: Perception |
| 10 | KSS 9 | — | Maximized Metakinesis; select Detonation; Torrent is the line alternative |
| 11 | KSS 10 | Improved Critical: Heavy Crossbow | **Kineticist Bonus Feat — Fire → Iron Will** |
| 12 | KSS 11 | — | Rending Arrows; Infusion Specialization rank 3 |
| 13 | KSS 12 | Blind-Fight | Kinetic Restoration |
| 14 | KSS 13 | — | Honed Infusion; Quicken Metakinesis |
| 15 | KSS 14 | Improved Precise Shot | Infusion Specialization rank 4; Skill Focus: Stealth |
| 16 | KSS 15 | — | Expanded Element: Air |
| 17 | KSS 16 | Critical Focus | Expanded Defense: Air (grants Enveloping Winds); Composite Specialization |
| 18 | KSS 17 | — | Pure-Flame Infusion for Blue Flame; Infusion Specialization rank 5 |
| 19 | KSS 18 | Improved Blind-Fight | Aerial Evasion or another legal Air utility |
| 20 | KSS 19 | — | Chain Arrows; Metakinetic Master |
| 21 | KSS 20 | Greater Blind-Fight if Perception 15; otherwise Toughness | Celerity; Critical Overdrive; Infusion Specialization rank 6 |
| 22 | MW 2 | Bonus: Combat Reflexes | — |
| 23 | MW 3 | Skill Focus: Use Magic Device | Mutagen; keep UMD ranks high |
| 24 | MW 4 | Bonus: Weapon Specialization: Heavy Crossbow | — |
| 25 | MW 5 | Great Fortitude | Weapon Training: Crossbows +1 |
| 26 | MW 6 | Bonus: Point-Blank Master: Heavy Crossbow | — |
| 27 | MW 7 | Toughness | Discovery: Preserve Organs |
| 28 | MW 8 | Bonus: Greater Weapon Focus: Heavy Crossbow | — |
| 29 | MW 9 | Skill Focus: Persuasion | Weapon Training: Crossbows +2 |
| 30 | MW 10 | Bonus: Advanced Weapon Training: Trained Initiative, or another legal combat feat | — |
| 31 | MW 11 | Improved Iron Will | Discovery: Preserve Organs again if offered |
| 32 | MW 12 | Bonus: Greater Weapon Specialization: Heavy Crossbow | — |
| 33 | MW 13 | Skill Focus: Mobility | Weapon Training: Crossbows +3 |
| 34 | MW 14 | Bonus: Shake It Off if the party uses teamwork feats; otherwise a legal defensive combat feat | — |
| 35 | MW 15 | Lightning Reflexes | Discovery: Greater Mutagen |
| 36 | MW 16 | Bonus: Advanced Weapon Training: Fighter's Reflexes or Fighter's Tactics | — |
| 37 | MW 17 | Improved Lightning Reflexes or the best remaining defense | Weapon Training: Crossbows +4 |
| 38 | MW 18 | Bonus: Seize the Moment if using an attack-of-opportunity team; otherwise a legal combat feat | — |
| 39 | MW 19 | Dodge | Discovery: Grand Mutagen |
| 40 | MW 20 | Bonus: Snap Shot or another legal combat feat | Weapon Mastery: Heavy Crossbow; it automatically confirms critical hits and improves the weapon multiplier |

### How to attack

- **Single target with SR:** Blue Flame + Pure-Flame (one Substance infusion). Ascendant Element: Fire handles resistance/immunity; Pure-Flame handles Spell Resistance.
- **Single target without SR:** Blue Flame + Rending Arrows (one Substance infusion). Rending stacks an AC penalty up to –10. Rending and Pure-Flame cannot be combined without Over-Infused Blasts, which is unavailable in a fresh Legend start.
- **Line or cluster:** Use Detonation/Torrent. Chain Arrows is an unaltered-blast toggle and cannot be combined with Rending or Pure-Flame.
- **Burst turn:** Use Quicken for a second blast only if the current combat log proves two Charged Ammunition entries and the expected extra Quiver cost; otherwise use Empowered/Maximized for the single blast. Rapid Shot and Manyshot do not create extra KSS blasts.
- Read the combat log before assuming Weapon Specialization, Deadly Aim, elemental weapon procs or normal-arrow-only gear bonuses affect a charged blast.
## Optional demon-heavy split

If your specific IE party is fighting almost exclusively demons and you value the immediate +2 attack/+2 damage more than KSS20’s rank-6 infusion discount, use **Kinetic Sharpshooter 19 / Mutation Warrior 20 / Demonslayer Ranger 1**. The [IE Ranger guide](https://gamefaqs.gamespot.com/switch/392088-pathfinder-wrath-of-the-righteous-inevitable-excess/faqs/80843/ranger) states that Demonslayer grants +2 attack and damage against all three demon categories at Ranger 1 and calls the one-level dip excellent. This is a demon-target alternative, not the primary all-enemy IE build: KSS20 has Infusion Specialization rank 6, a final Wild Talent and lower sustained infusion costs, while IE also contains inevitables, constructs and other non-demon enemies.

## Current implementation cautions

- **Exploding Arrows:** the [Steam test report](https://steamcommunity.com/app/1184370/discussions/0/4551533524170492937/) found that Exploding Arrows do not receive the normal Infusion Specialization/quiver discount. Avoid them for single-target damage; use Torrent, Wall, Rending or Chain as appropriate.
- **Chain Arrows:** the KSS guide documents that Chain is an unaltered-blast form and cannot be combined with Rending/Pure-Flame. It is a line/cluster tool, not the default single-target shot.
- **Deadly Earth:** KSS cannot select it. Do not copy a normal Earth/Fire Kineticist control build into this archetype.
- **Weapon feats:** Weapon Focus and Improved Critical must name the equipped Heavy Crossbow, not Kinetic Blast; the GameFAQs KSS section documents this distinction. Weapon Specialization/Greater Weapon Specialization are included for the Fighter extension; if a current patch combat log shows that a specialization bonus is not propagated to Charged Ammunition, replace that one feat with Improved Initiative, Toughness or Iron Will.
- **Mythic timing:** fresh IE Legend is a level-40/MR3 setup. If you already started an IE character on another path and passed the available Legend selection, do not assume the main-campaign MR8 transition remains available; respec or restart according to the mode’s path screen.

---



# DLC6 — Sable Company Marine (S)

**Source build:** [InEffect’s Paladin Mercenary, DLC6](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Standard_Paladin_Mercenary_%28DLC6%29)  
**Dedicated DLC evaluation:** [A Dance of Masks New Content Evaluation](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/DLC/A_Dance_of_Masks_New_Content_Evaluation)  
**Rank source:** [Neoseeker Class Rankings](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Class_Rankings)

## Evaluation

Sable Company Marine is one of the best one-level dips in the entire game: it supplies a hippogriff with Flying Attack, a full-round mounted attack that bypasses terrain and leaves the target flat-footed. The full source build wraps that dip in a Lawful Good Paladin shell. The mount is the real reason for the S ranking. Treat the flying attack as a quality-of-life feature that can be janky in some encounters.

## Creation

| Field | Recommendation |
|---|---|
| Race | Half-Elf (Kindred) |
| Alignment | Lawful Good |
| Deity | Sarenrae — adaptation; the source is silent, but its Dawnflower Kiss and War-Kilt of Sarenrae items make this thematic |
| Background | Pickpocket |
| Skills | Athletics 20; Use Magic Device 1; Perception spare |
| Role | Mounted Paladin tank/damage dealer |
| Stats | STR 16, DEX 7, CON 14, INT 7, WIS 10, CHA 21 → 26 |
| Core items | Fencer’s Gift or Gloves of Dueling; Righteous Crusader’s Ring; Half of the Pair; Boots of Stampede; Dawnflower Kiss (Good); Tower Shield; Robe of Order; Shy Lily’s Helmet; Life Infuser; Bracers of Animal Fury |

## Class

**Paladin 13 / Sohei Monk 1 / Sable Company Marine Ranger 1 / Mutation Warrior Fighter 5**

## Rider progression

| Level | Take |
|---:|---|
| 1 | Paladin: Improved Initiative |
| 2 | Ranger (Sable Company Marine) |
| 3 | Sohei: Boon Companion; Mounted Shield |
| 4 | Paladin |
| 5 | Paladin: Shield Focus |
| 6 | Paladin |
| 7 | Paladin: Outflank; Animal |
| 8 | Paladin |
| 9 | Paladin: Improved Critical: Scimitar |
| 10 | Paladin |
| 11 | Paladin: Weapon Focus: Scimitar |
| 12 | Paladin |
| 13 | Paladin: Medium Armor Focus |
| 14 | Fighter: Lunge |
| 15 | Fighter: Dazzling Display; Shatter Defenses |
| 16 | Fighter |
| 17 | Fighter: Toughness; Weapon Specialization: Scimitar |
| 18 | Fighter: Heavy Blades |
| 19 | Paladin: Back to Back |
| 20 | Paladin |

**Mercies:** Fatigue; Sickened; Exhaustion; Blindness.

## Paladin spell priority

| Spell level | Spells |
|---:|---|
| 1 | Grace; Divine Favor; Lesser Restoration |
| 2 | Aura of Courage; Bestow Grace; Remove Paralysis |
| 3 | Archon’s Aura; Delay Poison |
| 4 | Eaglesoul; Inspiring Recovery |

## IE MR10 mythic reference sequence

1. Master Shapeshifter  
2. Improved Critical (Mythic): Scimitar  
3. Mythical Beast  
4. Extra Mythic Ability: Abundant Smite  
5. Last Stand  
6. Mythic Armor Focus (Medium Armor) — Assault  
7. Inspirational Leader, or Ever Ready  
8. Weapon Specialization (Mythic): Scimitar  
9. Mythic Charge  
10. Improved Initiative, or Extra Mythic Ability: Rupture Restraints

## Hippogriff

- Pet type: Hippogriff, Bulwark.
- Pet skills: Mobility and Perception.
- Pet items: Half of the Pair; Bracers of Armor; Ultimate Predator; Helmet of Comradery; War-Kilt of Sarenrae; Misty Cover; or Clear Vision, Lizard Tail and a Cloak of Resistance.
- Pet feats: Dodge (1); Diehard (3); +1 INT or +1 DEX (4); Improved Unarmed Combat (5); Crane Style (7); +1 DEX (8); Outflank (9); Crane Wing (11); +1 DEX (12); Crane Riposte (13); Combat Reflexes (15); +1 DEX (16); Toughness (17); Back to Back (19).

## IE Legend adaptation

Keep the mount and Paladin core; do not rely on later Mythic Charge or Mythical Beast ranks.

For a level-40 Legend extension, use:

**Paladin 20 / Sohei 1 / Sable Company Marine 1 / Mutation Warrior 18** — adaptation. This keeps a level-20 Paladin, the Sable hippogriff and a large Fighter feat/mutagen package. The source’s pet plan remains the same; use the rider’s extra feats for mounted combat, critical, weapon specialization, Combat Reflexes, Seize the Moment and defensive feats.

---

# DLC5 — Ghost Rider / Riding Vivisectionist (S)

**Source build:** [InEffect’s Riding Vivisectionist Mercenary](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Riding_Vivi_Mercenary)  
**Dedicated DLC evaluation:** [The Lord of Nothing New Content Evaluation](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/DLC/The_Lord_of_Nothing_New_Content_Evaluation)  
**Rank source:** [Neoseeker Class Rankings](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Class_Rankings)

## Evaluation

The dedicated DLC review highlights Ghost Rider as a strong one-level dip for Etheric Tether. The current class-ranking page rates it S and notes two viable directions: a one-level tether dip or a full paralysis-DC build. The source build below chooses the one-level dip and uses the rest of the levels for a mounted Vivisectionist/Sacred Huntsmaster chassis.

## Creation

| Field | Source |
|---|---|
| Race | Tiefling (Motherless) |
| Alignment | Lawful Good or Lawful Neutral |
| Deity | Erastil |
| Background | Pickpocket |
| Skills | Athletics; Perception; spare points as the party requires |
| Role | Mounted damage/support; shield infusions; pet safety |
| Stats | STR 19 → 24, DEX 7, CON 14, INT 12, WIS 16, CHA 7 |
| Recommended gear | Finnean; Mutilated Angel; Gloves of Deathdealer; Amulet of Mighty Fists; Mask of Rapid Bites; Belt and Headband of Perfection +6 |

## Class

**Ghost Rider Cavalier 1 / Sacred Huntsmaster Inquisitor 8 / Vivisectionist Alchemist 8 / Sohei Monk 2 / Demonslayer Ranger 1**

## Level-by-level feats and abilities

| Level | Take |
|---:|---|
| 1 | Cavalier (Ghost Rider): Power Attack |
| 2 | Alchemist |
| 3 | Alchemist: Focused Strike; Infusion |
| 4 | Monk (Sohei): Improved Initiative |
| 5 | Alchemist: Boon Companion |
| 6 | Alchemist: Outflank |
| 7 | Alchemist: Accomplished Sneak Attacker |
| 8 | Alchemist: Weapon Focus: Glaive |
| 9 | Alchemist: Lunge |
| 10 | Inquisitor: Community domain |
| 11 | Inquisitor: Improved Critical: Glaive |
| 12 | Inquisitor: Back to Back |
| 13 | Inquisitor: Extend Spell |
| 14 | Inquisitor |
| 15 | Inquisitor: Spell Focus: Abjuration; Precise Strike (requires temporary Web Strider and a +4 DEX item) |
| 16 | Inquisitor: Dazzling Display |
| 17 | Inquisitor: Spell Specialization: Shield (quality-of-life choice) |
| 18 | Alchemist: Shatter Defenses |
| 19 | Ranger: Armor Focus: Light |
| 20 | Monk: Combat Reflexes |

## Inquisitor spellbook

| Spell level | Spells |
|---:|---|
| 1 | Divine Favor; Magic Weapon; Bless; Remove Fear; True Strike |
| 2 | Remove Paralysis; Lesser Restoration; Cure Moderate Wounds |
| 3 | Cure Serious Wounds; Delay Poison |

## Alchemist spellbook

| Spell level | Spells |
|---:|---|
| 1 | Shield |
| 2 | Barkskin; Animal Aspect; False Life |
| 3 | Delay Poison |

## IE MR10 mythic reference sequence

1. Last Stand  
2. Power Attack  
3. Impossible Domain: Animal  
4. Improved Critical (Mythic)  
5. Master Shapeshifter  
6. Extra Mythic Ability: Mythical Beast  
7. Abundant Casting  
8. Light Armor Focus — Assault  
9. Abundant Bane  
10. Any; the source suggests Rupture Restraints or Inspirational Leader

## Horse

- Pet type: Horse.
- Pet skills: Mobility and Perception.
- Pet feats: Bulwark and Dodge (1); Diehard (3); +1 INT (4); Improved Unarmed Combat (5); Crane Style (7); +1 DEX (8); Blind Fight (9); Crane Wing (11); +1 DEX (12); Crane Riposte (13); Iron Will (15); +1 DEX (16); Improved Iron Will (17); +1 DEX (18); Toughness (19); +1 DEX (20).

## IE Legend adaptation

The source build remains useful because its core is class-based: Etheric Tether, Vivisectionist infusions, Sacred Huntsmaster domain access, Sohei and a Demon-focused dip. Do not rely on the source’s Mythic Rank 4–10 list.

For a level-40 Legend extension, use:

**Ghost Rider 1 / Sacred Huntsmaster 8 / Vivisectionist 12 / Sohei 6 / Demonslayer 1 / Mutation Warrior 12** — adaptation. This keeps the original 20-level core, increases Vivisectionist and Sohei, and uses Mutation Warrior for the remaining levels.

---

# DLC5 — Weretouched (S)

**Source build:** [InEffect’s Demonic Shifter](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Demonic_Shifter)  
**Dedicated DLC evaluation:** [The Lord of Nothing New Content Evaluation](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/DLC/The_Lord_of_Nothing_New_Content_Evaluation)  
**Rank source:** [Neoseeker Class Rankings](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Class_Rankings)

## Evaluation

Weretouched is a strong natural-attack tank/damage dealer. The source specifically warns that much shapeshifting gear does not work correctly with Weretouched and that Use Magic Device is needed for Seamantle scrolls. The source’s Demon aspects are powerful, but a fresh IE Legend cannot select Demon and then transition later; this document therefore removes the Demon-only loop from the recommendation.

## Creation

| Field | Recommendation |
|---|---|
| Race | Human |
| Alignment | Any |
| Deity | Lamashtu; the source says this is thematic and mechanically replaceable |
| Background | Martial Disciple |
| Skills | Mobility 3; Athletics 20; Perception 20; Use Magic Device 20; Stealth spare |
| Role | Natural-attack tank/damage dealer |
| Stats | STR 19 → 24, DEX 14, CON 12, INT 7, WIS 16, CHA 9 |
| Core items | Mask of Nothing; Broken Trickster; Amulet of Mighty Fists; Icy Protector; Ring of Imminent Demise; Apprentice Robe; Embroidered Gloves; Bracers of Balance; Belt +8 |
| Scroll requirement | A +2 CHA item is needed to cast Seamantle scrolls |
| Gear bug note | Bestial Rags would be preferable if its Weretouched interaction is ever fixed |

## Class

**Shifter (Weretouched) 17 / Stigmatized Witch 1 / Fighter 1 / Demonslayer Ranger 1**

The Fighter level is explicitly swappable in the source.

## Level-by-level feats and abilities

| Level | Take |
|---:|---|
| 1 | Shifter: Extended Aspects; Dodge |
| 2 | Shifter |
| 3 | Shifter: Crane Style |
| 4 | Shifter |
| 5 | Stigmatized Witch: Lizard familiar; Plagued curse; Iceplant; Outflank |
| 6 | Shifter |
| 7 | Shifter: Shifter Multiattack |
| 8 | Shifter |
| 9 | Improved Critical: Claw |
| 10 | Shifter |
| 11 | Weapon Focus: Claw |
| 12 | Shifter |
| 13 | Dazzling Display |
| 14 | Shifter |
| 15 | Shatter Defenses |
| 16 | Shifter |
| 17 | Power Attack |
| 18 | Shifter |
| 19 | Demonslayer Ranger: Focused Strike |
| 20 | Fighter: Improved Initiative |

## Spell priority

The source’s Witch spell entry is:

| Source spell level | Spell |
|---:|---|
| 1 | Mage Armor |

The source also lists Demon-only spells that are **not available** to a fresh IE Legend who chooses Legend at MR3:

- Enlarge Person
- Mirror Image
- Haste
- Telekinetic Strike
- Profane Hymn
- Abyssal Skin
- Telekinetic Burst

For the IE Legend adaptation, obtain the same defensive functions from party casters or scrolls:

- Mage Armor
- Mirror Image
- Haste
- Seamantle
- Legendary Proportions or Frightful Aspect from a support caster
- True Seeing and communal defenses as needed

## IE MR10 mythic reference sequence

1. Danse Macabre; Last Stand  
2. Extra Mythic Ability: Master Shapeshifter  
3. Archmage Armor  
4. Improved Critical (Mythic)  
5. Mythic Charge  
6. Dodge (Mythic)  
7. Rupture Restraints  
8. Power Attack  
9. Inspirational Leader or Ever Ready  
10. Flawless Attacks

## IE Legend adaptation

Use only the fresh IE Legend Mythic ranks that the mode provides. Do not use Demon aspects, Kalavakus trip loops or Demon spell slots.

For a level-40 Legend extension, use:

**Shifter (Weretouched) 20 / Stigmatized Witch 1 / Fighter 18 / Demonslayer Ranger 1** — adaptation. The extra Shifter levels finish the class, while Fighter supplies the additional martial feats and Demonslayer remains a useful demon-focused dip.

---

# DLC5 — Geomancer (S)

**Source build:** [InEffect’s Burning Ember, DLC5](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Burning_Ember_%28DLC5%29)  
**Rank source:** [Neoseeker Class Rankings](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/guides/Class_Rankings)

## Evaluation

Geomancer is the best caster in this S/SS subset for a direct fire-ray plan. The source describes a ray Witch with AoE support, approximately 600 damage on a Hellfire Ray critical, and roughly 30 extra damage per round from Geomancy in AoE situations. The build remains usable in IE Legend because its core damage comes from spell selection, metamagic, gear and class features rather than a merged Mythic spellbook.

The source page is written for Ember and therefore does not repeat race, deity, alignment or background. For a new IE mercenary, use the completion fields below.

## Creation

| Field | Ember source | New mercenary completion |
|---|---|---|
| Race | Companion-fixed | Human or any race with useful Charisma/Dexterity |
| Alignment | Companion-fixed | Any |
| Deity | Companion-fixed/irrelevant | Any |
| Background | Companion-fixed/implicit | Pickpocket |
| Skills | Knowledge: World; Stealth; Use Magic Device spare | Same |
| Role | Fire ray damage, AoE, hex support |
| Stats | STR 9, DEX 16, CON 12, INT 12, WIS 13, CHA 17 → 22 | Same |
| Mandatory gear | Legacy of the Last Azlanti; Goggles of Piercing Gaze; Deadly Rays; Cloak of Carnage; Call of the Fiery Things or Robes of Fire; Pristine Mind; Ring of Pyromania; Steady Finger; Red Salamander; Gloves of Arcane Eradication; Scorching Bracers; Boots of Arcane Persistence; Ashmaker; Triceratops Statuette; Greater Maximize Rods; Quicken Rods |

## Class

**Stigmatized Witch 10 / Geomancer Sorcerer 1 / Loremaster 9**

## Level-by-level feats, secrets and spells

| Level | Take |
|---:|---|
| 1–3 | Stigmatized Witch opening levels; reserve the first Witch feat choices for the source’s level-4 table |
| 4 | Protective Luck |
| 5 | Spell Penetration |
| 6 | Cackle |
| 7 | Geomancer Sorcerer: Bolster Spell; Greater Spell Penetration; Gold bloodline |
| 8 | Witch |
| 9 | Skill Focus: World; Fortune |
| 10 | Loremaster: Druid spell — Barkskin |
| 11 | Loremaster: Spell Focus: Evocation |
| 12 | Loremaster: Rogue Secret — Combat Trick → Greater Weapon Focus: Ray |
| 13 | Weapon Focus: Ray |
| 14 | Improved Critical: Ray |
| 15 | Greater Spell Focus: Evocation |
| 16 | Loremaster: Cleric spell — Divine Power |
| 17 | Empower Spell |
| 18 | Witch |
| 19 | Elemental Focus: Fire; Beast’s Gift |
| 20 | Loremaster: Cleric spell — Mass Heal |

## Spell priority

Spells marked with an asterisk are supplied by the curse or gear in the source and do not need to be learned normally.

| Spell level | Spells |
|---:|---|
| 1 | Unbreakable Heart; Cure Light Wounds; Ear-Piercing Scream; Mage Armor; Reduce Person |
| 2 | Scorching Ray*; Burning Arc*; Glitterdust; Cure Moderate Wounds; Bone Fists |
| 3 | Stinking Cloud; Heroism; Cure Serious Wounds; Fireball* |
| 4 | Death Ward; Dimension Door; Cure Critical Wounds; Greater False Life |
| 5 | Feeblemind |
| 6 | Greater Heroism; Raise Dead; Greater Dispel Magic |
| 7 | Heal; Legendary Proportions; Hellfire Ray*; True Seeing (communal) |
| 8 | Mind Blank; Summon Monster VIII |
| 9 | Foresight; Heroic Invocation |

### Metamagic priorities

- Bolster: Scorching Ray; Burning Arc; Fireball; Controlled Fireball; Fire Snake; Hellfire Ray (level 6 and level 7 versions); Firestorm.
- Bolster + Empower: Scorching Ray; Fireball; Hellfire Ray (level 6 version).

## IE MR10 mythic reference sequence

1. Ascendant Element: Fire  
2. Extra Mythic Ability: Abundant Casting  
3. Improved Abundant Casting  
4. Improved Critical (Mythic)  
5. Last Stand  
6. Mythic Spell Penetration  
7. Greater Abundant Casting  
8. Extra Mythic Ability: Favorite Metamagic: Bolstered  
9. Master Shapeshifter  
10. Mythic Spell Focus

The source uses Animal Aspect or a similar transformation effect to trigger Master Shapeshifter; provide that buff from a Brown-Fur Transmuter or Alchemist if you use this normal-campaign sequence.

## IE Legend adaptation

Take Ascendant Element: Fire and the most useful casting/defensive options from the three IE Mythic ranks. Do not depend on the later Abundant Casting chain, Mythic Spell Penetration, Master Shapeshifter or Mythic Spell Focus entries from the source.

For a level-40 Legend extension, use:

**Stigmatized Witch 20 / Geomancer Sorcerer 1 / Loremaster 19** — adaptation. The original ray core stays intact; the extra Loremaster levels provide secrets and utility after normal caster-level breakpoints. Use your extra non-mythic feats for metamagic, ray accuracy, Spell Penetration, Improved Critical (Ray), Initiative and defensive survival.

---

## Final IE Legend build choices

If you want one build only:

1. **Kinetic Sharpshooter** for self-contained ranged damage.
2. **Inciter Skald** if the party is melee-heavy.
3. **Sable Marine + Paladin** for mounted frontline play.
4. **Geomancer** for fire-ray casting.
5. **Ghost Rider** for the mount/tether dip and mounted Vivisectionist.
6. **Weretouched** for natural attacks after removing Demon-only assumptions.

The central IE rule is the same for all six: select Legend at IE Mythic Rank 3 if that is the goal. For the IE Mythic entry, use the adapted MR10 sequence; for fresh IE Legend, every MR4–10 path feature is unavailable.
