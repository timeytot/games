# Pathfinder: Wrath of the Righteous - Builds

All retained build documents are in English. Each PvP category has one full natural-progression build. There is no final retraining variant, Toybox prerequisite bypass or separate archive of superseded builds.

## Build files

| Purpose | Configuration | File |
|---|---|---|
| Solo PvP | **Divination Wizard 20 / merged Lich MR10** | [Complete Lich build](./pathfinder-wrath/WOTR_Lich_Complete_Endgame_Build_EN.md) |
| Solo PvP | **INT Sword Saint 20 / Trickster MR10 / Death's Consonant Heavy Pick** | [Complete Sword Saint build](./pathfinder-wrath/SwordSaint_Trickster_INT_HeavyPick_IE_SoloPvP.md) |
| Solo PvP | **Sword Saint 20 / Swarm MR10 / Swarm Size 15 / up to five clones** | [Complete bounded Swarm build](./pathfinder-wrath/WOTR_SwordSaint_Swarm_Size15_Complete_Endgame_Build_EN.md) |
| Solo PvP | **Divination Wizard 20 / Aeon MR10** | [Complete Aeon build](./pathfinder-wrath/WOTR_Aeon_Divination_Complete_Endgame_Build_EN.md) |
| Boss PvE reference | Angel Oracle; Kinetic Sharpshooter; Inciter Skald | [PvE collection](./pathfinder-wrath/WOTR_IE_Complete_Endgame_Builds.md) |

## Shared solo-duel benchmark

- All DLC, character level 20 / MR10; Legend uses its legal level 40 progression. Turn-based combat; approximately 10 metres between the two main characters at the start.
- Both sides use the same player-character numerical/difficulty rules. No one-sided Unfair enemy-stat bonuses.
- Normal self-preparation is allowed. Spell, summon and feature durations continue to run during preparation and combat. The shortest buffs must still exist when used.
- Legal self-summons, path companions and class pets may participate, use their own actions and receive compatible allied buffs. Their resources, summoning limits, placement and equipment are declared. A summon is not an automatic interruption, hit or teleport blocker.
- Declare all accompanying units before initiative. They start on their controller's side of the opening gap; preparation does not include surrounding the opponent, attacking or applying hostile effects before combat. Each unit uses its actual initiative, actions and remaining resources.
- No external teammates, imported Repurpose army, unlimited rest/preparation loops, repeated combat resets, duplicated unique equipment or unearned campaign rewards. Use one rest's actual prepared/daily resources plus a declared finite owned consumable inventory.
- Declare the equipment loadout before initiative. An alternative item replaces the default in its slot; no simultaneous conflicting items or assumed free in-combat swaps.
- Natural progression means prerequisites and the correct ordinary/class/mythic selection menus must be satisfied when selected. A delayed class or mythic selection is allowed where the build explicitly requires it. No endpoint Hilor respec is assumed.
- Swarm requires an additional fixed Swarm Size, legal clone count and real equipment allocation. An unbounded farmed Swarm is not comparable to a bounded character.

Main-campaign rewards can be used if actually acquired and retained. A fresh Inevitable Excess character does not automatically own Razmir's Mask, a Phylactery or every other DLC reward. The build's legal item-acquisition requirement still applies.

## Mechanism-based comparison

These are **qualitative theory bands on a ten-point scale**, not measured win rates, statistical confidence intervals or a proven fixed ranking. They assess five equal considerations: initiative; usable actions and owned units; removable-buff pressure; offense after immunity/turning checks; and survival/recovery. The range expresses unresolved interactions and matchup variation. Overlapping bands do not establish an ordering.

Lich, Trickster Sword Saint, bounded Swarm Sword Saint and Aeon now have complete build files. Demon, Angel, Azata and Legend remain screening candidates rather than additional complete instructions. A blueprint/code audit is not a live round-robin duel test.

