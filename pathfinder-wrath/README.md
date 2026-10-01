# Pathfinder: Wrath of the Righteous

Each playthrough has its own folder. A save loads the mod config that matches its GameId.

## Shared mod guides

- [Buff It 2 The Limit — generic guide](./BuffIt-Guide.md) — buttons, live file path, JSON fields, personal spells, red-row debugging, restore checklist. Playthrough folders only store GameId pointers and config copies.

## Playthroughs

- [FaN lich](./lich/README.md) — Wrath Tactics, Buff It pointer, Kestoglyr and the horse build, the FaN save snapshot, and [the reproduction note](./lich/Reproduction.md).
- [Angel](./angel/Reproduction.md) — Buff It pointer and config copy for Hansen's Inevitable Excess campaign. There is no Wrath Tactics file for that GameId.
- [Angel IE Equip Profile](./HansenEquipmentManager/Docs/Angel_IE_Loadout.md) — inventory-only KEEP/CHANGE vs online builds, donors, and in-game **Equip Profile** steps. Profile JSON: [`HansenEquipmentManager/Profiles/Angel_Oracle_IE.json`](./HansenEquipmentManager/Profiles/Angel_Oracle_IE.json). Older raw-save notes: [angel/Gear.md](./angel/Gear.md).
- [Sword saint](./sword-saint/README.md) — Buff It, Wrath Tactics, and reproduction notes for that campaign.

`tools/refresh_current_snapshot.cmd` extracts the newest FaN save into `lich/current/`. The default GameId is `7ea3d466491c4249aec2742271c2e71a`. Repo, saves folder, and GameId can be overridden with arguments or `WOTR_REPO`, `WOTR_SAVES`, and `WOTR_GAME_ID`. Double-clicking extracts only. Pass `-Commit` to commit locally, and `-Push` to commit and push the current branch.

Start the game yourself. After you finish a FaN session, double-click that script.
