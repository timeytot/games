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
        public static int Score(ItemEntity item, CharacterView view)
        {
            if (item == null || view == null || view.Rules == null)
                return 0;
            int total = 0;
            foreach (var signal in Signals(item))
                total += signal.Value * CharacterAnalyzer.Weight(view.Rules, signal.Key);
            return total;
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
