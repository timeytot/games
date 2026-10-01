# Lich campaign — Buff It pointer

Generic Buff It rules: [../BuffIt-Guide.md](../BuffIt-Guide.md).

This folder only records **where** this campaign’s config lives. Undead-affinity targeting rules and historical edits are playthrough-specific; they are not part of the generic guide.

## Live file

| Field | Value |
|---|---|
| GameId | `7ea3d466491c4249aec2742271c2e71a` |
| Live path | `<GameInstall>\Mods\BuffIt2TheLimit\UserSettings\bi2tl-7ea3d466491c4249aec2742271c2e71a.json` |
| Repo copy | Inside [`WrathModsConfiguration.zip`](./WrathModsConfiguration.zip) as `buffit-current-config.json` (see [Reproduction.md](./Reproduction.md)) |

Wrath Tactics for the same GameId is separate: `Mods\WrathTactics\UserSettings\tactics-<GameId>.json`.

## Current layout (snapshot)

Use the JSON inside the zip / Reproduction as the source of truth for row lists. Typical pattern for this campaign:

- Most pre-buffs on **Normal** (`Long`)
- HP-cost Cruoromancer infusions on **Quick**
- Narrow `Wanted` for effects that harm undead (positive energy, Death Ward, Blessing of Unlife, and similar)

Do not delete a row only because the UI shows zero casts. Fix preparation, rest, or `Wanted` first (generic guide).

## Apply

1. Close Wrath before replacing the live JSON.
2. Copy the campaign config onto `bi2tl-<GameId>.json`.
3. Load the save → Buff It → press the intended button(s).

Full restore steps: [Reproduction.md](./Reproduction.md).  
Dated edit diary (optional history): [BuffIt-ChangeLog.md](./BuffIt-ChangeLog.md).
