# Angel IE Loadout

Inventory-only loadout for Hansen’s Inevitable Excess Angel Oracle party.
All blueprint IDs were verified against `report.txt`. Missing community BIS pieces are not invented.

**Profile:** `Profiles/Angel_Oracle_IE.json`  
**Last verified report:** 2026-10-02 03:10:21 (all Equip Profile rules PASS)

## How to apply

1. Load the Angel IE save with the six active party members.
2. Open Hansen Equipment Manager.
3. Click **Equip Profile**. The mod matches `Angel_Oracle_IE`, previews rules, and equips only **Ready** plans.
4. Optional: **Export Report** and compare against this document.

### Unequip rules

A profile rule with blueprint `__UNEQUIP__`, `none`, or empty string clears that slot (no insert). Used for Lann and Nenio armor so armor bonuses do not fight monk AC or bracers of armor.

### Donors

Some rules take an item from another character (`donor` / `donorUnitId`). Rule order matters: Lann takes Hansen’s natural armor amulet before Hansen equips Vellexia’s from Arueshalae.

---

## Hansen — Angel Oracle Seeker (full-slot audit)

Sources: Neoseeker / Fextralife Angel Oracle Seeker consensus, constrained to this save’s inventory.

**Missing from inventory:** Grave Singer, Robe of Virtue, Imminent Demise / Bane of Spirit, Flawless belt, Bracers of Balance, Haramaki of Divine Guidance.

| Slot | Decision | Blueprint | Why |
|---|---|---|---|
| Glasses | CHANGE | `DLC3_BrokenTricksterGlassesArtifactItem` | Consensus CHA/DC glasses; replaces Undeniable Truth |
| Head | CHANGE | `MaskOfNothingItem` | Consensus head; replaces Perfection +8 |
| Neck | CHANGE | `VellexiasMagnifyingAmuletItem` (from Arueshalae) | Consensus spell DC amulet |
| Primary | CHANGE | `FierySpellWeaverItem` | No Grave Singer; caster-focus staff |
| Gloves | CHANGE | `StarEmbroideredGlovesItem` (from Daeran) | SR 30 + luck saves |
| Cloak | KEEP | `Artifact_AngelCloakItem` | Bound of Possibility (Angel mythic cloak) |
| Ring 2 | KEEP | `DLC3_RingOfInstantTriumphItem` | Triumphant Advance |
| Ring 1 | KEEP | `RingOfProtection7` | No Imminent Demise; Boreal Might only adds cold spells |
| Wrist | KEEP | `StormlordsResolveItem` | Spontaneous spell-list expansion |
| Shirt | KEEP | `DLC3_RobeOfTheSinmageItem` | Robe of the Seven Sins |
| Boots | KEEP | `BootsOfFreestReinItem` | Strong general boots for Oracle |
| Belt | KEEP | `BeltOfPerfection8` | No Flawless belt |
| Armor | KEEP | `SarkorianWeddingBreastplateItem` | Best available chest on this save |
| Secondary | KEEP empty | — | Staff is two-handed |

---

## Arueshalae — Ranger Master Spy (full-slot audit)

**Missing:** Instant Enemy gloves, Gloves of Dueling, Heart of Iceland. Vellexia moves to Hansen.

| Slot | Decision | Blueprint | Why |
|---|---|---|---|
| Neck | CHANGE | `AmuletOfNaturalArmor7` | Replace Vellexia after Hansen takes it |
| Shirt | CHANGE | `DLC3_RobeOfUnspeakableTruthItem` | +2 Wis for Instant Enemy / ranger spells; Seven Sins stays on casters |
| Primary | KEEP | `LongbowOfLeechingStrikeItem` | Best dedicated bow on this save |
| Armor | KEEP | `DLC3_DemonhideLeatherArmorItem` | Snakeskin: +4 profane Dex, speed, acid immunity |
| Head | KEEP | `DarknessCaressItem` | Charisma to ranged weapon damage |
| Glasses | KEEP | `GogglesOfMalocchioItem` | Bow crit disorient; Broken Trickster goes to Hansen |
| Ring 1 | KEEP | `RingOfProtection7` | Defense over Guiding Star opener damage |
| Ring 2 | KEEP | `ShootDownItem` | Merciless Shot |
| Gloves | KEEP | `BigGameGlovesItem` | Quarry −2 AC; no Instant Enemy gloves |
| Wrist | KEEP | `BracersOfArchery` | Archery kit |
| Boots | KEEP | `BootsOfFreestReinItem` | Strong general boots |
| Belt | KEEP | `BeltOfPerfection8` | Mangling Frenzy needs rage; no Skald |
| Cloak | KEEP | `CloakOfResistance7` | Call to Violence needs rage; Carnage is evocation DC |
| Secondary | KEEP empty | — | Two-handed bow |

