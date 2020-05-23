using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;

namespace CompanionRespec
{
    partial class Utils
    {
        public const char Separator = '-';

        public static (string name, int index) NameIndexAnalysis(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var indexStr = name.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                if (!string.IsNullOrWhiteSpace(indexStr) && int.TryParse(indexStr, out var index))
                {
                    return (name.Substring(0, name.Length - (indexStr.Length + 1)), index - 1); // input index starting at1
                }
            }
            return (name, default);
        }

        static readonly Lazy<PerkObject[]> lazy_allPerks = new Lazy<PerkObject[]>(GetAllPerks);

        public static PerkObject[] AllPerks => lazy_allPerks.Value;

        static PerkObject[] GetAllPerks()
        {
            var perks = new HashSet<PerkObject>();
            var all_po = PerkObject.All;
            if (all_po != null)
            {
                foreach (var item in all_po)
                {
                    perks.Add(item);
                }
            }
            var all_def = DefaultPerks.GetAllPerks();
            if (all_def != null)
            {
                foreach (var item in all_def)
                {
                    perks.Add(item);
                }
            }
            var typeDefaultPerks = typeof(DefaultPerks);
            var typePerkObject = typeof(PerkObject);
            var classs = typeDefaultPerks.GetNestedTypes().Where(x => !x.IsGenericType && x.IsClass && x.IsAbstract && x.IsSealed);
            var fields = classs.SelectMany(x => x.GetProperties(BindingFlags.Public | BindingFlags.Static).Where(y => y.PropertyType == typePerkObject)).ToArray();
            foreach (var item in fields)
            {
                var value = item.GetValue(null);
                if (value != null && value is PerkObject perkObject)
                {
                    perks.Add(perkObject);
                }
            }
            return perks.ToArray();
        }
    }
}
