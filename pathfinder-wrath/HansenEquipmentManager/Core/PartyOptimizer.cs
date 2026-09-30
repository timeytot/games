using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Items;

namespace HansenEquipmentManager
{
    public static class PartyOptimizer
    {
        public static List<EquipmentRecommendation> Recommend(IList<CharacterView> party)
        {
            var offers = new List<Offer>();
            foreach (var item in DistinctItems())
            {
                string slot = ItemEvaluator.SlotName(item);
                if (slot == null || item.Blueprint == null)
                    continue;
                foreach (var view in party)
                {
                    string actualSlot = FirstAcceptingSlot(view.Unit, item, slot);
                    if (actualSlot == null || ConflictsWithShield(view, item, actualSlot))
                        continue;
                    var row = new EquipmentRecommendation();
                    ItemEvaluator.Explain(item, view, true, true, row);
                    if (row.Score < 20)
                        continue;
                    offers.Add(new Offer { Item = item, View = view, Slot = actualSlot, Row = row });
                }
            }

            var byItem = new Dictionary<string, List<Offer>>();
            foreach (var offer in offers)
            {
                List<Offer> list;
                if (!byItem.TryGetValue(offer.Item.UniqueId, out list))
                {
                    list = new List<Offer>();
                    byItem[offer.Item.UniqueId] = list;
                }
                list.Add(offer);
            }

            var candidates = new List<EquipmentRecommendation>();
            foreach (var pair in byItem)
            {
                var ranked = pair.Value.OrderByDescending(offer => offer.Row.Score).ToList();
                var best = ranked[0];
                var second = ranked.Count > 1 ? ranked[1] : null;
                bool worn = best.Item.HoldingSlot != null &&
                            best.Item.Wielder != null &&
                            ReferenceEquals(best.Item.Wielder, best.View.Unit.Descriptor);
                var row = best.Row;
                row.Character = NameOf(best.View.Unit);
                row.UnitId = best.View.Unit.UniqueId;
                row.Slot = best.Slot;
                row.Blueprint = best.Item.Blueprint.name;
                row.ItemId = best.Item.UniqueId;
                row.Current = CurrentName(best.View.Unit, best.Slot);
                row.AlreadyWorn = worn;
                row.TwoHanded = ItemEvaluator.IsTwoHanded(best.Item);
                row.Reason = "Stats +" + row.StatScore + ", Crit +" + row.CritScore + ", Build +" + row.BuildScore + ", Compatibility +" + row.CompatibilityScore;
                row.Confidence = row.Score;
                if (ReplacesEquippedWeapon(row))
                {
                    row.NeedsConfirmation = true;
                    row.Conflict = "replaces equipped " + row.Current;
                }
                if (IsSignatureWeapon(best.View, best.Slot))
                {
                    row.NeedsConfirmation = true;
                    row.Conflict = "class signature weapon stays until you confirm";
                }
                if (IsHandSlot(row.Slot) && Occupied(row.Current) && !worn)
                    ProtectExistingWeapon(row, best.View);
                if (second != null && best.Row.Score - second.Row.Score < 5 && string.IsNullOrEmpty(row.Conflict))
                {
                    row.NeedsConfirmation = true;
                    row.Apply = false;
                    row.Conflict = "close score with " + NameOf(second.View.Unit) + " " + second.Row.Score;
                }
                candidates.Add(row);
            }

            var usedItems = new HashSet<string>();
            var usedSlots = new HashSet<string>();
            var chosen = new List<EquipmentRecommendation>();
            foreach (var row in candidates.OrderByDescending(row => row.Score))
            {
                if (row.NeedsConfirmation)
                {
                    chosen.Add(row);
                    continue;
                }
                string slotKey = row.UnitId + "|" + row.Slot;
                if (usedItems.Contains(row.ItemId) || usedSlots.Contains(slotKey))
                    continue;
                usedItems.Add(row.ItemId);
                usedSlots.Add(slotKey);
                chosen.Add(row);
            }

            int applyCount = 0;
            foreach (var row in chosen.OrderByDescending(row => row.Score))
            {
                if (row.NeedsConfirmation || row.Skipped || row.AlreadyWorn || row.Score < 20)
                    continue;
                if (applyCount >= 5)
                    continue;
                row.Apply = true;
                applyCount++;
            }
            var twoHandUsers = new HashSet<string>();
            foreach (var row in chosen)
            {
                if (row.Apply && row.TwoHanded)
                    twoHandUsers.Add(row.UnitId);
            }
            foreach (var row in chosen)
            {
                if (row.Apply && row.Slot == "SecondaryHand" && twoHandUsers.Contains(row.UnitId))
                {
                    row.Apply = false;
                    row.Conflict = "conflicts with a two-handed weapon; not equipped together";
                }
            }
            return OneDecisionPerSlot(chosen);
        }

