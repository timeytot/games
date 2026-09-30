using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Items;

namespace HansenEquipmentManager
{
    public static class EquipmentAdvisor
    {
        public static readonly List<AdvisorPick> Picks = new List<AdvisorPick>();
        public static readonly string[] SlotNames = { "PrimaryHand", "SecondaryHand", "Armor", "Head", "Neck", "Ring1", "Ring2", "Gloves", "Feet", "Belt", "Shoulders" };

        public static string PartyList()
        {
            var text = new StringBuilder();
            text.AppendLine("Active party");
            foreach (var unit in CharacterAnalyzer.ActiveParty())
                text.AppendLine(CharacterBlock(unit, null));
            return text.ToString();
        }

        public static string EquipmentList(IList<CharacterView> party)
        {
            Picks.Clear();
            var text = new StringBuilder();
            foreach (var view in party)
            {
                text.AppendLine("=== " + NameOf(view.Unit) + " ===");
                text.AppendLine(CharacterBlock(view.Unit, view.Rules));
                foreach (var slot in SlotNames)
                    text.AppendLine(SlotTable(view, slot));
                text.AppendLine("");
            }
            return text.ToString();
        }

        private static string CharacterBlock(UnitEntityData unit, BuildRuleSet rules)
        {
            var pair = EquipmentScanner.ClassAndMythic(unit);
            var text = new StringBuilder();
            text.AppendLine(NameOf(unit));
            text.AppendLine("Class:");
            text.AppendLine(pair.Item1);
            text.AppendLine("Archetype:");
            text.AppendLine(EquipmentScanner.ArchetypeLine(unit));
            text.AppendLine("Mythic:");
            text.AppendLine(pair.Item2);
            if (rules != null)
            {
                text.AppendLine("Build:");
                text.AppendLine(rules.id);
            }
            return text.ToString();
        }

        public static string DisplayName(ItemEntity item)
        {
            if (item == null)
                return "(empty)";
            if (!string.IsNullOrEmpty(item.Name))
                return item.Name;
            return item.Blueprint == null ? "(unknown)" : item.Blueprint.name;
        }

        public static ItemEntity FindSelectedItem(string blueprint)
        {
            return Kingmaker.Game.Instance.Player.Inventory.Items
                .Where(item => item != null && item.Blueprint != null && string.Equals(item.Blueprint.name, blueprint, StringComparison.Ordinal))
                .OrderBy(item => item.HoldingSlot == null ? 0 : 1)
                .FirstOrDefault();
        }

        private static string SlotTable(CharacterView view, string slot)
        {
            var itemSlot = EquipmentScanner.SlotOf(view.Unit, slot);
            var text = new StringBuilder();
            text.AppendLine("=== " + PartyOptimizer.SlotLabel(slot) + " ===");
            text.AppendLine("CURRENT EQUIPPED");
            if (itemSlot == null || itemSlot.MaybeItem == null)
                text.AppendLine("(empty)");
            else
            {
                text.AppendLine("[worn] " + DisplayName(itemSlot.MaybeItem));
                text.AppendLine("ID: " + itemSlot.MaybeItem.Blueprint.name);
            }
            text.AppendLine("AVAILABLE");
            var ranked = Candidates(view, slot).Take(3).ToList();
            if (ranked.Count == 0)
            {
                text.AppendLine("none");
                return text.ToString();
            }
            int rank = 1;
            foreach (var row in ranked)
            {
                string shown = DisplayName(row.Item);
                Picks.Add(new AdvisorPick
                {
                    Character = NameOf(view.Unit),
                    Slot = slot,
                    Blueprint = row.Item.Blueprint.name,
                    DisplayName = shown,
                    Copies = row.Copies,
                    Sources = string.Join(", ", row.Sources)
                });
                text.AppendLine(rank + ". " + shown);
                text.AppendLine("   ID: " + row.Item.Blueprint.name);
                text.AppendLine("   Copies: " + row.Copies);
                text.AppendLine("   Sources: " + string.Join(", ", row.Sources));
                text.AppendLine("   Can use: Yes");
                text.AppendLine("   Tags: " + row.Tags);
                rank++;
            }
            return text.ToString();
        }

