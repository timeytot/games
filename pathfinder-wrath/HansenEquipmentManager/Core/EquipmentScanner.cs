using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kingmaker;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Items;
using Kingmaker.Items.Slots;

namespace HansenEquipmentManager
{
    public static class EquipmentScanner
    {
        public static string DescribeParty()
        {
            var main = MainCharacter();
            var text = new StringBuilder();
            text.AppendLine("Detected save");
            if (main == null)
            {
                text.AppendLine("Main character was not found.");
                return text.ToString();
            }

            text.AppendLine("Main: " + Safe(main.CharacterName));
            text.AppendLine("Classes: " + ClassLine(main));
            text.AppendLine("Level: " + main.Progression.CharacterLevel);
            text.AppendLine("Mythic: " + MythicName(main) + " MR" + main.Progression.MythicLevel);
            text.AppendLine("Party:");
            foreach (var unit in Game.Instance.Player.AllCharacters)
            {
                if (unit == null)
                    continue;
                text.AppendLine("- " + Safe(unit.CharacterName) + " / " + ClassLine(unit) + " / " + unit.UniqueId);
            }
            return text.ToString();
        }

        public static EquipmentProfile Suggest(IList<EquipmentProfile> profiles)
        {
            var main = MainCharacter();
            if (main == null || profiles == null)
                return null;

            EquipmentProfile best = null;
            int bestScore = 0;
            foreach (var profile in profiles)
            {
                int score = MatchScore(main, profile);
                if (score > bestScore)
                {
                    best = profile;
                    bestScore = score;
                }
            }
            return bestScore > 0 ? best : null;
        }

        public static List<PlannedAction> Preview(EquipmentProfile profile)
        {
            var plans = new List<PlannedAction>();
            if (profile == null)
                return plans;
            foreach (var rule in profile.rules)
                plans.Add(Resolve(rule));
            return plans;
        }

        public static PlannedAction Resolve(EquipmentRule rule)
        {
            var plan = new PlannedAction { Rule = rule, Current = "missing" };
            var target = FindUnit(rule.character, rule.unitId);
            if (target == null)
            {
                plan.Status = PlanStatus.Missing;
                plan.Detail = "character not in this party";
                return plan;
            }

            var slot = SlotOf(target, rule.slot);
            if (slot == null)
            {
                plan.Status = PlanStatus.Missing;
                plan.Detail = "slot is not a real equipment slot: " + rule.slot;
                return plan;
            }

            plan.Current = Describe(slot);
            if (ItemMatches(slot.MaybeItem, rule.blueprint))
            {
                plan.Status = PlanStatus.AlreadyCorrect;
                plan.Detail = "profile rule, already equipped";
                plan.ItemId = slot.MaybeItem.UniqueId;
                return plan;
            }

            var candidates = Candidates(rule).ToList();
            if (candidates.Count == 0)
            {
                plan.Status = PlanStatus.Missing;
                plan.Detail = "no single safe copy of " + rule.blueprint;
                return plan;
            }
            if (candidates.Count > 1)
            {
                plan.Status = PlanStatus.NeedsChoice;
                plan.Detail = candidates.Count + " copies. Not chosen automatically.";
                return plan;
            }

            var item = candidates[0];
            if (!slot.CanInsertItem(item))
            {
                plan.Status = PlanStatus.Blocked;
                plan.Detail = "CanInsertItem=false for " + rule.blueprint;
                return plan;
            }

            plan.Status = PlanStatus.Ready;
            plan.ItemId = item.UniqueId;
            plan.Detail = string.IsNullOrEmpty(rule.donor) ? "profile rule, one unworn copy" : "profile rule, donor " + rule.donor;
            return plan;
        }

