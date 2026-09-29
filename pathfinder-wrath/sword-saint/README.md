# 剑圣

这个目录是剑圣档案的空框架。角色还没建，所以没有 GameId，没有单位编号，也没有一键 Buff 配置。

游戏现在不会读这个目录。不要把 FaN 或 Hansen 的 JSON 复制过来，那两份配置属于另外两个存档。

## 建档之后再填

先正常建号并保存一次，再把存档头里的 `GameId` 写到下面。Buff It 和 Wrath Tactics 都按这个编号分文件。

| 栏 | 现在 | 建档后要填 |
|---|---|---|
| 角色名 | 空 | 存档里的角色名 |
| GameId | 空 | `header.json` 的 `GameId` |
| 存档文件 | 空 | `Saved Games` 里对应的 `.zks` |
| 出战队伍 | 空 | 每人的 `UniqueId`、职业、法术书 |
| Buff It 实机文件 | 空 | `Mods\BuffIt2TheLimit\UserSettings\bi2tl-<GameId>.json` |
| Wrath Tactics 实机文件 | 空 | 如果这号用战术模组，再写 `Mods\WrathTactics\UserSettings\tactics-<GameId>.json` |

剑圣法术书蓝图是职业共用的，不是某个角色的编号：

`SwordSaintSpellbook` `682545e1-1e53-06c4-5b14-ca78bcbe3e62`

单位编号必须从那份存档的 `party.json` 读。建档前不要猜。

## 以后这个目录里放什么

- `BuffIt-OneClickBuff.md`：一键 Buff 说明。三个按钮仍是 Normal（`Long`）、Quick（`Quick`）、Important（`Important`）。
- `buffit-current-config.json`：实机 Buff It 配置的副本。
- `WrathModsConfiguration.zip`：上面两份的打包。游戏不读 zip。
- 如果要做构筑笔记，用英文文件名另写一份 markdown。

`../tools/refresh_current_snapshot.cmd` 只同步 FaN。剑圣存档出现之后，它也不会被写进 `lich/current/`。要给剑圣做存档快照，等有 GameId 再单独加。

写实机 JSON 之前先确认 `Wrath.exe` 没在运行。
