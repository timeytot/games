using System;
using System.Collections.Generic;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Items;
using Kingmaker.UnitLogic.FactLogic;

namespace HansenEquipmentManager
{
    public static class ItemEvaluator
    {
        public static void Explain(ItemEntity item, CharacterView view, bool canInsert, bool slotOk, EquipmentRecommendation row)
        {
            row.StatScore = 0;
            row.CritScore = 0;
            row.BuildScore = 0;
            row.CompatibilityScore = 0;
            row.Score = -999;
            if (!slotOk || !canInsert || item == null || view == null)
                return;

            var signals = Signals(item);
            int statRaw = 0;
            foreach (var signal in signals)
            {
                if (IsTag(signal.Key))
                    continue;
                int weight = CharacterAnalyzer.Weight(view.Rules, signal.Key);
                if (weight > 0)
                    statRaw += signal.Value * weight;
            }
            int enhancement = 0;
            signals.TryGetValue("Enhancement", out enhancement);
            int enhancementWeight = CharacterAnalyzer.Weight(view.Rules, "Enhancement");
            if (enhancementWeight > 0)
                statRaw += Math.Min(10, Math.Max(0, enhancement) * enhancementWeight);
            row.StatScore = Math.Min(50, Math.Max(0, statRaw));

            var weapon = item.Blueprint as BlueprintItemWeapon;
            if (weapon != null && CharacterAnalyzer.Weight(view.Rules, "Crit") > 0)
                row.CritScore = Math.Min(15, Math.Max(0, 21 - weapon.CriticalRollEdge) * Math.Min(5, CharacterAnalyzer.Weight(view.Rules, "Crit")) / 2);
            if (weapon != null && CharacterAnalyzer.Weight(view.Rules, weapon.Category.ToString()) > 0)
                row.CompatibilityScore = 15;
            else if (SlotName(item) == "SecondaryHand" && CharacterAnalyzer.Weight(view.Rules, "Shield") > 0)
                row.CompatibilityScore = 15;
            else if (weapon != null)
                row.CompatibilityScore = 5;
            int spell = 0;
            signals.TryGetValue("SpellDC", out spell);
            if (spell > 0 && CharacterAnalyzer.Weight(view.Rules, "SpellDC") > 0)
                row.CompatibilityScore = Math.Min(15, row.CompatibilityScore + 5);

            bool matched = row.StatScore > 0 || row.CritScore > 0 || row.CompatibilityScore >= 15;
            if (view.Rules != null && view.Rules.id != "Default" && matched)
                row.BuildScore = 20;
            row.Score = Math.Min(100, row.StatScore + row.CritScore + row.BuildScore + row.CompatibilityScore);
        }

        private static bool IsTag(string key)
        {
            return key == "Crit" || key == "Shield" || key == "Enhancement" || key == "SpellDC";
        }

        public static string SlotName(ItemEntity item)
        {
            if (item == null || item.Blueprint == null)
                return null;
            string type = item.Blueprint.GetType().Name;
            if (type.IndexOf("Shield", StringComparison.OrdinalIgnoreCase) >= 0)
                return "SecondaryHand";
            if (type.IndexOf("Weapon", StringComparison.OrdinalIgnoreCase) >= 0)
                return "PrimaryHand";
            if (type.IndexOf("Armor", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Armor";
            if (type.IndexOf("Head", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Head";
            if (type.IndexOf("Glasses", StringComparison.OrdinalIgnoreCase) >= 0 || type.IndexOf("Eyes", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Glasses";
            if (type.IndexOf("Neck", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Neck";
            if (type.IndexOf("Shoulder", StringComparison.OrdinalIgnoreCase) >= 0 || type.IndexOf("Cloak", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Shoulders";
            if (type.IndexOf("Ring", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Ring";
            if (type.IndexOf("Belt", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Belt";
            if (type.IndexOf("Feet", StringComparison.OrdinalIgnoreCase) >= 0 || type.IndexOf("Boot", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Feet";
            if (type.IndexOf("Glove", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Gloves";
            if (type.IndexOf("Wrist", StringComparison.OrdinalIgnoreCase) >= 0 || type.IndexOf("Bracer", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Wrist";
            if (type.IndexOf("Shirt", StringComparison.OrdinalIgnoreCase) >= 0 || type.IndexOf("Robe", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Shirt";
            return null;
        }

        public static bool IsTwoHanded(ItemEntity item)
        {
            var weapon = item == null ? null : item.Blueprint as BlueprintItemWeapon;
            return weapon != null && weapon.IsTwoHanded;
        }

        private static Dictionary<string, int> Signals(ItemEntity item)
        {
            var signals = new Dictionary<string, int>();
            Add(signals, "Enhancement", item.EnchantmentValue);
            Walk(item.Blueprint == null ? null : item.Blueprint.ComponentsArray, signals);
            if (item.Blueprint != null && item.Blueprint.Enchantments != null)
            {
                foreach (BlueprintItemEnchantment enchantment in item.Blueprint.Enchantments)
                {
                    if (enchantment == null)
                        continue;
                    Walk(enchantment.ComponentsArray, signals);
                    string name = enchantment.name ?? "";
                    if (name.IndexOf("SpellDC", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        name.IndexOf("IncreaseDC", StringComparison.OrdinalIgnoreCase) >= 0)
                        Add(signals, "SpellDC", 1);
                }
            }

            var weapon = item.Blueprint as BlueprintItemWeapon;
            if (weapon != null)
            {
                Add(signals, "Crit", Math.Max(0, 21 - weapon.CriticalRollEdge));
                Add(signals, weapon.Category.ToString(), 1);
            }
            if (SlotName(item) == "SecondaryHand")
                Add(signals, "Shield", 1 + Math.Max(0, item.EnchantmentValue));
            return signals;
        }

        private static void Walk(Kingmaker.Blueprints.BlueprintComponent[] components, Dictionary<string, int> signals)
        {
            if (components == null)
                return;
            foreach (var component in components)
            {
                var bonus = component as AddStatBonus;
                if (bonus == null || bonus.Stat == StatType.Unknown)
                    continue;
                Add(signals, bonus.Stat.ToString(), bonus.Value);
            }
        }

        private static void Add(Dictionary<string, int> signals, string key, int amount)
        {
            if (string.IsNullOrEmpty(key) || amount == 0)
                return;
            int current;
            signals.TryGetValue(key, out current);
            signals[key] = current + amount;
        }
    }
}
