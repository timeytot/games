# Hansen Equipment Manager

Advisor Mode lists what each active character can wear and equips one chosen item. Equip uses `CanInsertItem`, then `RemoveItem`, then `InsertItem`, then checks that the blueprint is in the slot. It does not edit `party.json` or any `.zks` save, and it does not copy weapon sets.

## Profiles

Profile files still load at startup. Advisor Mode does not preview them, verify them, or equip their rules.

`Profiles/Angel_Oracle_IE.json` is the Daeran, Sosiel, and Camellia list that used to be hardcoded. Sosiel has no primary-hand rule. The shield stays a secondary-hand rule. A donor in the file is an explicit profile choice.

`Profiles/SwordSaint_Trickster_IE.json` matches a Sword Saint / Trickster main character. It has no item rules. Those are not invented here.

`Profiles/Lich_Wizard_IE.json` matches a Wizard / Lich main character (FaN). It has no item rules yet.

BuildRules cover Angel Oracle, Zen Archer, Sword Saint Trickster, and Wizard Lich. Advisor Mode only uses them for match and factual tags, not auto equip.

`Scan Party` names a profile when the main character's class, archetype, or mythic path matches. It does not equip anything.

## Buttons

1. Scan Party
2. Generate Equipment List
3. Equip Selected Item
4. Export Report

Equip Selected Item equips the one item chosen on the screen.

## Recommendation

`BuildRules/*.json` holds stat and tag weights. A new build is a new file. The DLL does not contain per-character scores. `classContains` matches the class asset, the archetype asset, or the spaced display name. `ZenArcher` matches a Zen Archer whose class asset is `MonkClass`. `SwordSaint` matches the same way.

The screen is Party, Equipment List, Select Equipment, and Report. The list covers hands, armor, shirt, head, glasses, neck, both rings, gloves, wrist, boots, belt, and cloak. Each slot shows the worn item, then each different usable item. Copies of the same blueprint are one row, with a copy count and whether they are in inventory or outside the party. Tags are facts such as one-hand or shield compatible. Character and Slot are dropdowns. Changing character clears the slot and the item. The screen names the main character and the selected character separately. Blueprint ids stay in the report. Equip Selected Item stays disabled until an item is chosen, and the choice shows whether that item is in inventory or on another character. The worn item stays selectable under Current. After an equip, the item that was taken off is placed under Available so it can be put back. Primary-hand choices list one-handed weapons before two-handed weapons. The equip button is Equip Selected Item. The report header says Version: Advisor Mode, and a build id such as Oracle_Angel is also shown as Oracle Angel. Export Report overwrites `report.txt` with the latest list only.

## Build on this machine

This machine has no .NET SDK. `Build.ps1` uses Visual Studio 2022 Build Tools `csc.exe` and the local WotR 2.7.0x assemblies.

```powershell
.\Build.ps1
```

The old `HansenRuntimeEquipFix` mod is disabled by renaming its `Info.json`, so both mods do not load.
