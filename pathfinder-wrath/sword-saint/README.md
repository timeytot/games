# Sword Saint

This folder is Fan's Sword Saint profile. The game does not read this folder. Do not copy the FaN or Hansen JSON files here. Those configs belong to the other two saves.

The current setup, and the steps to copy it back, are [Reproduction.md](./Reproduction.md). The level-by-level plan is [SwordSaint_Trickster_Build.md](./SwordSaint_Trickster_Build.md). The one-click buttons are [BuffIt-OneClickBuff.md](./BuffIt-OneClickBuff.md). How the spellbook, Buff It, and Wrath Tactics are edited is [ModEditMethods.md](./ModEditMethods.md).

| Field | Value |
|---|---|
| Character name | Fan |
| GameId | `8dd97a37ca674651afefb4dd19e06967` |
| Test save | Header name `Quicksave2`, Artisan's Tower, in-game `01:25:40`. On 2026-09-30 that header is `Quick_5.zks`. `Quicksave2 1` is a different file and was not edited. |
| Party | Fan, Seelah, Arueshalae, Ember, Daeran, Camellia |
| Live Buff It file | `Mods\BuffIt2TheLimit\UserSettings\bi2tl-8dd97a37ca674651afefb4dd19e06967.json` |

The Sword Saint spellbook blueprint is shared by the class. It is not a character id:

`SwordSaintSpellbook` `682545e1-1e53-06c4-5b14-ca78bcbe3e62`

Unit ids were read from that save's `party.json`.

## Files

- `Reproduction.md` — the live Buff It rows, the six Wrath Tactics rule lists, and the Quicksave2 state. Follow this file to reproduce the setup.
- `SwordSaint_Trickster_Build.md` — the level-by-level plan.
- `BuffIt-OneClickBuff.md` — one-click buff notes. The buttons are Normal (`Long`), Quick (`Quick`), and Important (`Important`).
- `buffit-current-config.json` — copy of the live Buff It config for all six characters.
- `tactics-current-config.json` — copy of the live Wrath Tactics config for all six characters.
- `ModEditMethods.md` — how the spellbook, Buff It, and Wrath Tactics are edited. Older save names in that file are history.

`../tools/refresh_current_snapshot.cmd` syncs only FaN. This save is not written into `lich/current/`.

Confirm `Wrath.exe` is not running before writing a live JSON file.