        public static string CandidateReport(ItemSlot primary)
        {
            var text = new StringBuilder();
            text.AppendLine("One-handed melee candidates for the current primary hand. Nothing is equipped.");
            if (primary == null)
            {
                text.AppendLine("Primary slot is missing.");
                return text.ToString();
            }

            int count = 0;
            foreach (var item in Game.Instance.Player.Inventory.Items)
            {
                var weapon = item as ItemEntityWeapon;
                if (weapon == null || weapon.HoldingSlot != null)
                    continue;
                var blueprint = weapon.Blueprint as BlueprintItemWeapon;
                if (blueprint == null || !blueprint.IsMelee || blueprint.IsTwoHanded)
                    continue;
                if (!primary.CanInsertItem(weapon))
                    continue;
                count++;
                text.AppendLine("ONEHAND Blueprint=" + blueprint.name
                    + " Category=" + blueprint.Category
                    + " Enhancement=" + weapon.EnchantmentValue
                    + " Cost=" + weapon.Cost);
            }
            text.AppendLine("ONEHAND count " + count);
            return text.ToString();
        }

        public static System.Tuple<string, string> ClassAndMythic(UnitEntityData unit)
        {
            return System.Tuple.Create(ClassLine(unit), MythicName(unit));
        }

        public static UnitEntityData MainCharacter()
        {
            if (Game.Instance == null || Game.Instance.Player == null)
                return null;
            return Game.Instance.Player.MainCharacter.Value;
        }

        public static UnitEntityData FindUnit(string name, string unitId)
        {
            var all = Game.Instance.Player.AllCharacters;
            if (!string.IsNullOrEmpty(unitId))
            {
                var byId = all.FirstOrDefault(unit => string.Equals(Convert.ToString(unit.UniqueId), unitId, StringComparison.OrdinalIgnoreCase));
                if (byId != null)
                    return byId;
            }
            if (string.IsNullOrEmpty(name))
                return null;
            return all.FirstOrDefault(unit =>
                string.Equals(unit.CharacterName, name, StringComparison.OrdinalIgnoreCase) ||
                (unit.Blueprint != null && string.Equals(unit.Blueprint.name, name, StringComparison.OrdinalIgnoreCase)));
        }

        public static ItemSlot SlotOf(UnitEntityData unit, string slot)
        {
            if (unit == null || unit.Body == null || string.IsNullOrEmpty(slot))
                return null;
            var hands = unit.Body.CurrentHandsEquipmentSet;
            switch (slot)
            {
                case "Armor": return unit.Body.Armor;
                case "Shirt": return unit.Body.Shirt;
                case "Belt": return unit.Body.Belt;
                case "Head": return unit.Body.Head;
                case "Glasses": return unit.Body.Glasses;
                case "Feet": return unit.Body.Feet;
                case "Gloves": return unit.Body.Gloves;
                case "Neck": return unit.Body.Neck;
                case "Ring1": return unit.Body.Ring1;
                case "Ring2": return unit.Body.Ring2;
                case "Wrist": return unit.Body.Wrist;
                case "Shoulders": return unit.Body.Shoulders;
                case "PrimaryHand": return hands == null ? null : hands.PrimaryHand;
                case "SecondaryHand": return hands == null ? null : hands.SecondaryHand;
                default: return null;
            }
        }

        public static ItemEntity FindPlannedItem(PlannedAction plan)
        {
            if (plan == null || string.IsNullOrEmpty(plan.ItemId))
                return null;
            return Game.Instance.Player.Inventory.Items.FirstOrDefault(item => item != null && item.UniqueId == plan.ItemId);
        }

        private static IEnumerable<ItemEntity> Candidates(EquipmentRule rule)
        {
            var matches = Game.Instance.Player.Inventory.Items
                .Where(item => ItemMatches(item, rule.blueprint))
                .GroupBy(item => item.UniqueId)
                .Select(group => group.First())
                .ToList();

            if (!string.IsNullOrEmpty(rule.donor) || !string.IsNullOrEmpty(rule.donorUnitId))
            {
                var donor = FindUnit(rule.donor, rule.donorUnitId);
                var worn = matches.Where(item => donor != null && WornBy(item, donor)).ToList();
                if (worn.Count > 0)
                    return worn;
            }

            return matches.Where(item => item.HoldingSlot == null);
        }

        private static bool WornBy(ItemEntity item, UnitEntityData unit)
        {
            return item != null &&
                   item.HoldingSlot != null &&
                   unit != null &&
                   unit.Descriptor != null &&
                   ReferenceEquals(item.HoldingSlot.Owner, unit.Descriptor);
        }

