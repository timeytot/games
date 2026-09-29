# Kestoglyr 高 AC 盾坦 Build

> 目标：在不使用彻底洗点 Mod 的前提下，利用正常重训把 Kestoglyr 改成队伍主坦，重点提高 AC、先攻和第一轮生存。
>
> 当前方案基于本机实际重训界面、当前装备截图和实际战斗需求整理。游戏内实际蓝图/角色卡优先于旧攻略。

## 最终职业

```text
Fighter 9
Stigmatized Witch 1
Stalwart Defender 10
```

Kestoglyr 前 3 级 Fighter 锁定，不改。

## 属性

基础成长计划：

```text
Lv4   STR 15 -> 16
Lv8   STR 16 -> 17
Lv12  STR 17 -> 18
Lv16  STR 18 -> 19
Lv20  STR 19 -> 20
```

目标基础属性：

```text
STR 20
DEX 20
CON -
INT 7
WIS 10
CHA 14
```

DEX 20 后不再继续加点。升级界面里如果看到 STR / DEX 24 等更高数字，可能包含装备或当前效果，不改变上述基础成长计划。

## Skills

当前已经有：

- Athletics：原有 Rank
- Mobility：已点到 Rank 5
- Persuasion：原有 Rank

这套只要求 Mobility 至少 3 ranks，因此后面不再继续加 Mobility。

后续技能优先级：

1. Perception
2. Athletics
3. 其他不再投入，除非有明确需求

## 4 级：Stigmatized Witch 1

- Ability：STR +1
- Familiar：**Hare Familiar**
- Hex：**Iceplant**
- Oracle's Curse：**Hellbound**
- Level 1 Spells：
  - **Inflict Light Wounds**
  - **Unbreakable Heart**

Hare 用于 +4 Initiative。Iceplant 用于 AC。Hellbound 是当前最终实际选择；当前角色页已显示 Fire immunity，且 Hellbound 有效等级已到 15。

## 5–20 级完整路线

| 角色等级 | 职业 | 选择 |
|---:|---|---|
| 5 | Fighter 4 | 普通 Feat：**Toughness**；Fighter Bonus：**Dodge** |
| 6 | Fighter 5 | Weapon Training：**Heavy Blades** |
| 7 | Fighter 6 | 普通 Feat：**Endurance**；Fighter Bonus：**Armor Focus (Medium Armor)** |
| 8 | Fighter 7 | STR +1 |
| 9 | Stalwart Defender 1 | **Improved Initiative** |
| 10 | Stalwart Defender 2 | Defensive Power：**Internal Fortitude** |
| 11 | Fighter 8 | 普通 Feat：**Shield Focus**；Fighter Bonus：**Greater Shield Focus** |
| 12 | Stalwart Defender 3 | STR +1；自动获得 Uncanny Dodge |
| 13 | Stalwart Defender 4 | **Improved Unarmed Strike**；Defensive Power：**Fearless Defense** |
| 14 | Stalwart Defender 5 | 自动获得职业 DR |
| 15 | Stalwart Defender 6 | **Crane Style**；Defensive Power：**Increased Damage Reduction** |
| 16 | Stalwart Defender 7 | STR +1；自动获得更高 DR / Improved Uncanny Dodge |
| 17 | Stalwart Defender 8 | **Missile Shield**；Defensive Power：**Increased Damage Reduction** 第二次 |
| 18 | Stalwart Defender 9 | 无额外普通 Feat |
| 19 | Stalwart Defender 10 | **Blind Fight**；Defensive Power：**Renewed Defense**；自动获得最高档职业 DR |
| 20 | Fighter 9 | STR +1；Advanced Weapon Training：**Trained Initiative**；保留 **Weapon Training (Heavy Blades)** |

### 为什么要 Improved Unarmed Strike

不是为了空手攻击。

它只是为了满足 **Crane Style** 前置。实际武器仍然是弯刀 + 重盾。

