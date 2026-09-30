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
        private static readonly string[] Slots = { "PrimaryHand", "SecondaryHand", "Head", "Armor", "Neck" };

        public static string PartyList()
        {
            var text = new StringBuilder();
            text.AppendLine("Active party");
            foreach (var unit in CharacterAnalyzer.ActiveParty())
            {
                var pair = EquipmentScanner.ClassAndMythic(unit);
                text.AppendLine(NameOf(unit) + " | " + pair.Item1 + " | " + pair.Item2);
            }
            return text.ToString();
        }

        public static string EquipmentList(IList<CharacterView> party)
        {
            var text = new StringBuilder();
            foreach (var view in party)
            {
                var pair = EquipmentScanner.ClassAndMythic(view.Unit);
                text.AppendLine("# " + NameOf(view.Unit));
                text.AppendLine(pair.Item1 + " | " + pair.Item2 + " | build " + (view.Rules == null ? "none" : view.Rules.id));
                foreach (var slot in Slots)
                    text.AppendLine(SlotTable(view, slot));
                text.AppendLine("");
            }
            return text.ToString();
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
            text.AppendLine("## " + PartyOptimizer.SlotLabel(slot));
            text.AppendLine("Current: " + EquipmentScanner.Describe(itemSlot));
            var ranked = Candidates(view, slot).Take(3).ToList();
            if (ranked.Count == 0)
            {
                text.AppendLine("No usable candidate in the stash.");
                return text.ToString();
            }
            text.AppendLine("Rank | Item | Type | Can use | Shield | Build");
            int rank = 1;
            foreach (var row in ranked)
            {
                text.AppendLine(rank + " | " + row.Item.Blueprint.name + " | " + row.Type + " | yes | " + row.Shield + " | " + row.Build);
                rank++;
            }
            return text.ToString();
        }

        private static IEnumerable<Candidate> Candidates(CharacterView view, string slot)
        {
            var rows = new List<Candidate>();
            foreach (var item in DistinctItems())
            {
                if (!SlotFits(item, slot))
                    continue;
                var target = EquipmentScanner.SlotOf(view.Unit, slot);
                if (target == null || target.MaybeItem == item || !target.CanInsertItem(item))
                    continue;
                if (slot == "PrimaryHand" && ItemEvaluator.IsTwoHanded(item) && ShieldInOffhand(view))
                    continue;
                rows.Add(new Candidate
                {
                    Item = item,
                    Type = TypeLabel(item),
                    Shield = ShieldLabel(view, item, slot),
                    Build = ItemMatchesBuild(item, view) ? "High" : "Low",
                    Sort = SortKey(view, item, slot)
                });
            }
            return rows.OrderByDescending(row => row.Sort).ThenBy(row => row.Item.Blueprint.name);
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

        private static string ShieldLabel(CharacterView view, ItemEntity item, string slot)
        {
            if (slot != "PrimaryHand")
                return "-";
            if (!ShieldInOffhand(view))
                return ItemEvaluator.IsTwoHanded(item) ? "two-hand" : "one-hand";
            return ItemEvaluator.IsTwoHanded(item) ? "no" : "yes";
        }

        private static bool ShieldInOffhand(CharacterView view)
        {
            var slot = EquipmentScanner.SlotOf(view.Unit, "SecondaryHand");
            return slot != null && slot.MaybeItem != null && slot.MaybeItem.Blueprint != null &&
                   slot.MaybeItem.Blueprint.GetType().Name.IndexOf("Shield", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string TypeLabel(ItemEntity item)
        {
            string held = item.HoldingSlot == null ? "" : " held outside party";
            var weapon = item.Blueprint as BlueprintItemWeapon;
            if (weapon != null)
                return weapon.Category + (weapon.IsTwoHanded ? " two-hand" : " one-hand") + " +" + item.EnchantmentValue + held;
            return ItemEvaluator.SlotName(item) + " +" + item.EnchantmentValue + held;
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

        private sealed class Candidate
        {
            public ItemEntity Item;
            public string Type;
            public string Shield;
            public string Build;
            public int Sort;
        }
    }
}
