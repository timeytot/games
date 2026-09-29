# FaN lich profile

This folder is the Wrath Tactics and Buff It 2 The Limit configuration for FaN, the lich save. Hansen's angel profile is in `../angel-hansen/`.

`WrathModsConfiguration.zip` is a snapshot. The game does not read it. The live files are:

```
D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure\Mods\WrathTactics\UserSettings\tactics-7ea3d466491c4249aec2742271c2e71a.json
D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure\Mods\BuffIt2TheLimit\UserSettings\bi2tl-7ea3d466491c4249aec2742271c2e71a.json
```

The zip contains the notes and copies of those two configs. Notes are in Chinese. Filenames are English.

## Build notes

- [Kestoglyr High AC Build](./Kestoglyr_High_AC_Build.md) — normal-retrain high-AC shield-tank build, equipment, mythic plan, combat toggles, and verified pitfalls.
- [Ciar Horse Bulwark Build](./Ciar_Horse_Bulwark_Build.md) — Bulwark animal companion as the second front line.

## Current state

`current/` is the newest FaN save snapshot. The refresh script ignores other GameIds, including Hansen.

`diagnostics/` contains immutable historical snapshots.

Build files are the intended configuration. `current/` is the actual newest parsed save state. When a build file and `current/` conflict, `current/` wins.

- `Current_Report.md`
- `Party_Current.json`
- `Kestoglyr_Current.json`
- `Horse_Current.json`

## Sync workflow

Manual sync:

`../tools/refresh_current_snapshot.cmd`

Start the game yourself. After you finish playing, double-click `../tools/refresh_current_snapshot.cmd`.

No scheduled task, no background service, no startup item, no automatic game launch, and no sync when the game exits.

## Diagnostics

The build file is the plan. A diagnostic file is what was read from a save and the logs at one time. When they conflict, the save diagnostic wins over an older build note.

- Kestoglyr build: [Kestoglyr_High_AC_Build.md](./Kestoglyr_High_AC_Build.md)
- Kestoglyr save diagnostic: [2026-09-28 Auto_1 report](./diagnostics/kestoglyr/2026-09-28_Auto_1/Kestoglyr_Report.md)
- Snapshot save: `Auto_1.zks`, 2026-09-28 23:14:28, under `diagnostics/kestoglyr/2026-09-28_Auto_1/raw/`