---

## Lann — Zen Archer Monk (full-slot audit)

Zen Archers must stay **unarmored**. Body armor disables monk Wisdom AC and flurry.

| Slot | Decision | Blueprint | Why |
|---|---|---|---|
| Neck | CHANGE | `AmuletOfNaturalArmor7` (from Hansen) | Fill empty neck after Hansen swaps to Vellexia |
| Boots | CHANGE | `BootsOfFreestReinItem` | Fill empty feet |
| Armor | CHANGE unequip | `__UNEQUIP__` (was `ImpendingEclipseItem`) | Haramaki kills monk AC / flurry |
| Primary | KEEP | `FinneanCompositeLongbowStage3Base` | Stage 3 Finnean bow |
| Shirt | KEEP | `RobeOfOrderItem` | Monk-only robe; ki / lawful attack bonus |
| Glasses | KEEP | `GogglesOfMalocchioItem` | Bow crit utility |
| Head | KEEP | `HeadbandOfPerfection8` | Mental Perfection +8 |
| Ring 1 | KEEP | `RingOfProtection7` | Deflection |
| Ring 2 | KEEP | `ShootDownItem` | Merciless Shot |
| Gloves | KEEP | `DLC3_GlovesOfSurgicalExtractionItem` | Phlebotomy; no better archery gloves free |
| Wrist | KEEP | `BracersOfArchery` | Attack/damage over armor bracers on unarmored monk |
| Belt | KEEP | `BeltOfPerfection8` | Physical Perfection +8 |
| Cloak | KEEP | `CloakOfResistance7` | No Skald rage chain for Call to Violence |
| Secondary | KEEP empty | — | Two-handed bow |

**Not used:** `AmuletOfMightyFists5` (unarmed/natural weapons; Lann shoots a bow).  
**Not used:** Call to Violence (rage aura; worse than Resistance +7 here).

---

## Nenio — Wizard Scrollmaster (full-slot audit)

Sources: Neoseeker / InEffect Scroll Savant gear notes, inventory-limited.

**Missing:** Bane of Spirit, Magician’s Ring, Draven’s Hat, Sin Mage’s Staff.  
**Note:** Ring of Boreal Might requires spontaneous casting; Scrollmaster Wizard does not qualify.

| Slot | Decision | Blueprint | Why |
|---|---|---|---|
| Ring 1 | CHANGE | `RingOfProtection7` | Fill empty ring; +7 deflection beats Devastating Will’s +3 |
| Gloves | CHANGE | `GlovesOfArcaneEradicationItem` (from Ember) | +4 ranged touch (rays) + UMD |
| Boots | CHANGE | `BootsOfMagicalWhirlItem` | Quicken next spell after first demon kill |
| Armor | CHANGE unequip | `__UNEQUIP__` (was `ArrowCatcherItem`) | Armor bonus does not stack with Bracers of Armor +9 |
| Primary | KEEP | `MapPlaningBardicheItem` | Death’s Consonant (INT weapon) |
| Shirt | KEEP | `DLC3_RobeOfTheSinmageItem` | Seven Sins |
| Head | KEEP | `HeadbandOfPerfection8` | INT headband |
| Glasses | KEEP | `GogglesOfMindControlItem` | Enchantment DC |
| Neck | KEEP | `GlassAmuletOfClarityItem` | Enchantment DC; stays on Nenio |
| Ring 2 | KEEP | `DLC3_RingOfInstantTriumphItem` | Triumphant Advance |
| Wrist | KEEP | `BracersOfArmor9` | +9 armor AC |
| Belt | KEEP | `BeltOfPerfection8` | Physical Perfection |
| Cloak | KEEP | `LibrariansCloakItem` | Scroll CL +4 / UMD (Scrollmaster core) |
| Secondary | KEEP empty | — | Two-handed bardiche |

---

## Daeran — Life Oracle CHA healer (full-slot audit)

Powerless Prophecy wants freedom of movement-style boots. Star Embroidered Gloves move to Hansen.

