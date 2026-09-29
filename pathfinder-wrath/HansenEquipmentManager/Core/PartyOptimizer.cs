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
                    if (actualSlot == null)
                        continue;
                    int score = ItemEvaluator.Score(item, view);
                    if (score <= 0)
                        continue;
                    offers.Add(new Offer { Item = item, View = view, Slot = actualSlot, Score = score });
                }
            }

            offers.Sort((a, b) => b.Score.CompareTo(a.Score));
            var usedItems = new HashSet<string>();
            var usedSlots = new HashSet<string>();
            var blockedTwoHand = new HashSet<string>();
            var blockedShield = new HashSet<string>();
            var chosen = new List<EquipmentRecommendation>();
            foreach (var offer in offers)
            {
                string itemId = offer.Item.UniqueId;
                string slotKey = offer.View.Unit.UniqueId + "|" + offer.Slot;
                if (usedItems.Contains(itemId) || usedSlots.Contains(slotKey))
                    continue;
                if (ItemEvaluator.IsTwoHanded(offer.Item) && blockedTwoHand.Contains(offer.View.Unit.UniqueId))
                    continue;
                if (offer.Slot == "SecondaryHand" && blockedShield.Contains(offer.View.Unit.UniqueId))
                    continue;

                usedItems.Add(itemId);
                usedSlots.Add(slotKey);
                if (ItemEvaluator.IsTwoHanded(offer.Item))
                    blockedShield.Add(offer.View.Unit.UniqueId);
                if (offer.Slot == "SecondaryHand")
                    blockedTwoHand.Add(offer.View.Unit.UniqueId);

                var conflict = offers.FirstOrDefault(other =>
                    other.Item.UniqueId == itemId && other.View.Unit.UniqueId != offer.View.Unit.UniqueId);
                bool worn = offer.Item.HoldingSlot != null &&
                            offer.Item.Wielder != null &&
                            ReferenceEquals(offer.Item.Wielder, offer.View.Unit.Descriptor);
                chosen.Add(new EquipmentRecommendation
                {
                    Character = offer.View.Unit.CharacterName,
                    UnitId = offer.View.Unit.UniqueId,
                    Slot = offer.Slot,
                    Blueprint = offer.Item.Blueprint.name,
                    ItemId = itemId,
                    Score = offer.Score,
                    AlreadyWorn = worn,
                    Conflict = conflict == null ? null : conflict.View.Unit.CharacterName + " score " + conflict.Score
                });
            }
            return chosen;
        }

        public static string Report(IList<EquipmentRecommendation> recommendations)
        {
            var text = new StringBuilder();
            text.AppendLine("Recommended");
            if (recommendations == null || recommendations.Count == 0)
            {
                text.AppendLine("No positive-score assignment.");
                return text.ToString();
            }
            foreach (var row in recommendations.Where(row => !row.AlreadyWorn))
            {
                text.AppendLine(row.Character + " " + row.Slot + " " + row.Blueprint + " Score " + row.Score);
                if (!string.IsNullOrEmpty(row.Conflict))
                    text.AppendLine("Conflict: " + row.Conflict + ". Resolution: " + row.Character + " has the higher score.");
            }
            return text.ToString();
        }

        public static List<PlannedAction> ToPlans(IList<EquipmentRecommendation> recommendations)
        {
            var plans = new List<PlannedAction>();
            foreach (var row in recommendations.Where(row => !row.AlreadyWorn))
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

        private sealed class Offer
        {
            public ItemEntity Item;
            public CharacterView View;
            public string Slot;
            public int Score;
        }
    }
}
