// Decompiled with JetBrains decompiler
// Type: CompanionRespec.ConsoleCommand
// Assembly: CompanionRespec, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94BDDB6C-D57A-434E-9C4A-3FE10DCDEE7A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CompanionRespec\bin\Win64_Shipping_Client\CompanionRespec.dll

#pragma warning disable IDE0060 // 删除未使用的参数

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace CompanionRespec
{
    public static class ConsoleCommand
    {
        /// <summary>
        /// campaign.respec_mainhero - 重置玩家的 属性点/专精点/技能点
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        [CommandLineFunctionality.CommandLineArgumentFunction("respec_mainhero", "campaign")]
        public static string Respec_MainHero(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            Utils.RespecHero(Hero.MainHero);
            return "[Done]";
        }

        /// <summary>
        /// campaign.respec_allcompanions - 重置玩家队伍中的随从的 属性点/专精点/技能点
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        [CommandLineFunctionality.CommandLineArgumentFunction("respec_allcompanions", "campaign")]
        public static string Respec_Companions(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            var mainHero = Hero.MainHero;
            if (mainHero.PartyBelongedTo == null || mainHero.Clan == null)
                return "Party or Clan is null. What have you done?!";
            if (mainHero.Clan.Companions.Count == 0)
                return "You have no companions";
            var stringBuilder = new StringBuilder();
            foreach (var npcHero in mainHero.Clan.Companions)
            {
                if (npcHero != null && npcHero.PartyBelongedTo == mainHero.PartyBelongedTo)
                {
                    Utils.RespecHero(npcHero);
                    stringBuilder.Append($"{npcHero.Name} ");
                }
            }
            Utils.DisplayMessage(stringBuilder.ToString());
            var mainHeroCompanionsInPartyCount = mainHero.CompanionsInParty.Count();
            if (mainHero.Clan.Companions.Count > mainHeroCompanionsInPartyCount)
            {
                return string.Format("Done. {0} companion(s) were excluded (not in party)", mainHero.Clan.Companions.Count - mainHeroCompanionsInPartyCount);
            }
            return "Done";
        }

        /// <summary>
        /// campaign.respec_companion [name] - 通过英文名指定npc重置 属性点/专精点/技能点
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        [CommandLineFunctionality.CommandLineArgumentFunction("respec_companion", "campaign")]
        public static string Respec_1Hero(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            if (CampaignCheats.CheckParameters(strings, 0) || CampaignCheats.CheckHelp(strings))
                return "Format is \"campaign.respec_companion [Hero Name]\"";
            return Utils.Handle(strings, Utils.RespecHero);
        }

        /// <summary>
        /// campaign.respec_perks [name] - 通过英文名指定npc重置 技能点
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        [CommandLineFunctionality.CommandLineArgumentFunction("respec_perks", "campaign")]
        public static string Respec_Perks(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            if (CampaignCheats.CheckParameters(strings, 0) || CampaignCheats.CheckHelp(strings))
                return "Format is \"campaign.respec_perks [Hero Name]\"";
            return Utils.Handle(strings, Utils.RespecPerks);
        }

        /// <summary>
        /// campaign.respec_reset [name] - 通过英文名指定npc重置为最低级别1状态，并具有平衡的起始技能点和可用于花费已知问题的所有起始属性点/专精点
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        [CommandLineFunctionality.CommandLineArgumentFunction("respec_reset", "campaign")]
        public static string Respec_Reset(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            if (CampaignCheats.CheckParameters(strings, 0) || CampaignCheats.CheckHelp(strings))
                return "Format is \"campaign.respec_reset [Hero Name]\"";
            return Utils.Handle(strings, Utils.RespecReset);
        }

        /// <summary>
        /// campaign.respec_allnpcs - 重置玩家队伍中的所有npc的 属性点/专精点/技能点
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        [CommandLineFunctionality.CommandLineArgumentFunction("respec_allnpcs", "campaign")]
        public static string Respec_NPCs(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            var mainHero = Hero.MainHero;
            if (mainHero.PartyBelongedTo == null || mainHero.Clan == null)
                return "Party or Clan is null. What have you done?!";
            if (mainHero.Clan.Companions.Count == 0)
                return "You have no companions";
            var npcHeros = Utils.NpcHeros;
            return Utils.Handle(npcHeros, Utils.RespecHero);
        }

        /// <summary>
        /// <para>campaign.fill_up all - 玩家队伍中的所有npc的 属性点/专精点 加满，熟练度全部设为330</para>
        /// <para>campaign.fill_up all [num] - 玩家队伍中的所有npc的 属性点/专精点 加满，熟练度全部设为输入的num，例如999，格式必须为正整数，值太大会崩溃</para>
        /// <para>campaign.fill_up [name] [num] - 通过英文名指定npc的 属性点/专精点 加满，熟练度全部设为输入的num</para>
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        [CommandLineFunctionality.CommandLineArgumentFunction("fill_up", "campaign")]
        public static string FillUp(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            if (CampaignCheats.CheckParameters(strings, 0) || CampaignCheats.CheckHelp(strings))
                return "Format is \"campaign.fill_up [Hero Name]\"";
            switch (strings.Count)
            {
                case 1 when strings.Single().Trim() == "all":
                    return Utils.Handle(Utils.NpcHeros, Utils.FillUp);
                case 2 when strings.First().Trim() == "all" && int.TryParse(strings.Last().Trim(), out var skillValue):
                    return Utils.Handle(Utils.NpcHeros, hero => Utils.FillUp(hero, skillValue));
                default:
                    if (int.TryParse(strings.Last().Trim(), out var skillValue2))
                        return Utils.Handle(strings, hero => Utils.FillUp(hero, skillValue2));
                    return Utils.Handle(strings, Utils.FillUp);
            }
        }

        /// <summary>
        /// <para>campaign.check_legendary_smith - 检查玩家是否有传奇铁匠技能点，控制台上显示True表示有，False表示没有</para>
        /// <para>campaign.check_legendary_smith [name] - 通过英文名指定npc 检查是否有传奇铁匠技能点，在左下角日志输出有该技能点的npc名称，与没有该技能点的npc名称</para>
        /// <para>campaign.check_legendary_smith all 检查玩家部队中所有的npc是否有传奇铁匠技能点，并将结果输出在左下角日志中</para>
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>

        [CommandLineFunctionality.CommandLineArgumentFunction("check_legendary_smith", "campaign")]
        public static string CheckLegendarySmith(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            if (strings == null || !strings.Any()) return Utils.CheckLegendarySmith(Hero.MainHero).ToString();
            switch (strings.Count)
            {
                case 1 when strings.Single().Trim() == "all":
                    return Utils.CheckLegendarySmith(Utils.NpcHeros);
                default:
                    return Utils.CheckLegendarySmith(Utils.Search(strings));
            }
        }

        /// <summary>
        /// <para>campaign.add_perk_legendary_smith - 给玩家点上传奇铁匠技能点</para>
        /// <para>campaign.add_perk_legendary_smith [name] 通过英文名指定npc 点上传奇铁匠技能点</para>
        /// <para>campaign.add_perk_legendary_smith all 给玩家部队中所有的npc点上传奇铁匠技能点</para>
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        [CommandLineFunctionality.CommandLineArgumentFunction("add_perk_legendary_smith", "campaign")]
        public static string AddPerkLegendarySmith(List<string> strings)
        {
            if (Campaign.Current == null)
                return "Campaign is null";
            if (strings == null || !strings.Any()) return Utils.AddLegendarySmith(Hero.MainHero).ToString();
            switch (strings.Count)
            {
                case 1 when strings.Single().Trim() == "all":
                    return Utils.AddLegendarySmith(Utils.NpcHeros);
                default:
                    return Utils.AddLegendarySmith(Utils.Search(strings));
            }
        }
    }
}