## Stalwart Defender Defensive Powers

最终顺序：

```text
SD2   Internal Fortitude
SD4   Fearless Defense
SD6   Increased Damage Reduction
SD8   Increased Damage Reduction
SD10  Renewed Defense
```

不选：

- Roused Defense：Kestoglyr 为亡灵，疲劳相关价值低
- Smash：不是本构筑的防御核心

职业自身 SD5 / SD7 / SD10 的 Damage Reduction 是自动获得，不需要重复选择。

## Mythic 计划

当前推荐路线：

| Mythic Rank | 选择 |
|---:|---|
| 1 | **Last Stand** |
| 2 | **Improved Initiative (Mythic)** |
| 3 | **Ever Ready** |
| 4 | **Mythic Armor Focus (Medium Armor) — Endurance**（已实际取得；当前 Scalemail 明确为 Medium Armor，因此当前生效） |
| 5 | **Rupture Restraints** |
| 6 | **Dodge (Mythic)** |
| 7 | **Unrelenting Assault** |
| 8 | **Toughness (Mythic)** |
| 9 | **Unstoppable** |
| 10 | **Shield Focus (Mythic)** 或按最终缺口调整 |

### Medium Armor Endurance 当前状态与换甲验证

**Mythic Armor Focus (Medium Armor) — Endurance 已经实际取得。** 当前装备的 **Scalemail** 明确显示为 Medium Armor，因此当前一定能正常吃到该神话专长。

后续如果找到 **Mithral Full Plate +4/+5**，换上之后仍要打开 AC 详细构成，确认它在本机版本下继续按 Medium Armor 处理。至少检查：

```text
Armor Focus (Medium Armor) +1
```

如果换上秘银全身甲后这行消失，说明该件装备在本机版本下没有按 Medium 处理，不要把它作为本构筑最终护甲。

## 武器和盾牌

### 主手

**Dawnflower's Kiss +5**

- Scimitar
- Heavy Blades
- +5 Enhancement
- 默认主手

**Rupturing Storm +4** 留作特定场景替换，不作为默认主手。

### 副手

当前首选：

**Assertion of Dominance**

- Heavy Shield +5
- 7 Shield AC
- 不限制 Max Dexterity
- 没有 Tower Shield 的 -2 Attack
- 满血时，按当前 tooltip：免疫 slashing 和 piercing damage

其他盾：

- 普通 Heavy Shield +5：可用，但没有 Assertion of Dominance 的特殊效果
- Holemaker：次选，暴击后可降低敌人攻击并给予 piercing vulnerability
- Charred Bulwark：特定需要 cold immunity 时考虑
- Tower Shield：本构筑不推荐

### 为什么不用 Tower Shield

+5 Tower Shield 虽然有 9 AC，但：

- Max Dexterity = 2
- Attack Rolls -2
- Armor Check Penalty 很高

本构筑依赖 DEX 20 + Fighter Armor Training，因此 Tower Shield 会压掉太多 DEX AC，综合收益反而更差。

## 护甲

目标：

**Mithral Full Plate +4/+5**

当前核心思路不是换成普通轻甲，而是利用秘银全身甲 + Fighter Armor Training，并现场验证它是否吃 **Armor Focus (Medium Armor)** / Medium Mythic Armor Focus。

## 战斗开关

### 常驻打开

- **Crane Style**
- **Fighting Defensively**

Crane Style 只在 Fighting Defensively 开启时发挥核心价值。

### 站好位置后打开

- **Defensive Stance**

Defensive Stance 开启后不能自由移动，因此先让 Kestoglyr 到前排卡位，再开启。

### 一般关闭

- Power Attack：主坦优先稳定命中和防御，不以伤害为第一目标

## 实战定位

Kestoglyr 的职责：