        private static List<EquipmentRecommendation> OneDecisionPerSlot(List<EquipmentRecommendation> chosen)
        {
            var shown = new List<EquipmentRecommendation>();
            var seen = new HashSet<string>();
            foreach (var row in chosen.OrderByDescending(row => row.Score))
            {
                if (!row.Apply && !row.NeedsConfirmation && !row.Skipped)
                    continue;
                if (row.Conflict != null && row.Conflict.StartsWith("close score"))
                    continue;
                string key = row.UnitId + "|" + row.Slot;
                if (seen.Contains(key))
                    continue;
                seen.Add(key);
                shown.Add(row);
            }
            return shown;
        }

        public static string Report(IList<EquipmentRecommendation> recommendations)
        {
            var text = new StringBuilder();
            text.AppendLine("Recommended changes");
            if (recommendations == null || recommendations.Count == 0)
            {
                text.AppendLine("No confident change.");
                return text.ToString();
            }
            foreach (var row in recommendations.Where(row => row.Apply))
            {
                text.AppendLine(DescribeChange(row));
            }
            foreach (var row in recommendations.Where(row => row.NeedsConfirmation))
            {
                text.AppendLine(DescribeChange(row));
                text.AppendLine("NEEDS CONFIRMATION. Not equipped. " + row.Conflict);
            }
            foreach (var row in recommendations.Where(row => row.Skipped))
            {
                text.AppendLine("SKIPPED:");
                text.AppendLine(DescribeChange(row));
                text.AppendLine(row.Conflict);
            }
            return text.ToString();
        }

        public static string ChangeList(IList<EquipmentRecommendation> recommendations)
        {
            var text = new StringBuilder();
            text.AppendLine("Changes:");
            bool any = false;
            if (recommendations != null)
            {
                foreach (var row in recommendations.Where(row => row.Apply))
                {
                    any = true;
                    text.AppendLine("");
                    text.AppendLine(DescribeChange(row));
                    text.AppendLine("Will equip when you confirm.");
                }
            }
            if (!any)
                text.AppendLine("No confident change.");
            if (recommendations != null)
            {
                foreach (var row in recommendations.Where(row => row.NeedsConfirmation))
                {
                    text.AppendLine("");
                    text.AppendLine("NEEDS CONFIRMATION");
                    text.AppendLine(DescribeChange(row));
                    text.AppendLine(row.Conflict);
                }
                foreach (var row in recommendations.Where(row => row.Skipped))
                {
                    text.AppendLine("");
                    text.AppendLine("SKIPPED");
                    text.AppendLine(DescribeChange(row));
                    text.AppendLine(row.Conflict);
                }
            }
            return text.ToString();
        }

        private static string DescribeChange(EquipmentRecommendation row)
        {
            string current = string.IsNullOrEmpty(row.Current) ? "empty" : row.Current;
            return row.Character + " " + SlotLabel(row.Slot) + "\n"
                + current + "\n->\n" + row.Blueprint
                + "\nScore: " + row.Score
                + "\nReason: " + row.Reason
                + "\nConfidence: " + row.Confidence + "%";
        }

        private const int ReplacementThreshold = 20;

        private static bool ConflictsWithShield(CharacterView view, ItemEntity item, string slot)
        {
            if (slot == "PrimaryHand" && ItemEvaluator.IsTwoHanded(item) && SecondaryIsShield(view))
                return true;
            if (slot == "SecondaryHand" && IsShieldItem(item) && PrimaryIsTwoHanded(view))
                return true;
            return false;
        }

        private static bool SecondaryIsShield(CharacterView view)
        {
            var slot = EquipmentScanner.SlotOf(view.Unit, "SecondaryHand");
            return slot != null && IsShieldItem(slot.MaybeItem);
        }

        private static bool PrimaryIsTwoHanded(CharacterView view)
        {
            var slot = EquipmentScanner.SlotOf(view.Unit, "PrimaryHand");
            return slot != null && ItemEvaluator.IsTwoHanded(slot.MaybeItem);
        }

