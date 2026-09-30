# Hansen Equipment Manager

Phase 1 of the profile-driven equipment tool. It keeps the verified runtime path: `CanInsertItem`, then `RemoveItem`, then `InsertItem`, then verify. It does not edit `party.json` or any `.zks` save, and it does not copy weapon sets.

## Profiles

`Profiles/Angel_Oracle_IE.json` is the Daeran, Sosiel, and Camellia rule list that used to be hardcoded. Sosiel has no primary-hand rule. The shield stays a secondary-hand rule. A donor in the file is an explicit profile choice. If a blueprint has several unmarked copies, preview marks it `NeedsChoice` and equip skips it.

`Profiles/SwordSaint_Trickster_IE.json` only matches a Sword Saint / Trickster main character. It has no item rules. Those are not invented here.

`Scan Party` suggests a profile from the main character's class and mythic class names. It does not equip anything.

## Buttons

1. Scan Party
2. Preview
3. Equip Selected
4. Verify
5. Export Report

Equip Selected runs only after Preview for the same profile, and only for rows marked `Ready`.

## Recommendation

`BuildRules/*.json` holds stat and tag weights. A new build is a new file. The DLL does not contain per-character scores.

The screen is Party, Equipment List, Select Equipment, and Report. The list covers hands, armor, head, neck, both rings, gloves, boots, belt, and cloak. Each slot shows the worn item, then up to three different usable items. Copies of the same blueprint are one row, with a copy count and whether they are in inventory or outside the party. Tags are facts such as one-hand or shield compatible. Character and Slot are dropdowns. Changing character clears the slot, the item, and the preview. The screen names the main character and the selected character separately. Blueprint ids stay in the report. Equip Selected Item stays disabled until an item is chosen, and the choice shows whether that item is in inventory or on another character. The worn item stays selectable under Current. After an equip, the item that was taken off is placed under Available so it can be put back. Primary-hand choices list one-handed weapons before two-handed weapons. The equip button is Equip Selected Item. The report header says Version: Advisor Mode, and a build id such as Oracle_Angel is also shown as Oracle Angel. Export Report overwrites `report.txt` with the latest list only.

## Build on this machine

This machine has no .NET SDK. `Build.ps1` uses Visual Studio 2022 Build Tools `csc.exe` and the local WotR 2.7.0x assemblies.

```powershell
.\Build.ps1
```

The old `HansenRuntimeEquipFix` mod is disabled by renaming its `Info.json`, so both mods do not load.
