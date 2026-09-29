# 天使 Hansen 的一键 Buff

这是 Inevitable Excess 存档 Hansen 的 Buff It 2 The Limit 配置。巫妖 FaN 的配置在 `../lich/`。两份配置对应两个 GameId，游戏按存档读取，不会混用。

配置时间：2026-09-29。写这份配置时游戏已关闭。

## 游戏实际读取的文件

```
D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure\Mods\BuffIt2TheLimit\UserSettings\bi2tl-fea04e92a6f54507a84b86b8444eec8f.json
```

- 模组：Buff It 2 The Limit 1.21.1
- GameId：`fea04e92a6f54507a84b86b8444eec8f`
- 存档：Hansen，Inevitable Excess，Threshold，5 Abadius (I) 4717
- 存档文件：`Manual_8_Threshold__5_Abadius__I__4717__15_49_23.zks`
- 同目录的 `.bak-20260929-angel` 是改写前那份 134 条全放在 Normal 里的备份

仓库里的 `buffit-current-config.json` 是这份配置的副本。游戏不读仓库，也不读 zip。

## 三个按钮

Hansen 的先知书没有 Enduring Spells，也没有 Greater Enduring Spells。回合级法术不放进 Normal。

| 游戏按钮 | JSON | 条数 | 什么时候点 |
|---|---|---|---|
| Normal | `Long` | 56 | 进新区域，或休息之后。这些是分钟级、十分钟级或小时级 |
| Quick | `Quick` | 9 | 每场战斗开打前。这些是回合级 |
| Important | `Important` | 4 | 硬仗。信仰堡垒、日轮形态、复仇祝福、神圣灵光不要花在普通遭遇上 |

三个按钮互不包含。点 Normal 不会把 Quick 和 Important 一起放掉。

## 队伍

出战 6 人加 Arueshalae 的狼。编号和存档 `party.json` 的 `UniqueId` 一致。

| 角色 | 单位编号 | 职业 | 法术书 |
|---|---|---|---|
| Hansen | `360c7122-3094-4ab4-9706-04ae85f7715a` | 先知 20，天使神话 10。自发施法，书已并入天使法术 | Oracle `6c033647-12b4-1594-1a98-f74522a81273` |
| Lann | `e437d264-30d0-4f82-b498-10d5779735e1` | 武僧 20 | 无法术书，只接受增益 |
| Nenio | `a362b4fa-464a-43df-99cf-48216117e70b` | 法师 20。准备施法 | Wizard `5a38c9ac-8607-8904-09fc-b8f6342da6f4` |
| Sosiel | `3e1e0b22-78e6-475f-b09c-e4beac1bbca1` | 牧师 20。准备施法 | Cleric `4673d19a-0cf2-fab4-f885-cc4d1353da33` |
| Arueshalae | `166F1D` | 游侠 20，大师间谍。准备施法 | Master Spy `12bfcf91-d541-6b04-7a2a-9110ff8968c5` |
| Galfrey | `5A6856` | 圣武士 20。准备施法 | Paladin `bce4989b-070c-e924-b986-bf346f59e885` |
| Wolf | `47CDA1` | 动物伙伴 20 | 无法术书，只接受增益 |

Hansen 是自发施法，所以天使法和大部分神术由他优先放，不依赖准备列表。同一条里后面的人是备用。

个人法术只绑在施法者自己身上，例如 Nenio 的预知术、Galfrey 的高等天使形态、Sosiel 的神圣力量。这样一次点击不会让 Hansen 变成别的生物，也不会把高等魔法武器扔到狼的天生武器上。

## Normal

