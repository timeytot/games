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

The advisor buttons are grouped as Party, Equipment List, and Actions. The list covers hands, armor, head, neck, both rings, gloves, boots, belt, and cloak. Each slot shows the worn item first, then up to three usable alternatives with a readable name and the blueprint underneath. Equip Selected uses those dropdowns and moves only that one item. Export Report overwrites `report.txt` with the latest list only. Two-handed weapons stay visible when the offhand is empty, marked as not shield compatible.

## Build on this machine

This machine has no .NET SDK. `Build.ps1` uses Visual Studio 2022 Build Tools `csc.exe` and the local WotR 2.7.0x assemblies.

```powershell
.\Build.ps1
```

The old `HansenRuntimeEquipFix` mod is disabled by renaming its `Info.json`, so both mods do not load.
