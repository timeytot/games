# Sword Saint

This folder is the Sword Saint profile. The character has not been saved yet, so there is no GameId, no unit ids, and no Buff It or Wrath Tactics config.

The game does not read this folder. Do not copy the FaN or Hansen JSON files here. Those configs belong to the other two saves.

The level-by-level plan is [SwordSaint_Trickster_Build.md](./SwordSaint_Trickster_Build.md).

## Fill this in after the first save

Create the character, save once, then copy `GameId` from the save header. Buff It and Wrath Tactics each use that id in the filename.

| Field | Now | After the first save |
|---|---|---|
| Character name | empty | Name in the save |
| GameId | empty | `GameId` in `header.json` |
| Save file | empty | Matching `.zks` under `Saved Games` |
| Party | empty | Each member's `UniqueId`, class, and spellbook |
| Live Buff It file | empty | `Mods\BuffIt2TheLimit\UserSettings\bi2tl-<GameId>.json` |
| Live Wrath Tactics file | empty | `Mods\WrathTactics\UserSettings\tactics-<GameId>.json`, if this character uses that mod |

The Sword Saint spellbook blueprint is shared by the class. It is not a character id:

`SwordSaintSpellbook` `682545e1-1e53-06c4-5b14-ca78bcbe3e62`

Read unit ids from that save's `party.json`. Do not guess them before the save exists.

## Files this folder will hold

- `SwordSaint_Trickster_Build.md` — the level-by-level plan.
- `BuffIt-OneClickBuff.md` — one-click buff notes, after a save exists. The buttons stay Normal (`Long`), Quick (`Quick`), and Important (`Important`).
- `buffit-current-config.json` — copy of the live Buff It config.
- `WrathModsConfiguration.zip` — a snapshot of those notes. The game does not read the zip.

`../tools/refresh_current_snapshot.cmd` syncs only FaN. A Sword Saint save will not be written into `lich/current/`. Add a separate snapshot only after this profile has a GameId.

Confirm `Wrath.exe` is not running before writing a live JSON file.