| Candidate | Theory band /10 | Main case for inclusion | Main limitation / unresolved check |
|---|---:|---|---|
| **Divination Wizard 20 / Lich** | **8.5-9.5** | Fixed initiative 20 plus school/familiar bonuses; high merged CL, multiple dispels, critical immunity, skeleton and finite summons. | Targeted Spell Turning can obstruct its main dispel/death sequence; Last Stand bypass is not established. Its ordinary SR:yes spell use is limited outside Deadly Magic. |
| **INT Sword Saint 20 / Trickster** | **8.0-9.5** | Fixed initiative 20, Trick Fate, Wizard-book defenses, swift domain approach, strong weapon and summon pressure. | Critical immunity prevents the advertised critical burst; safe removal against a mask and survival after enemy dispels remain decisive. Swift movement competes with Dimension Strike. |
| **Divination Wizard 20 / Aeon** | **8.5-9.5** | Fixed initiative 20; Zero State's +10 dispel checks; defensive edicts, Aeon's Bane and legal summons. | Zero State's 30-foot radius is shorter than a 10-metre opening; actual CL, movement and action costs matter. Edict of Invulnerability is not universal damage immunity. |
| Divination Wizard 20 / Demon | 8.0-9.5 | Wizard initiative foundation, demonic aspects and improved action use during the limited rage window. | Needs an actual aspect/resource schedule and immunity-safe offense; action flags are not proof of unlimited simultaneous casts. |
| Dual-Cursed Oracle 20 / merged Angel | 8.0-9.0 | Strong self-protection, healing, merged spells and finite summons. | Initiative and enemy dispelling can matter more than its PvE damage reliability. This is not the party-supported dipped Oracle in the PvE file. |
| Magic Deceiver 20 / Azata, including Aivu | 7.5-9.5 | Fusion options plus a legal additional path companion; allowing owned units improves its case compared with a no-summons benchmark. | Fusion targets, immunity, action costs and Aivu's current book must be checked. Multi-target spell value is not automatically single-target duel superiority. |
| Sword Saint 20 / Mutation Warrior 20, Trickster to Legend | 7.5-9.0 | Strong legal martial progression, attributes, initiative and damage. | Do not retain departed-path spells/tricks without evidence. Losing Trick Fate/UMD tools changes the matchup even if particular learned feats survive legally. |
| **Sword Saint 20 / bounded Swarm** | **8.5-9.5** | At Size 15, +19 to STR/DEX/INT/WIS/CHA, up to five clones, and Eye-enhanced Swarm Feast's reach/touch attacks create substantial pressure. | Size 15 is earned, not granted by MR10. Clones require real equipment and preparation; area vulnerability, force damage and Swarmbane can change matchups. Combined clone behavior still needs current runtime tests. |

**There is no demonstrated universal winner.** Lich remains a strong prepared-caster recommendation; Sword Saint remains a strong melee recommendation. Aeon, Demon and owned-unit paths cannot be excluded by applying a different rule set to them.

### Interpreting the proposed 96 / 95 / 94 / 93 ladder

The Swarm's stated Size-15 ability-score bonuses and five-clone ceiling are supported by the installed data. They make it a serious first-place candidate in this particular owned-unit benchmark. They do not establish that it beats every listed opponent, or justify one-point distinctions between untested builds. The table above deliberately uses overlapping bands instead of presenting 96/100 versus 95/100 as a measured ordering.

Eye of the Swarm supplies the STR/DEX bonus at MR9; The Swarm supplies INT/WIS/CHA at MR10. Neither supplies +19 CON. The bonuses are untyped, while SR becomes 40 at Size 15. The original and five clones are six bodies, not six copies of every unique item. Swarm Feast and Swarm Form are alternative modes: do not combine Feast's Eye-enhanced reach/touch attacks with Form's separate armor, damage and retaliation bonuses.

The earlier Lich-versus-Trickster initiative example below only compares those two declared loadouts. It does not apply unchanged to a Size-15 Swarm or give all clones their controller's equipment bonuses.

### A transparent initiative example

With the two retained builds' listed equipment, no additional permanent campaign rewards, no overlapping stat bonuses and Wind Breath contributing its actual+4:

| Component | Lich | Sword Saint |
|---|---:|---:|
| Fixed initiative die | 20 | 20 |
| Forewarned school bonus | 10 | - |
| Hare familiar | 4 | - |
| Lightning Draw: INT 32 | - | 11 |
| DEX with the listed+8 belt | 8, from DEX 26 | 6, from DEX 22 |
| Pickpocket | 2 | 2 |
| Improved Initiative | 4 | 4 |
| Improved Initiative (Mythic), MR10 | 10 | 10 |
| Wind Breath | 4 | 4 |
| **Illustrative total** | **62** | **57** |

This example favors the Lich's first turn; it is not a universal initiative ceiling or a victory result. Declare and recalculate food, permanent rewards, alternative equipment and any other legal modifiers for both sides. Sin Mage's Staff improves Lich INT/DC and slots; that Wizard does not add INT directly to initiative. Ring of Triumphant Advance has no verified Initiative feature, so Wind Breath is not budgeted as+8.

