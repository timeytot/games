# Angel IE Loadout

Inventory-only Equip Profile for Hansen’s Inevitable Excess Angel Oracle party.
Online sources: [Neoseeker Angel Oracle](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Angel_Oracle), [Neoseeker Ember](https://www.neoseeker.com/pathfinder-wrath-of-the-righteous/builds/Ember), [Saga of the Jasonite Seelah / Camellia](https://sagaofthejasonite.com/). Missing BIS is listed, never invented.

**Profile:** `Profiles/Angel_Oracle_IE.json`  
**Save:** Quick_8.zks (2026-10-02 04:04, GameId `fea04e92…`)  
**Report:** 2026-10-02 04:04:20

## Active party

| # | Character | Build in save | UniqueId |
|---|---|---|---|
| 1 | Hansen | Oracle 20 Seeker / Angel MR10 | `360c7122-3094-4ab4-9706-04ae85f7715a` |
| 2 | Seelah | Paladin 20 / MR9 | `0ad3253d-0009-464c-8fea-5162de292bb9` |
| 3 | Camellia | Shaman 20 Spirit Hunter / MR8 | `d489d1c3-83ff-45e0-bb90-8549b7b0c6dd` |
| 4 | Queen Galfrey | Paladin 20 / MR10 | `5A6856` |
| 5 | Arueshalae | Ranger 20 Master Spy / MR10 | `166F1D` |
| 6 | Ember | Witch 20 Accursed / MR8 | `7ea9b3f6-19ad-4b7c-98fb-3d935bf698f3` |

Donors (inactive, still in `AllCharacters`): Nenio (`a362b4fa-…`), Daeran (`d3da2a90-…`).

## How to apply in game

1. Load the Angel IE quicksave that matches this report.
2. Open **Hansen Equipment Manager**.
3. Click **Equip Profile** once (applies all Ready rules, including donor pulls).
4. Click **Equip Profile** again — Camellia’s `Interceptor` is Blocked while Disk of Unbalance is still equipped; pass 1 unequips, pass 2 inserts.
5. Optional: **Export Report** and diff against the tables below.

HEM never edits `.zks` files. This repo only ships the profile + docs.

---

## Preview — current vs online (inventory-limited)

### Hansen — KEEP (already inventory-best Angel Oracle)

| Slot | Equipped | Online core | Gap |
|---|---|---|---|
| Glasses / Head / Neck / Gloves / Staff / Cloak / Rings | Broken Trickster, Mask of Nothing, Vellexia, Star Embroidered, Fiery Spell Weaver, Bound of Possibility, Prot+7, Triumphant | Same Neoseeker Angel core where owned | — |
| Missing | — | Grave Singer, Robe of Virtue, Flawless belt, Bracers of Balance, Imminent Demise | not in save |

### Seelah — CHANGE (Paladin tank)

| Slot | Was | Equip | Why |
|---|---|---|---|
| Secondary | empty | `AssertionOfDominanceShieldItem` | Jasonite #1 shield; Hopebringer stays on Galfrey |
| Shirt | empty | `ClothOfHeavyFortificationItem` | Fortification cloth for tank |
| Wrist | empty | `ClearPurposeItem` (donor Daeran) | Fill empty wrist; concentration / heal utility |
| Gloves | Claws | `GlovesOfMartialExcellenceItem` | Better martial AB gloves in inventory |
| Ring 2 | Triumphant | `RingOfEvasionItem` | Tank Reflex Evasion; Triumphant remains on others |
| KEEP | Radiance, Mithral FP+5, Mental+8, Undeniable Truth, NA+7, Prot+7, Freest Rein, Belt+8, Res+7 | | |
| Missing | — | Living Fortress, Heartstone, Lizard Tail, Dawnflower (Radiance kept) | not owned / Radiance preferred |

### Camellia — CHANGE (Spirit Hunter dual rapier)

| Slot | Was | Equip | Why |
|---|---|---|---|
| Secondary | Disk of Unbalance | `__UNEQUIP__` → `InterceptorItem` | Jasonite dual-rapier off-hand (2× Equip Profile) |
| Neck | Bone Amulet | `VoraciousSpiritItem` | Endgame AC stacking amulet in inventory |
| KEEP | Translucent Needle, Mithral BP+5, Seven Sins, Mental+8, Undeniable Truth, Prot+7, Triumphant, Claws, Repelling, Freest Rein, Belt+8, Res+7 | | |
| Missing | — | Fencer’s Gift, Spirit Trackers, Rapier of Speed, Heartstone | not in save |

### Queen Galfrey — CHANGE (Paladin + Hopebringer)

| Slot | Was | Equip | Why |
|---|---|---|---|
| Glasses | empty | `DLC3_GlassesOfundeniableTruthItem` | Spare copy in inventory / inactive |
| Wrist | empty | `BracersOfHeavyHandItem` | Fill empty wrist (shield kit) |
| KEEP | Radiance, Hopebringer, Mithral FP+5, Seven Sins, Mental+8, NA+7, Triumphant, Prot+7, Claws, Freest Rein, Belt+8, Res+7 | | |

### Arueshalae — KEEP (Master Spy archery kit)

| Slot | Equipped | Notes |
|---|---|---|
| Full kit | Snakeskin, Unspeakable Truth, Darkness Caress, Malocchio, Leeching Strike, Big Game, Merciless Shot, Archery bracers, NA+7, Prot+7, Freest Rein, Belt+8, Res+7 | Already matches prior inventory audit |
| Missing | Instant Enemy gloves, Heart of Iceland | not in save |
| Not used | Call to Violence / Mangling Frenzy in inventory | need rage / Skald; worse than Res+7 here |

### Ember — CHANGE (Neoseeker ray witch)

| Slot | Was | Equip | Why |
|---|---|---|---|
| Gloves | empty | `GlovesOfArcaneEradicationItem` (donor Nenio) | Mandatory ranged-touch gloves |
| Feet | Freest Rein | `BootsOfMagicalWhirlItem` (donor Nenio) | Quicken alt; Arcane Persistence not owned |
| Shirt | Seven Sins | `BaphometFireCloth_AnimalisticFireItem` | Call of the Fiery Things (mandatory fire cloth) |
| Belt | Mallander’s Insult | `MaskOfAreshkagalBelt_TabulaRasaItem` | Pristine Mind (mandatory) |
| Ring 2 | Sacred Touch | `RedSalamandraItem` | Red Salamander (mandatory) |
| Glasses | Cinder Goggles | `GogglesOfPiercingGazeItem` | Mandatory SR glasses |
| KEEP | Lethal Conductor, Deadly Rays, Mental+8, Pyromania, Eldritch Scholar, Carnage | | |
| Missing | Ashmaker, Ward Master, Steady Finger, Scorching Bracers, Arcane Persistence, Assailant’s Belt | not in save |

---

## Equip Profile rule list

| Order | Character | Slot | Blueprint | Donor |
|---|---|---|---|---|
| 1 | Ember | Gloves | `GlovesOfArcaneEradicationItem` | Nenio |
| 2 | Ember | Feet | `BootsOfMagicalWhirlItem` | Nenio |
| 3 | Seelah | Wrist | `ClearPurposeItem` | Daeran |
| 4 | Seelah | SecondaryHand | `AssertionOfDominanceShieldItem` | — |
| 5 | Seelah | Shirt | `ClothOfHeavyFortificationItem` | — |
| 6 | Seelah | Gloves | `GlovesOfMartialExcellenceItem` | — |
| 7 | Seelah | Ring2 | `RingOfEvasionItem` | — |
| 8 | Camellia | SecondaryHand | `__UNEQUIP__` | — |
| 9 | Camellia | SecondaryHand | `InterceptorItem` | — |
| 10 | Camellia | Neck | `VoraciousSpiritItem` | — |
| 11 | Queen Galfrey | Glasses | `DLC3_GlassesOfundeniableTruthItem` | — |
| 12 | Queen Galfrey | Wrist | `BracersOfHeavyHandItem` | — |
| 13 | Ember | Shirt | `BaphometFireCloth_AnimalisticFireItem` | — |
| 14 | Ember | Belt | `MaskOfAreshkagalBelt_TabulaRasaItem` | — |
| 15 | Ember | Ring2 | `RedSalamandraItem` | — |
| 16 | Ember | Glasses | `GogglesOfPiercingGazeItem` | — |

Hansen and Arueshalae have no CHANGE rules (already correct).
