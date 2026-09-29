# Hansen gear assignment, 2026-09-30

Read this before moving equipment in Hansen's save. The game does not read this file. The edited save is on disk only.

## Save

| Field | Value |
|---|---|
| File | `Quick_7.zks` |
| Header `Name` | `Quicksave1 1` |
| Player | Hansen |
| GameId | `fea04e92a6f54507a84b86b8444eec8f` |
| `GameTotalTime` | `8.09:49:36.0960000` |
| Money | 15301052, unchanged |
| Backup before the edit | `Quick_7.zks.bak-20260930-gear` in the same Saved Games folder |

Saved Games:

```
C:\Users\timeg\AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games
```

`Wrath.exe` was closed. `party.json` inside the zip was rewritten. `header.json` and `checksums` were not changed. Load `Quicksave1 1`. An older Hansen save, including `Manual_8`, does not have this gear.

`ForImport_1.zks` is a different Hansen GameId, `cd14e1db75594fff95cf52e3e3d50a27`. Do not edit it for this party.

## Who matters

Final party, in priority order. The protagonist is first. Sosiel is explicitly last. People who are not on this list can give up a duplicate stat item. People who are on this list do not.

| Priority | Character | Unit id | What this edit did |
|---|---|---|---|
| 1 | Hansen, Oracle 20 / Angel | `360c7122-3094-4ab4-9706-04ae85f7715a` | Nothing. His worn set stays |
| 2 | Seelah, Paladin 20 | `0ad3253d-0009-464c-8fea-5162de292bb9` | Nothing |
| 2 | Camellia, Shaman 20 | `d489d1c3-83ff-45e0-bb90-8549b7b0c6dd` | Neck was empty. Her own amulet was in the stash and is now worn |
| 2 | Arueshalae, Ranger 20 | `166F1D` | Nothing |
| 2 | Ember, Witch 19 | `7ea9b3f6-19ad-4b7c-98fb-3d935bf698f3` | Nothing |
| 2 | Daeran, Oracle 20 | `d3da2a90-9520-4171-a346-c7971a171b77` | Was wearing nothing. Geared from stash copies |
| last | Sosiel, Cleric 20 | `3e1e0b22-78e6-475f-b09c-e4beac1bbca1` | Was wearing nothing. Geared from leftover stash items, then from Regill and Lann |

Daeran at the time of the screenshots: Aasimar, Neutral Evil, Strength 10, Dexterity 18, Constitution 15, Intelligence 13, Wisdom 16, Charisma 26. He is a back-line divine caster. Charisma is the casting stat. A heavy weapon that uses Strength is a poor fit.

Sosiel: Human, Neutral Good, Strength 18, Dexterity 12, Constitution 16, Intelligence 12, Wisdom 25, Charisma 16. He is a front-line cleric. Wisdom is the casting stat. He can wear heavy armor. He is not in the final party, so he does not receive the last copy of a caster item that Daeran still needs.

Other unit ids in this save, not in the final party:

| Character | Unit id | Taken from him |
|---|---|---|
| Lann, Monk 20 | `e437d264-30d0-4f82-b498-10d5779735e1` | Amulet of natural armor +7 only |
| Regill, Hellknight 10 / Fighter 10 | `6fb82a23-c68d-4964-aa5e-20f4c180a7ff` | Belt of perfection +8, headband of perfection +8, cloak of resistance +7, bracers of the heavy hand |
| Galfrey, Paladin 20 | `5A6856` | Nothing |
| Nenio, Wizard 20 | `a362b4fa-464a-43df-99cf-48216117e70b` | Nothing |
| Woljif, Rogue 20 | `66befdb4-62f9-4faa-a788-65004482af56` | Nothing |
| Greybor, Slayer 20 | `E55C2` | Nothing |
| Wolf | `47CDA1` | Nothing |

The stash had one unused copy of each best caster piece. That copy went to Daeran. Sosiel's matching stat pieces came off Regill and Lann because a second unused copy did not exist, and those two are outside the final party. Regill still has his mithral full plate, glasses, boots, both rings, and weapon. Lann still has his armor, bow, belt, headband, and the rest of his kit. His neck slot is empty.

## Daeran, after the edit

Every piece except the rapier was an unworn stash copy. Hansen's own copy of the same item was left on Hansen.

| Slot | Blueprint name | Why |
|---|---|---|
| Armor | `ChainshirtAcidResistance30Plus5` | Light armor, enhancement +5, acid resistance 30. Dexterity 18 still applies. He is divine, so armor does not cause spell failure |
| Shirt | `DLC3_RobeOfTheSinmageItem` | Same shirt the other casters use |
| Belt | `BeltOfPerfection8` | +8 enhancement to all six abilities |
| Head | `HeadbandOfPerfection8` | Same, and it raises Charisma |
| Glasses | `DLC3_GlassesOfundeniableTruthItem` | Same glasses as the rest of the geared party |
| Feet | `BootsOfFreestReinItem` | Same boots as the rest of the geared party |
| Gloves | `StarEmbroideredGlovesItem` | Caster gloves. `ClawsOfAMonsterItem` is for natural attacks |
| Neck | `AmuletOfNaturalArmor7` | +7 natural armor. `CameliaAmuletItem` was not given to him |
| Ring 1 | `RingOfProtection7` | +7 deflection |
| Ring 2 | `DLC3_RingOfInstantTriumphItem` | Same second ring the party already uses |
| Shoulders | `CloakOfResistance7` | +7 resistance |
| Primary hand | `RapierPlus5` | Best remaining one-handed weapon. No crossbow or staff was unworn. Strength is 10, so this is a poor melee weapon unless he has Weapon Finesse |
| Wrist | empty | The useful caster bracers are `StormlordsResolveItem` on Hansen and `BracersOfEldritchScholarItem` on Ember. Those stay |

