// Decompiled with JetBrains decompiler
// Type: CompanionRespec.RespecFunctions
// Assembly: CompanionRespec, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94BDDB6C-D57A-434E-9C4A-3FE10DCDEE7A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\CompanionRespec\bin\Win64_Shipping_Client\CompanionRespec.dll

using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace CompanionRespec
{
    internal static partial class Utils
    {
        public static void DisplayMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            InformationManager.DisplayMessage(new InformationMessage(message));
        }

        public static void RespecHero(Hero hero)
        {
            if (hero == default) return;
            int num1 = 0;
            int num2 = 0;
            DisplayMessage(string.Format("{0}", hero));
            RespecPerks(hero);
            DisplayMessage("Clearing focus...");
            using (IEnumerator<SkillObject> enumerator = DefaultSkills.GetAllSkills().GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    int focus = hero.HeroDeveloper.GetFocus(current);
                    if (focus > 0)
                        num1 += focus;
                }
            }
            hero.HeroDeveloper.UnspentFocusPoints += MBMath.ClampInt(num1, 0, 999);
            hero.HeroDeveloper.ClearFocuses();
            DisplayMessage("Clearing stats...");
            for (CharacterAttributesEnum characterAttributesEnum = 0; characterAttributesEnum < CharacterAttributesEnum.End; characterAttributesEnum += 1)
            {
                int attributeValue = hero.GetAttributeValue(characterAttributesEnum);
                if (hero == Hero.MainHero)
                {
                    num2 += attributeValue - 2;
                    hero.SetAttributeValue(characterAttributesEnum, 2);
                }
                else
                {
                    num2 += attributeValue - 1;
                    hero.SetAttributeValue(characterAttributesEnum, 1);
                }
            }
            hero.HeroDeveloper.UnspentAttributePoints += MBMath.ClampInt(num2, 0, 999);
            DisplayMessage(string.Format("Unspent: {0} stat | {1} focus", hero.HeroDeveloper.UnspentAttributePoints, hero.HeroDeveloper.UnspentFocusPoints));
        }

        public static void ResetPerksCheckSmithPerk(Hero hero)
        {
            if (hero.HeroDeveloper.GetPerkValue(DefaultPerks.Crafting.VigorousSmith))
            {
                // 第一排第六个
                // 有力的铁匠，立刻提升一点活力
                int value = hero.GetAttributeValue(CharacterAttributesEnum.Vigor) - 1;
                DisplayMessage($"VigorousSmith Vigor: {value}");
                if (value > 0) hero.SetAttributeValue(CharacterAttributesEnum.Vigor, value);
            }
            if (hero.HeroDeveloper.GetPerkValue(DefaultPerks.Crafting.StrongSmith))
            {
                // 第二排第六个
                // 精密锻造，立刻增加一点控制
                int value = hero.GetAttributeValue(CharacterAttributesEnum.Control) - 1;
                DisplayMessage($"StrongSmith Control: {value}");
                if (value > 0) hero.SetAttributeValue(CharacterAttributesEnum.Control, value);
            }
            if (hero.HeroDeveloper.GetPerkValue(DefaultPerks.Crafting.EnduringSmith))
            {
                // 第一排倒数第二个
                // 正规铁匠，立刻提高忍耐1级
                int value = hero.GetAttributeValue(CharacterAttributesEnum.Endurance) - 1;
                DisplayMessage($"EnduringSmith Endurance: {value}");
                if (value > 0) hero.SetAttributeValue(CharacterAttributesEnum.Endurance, value);
            }
            if (hero.HeroDeveloper.GetPerkValue(DefaultPerks.Crafting.WeaponMasterSmith))
            {
                // 第二排倒数第二个
                // 击剑铁匠，单手系和双手系技能各获得1点专精点
                hero.HeroDeveloper.AddFocus(DefaultSkills.OneHanded, -1, false);
                hero.HeroDeveloper.AddFocus(DefaultSkills.TwoHanded, -1, false);
                DisplayMessage($"WeaponMasterSmith");
            }
            hero.ClearPerks();
            // ??? why setInitialSkillLevel
            foreach (var item in DefaultSkills.GetAllSkills())
            {
                int skillValue = hero.GetSkillValue(item);
                hero.HeroDeveloper.SetInitialSkillLevel(item, skillValue);
            }
        }

        public static void RespecPerks(Hero hero)
        {
            if (hero == default) return;
            DisplayMessage("Clearing perks...");
            ResetPerksCheckSmithPerk(hero);
        }

        public static void FillUp(Hero hero) => FillUp(hero,/*DefaultSkills.MaxAssumedValue*/ 330);

        public static void FillUp(Hero hero, int skillValue, bool ignorePerks = true)
        {
            if (hero == default) return;
            try
            {
                DisplayMessage(string.Format("FillUp {0}", hero));
                hero.HeroDeveloper.ClearFocuses();
                hero.ClearAttributes();
                //hero.ClearPerks();
                foreach (var skill in DefaultSkills.GetAllSkills())
                {
                    hero.SetSkillValue(skill, skillValue);
                    var xpValue = Campaign.Current.Models.CharacterDevelopmentModel.GetXpRequiredForSkillLevel(skillValue);
                    hero.HeroDeveloper.SetPropertyValue(skill, xpValue);
                    //var focus = hero.HeroDeveloper.GetFocus(skill);
                    //var changeAmount = HeroDeveloper.MaxFocusPerSkill - focus;
                    //hero.HeroDeveloper.AddFocus(skill, changeAmount, false);
                    // 因为上面调用了 ClearFocuses 这里直接给max
                    hero.HeroDeveloper.AddFocus(skill, HeroDeveloper.MaxFocusPerSkill, false);
                }
                for (var i = CharacterAttributesEnum.First; i < CharacterAttributesEnum.End; i++)
                {
                    try
                    {
                        //hero.HeroDeveloper.AddAttribute((CharacterAttributesEnum)item, HeroDeveloper.MaxAttribute, false);
                        hero.SetAttributeValue(i, HeroDeveloper.MaxAttribute);
                    }
                    catch (Exception e)
                    {
                        DisplayMessage($"Attr(catch) item: {i}" + e.ToString());
                    }
                }
                if (!ignorePerks)
                {
                    #region Perks
                    foreach (var item in AllPerks)
                    {
                        try
                        {
                            hero.HeroDeveloper.AddPerk(item);
                        }
                        catch (Exception e)
                        {
                            DisplayMessage($"Perk(catch) item: {item}" + e.ToString());
                        }
                    }
                    #endregion
                }
                hero.Level = 1;
                hero.HeroDeveloper.UnspentAttributePoints = 0;
                hero.HeroDeveloper.UnspentFocusPoints = 0;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.ToString());
            }
        }

        public static bool CheckLegendarySmith(Hero hero)
        {
            return hero.HeroDeveloper.GetPerkValue(DefaultPerks.Crafting.LegendarySmith);
        }

        public static string CheckLegendarySmith(IEnumerable<Hero> findHeros)
            => Handle2(findHeros, nameof(DefaultPerks.Crafting.LegendarySmith), CheckLegendarySmith);

        public static bool AddLegendarySmith(Hero hero)
        {
            if (!CheckLegendarySmith(hero))
            {
                hero.HeroDeveloper.AddPerk(DefaultPerks.Crafting.LegendarySmith);
                return CheckLegendarySmith(hero);
            }
            else
            {
                return true;
            }
        }

        public static string AddLegendarySmith(IEnumerable<Hero> findHeros)
            => Handle2(findHeros, nameof(DefaultPerks.Crafting.LegendarySmith), AddLegendarySmith);

        public static void RespecReset(Hero hero)
        {
            if (hero == default) return;
            DisplayMessage(string.Format("Reset {0}", hero));
            hero.HeroDeveloper.ClearFocuses();
            hero.ClearAttributes();
            using (IEnumerator<SkillObject> enumerator = DefaultSkills.GetAllSkills().GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    hero.HeroDeveloper.SetInitialSkillLevel(current, 5);
                }
            }
            hero.HeroDeveloper.SetInitialSkillLevel(DefaultSkills.OneHanded, 10);
            hero.HeroDeveloper.SetInitialSkillLevel(DefaultSkills.TwoHanded, 10);
            hero.HeroDeveloper.SetInitialSkillLevel(DefaultSkills.Polearm, 10);
            hero.HeroDeveloper.SetInitialSkillLevel(DefaultSkills.Bow, 10);
            hero.HeroDeveloper.SetInitialSkillLevel(DefaultSkills.Crossbow, 10);
            hero.HeroDeveloper.SetInitialSkillLevel(DefaultSkills.Throwing, 10);
            hero.ClearPerks();
            HeroHelper.DetermineInitialLevel(hero);
            if (hero == Hero.MainHero)
            {
                for (CharacterAttributesEnum characterAttributesEnum = 0; characterAttributesEnum < CharacterAttributesEnum.End; characterAttributesEnum += 1)
                    hero.SetAttributeValue(characterAttributesEnum, 2);
                hero.HeroDeveloper.UnspentAttributePoints = 6;
                hero.HeroDeveloper.UnspentFocusPoints = 13;
            }
            else
            {
                hero.HeroDeveloper.UnspentAttributePoints = 9;
                hero.HeroDeveloper.UnspentFocusPoints = 5;
            }
        }

        public static (string name, int index)[] GetNames(IEnumerable<string> names)
            => names.Select(name => NameIndexAnalysis(name.Replace('_', ' ').Trim(new char[] { '"', '“', '”' }))).ToArray();

        public static Hero[] NpcHeros
        {
            get
            {
                var npcHeros = new[] {
                    new[] { Hero.MainHero }, // Me
                    Hero.MainHero.Clan.Companions.Where(x => Hero.MainHero.CompanionsInParty.Contains(x)).ToArray(), // CompanionsInParty 
                    Hero.MainHero.Clan.Heroes.Where(x => x.PartyBelongedTo != null && x.PartyBelongedTo.IsMainParty).ToArray() // Heroes PartyBelongedTo IsMainParty
                }.SelectMany(x => x).Distinct().ToArray();
                return npcHeros;
            }
        }

        public static Hero[] Search(IEnumerable<string> inputNames)
        {
            (string name, int index)[] names = GetNames(inputNames);
            var findHeros = new Hero[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                var name = names[i];
                int currentIndex = 0;
                Hero currentHero = null;
                var npcHeros = NpcHeros;
                foreach (var npcHero in npcHeros)
                {
                    if (string.Equals(name.name, npcHero.Name.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (currentIndex == name.index)
                        {
                            currentHero = npcHero;
                            break;
                        }
                        currentIndex++;
                    }
                }
                findHeros[i] = currentHero;
            }
            return findHeros;
        }

        public static string Handle(IEnumerable<Hero> findHeros, Action<Hero> action)
        {
            var stringBuilder = new StringBuilder();
            foreach (var npcHero in findHeros)
            {
                if (npcHero != null)
                {
                    action?.Invoke(npcHero);
                    stringBuilder.Append($"{npcHero.Name} ");
                }
            }
            DisplayMessage(stringBuilder.ToString());
            return stringBuilder.Length > 0 ? "Done" : "Not Found";
        }

        public static string Handle(IEnumerable<string> inputNames, Action<Hero> action)
        {
            var findHeros = Search(inputNames);
            return Handle(findHeros, action);
        }

        public static string Handle2(IEnumerable<Hero> findHeros, string tag, Func<Hero, bool> func)
        {
            var stringBuilder_has = new StringBuilder();
            var stringBuilder_not_has = new StringBuilder();
            foreach (var npcHero in findHeros)
            {
                if (npcHero != null)
                {
                    var has = func(npcHero);
                    (has ? stringBuilder_has : stringBuilder_not_has).Append($"{npcHero.Name} ");
                }
            }
            var isDone = false;
            if (stringBuilder_has.Length > 0)
            {
                DisplayMessage($"({bool.TrueString}){tag}");
                DisplayMessage(stringBuilder_has.ToString());
                isDone = true;
            }
            if (stringBuilder_not_has.Length > 0)
            {
                DisplayMessage($"({bool.FalseString}){tag}");
                DisplayMessage(stringBuilder_not_has.ToString());
                isDone = true;
            }
            return isDone ? "Done" : "Not Found";
        }
    }
}
