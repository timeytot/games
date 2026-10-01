# Angel campaign — Buff It pointer

Generic Buff It rules: [../BuffIt-Guide.md](../BuffIt-Guide.md).

This folder only records **where** this campaign’s config lives. Do not treat party names or row counts here as universal rules.

## Live file

| Field | Value |
|---|---|
| GameId | `fea04e92a6f54507a84b86b8444eec8f` |
| Live path | `<GameInstall>\Mods\BuffIt2TheLimit\UserSettings\bi2tl-fea04e92a6f54507a84b86b8444eec8f.json` |
| Repo copy | [`buffit-current-config.json`](./buffit-current-config.json) |

There is no Wrath Tactics file for this GameId in the repo or live UserSettings.

## Current layout (snapshot)

All buff rows are on **Normal** (`Long`). Quick and Important are empty. Exact row count and `Wanted` lists are in `buffit-current-config.json` — that file wins if this note and the JSON disagree.

When the active party changes, remap unit ids in `Wanted` / `Casters` from the current save’s `party.json` (see the generic guide). Personal spells (for example Effortless Armor) must stay self-cast only for characters who know the spell.

## Apply

1. Ensure the live JSON matches the repo copy (or intentionally differs).
2. In game: Spellbook → Buff It → confirm Normal / Quick / Important counts.
3. Press Normal after resting when you want the full pre-buff pass.

Restore steps and troubleshooting: [BuffIt-Guide.md](../BuffIt-Guide.md). Spell guids and older save notes: [Reproduction.md](./Reproduction.md).
