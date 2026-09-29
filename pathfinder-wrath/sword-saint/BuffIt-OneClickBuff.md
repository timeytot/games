# Fan Sword Saint One-Click Buffs

Buff It 2 The Limit configuration for Fan's Inevitable Excess save. Hansen's angel configuration is in `../angel/`. FaN's lich configuration is in `../lich/`. Each save has its own GameId, and the game loads the matching file.

Written on 2026-09-29. The game was closed.

## Live file

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Mods\BuffIt2TheLimit\UserSettings\bi2tl-8dd97a37ca674651afefb4dd19e06967.json
```

- GameId: `8dd97a37ca674651afefb4dd19e06967`
- Save: Fan, Inevitable Excess, Artisan's Tower, 16 Arodus (VIII) 4715
- Test save: header name `Quicksave2`, in-game 1 hour 25 minutes. On 2026-09-30 that file is `Quick_5.zks`. Buff It is not inside the save. The GameId file applies to every save of this campaign.

`buffit-current-config.json` in this folder is a copy of the live file. The row list another agent should follow is [Reproduction.md](./Reproduction.md). The game does not read the repository.

## The three buttons

Fan has Enduring Spells and Greater Enduring Spells. The other five do not. Bull's Strength, Bear's Endurance, Cat's Grace, and Shield of Faith are not on the buttons. Fan's Strength, Dexterity, and Constitution are already +8, and his ring is deflection +6.

| Button | JSON | Rows | When to press it |
|---|---|---|---|
| Normal | `Long` | 40 | After resting, or after entering a new area. This is the only button |
| Quick | `Quick` | 0 | Empty |
| Important | `Important` | 0 | Empty |

Every row is on Normal, including Haste, Prayer, Greater Invisibility, Vampiric Shadow Shield, Transformation, Frightful Aspect, and Burst of Glory.

## Party

Ids match `UniqueId` in the save's `party.json`. Active party order is Fan, Seelah, Arueshalae, Ember, Daeran, Camellia.

| Character | Unit id | Spellbook |
|---|---|---|
| Fan | `6078761c-2271-48a8-bfe2-e82f88a8f041` | Sword Saint `682545e1-1e53-06c4-5b14-ca78bcbe3e62` |
| Seelah | `615A` | Paladin `bce4989b-070c-e924-b986-bf346f59e885` |
| Arueshalae | `6224` | Master Spy `12bfcf91-d541-6b04-7a2a-9110ff8968c5` |
| Ember | `5AC2` | Witch `b897fe09-47e4-b804-082b-1a687c21e6e2` |
| Daeran | `5A2C` | Oracle `6c033647-12b4-1594-1a98-f74522a81273` |
| Camellia | `60D5` | Shaman `44f16931-dabd-ff64-3bfe-2a48138e769f` |

## Normal

All 40 rows target all six characters. The casters are Fan, Seelah, Arueshalae, Ember, and Daeran. Camellia is a recipient on every row and is not a caster. Her shaman abilities are Wrath Tactics rules, listed in [Reproduction.md](./Reproduction.md).

The live rows are not the shorter list this file used to show. Death Ward, Freedom of Movement, Remove Fear, communal energy resistance, communal energy protection, and Bless Weapon are not on the button. Barkskin's caster is Arueshalae. Haste's caster is Fan. Frightful Aspect's caster is Ember. Spell guids and caster order are in `Reproduction.md` and in `buffit-current-config.json`.

Seelah's Mark of Justice is not on the button and is not a tactics rule. Ember does not have Cackle or Evil Eye. Protective Luck is an Ember tactics rule.