1. 抢先攻
2. 站住第一接敌位置
3. 开 Defensive Stance
4. 通过一次攻击让 Fighting Defensively 正常进入工作状态
5. 用高 AC、盾牌、Last Stand 和 DR 吃掉大部分普通物理压力

这套并不是为了让 Kestoglyr 单独硬吃所有超高 AB Boss。像 Keketar 这种极端高 AB 目标，仍应配合：

- Corrupt Magic
- Mirror Image
- 控制
- Last Stand
- 后排集中输出

## 当前默认装备组合

```text
Main Hand:  Dawnflower's Kiss +5
Off Hand:   Assertion of Dominance
Armor:      当前 Scalemail（Medium Armor，临时）；目标 Mithral Full Plate +4/+5，换装时验证 Medium Focus
```

## 已确认的关键避坑

- Toughness 不是 Fighter Bonus Combat Feat；5级应当普通 Feat 选 Toughness，奖励专长选 Dodge。
- Greater Shield Focus 需要 Fighter 8，因此在角色11级回到 Fighter 8 时即可取得。
- Endurance 是当前本机 Stalwart Defender 路线的前置需求之一。
- Increased Damage Reduction 要到 Stalwart Defender 6 才能选择，并且最多选择两次。
- Improved Unarmed Strike 只是 Crane Style 前置，不代表改用空手。
- 不使用 Tower Shield 压低 Max Dexterity。
- 不点 Heavy Armor Avoidance：本构筑 DEX 高，使用该机制不划算。

## 2026-09-28 实际完成状态

本轮正常重训已经完成，当前角色页核对结果：

- **Class**：Fighter 9 / Stigmatized Witch 1 / Stalwart Defender 10
- **Mythic Rank**：10
- **当前面板 AC**：62
- **Flat-footed AC**：41
- **Touch AC**：39
- **Initiative**：+38
- **HP**：371/371
- **当前主手**：Dawnflower's Kiss +5
- **当前副手**：Assertion of Dominance
- **当前护甲**：Scalemail（Medium Armor，Base AC 5，Max Dexterity 3），只是暂时没有找到更好的中甲/秘银全身甲
- **当前 Fire immunity**：已在角色页显示，来自最终 Hellbound 路线
- **Weapon Training**：Heavy Blades；Advanced Weapon Training：Trained Initiative
- **Mythic**：Last Stand / Improved Initiative (Mythic) / Ever Ready / Mythic Armor Focus (Medium Armor) — Endurance / Rupture Restraints / Dodge (Mythic) / Unrelenting Assault / Toughness (Mythic) / Unstoppable / Shield Focus (Mythic)
- **Stalwart Defender**：Internal Fortitude / Fearless Defense / Increased Damage Reduction ×2 / Renewed Defense
- **Feats 已核对存在**：Toughness / Dodge / Endurance / Armor Focus (Medium Armor) / Improved Initiative / Shield Focus / Greater Shield Focus / Improved Unarmed Strike / Crane Style / Missile Shield / Blind Fight
- **Witch spells 已核对**：Inflict Light Wounds / Unbreakable Heart
- **常驻/可用能力已核对**：Crane Style / Fighting Defensively / Defensive Stance / Hare Familiar

### Skill 小失误

升级过程中 **Mobility 多投了 2 ranks**。这不会破坏构筑，只是浪费了 2 个 skill points；Crane Style / Fighting Defensively 实际只需要 Mobility 至少 3 ranks。

当前面板技能已经足够使用，不建议为了这 2 个 skill points 单独再洗一次。以后不再继续加 Mobility，技能点优先 Perception，其次 Athletics。

### 当前剩余事项

目前没有发现需要重新洗点的结构性错误。

唯一仍未完成的是最终护甲：当前只有 Scalemail。后续找到更好的 **Medium Armor** 或 **Mithral Full Plate +4/+5** 时，再比较实际 AC。若换 Mithral Full Plate，必须确认 `Armor Focus (Medium Armor)` 仍然实际生效后再作为最终装备。