        private static bool IsShieldItem(ItemEntity item)
        {
            return item != null && item.Blueprint != null &&
                   item.Blueprint.GetType().Name.IndexOf("Shield", System.StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static bool IsHandSlot(string slot)
        {
            return slot == "PrimaryHand" || slot == "SecondaryHand";
        }

        private static bool Occupied(string current)
        {
            return !string.IsNullOrEmpty(current) && current != "empty" && current != "missing";
        }

        private static void ProtectExistingWeapon(EquipmentRecommendation row, CharacterView view)
        {
            int currentScore = EquippedScore(view, row.Slot);
            int delta = row.Score - currentScore;
            row.Apply = false;
            row.Reason = "Existing weapon protected. Delta " + delta + ". " + row.Reason;
            if (delta < ReplacementThreshold)
            {
                row.NeedsConfirmation = false;
                row.Skipped = true;
                row.Conflict = "Replacement threshold not reached";
            }
            else
            {
                row.Skipped = false;
                row.NeedsConfirmation = true;
                row.Conflict = "Existing weapon protected until you confirm";
            }
        }

        private static int EquippedScore(CharacterView view, string slot)
        {
            var itemSlot = EquipmentScanner.SlotOf(view.Unit, slot);
            if (itemSlot == null || itemSlot.MaybeItem == null)
                return 0;
            var scored = new EquipmentRecommendation();
            ItemEvaluator.Explain(itemSlot.MaybeItem, view, true, true, scored);
            return scored.Score < 0 ? 0 : scored.Score;
        }

        private static bool ReplacesEquippedWeapon(EquipmentRecommendation row)
        {
            if (row.Slot != "PrimaryHand" && row.Slot != "SecondaryHand")
                return false;
            return !string.IsNullOrEmpty(row.Current) && row.Current != "empty" && row.Current != "missing" && row.Current != row.Blueprint;
        }

        private static bool IsSignatureWeapon(CharacterView view, string slot)
        {
            if (view == null || view.Rules == null || view.Rules.signatureCategories == null)
                return false;
            var slotItem = EquipmentScanner.SlotOf(view.Unit, slot);
            if (slotItem == null || slotItem.MaybeItem == null)
                return false;
            var weapon = slotItem.MaybeItem.Blueprint as Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon;
            if (weapon == null)
                return false;
            string category = weapon.Category.ToString();
            foreach (var signature in view.Rules.signatureCategories)
            {
                if (string.Equals(signature, category, System.StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private static bool HasShield(CharacterView view)
        {
            if (view == null || CharacterAnalyzer.Weight(view.Rules, "Shield") <= 0)
                return false;
            string current = EquipmentScanner.Describe(EquipmentScanner.SlotOf(view.Unit, "SecondaryHand"));
            return current != "empty" && current != "missing";
        }

        public static string SlotLabel(string slot)
        {
            switch (slot)
            {
                case "PrimaryHand": return "Primary hand";
                case "SecondaryHand": return "Secondary hand";
                case "Armor": return "Armor";
                case "Head": return "Head";
                case "Neck": return "Neck";
                case "Belt": return "Belt";
                case "Feet": return "Boots";
                case "Gloves": return "Gloves";
                case "Wrist": return "Wrist";
                case "Shoulders": return "Cloak";
                case "Glasses": return "Glasses";
                case "Shirt": return "Shirt";
                case "Ring1": return "Ring 1";
                case "Ring2": return "Ring 2";
                default: return slot;
            }
        }

        public static List<PlannedAction> ToPlans(IList<EquipmentRecommendation> recommendations)
        {
            var plans = new List<PlannedAction>();
            foreach (var row in recommendations.Where(row => row.Apply))
            {
                plans.Add(new PlannedAction
                {
                    Status = PlanStatus.Ready,
                    ItemId = row.ItemId,
                    Rule = new EquipmentRule
                    {
                        character = row.Character,
                        unitId = row.UnitId,
                        slot = row.Slot,
                        blueprint = row.Blueprint
                    }
                });
            }
            return plans;
        }

        private static string FirstAcceptingSlot(UnitEntityData unit, ItemEntity item, string slot)
        {
            if (slot != "Ring")
            {
                var target = EquipmentScanner.SlotOf(unit, slot);
                return target != null && target.CanInsertItem(item) ? slot : null;
            }
            if (CanUse(unit, item, "Ring1"))
                return "Ring1";
            if (CanUse(unit, item, "Ring2"))
                return "Ring2";
            return null;
        }

        private static bool CanUse(UnitEntityData unit, ItemEntity item, string slot)
        {
            var target = EquipmentScanner.SlotOf(unit, slot);
            return target != null && target.CanInsertItem(item);
        }

        private static IEnumerable<ItemEntity> DistinctItems()
        {
            return Kingmaker.Game.Instance.Player.Inventory.Items
                .Where(item => item != null && item.Blueprint != null)
                .GroupBy(item => item.UniqueId)
                .Select(group => group.First());
        }

        private static string NameOf(UnitEntityData unit)
        {
            return string.IsNullOrEmpty(unit.CharacterName) ? unit.UniqueId : unit.CharacterName;
        }

        private static string CurrentName(UnitEntityData unit, string slot)
        {
            return EquipmentScanner.Describe(EquipmentScanner.SlotOf(unit, slot));
        }

        private sealed class Offer
        {
            public ItemEntity Item;
            public CharacterView View;
            public string Slot;
            public EquipmentRecommendation Row;
        }
    }
}
