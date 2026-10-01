# Sword Saint campaign — Buff It pointer

Generic Buff It rules: [../BuffIt-Guide.md](../BuffIt-Guide.md).

This folder only records **where** this campaign’s config lives. Do not copy Angel or Lich JSON onto this GameId.

## Live file

| Field | Value |
|---|---|
| GameId | `8dd97a37ca674651afefb4dd19e06967` |
| Live path | `<GameInstall>\Mods\BuffIt2TheLimit\UserSettings\bi2tl-8dd97a37ca674651afefb4dd19e06967.json` |
| Repo copy | [`buffit-current-config.json`](./buffit-current-config.json) |

Wrath Tactics for the same GameId: [`tactics-current-config.json`](./tactics-current-config.json) → live `tactics-<GameId>.json`.

## Current layout (snapshot)

All Buff It rows are on **Normal** (`Long`). Quick and Important are empty. Exact rows, casters, and unit ids are in `buffit-current-config.json` and [Reproduction.md](./Reproduction.md).

Companion abilities that are not Buff It rows may live in Wrath Tactics instead — do not assume every toggle belongs on a Buff It button.

## Apply

1. Confirm GameId from the save header.
2. Close Wrath before replacing live JSON.
3. Copy the repo config onto the live filename → load save → Buff It → Normal.

Restore and troubleshooting: [BuffIt-Guide.md](../BuffIt-Guide.md). Edit methods: [ModEditMethods.md](./ModEditMethods.md).