        private static int MatchScore(UnitEntityData main, EquipmentProfile profile)
        {
            if (profile.match == null)
                return 0;
            int score = 0;
            string classes = ClassLine(main);
            string mythic = MythicName(main);
            if (!string.IsNullOrEmpty(profile.match.classContains) &&
                classes.IndexOf(profile.match.classContains, StringComparison.OrdinalIgnoreCase) >= 0)
                score += 2;
            if (!string.IsNullOrEmpty(profile.match.mythicContains) &&
                mythic.IndexOf(profile.match.mythicContains, StringComparison.OrdinalIgnoreCase) >= 0)
                score += 2;
            return score;
        }

        public static string ArchetypeLine(UnitEntityData unit)
        {
            var names = new List<string>();
            foreach (var klass in BaseClasses(unit))
            {
                var data = unit.Progression.GetClassData(klass);
                if (data == null || data.Archetypes == null)
                    continue;
                foreach (var archetype in data.Archetypes)
                {
                    if (archetype == null)
                        continue;
                    string asset = string.IsNullOrEmpty(archetype.name) ? archetype.Name : archetype.name;
                    string pretty = Pretty(asset);
                    if (!names.Contains(pretty))
                        names.Add(pretty);
                }
            }
            return names.Count == 0 ? "none" : string.Join(", ", names.ToArray());
        }

        public static string MatchText(UnitEntityData unit)
        {
            return ClassLine(unit) + " " + ArchetypeLine(unit) + " " + MythicName(unit);
        }

        private static string ClassLine(UnitEntityData unit)
        {
            var parts = new List<string>();
            foreach (var klass in BaseClasses(unit))
                parts.Add(Pretty(AssetName(klass)) + " " + unit.Progression.GetClassLevel(klass));
            return parts.Count == 0 ? "unknown" : string.Join(", ", parts.ToArray());
        }

        private static IEnumerable<BlueprintCharacterClass> BaseClasses(UnitEntityData unit)
        {
            var seen = new HashSet<string>();
            if (unit == null || unit.Progression == null || unit.Progression.ClassesOrder == null)
                yield break;
            foreach (BlueprintCharacterClass klass in unit.Progression.ClassesOrder)
            {
                if (klass == null)
                    continue;
                string asset = AssetName(klass);
                if (asset.IndexOf("Mythic", StringComparison.OrdinalIgnoreCase) >= 0)
                    continue;
                if (!seen.Add(asset))
                    continue;
                yield return klass;
            }
        }

        private static string MythicName(UnitEntityData unit)
        {
            if (unit == null || unit.Progression == null)
                return "none";
            var data = unit.Progression.GetCurrentMythicClass();
            if (data == null || data.CharacterClass == null)
                return "none";
            return Pretty(AssetName(data.CharacterClass)) + " MR" + unit.Progression.MythicLevel;
        }

        private static string Pretty(string asset)
        {
            if (string.IsNullOrEmpty(asset))
                return asset;
            if (asset.EndsWith("MythicClass"))
                return asset.Substring(0, asset.Length - "MythicClass".Length);
            if (asset.EndsWith("Class"))
                return asset.Substring(0, asset.Length - "Class".Length);
            return asset;
        }

        private static string AssetName(BlueprintCharacterClass klass)
        {
            return string.IsNullOrEmpty(klass.name) ? klass.Name : klass.name;
        }

        public static string Describe(ItemSlot slot)
        {
            if (slot == null)
                return "missing";
            if (slot.MaybeItem == null || slot.MaybeItem.Blueprint == null)
                return "empty";
            return slot.MaybeItem.Blueprint.name;
        }

        private static bool ItemMatches(ItemEntity item, string blueprint)
        {
            return item != null &&
                   item.Blueprint != null &&
                   string.Equals(item.Blueprint.name, blueprint, StringComparison.Ordinal);
        }

        private static string Safe(string value)
        {
            return string.IsNullOrEmpty(value) ? "(unnamed)" : value;
        }
    }
}