## Sosiel, after the edit

| Slot | Blueprint name | Source |
|---|---|---|
| Armor | `MithralFullplateStandartPlus5` | Stash. Dexterity 12 does not need a light armor |
| Primary hand | `DawnflowersKiss_Good_Scimitar` | Stash. One-handed, and he is Neutral Good |
| Secondary hand | `TheUndyingLoveOfTheHopebringerShieldItem` | Stash copy. Seelah's worn copy was not taken |
| Feet | `BootsOfStampedeItem` | Stash. Melee boots. The freest-rein pair went to Daeran |
| Gloves | `GlovesOfMartialExcellenceItem` | Stash. `GraspOfDevotionItem` is a weapon, not a glove |
| Glasses | `GogglesOfPiercingGazeItem` | Stash. The truth glasses went to Daeran |
| Ring 1 | `RingOfEvasionItem` | Stash |
| Ring 2 | `PaladinsRingItem` | Stash. It is an equipment ring with no class restriction in the blueprint |
| Belt | `BeltOfPerfection8` | Regill |
| Head | `HeadbandOfPerfection8` | Regill. Wisdom 25 is his casting stat |
| Shoulders | `CloakOfResistance7` | Regill |
| Wrist | `BracersOfHeavyHandItem` | Regill |
| Neck | `AmuletOfNaturalArmor7` | Lann |
| Shirt | empty | The spare sin-mage robe went to Daeran |

## Camellia

Neck is `CameliaAmuletItem`. It was unworn in the stash, and her neck slot was empty. Everything else she was already wearing stayed.

## How an item is worn

The inventory screen's shared stash is not `player.json`'s `SharedStash`. That object had two items. The grid is one inventory, `Descriptor.m_Inventory`, and every companion's `m_Inventory` is a `$ref` to it. On this save that collection has 532 item entities. Hansen's descriptor is a reliable place to read it.

An equipped slot and the item point at each other.

| Piece | Field |
|---|---|
| Body slot, or `m_HandsEquipmentSets[0].PrimaryHand` / `SecondaryHand` | `m_ItemRef` is the item `UniqueId` |
| Item | `m_WielderRef` is the unit `UniqueId` |
| Item | `HoldingSlot` is `{"$ref":"<slot $id>"}` |
| Item | Stays inside the inventory collection |

An empty paper-doll slot in this save is only `{"$id":"..."}` with no `$type` and no `m_ItemRef`. Filling it means adding `$type` and `m_ItemRef` on that same object. Do not invent a second slot `$id`.

Slot classes already used by a worn item on Hansen:

| Slot | `$type` |
|---|---|
| Armor | `Kingmaker.Items.Slots.ArmorSlot, Assembly-CSharp` |
| Hands | `Kingmaker.Items.Slots.HandSlot, Assembly-CSharp` |
| Shirt, belt, head, glasses, feet, gloves, neck, rings, wrist, shoulders | generic equipment slot for that field |

The shirt, belt, head, glasses, feet, gloves, neck, ring, wrist, and shoulder slots use `Kingmaker.Items.Slots.EquipmentSlot` with the blueprint class that matches the field name, the same string Hansen's worn items already store. `ChainshirtAcidResistance30Plus5` and `MithralFullplateStandartPlus5` are `BlueprintItemArmor`. A shield is `BlueprintItemShield` and goes in `SecondaryHand`. `GraspOfDevotionItem` is a weapon.

If the item is already worn, its `HoldingSlot` object is the old owner's slot. Clearing `m_WielderRef` without putting that slot object back on the old body leaves the old body with a dangling `$ref`. Set the old slot's `m_ItemRef` to null, park that slot object back on the old body field, then point the item at the new slot.

`m_InventorySlotIndex` was removed from items that were equipped. Worn items on Hansen do not have that field.

Close `Wrath.exe` before writing `party.json`. Repack the zip with `ZIP_DEFLATED`, keep the other zip members, and leave `checksums` unchanged. `json.dumps` of the whole `party.json` loaded and the slot links still resolved.

## Leave the final party's worn set in place

Hansen, Seelah, Arueshalae, and Ember already wear a +8 perfection belt, a +8 perfection headband, a +7 protection ring, and a +7 resistance cloak, or a piece that belongs to that character. Daeran wears the unused copies of those. Sosiel's copies came from Regill and Lann.