        private static List<Candidate> Candidates(CharacterView view, string slot)
        {
            var groups = new Dictionary<string, Candidate>(StringComparer.Ordinal);
            foreach (var item in DistinctItems())
            {
                if (!SlotFits(item, slot))
                    continue;
                var target = EquipmentScanner.SlotOf(view.Unit, slot);
                if (target == null || target.MaybeItem == item || !target.CanInsertItem(item))
                    continue;
                string blueprint = item.Blueprint.name;
                Candidate row;
                if (!groups.TryGetValue(blueprint, out row))
                {
                    row = new Candidate
                    {
                        Item = item,
                        Tags = FactTags(item, slot),
                        Sort = SortKey(view, item, slot),
                        Sources = new List<string>()
                    };
                    groups[blueprint] = row;
                }
                row.Copies++;
                if (item.HoldingSlot == null && row.Item.HoldingSlot != null)
                    row.Item = item;
                string source = item.HoldingSlot == null ? "Inventory" : "Outside party";
                if (!row.Sources.Contains(source))
                    row.Sources.Add(source);
            }
            return groups.Values.OrderByDescending(row => row.Sort).ThenBy(row => row.Item.Blueprint.name).ToList();
        }

        private static string FactTags(ItemEntity item, string slot)
        {
            var tags = new List<string>();
            var weapon = item.Blueprint as BlueprintItemWeapon;
            if (weapon != null)
            {
                tags.Add(SplitWords(weapon.Category.ToString()));
                tags.Add(weapon.IsTwoHanded ? "two-hand" : "one-hand");
                if (slot == "PrimaryHand")
                    tags.Add(weapon.IsTwoHanded ? "not shield compatible" : "shield compatible");
            }
            else if (slot == "SecondaryHand")
                tags.Add("shield");
            else
                tags.Add(PartyOptimizer.SlotLabel(slot).ToLowerInvariant());
            return string.Join(", ", tags);
        }

        private static string SplitWords(string asset)
        {
            if (string.IsNullOrEmpty(asset))
                return asset;
            var text = new StringBuilder();
            for (int i = 0; i < asset.Length; i++)
            {
                if (i > 0 && char.IsUpper(asset[i]) && char.IsLower(asset[i - 1]))
                    text.Append(' ');
                text.Append(asset[i]);
            }
            return text.ToString();
        }

        private static bool SlotFits(ItemEntity item, string slot)
        {
            string natural = ItemEvaluator.SlotName(item);
            if (natural == "Ring")
                return slot == "Ring1" || slot == "Ring2";
            return natural == slot;
        }

        private static int SortKey(CharacterView view, ItemEntity item, string slot)
        {
            int key = ItemMatchesBuild(item, view) ? 2 : 0;
            if (slot == "PrimaryHand" && !ItemEvaluator.IsTwoHanded(item))
                key += 1;
            key += Math.Min(9, Math.Max(0, item.EnchantmentValue));
            return key;
        }

        private static bool ItemMatchesBuild(ItemEntity item, CharacterView view)
        {
            if (view.Rules == null || view.Rules.id == "Default")
                return false;
            var weapon = item.Blueprint as BlueprintItemWeapon;
            if (weapon != null && CharacterAnalyzer.Weight(view.Rules, weapon.Category.ToString()) > 0)
                return true;
            if (ItemEvaluator.SlotName(item) == "SecondaryHand" && CharacterAnalyzer.Weight(view.Rules, "Shield") > 0)
                return true;
            var probe = new EquipmentRecommendation();
            ItemEvaluator.Explain(item, view, true, true, probe);
            return probe.StatScore > 0;
        }

        private static IEnumerable<ItemEntity> DistinctItems()
        {
            var party = new HashSet<UnitEntityData>(CharacterAnalyzer.ActiveParty());
            return Kingmaker.Game.Instance.Player.Inventory.Items
                .Where(item => item != null && item.Blueprint != null && !WornByActiveParty(item, party))
                .GroupBy(item => item.UniqueId)
                .Select(group => group.First());
        }

        private static bool WornByActiveParty(ItemEntity item, HashSet<UnitEntityData> party)
        {
            if (item.HoldingSlot == null || item.Wielder == null)
                return false;
            foreach (var unit in party)
            {
                if (unit.Descriptor != null && ReferenceEquals(item.Wielder, unit.Descriptor))
                    return true;
            }
            return false;
        }

        private static string NameOf(UnitEntityData unit)
        {
            return string.IsNullOrEmpty(unit.CharacterName) ? unit.UniqueId : unit.CharacterName;
        }

        public sealed class AdvisorPick
        {
            public string Character;
            public string Slot;
            public string Blueprint;
            public string DisplayName;
            public int Copies;
            public string Sources;
        }

        private sealed class Candidate
        {
            public ItemEntity Item;
            public string Tags;
            public int Sort;
            public int Copies;
            public List<string> Sources;
        }
    }
}
