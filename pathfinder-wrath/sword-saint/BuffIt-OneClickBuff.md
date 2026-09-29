# Fan Sword Saint One-Click Buffs

Buff It 2 The Limit configuration for Fan's Inevitable Excess save. Hansen's angel configuration is in `../angel/`. FaN's lich configuration is in `../lich/`. Each save has its own GameId, and the game loads the matching file.

Written on 2026-09-29. The game was closed.

## Live file

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Mods\BuffIt2TheLimit\UserSettings\bi2tl-8dd97a37ca674651afefb4dd19e06967.json
```

- GameId: `8dd97a37ca674651afefb4dd19e06967`
- Save: Fan, Inevitable Excess, Artisan's Tower, 16 Arodus (VIII) 4715
- Save file: `Manual_9_Artisan_s_Tower__16_Arodus__VIII__4715__12_03_13.zks`
- `.bak-20260929-fan` in that folder is the previous file, which had only Transformation

`buffit-current-config.json` in this folder is a copy. The game does not read the repository.

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

| Spell | Targets | Casters, in order |
|---|---|---|
| Mage Armor | Fan, Ember | Ember |
| Barkskin | All six | Camellia, Arueshalae |
| Shield | Fan | Fan |
| Stoneskin | Fan, Seelah, Camellia | Fan, Camellia |
| True Seeing | Fan | Fan |
| Mirror Image | Fan | Fan |
| Enlarge Person, Mass | All six | Fan |
| Death Ward | All six | Daeran, Ember, Seelah, Camellia |
| Freedom of Movement | All six | Daeran, Camellia, Ember |
| Heroic Invocation | All six | Ember, Daeran |
| Remove Fear | All six | Daeran, Seelah |
| Delay Poison, Communal | All six | Daeran, Camellia |
| Protection from Evil, Communal | All six | Daeran, Seelah, Camellia |
| Resist Acid, Cold, Electricity, Fire, Sonic, Communal | All six | Daeran, Camellia |
| Protection from Acid, Cold, Electricity, Fire, Sonic, Communal | All six | Daeran, Ember |
| Blessing of Luck and Resolve, Mass | All six | Daeran |
| Veil of Heaven | Seelah | Seelah |
| Aura of Greater Courage | Seelah | Seelah |
| Bless Weapon | Fan, Seelah | Seelah |
| Angelic Aspect, Greater | Seelah | Seelah |

These are also on Normal:

| Spell | Targets | Casters, in order |
|---|---|---|
| Haste | All six | Daeran, Camellia, Fan |
| Prayer | All six | Daeran |
| Greater Invisibility | Fan | Fan |
| Vampiric Shadow Shield | Fan | Fan |
| Transformation | Fan | Fan |
| Frightful Aspect | Ember, Daeran, Camellia | Ember, Daeran, Camellia |
| Burst of Glory | All six | Seelah, Daeran |

Seelah still uses Mark of Justice herself at the start of a boss fight. Ember still puts Protective Luck on Fan and refreshes it with Cackle. Those are not spells on these three buttons.
