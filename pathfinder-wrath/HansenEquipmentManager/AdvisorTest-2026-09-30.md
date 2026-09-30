# Advisor test, Quicksave2 2, 2026-09-30

Loaded save header `Quicksave2 2`, file `Quick_9.zks`, in-game time `8.10:12:52`. GameId is the Hansen Inevitable Excess save. FinneanCompositeLongbowStage3Base is worn by Lann in this file.

Hansen Equipment Manager 0.2.0 loaded 2 profiles and 6 build rules. The player used Scan Party, then Generate Equipment List, then Equip Selected with the three text fields still empty, then Export Report. No item was equipped. The empty Equip Selected call logged:

```
InvalidOperationException: Type a character, a slot, and a blueprint first.
```

Export Report wrote `Mods\HansenEquipmentManager\report.txt`.

Active party in this save: Hansen, Lann, Nenio, Arueshalae, Sosiel, Daeran.

Current worn items the list reported:

- Hansen primary `FierySpellWeaverItem`, secondary empty, head `HeadbandOfPerfection8`, armor `SarkorianWeddingBreastplateItem`, neck `AmuletOfNaturalArmor7`. Build match `Oracle_Angel`.
- Lann primary `FinneanCompositeLongbowStage3Base`, secondary empty, neck empty. Build match `Default`, not `ZenArcher`.
- Nenio primary `MapPlaningBardicheItem`. Build match `Default`.
- Arueshalae primary `LongbowOfLeechingStrikeItem`. Build match `Default`.
- Sosiel primary `DLC3_BeautyslasherGlaiveWeaponItem`, secondary empty, armor `MithralFullplateStandartPlus5`. Build match `Cleric`.
- Daeran primary `RapierPlus5`, armor `ChainshirtAcidResistance30Plus5`. Build match `Oracle`.

The class line repeats `ClassesOrder` instead of printing one class and one level. Example: `OracleClass 20` dozens of times, then `AngelMythicClass 8`. Lann is a Zen Archer but the class asset is `MonkClass`, so the Zen Archer build rule did not match.

The list did not auto-equip. It ranked stash candidates beside the current item. Two-handed weapons still appear for characters whose secondary hand is empty, including Sosiel.
