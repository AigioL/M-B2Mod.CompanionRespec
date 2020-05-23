# MB2Mod.CompanionRespec

```
原mod地址：https://www.nexusmods.com/mountandblade2bannerlord/mods/378

使用mod前推荐先单独存一个档！！！！！！！！

修改内容：
修改了name参数的查询逻辑与格式
添加了一些新的命令

命令：
campaign.respec_mainhero - 重置玩家的 属性点/专精点/技能点

campaign.respec_allcompanions - 重置玩家队伍中的随从的 属性点/专精点/技能点

campaign.respec_companion [name] - 通过英文名指定npc重置 属性点/专精点/技能点

campaign.respec_perks [name] - 通过英文名指定npc重置 技能点

campaign.respec_reset [name] - 通过英文名指定npc重置为最低级别1状态，并具有平衡的起始技能点和可用于花费已知问题的所有起始属性点/专精点

campaign.respec_allnpcs - 重置玩家队伍中的所有npc的 属性点/专精点/技能点

----- 添加的新命令(功能性) -----

campaign.check_legendary_smith - 检查玩家是否有传奇铁匠技能点，控制台上显示True表示有，False表示没有

campaign.check_legendary_smith [name] - 通过英文名指定npc 检查是否有传奇铁匠技能点，在左下角日志输出有该技能点的npc名称，与没有该技能点的npc名称

campaign.check_legendary_smith all 检查玩家部队中所有的npc是否有传奇铁匠技能点，并将结果输出在左下角日志中

campaign.add_perk_legendary_smith - 给玩家点上传奇铁匠技能点

campaign.add_perk_legendary_smith [name] 通过英文名指定npc 点上传奇铁匠技能点

campaign.add_perk_legendary_smith all 给玩家部队中所有的npc点上传奇铁匠技能点

----- 添加的新命令(可能会破坏游戏体验) -----

campaign.fill_up all - 玩家队伍中的所有npc的 属性点/专精点 加满，熟练度全部设为330

campaign.fill_up all [num] - 玩家队伍中的所有npc的 属性点/专精点 加满，熟练度全部设为输入的num，例如999，格式必须为正整数，值太大会崩溃

campaign.fill_up [name] [num] - 通过英文名指定npc的 属性点/专精点 加满，熟练度全部设为输入的num

说明：
所有npc的(包含配偶/前配偶/孩子/随从)
注意：随从中包括【某某需要一位导师】或类似任务中给的npc

name 参数
npc的英文名，在【ESC-选项-游戏设置-语言-English】 将游戏改为英文后，可以看到人物的英文名，英文不区分大小写
英文名中存在空格 则需要使用下划线_代替空格，通常为随从名，例如 chalia_the_black
npc名称重复，使用[英文名-2]表示第二个，例如得瑟特家族的莫尔孔 morcon-2
npc必须在队伍中，可以是配偶/前配偶/孩子/随从
可指定多个npc名字，使用空格分割

命令示例：
	campaign.respec_companion morcon
	campaign.respec_companion morcon-2
	campaign.respec_companion chalia_the_black
	campaign.fill_up all 999
	campaign.fill_up morcon 399

示例 name 中英对照：
	莫尔孔 - Morcon
	哈利娅 · 黑道 Chalia the Black
```