| Slot | Decision | Blueprint | Why |
|---|---|---|---|
| Wrist | CHANGE | `ClearPurposeItem` | Heal without AoO + concentration; empty wrist |
| Gloves | CHANGE (donor) | empty after Equip Profile | Star Embroidered → Hansen; no better CHA/heal gloves left |
| Primary | KEEP | `RapierPlus5` | Filler; Fiery Spell Weaver goes to Hansen |
| Armor | KEEP | `ChainshirtAcidResistance30Plus5` | Medium armor + acid resist 30 |
| Shirt | KEEP | `DLC3_RobeOfTheSinmageItem` | Seven Sins |
| Head | KEEP | `HeadbandOfPerfection8` | CHA headband |
| Glasses | KEEP | `DLC3_GlassesOfundeniableTruthItem` | Broken Trickster goes to Hansen |
| Neck | KEEP | `AmuletOfNaturalArmor7` | Defense |
| Ring 1 | KEEP | `RingOfProtection7` | Deflection; Sacred Touch’s +1d6 heal is not worth losing +7 |
| Ring 2 | KEEP | `DLC3_RingOfInstantTriumphItem` | Triumphant Advance |
| Boots | KEEP | `BootsOfFreestReinItem` | Helps Powerless Prophecy; Magical Whirl goes to Nenio |
| Belt | KEEP | `BeltOfPerfection8` | Physical Perfection |
| Cloak | KEEP | `CloakOfResistance7` | Carnage is evocation DC |
| Secondary | KEEP empty | — | Healer, not shield tank |

**Not used:** Eldritch Scholar bracers (armor +6; does not stack with chainshirt).  
**Not used:** Boreal Might (cold list does not beat Prot +7 / Triumphant Advance).

---

## Sosiel — Cleric glaive + domain support (full-slot audit)

Sources: Jasonite / InEffect Cleric notes. Shelyn glaive proficiency and reach support.

**Important corrections vs early draft:**

- `InterceptorItem` is **not** on Sosiel’s Available list (rapier; Cleric is not proficient).
- Hopebringer requires a one-handed weapon and would force dropping **Mutilated Angel**.

| Slot | Decision | Blueprint | Why |
|---|---|---|---|
| Shirt | CHANGE | `ClothOfHeavyFortificationItem` | Fill empty shirt; fortification for front line |
| Ring 2 | CHANGE | `RingOfProtection7` | Replaces Righteous Crusader’s Ring (extra Smite Evil; Cleric has no Smite) |
| Boots | CHANGE | `BootsOfFreestReinItem` | Stampede is charge-damage only; Freest Rein is safer general use |
| Primary | KEEP | `DLC3_BeautyslasherGlaiveWeaponItem` | Mutilated Angel: +5 adamantine glaive, evil bonuses, stacking −AC |
| Secondary | KEEP empty | — | Two-handed glaive; Hopebringer stays in stash |
| Armor | KEEP | `MithralFullplateStandartPlus5` | Mithral full plate +5 |
| Head | KEEP | `HeadbandOfPerfection8` | +8 mental; Zaoris headband does not beat it |
| Glasses | KEEP | `GogglesOfPiercingGazeItem` | +1 vs outsiders |
| Neck | KEEP | `AmuletOfNaturalArmor7` | Defense |
| Ring 1 | KEEP | `RingOfEvasionItem` | Evasion on Reflex saves |
| Gloves | KEEP | `GlovesOfMartialExcellenceItem` | Unarmed-oriented; better gloves already assigned elsewhere |
| Wrist | KEEP | `BracersOfHeavyHandItem` | Off-hand damage; useless on 2H glaive but Clear Purpose is on Daeran; armor bracers do not stack with full plate |
| Belt | KEEP | `BeltOfPerfection8` | Physical Perfection |
| Cloak | KEEP | `CloakOfResistance7` | Call to Violence needs rage |

**Hopebringer left in inventory:** shield + mace is a pure tank line; this party keeps Sosiel on glaive reach / domains.

---

## Equip Profile rule checklist

| Character | Slot | Blueprint |
|---|---|---|
| Lann | Neck | `AmuletOfNaturalArmor7` ← Hansen |
| Lann | Feet | `BootsOfFreestReinItem` |
| Lann | Armor | `__UNEQUIP__` |
| Hansen | Glasses | `DLC3_BrokenTricksterGlassesArtifactItem` |
| Hansen | Head | `MaskOfNothingItem` |
| Hansen | Neck | `VellexiasMagnifyingAmuletItem` ← Arueshalae |
| Hansen | PrimaryHand | `FierySpellWeaverItem` |
| Hansen | Gloves | `StarEmbroideredGlovesItem` ← Daeran |
| Arueshalae | Neck | `AmuletOfNaturalArmor7` |
| Arueshalae | Shirt | `DLC3_RobeOfUnspeakableTruthItem` |
| Nenio | Ring1 | `RingOfProtection7` |
| Nenio | Gloves | `GlovesOfArcaneEradicationItem` ← Ember |
| Nenio | Feet | `BootsOfMagicalWhirlItem` |
| Nenio | Armor | `__UNEQUIP__` |
| Sosiel | Shirt | `ClothOfHeavyFortificationItem` |
| Sosiel | Ring2 | `RingOfProtection7` |
| Sosiel | Feet | `BootsOfFreestReinItem` |
| Daeran | Wrist | `ClearPurposeItem` |

KEEP slots are documented above but are **not** written as profile rules (already correct or intentionally left alone).
