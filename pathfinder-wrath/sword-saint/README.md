# Sword Saint

This folder is Fan's Sword Saint profile. The game does not read this folder. Do not copy the FaN or Hansen JSON files here. Those configs belong to the other two saves.

The level-by-level plan is [SwordSaint_Trickster_Build.md](./SwordSaint_Trickster_Build.md). The one-click buttons are [BuffIt-OneClickBuff.md](./BuffIt-OneClickBuff.md). How the spellbook, Buff It, and Wrath Tactics are edited is [ModEditMethods.md](./ModEditMethods.md).

| Field | Value |
|---|---|
| Character name | Fan |
| GameId | `8dd97a37ca674651afefb4dd19e06967` |
| Save file | `Quick_3.zks` is the spellbook edit on 2026-09-29. `Quick_4.zks` was left unchanged. `Manual_9_Artisan_s_Tower__16_Arodus__VIII__4715__12_03_13.zks` is the earlier manual save. |
| Party | Fan, Seelah, Arueshalae, Ember, Daeran, Camellia |
| Live Buff It file | `Mods\BuffIt2TheLimit\UserSettings\bi2tl-8dd97a37ca674651afefb4dd19e06967.json` |

The Sword Saint spellbook blueprint is shared by the class. It is not a character id:

`SwordSaintSpellbook` `682545e1-1e53-06c4-5b14-ca78bcbe3e62`

Unit ids were read from that save's `party.json`.

## Files

- `SwordSaint_Trickster_Build.md` — the level-by-level plan.
- `BuffIt-OneClickBuff.md` — one-click buff notes. The buttons are Normal (`Long`), Quick (`Quick`), and Important (`Important`).
- `buffit-current-config.json` — copy of the live Buff It config.
- `tactics-current-config.json` — copy of Fan's live Wrath Tactics config.
- `ModEditMethods.md` — how to edit the spellbook, Buff It, and Wrath Tactics.

`../tools/refresh_current_snapshot.cmd` syncs only FaN. This save is not written into `lich/current/`.

Confirm `Wrath.exe` is not running before writing a live JSON file.