The new files add these distinct, fully declared examples:

| Acting unit | Illustrative initiative | Preparation / inventory assumption |
|---|---:|---|
| Size-15 Swarm Sword Saint, original | **74** | Its listed +6 mental headband, +8 physical belt and one Wind Breath |
| Each of five Swarm clones | **67** | A separately owned +4 INT headband and +4 physical belt for each; no copied Wind Breath |
| Unequipped Swarm clone | **63** | Innate Size-15 and class/feat bonuses only |
| Divination Wizard / Aeon | **65** | Its listed equipment and a still-active Perfect Form using base-stat differences |
| The same Aeon without Perfect Form | **62** | Its listed equipment only |

These are initiative calculations for the stated loadouts, not additional score points or proof that all six Swarm turns finish before any opponent can respond. They also do not supply a clone with its controller's items or a Wizard with the Sword Saint's INT-to-initiative feature.

### Interactions that prevent a definitive ladder

1. **Razmir's Mask occupies Glasses.** It conflicts with Goggles of Pure Sight, not a headband. Its Spell Turning is not restricted to SR:yes spells; SR:no therefore does not prove that Corrupt Magic or Absolute Death lands safely.
2. **Absolute Death is not a proven Last Stand bypass.** The inspected health/death code instead supports prevention of its ordinary kill action while the guard is effective. First activation and expiry still need a current runtime test.
3. **Trick Fate affects its owner's rolls.** It does not set an enemy Lich's dispel die to 20, and a natural20 does not bypass critical immunity or automatically pass a numerical dispel check.
4. **Allowing summons changes action pressure.** Lich gains its skeleton/army, Azata keeps Aivu, other paths use their own legal units, and a bounded Swarm may use legal clones. Every unit needs its own successful actions and can be removed or controlled.
5. **Physical immunity is not all damage immunity.** Current Bane of Spirit spends a swift action for temporary force conversion. Its action conflict and self-damage must be paid; this is not an unconditional free counter.

## Version and evidence

Reviewed 2026-10-30 against the installed Steam **build 20212986**, its [blueprint archive](<C:/Program Files (x86)/Steam/steamapps/common/Pathfinder Second Adventure/blueprints.zip>), English localization and read-only engine inspection. The build files distinguish blueprint-confirmed properties, code-derived expectations and combined interactions still requiring live tests. Public exports and older descriptions do not override the installed data.

Key primary references: [Razmir's Mask](https://wrath.bubbleprints.dev/bp/get/9338510a8d5c4b43b1284470b706128d?strings=true), [Corrupt Magic](https://wrath.bubbleprints.dev/bp/get/6fd7bdd6dfa9dd943b36d65faf97ac41?strings=true), [Absolute Death](https://wrath.bubbleprints.dev/bp/get/7d721be6d74f07f4d952ee8d6f8f44a0?strings=true), [Last Stand standby](https://wrath.bubbleprints.dev/bp/get/c5455f88975e16648b4abc47a28fa120?strings=true), [Trick Fate](https://wrath.bubbleprints.dev/bp/get/29d646e16e2539e45964f708f4c4f000?strings=true), [Wind Breath initiative enchantment](https://wrath.bubbleprints.dev/bp/get/de1d3eee66d7cff478b55384dcbd735d?strings=true). Additional primary entries and source limitations are listed inside each build.

The PvE collection permits allied support, fixes the Oracle AC/Paladin progression errors and remains separate from all of these solo-duel scores. No live round-robin PvP experiment has been performed.

Additional Swarm primary references: [Eye of the Swarm](https://wrath.bubbleprints.dev/bp/get/73c9302686b957d4dae298061eb9ffe1?strings=true), [The Swarm](https://wrath.bubbleprints.dev/bp/get/704d7f26933c3784ea28949e0c3511c0?strings=true), [Eye-enhanced Swarm Feast](https://wrath.bubbleprints.dev/bp/get/77558f3e79847bb448aa980a1aee326e?strings=true), and [clone creation code](https://github.com/xADDBx/WrathDecompiled/blob/6ce4a6ba6d35039cc73ba16faf70c2d9952a63c2/Assembly-CSharp/Kingmaker/UnitLogic/Parts/UnitPartLocustClonePets.cs). The linked public code snapshot is older; the corresponding clone buff-removal flow and main-character SwarmScale getter were also checked in the installed assembly. Combined combat outcomes remain untested.