| 法术 | 给谁 | 优先由谁施放 |
|---|---|---|
| Guidance | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Sosiel、Hansen |
| Resistance | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Nenio、Sosiel、Hansen |
| Virtue | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Sosiel、Galfrey、Hansen |
| Shield of Faith | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Remove Fear | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Effortless Armor | Hansen、Sosiel、Arueshalae、Galfrey | Hansen、Sosiel、Galfrey、Arueshalae |
| Barkskin | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Arueshalae、Hansen |
| Protection from Evil, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Protection from Chaos, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Delay Poison, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel、Galfrey、Arueshalae |
| Archon's Aura | Hansen、Sosiel、Galfrey | Hansen、Sosiel、Galfrey |
| Shield from Demonkind | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Protection from Acid, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Protection from Cold, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Protection from Electricity, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Protection from Fire, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Protection from Sonic, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Magic Vestment, Armor | Hansen、Sosiel、Arueshalae、Galfrey | Hansen、Sosiel |
| Magic Vestment, Shield | Sosiel、Galfrey | Hansen、Sosiel |
| Crusader's Edge | Hansen、Lann、Sosiel、Arueshalae、Galfrey | Hansen、Sosiel、Galfrey |
| Death Ward | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Freedom of Movement | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Arueshalae、Sosiel |
| Greater Magic Weapon, primary | Hansen、Lann、Sosiel、Arueshalae、Galfrey | Hansen、Sosiel、Galfrey、Nenio |
| Spell Resistance | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Life Bubble | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Arueshalae、Sosiel |
| Aegis of the Faithful | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Eagle's Splendor, Mass | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Sosiel、Hansen |
| Bear's Endurance, Mass | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Sosiel、Hansen |
| Bull's Strength, Mass | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Sosiel、Hansen |
| Owl's Wisdom, Mass | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Sosiel、Hansen |
| Cat's Grace, Mass | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Nenio |
| Sun Marked | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Ward against Weakness, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Ward against Harm, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Ward against Disease, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Ward against Impurity, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Pure Form | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Blade of the Sun | Hansen、Lann、Sosiel、Arueshalae、Galfrey | Hansen |
| True Seeing, Communal | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Nenio、Sosiel、Hansen |
| Heroic Invocation | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Nenio |
| Foresight | Nenio | Nenio |
| Seamantle | Nenio | Nenio |
| Mirror Image | Nenio | Nenio |
| Mage Armor | Lann、Nenio、Wolf | Nenio |
| Stoneskin | Lann、Arueshalae、Galfrey、Wolf | Nenio |
| Longstrider, Greater | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Arueshalae |
| Hurricane Bow | Lann、Arueshalae | Arueshalae |
| Aspect of the Falcon | Arueshalae | Arueshalae |
| Animal Growth | Wolf | Arueshalae |
| Magic Fang, Greater | Wolf | Arueshalae |
| Angelic Aspect, Greater | Galfrey | Galfrey |
| Veil of Heaven | Galfrey | Galfrey |
| Veil of Positive Energy | Galfrey | Galfrey |
| Bless Weapon | Galfrey | Galfrey |
| Aura of Greater Courage | Galfrey | Galfrey |
| Bestow Grace | Hansen | Galfrey |

## Quick

| 法术 | 给谁 | 优先由谁施放 |
|---|---|---|
| Haste | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Nenio |
| Prayer | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Sosiel、Galfrey、Hansen |
| Divine Power | Sosiel | Sosiel |
| Righteous Might | Sosiel | Sosiel |
| Eaglesoul | Sosiel、Galfrey | Galfrey、Sosiel |
| Holy Hymn | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Circle of Clarity | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen、Sosiel |
| Displacement | Nenio | Nenio |
| Bestow Grace of the Champion | Hansen、Galfrey | Galfrey |

## Important

| 法术 | 给谁 | 优先由谁施放 |
|---|---|---|
| Fortress of the Faithful | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Sun Form | Hansen | Hansen |
| Avenger's Blessing | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Hansen |
| Holy Aura | Hansen、Lann、Nenio、Sosiel、Arueshalae、Galfrey、Wolf | Sosiel、Hansen |

## 必须先准备的法术

Hansen 不用准备。下面这些角色是准备施法，对应法术没准备好时，这一条不会放出来。有 Hansen 兜底的神术可以不准备。

Nenio 需要准备：Heroic Invocation、Haste、Cat's Grace Mass、True Seeing Communal、Stoneskin、Foresight、Seamantle、Mirror Image、Displacement、Mage Armor。

Arueshalae 需要准备：Longstrider Greater、Hurricane Bow、Aspect of the Falcon、Animal Growth、Magic Fang Greater。Barkskin 没准备时由 Hansen 放。自由行动由 Hansen 优先放。

Galfrey 需要准备：Bestow Grace、Bestow Grace of the Champion、Bless Weapon、Veil of Heaven、Veil of Positive Energy、Aura of Greater Courage、Angelic Aspect Greater、Eaglesoul。

Sosiel 需要准备：Divine Power、Righteous Might、Eaglesoul。群体属性增强、死亡守护、神圣灵光和祈祷术没准备时由 Hansen 放。

## 从旧列表里拿掉的

旧配置 134 条全部堆在 Normal。这次没有留在一键里的包括：

- 邪恶和混乱光环：Unholy Aura、Cloak of Chaos。这队走天使，不自动放。
- 变形和形态：四系巨灵、变形术各形态、冰体、火体、惊骇形态、变换自身、复仇之风、太阳形态以外的变身。太阳形态留在 Important，只在硬仗给 Hansen 自己。
- 不是增益的法术：洞穴尖牙、天堂军、凤凰赠礼、震击预兆、克敌机先。
- 神话能力和开关：Trickster 第一次飞升、Angel Minor、疯狂领域高等能力。
- 和队伍阵营冲突或重复的弱法术：防护善良、防护守序、混乱或邪恶的阵营武器、单目标守护（已有群体版）、祝福术和援助术（和 Heroic Invocation 的士气加值冲突）。
- 会一次给全队的高等隐身，以及副手高等魔法武器。

防护能量用的是吸收伤害的群体版，不再额外放抗性能量。Shield of Law 不放，Nenio 是混乱阵营。
