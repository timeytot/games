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

        private static int MatchScore(UnitEntityData main, EquipmentProfile profile)
        {
            if (profile.match == null)
                return 0;
            int score = 0;
            int classScore = ClassMatchScore(main, profile.match.classContains);
            if (classScore > 0)
                score += classScore;
            int mythicScore = MythicMatchScore(main, profile.match.mythicContains);
            if (mythicScore > 0)
                score += mythicScore;
            return score;
        }

        public static int ClassMatchScore(UnitEntityData unit, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;
            if (unit == null)
                return -1;
            bool classHit = TextContains(ClassLine(unit) + " " + ClassAssetText(unit), needle);
            bool archetypeHit = TextContains(ArchetypeLine(unit) + " " + ArchetypeAssetText(unit), needle);
            if (!classHit && !archetypeHit)
                return -1;
            if (archetypeHit && !classHit)
                return 3;
            return 2;
        }

        public static int MythicMatchScore(UnitEntityData unit, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;
            return TextContains(MythicMatchText(unit), needle) ? 2 : -1;
        }

        private static bool TextContains(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle) || string.IsNullOrEmpty(haystack))
                return false;
            if (haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            string compactNeedle = Compact(needle);
            if (compactNeedle.Length == 0)
                return false;
            return Compact(haystack).IndexOf(compactNeedle, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string Compact(string value)
        {
            var text = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (c == ' ' || c == '_' || c == '-')
                    continue;
                text.Append(c);
            }
            return text.ToString();
        }

        public static string ArchetypeLine(UnitEntityData unit)
        {
            var names = new List<string>();
            CollectArchetypes(unit, names, null);
            return names.Count == 0 ? "none" : string.Join(", ", names.ToArray());
        }

        private static string ArchetypeAssetText(UnitEntityData unit)
        {
            var assets = new List<string>();
            CollectArchetypes(unit, null, assets);
            return assets.Count == 0 ? "" : string.Join(" ", assets.ToArray());
        }

        private static void CollectArchetypes(UnitEntityData unit, List<string> pretty, List<string> assets)
        {
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
                    if (string.IsNullOrEmpty(asset))
                        continue;
                    if (assets != null && !assets.Contains(asset))
                        assets.Add(asset);
                    if (pretty == null)
                        continue;
                    string name = Pretty(asset);
                    if (!pretty.Contains(name))
                        pretty.Add(name);
                }
            }
        }

        private static string ClassAssetText(UnitEntityData unit)
        {
            var parts = new List<string>();
            foreach (var klass in BaseClasses(unit))
            {
                string asset = AssetName(klass);
                if (!parts.Contains(asset))
                    parts.Add(asset);
            }
            return parts.Count == 0 ? "" : string.Join(" ", parts.ToArray());
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

        private static string MythicMatchText(UnitEntityData unit)
        {
            if (unit == null || unit.Progression == null)
                return "none";
            var data = unit.Progression.GetCurrentMythicClass();
            if (data == null || data.CharacterClass == null)
                return MythicName(unit);
            return MythicName(unit) + " " + AssetName(data.CharacterClass);
        }

        private static string Pretty(string asset)
        {
            if (string.IsNullOrEmpty(asset))
                return asset;
            if (asset.EndsWith("Archetype"))
                asset = asset.Substring(0, asset.Length - "Archetype".Length);
            if (asset.EndsWith("MythicClass"))
                asset = asset.Substring(0, asset.Length - "MythicClass".Length);
            else if (asset.EndsWith("Class"))
                asset = asset.Substring(0, asset.Length - "Class".Length);
            var text = new StringBuilder();
            for (int i = 0; i < asset.Length; i++)
            {
                if (i > 0 && char.IsUpper(asset[i]) && char.IsLower(asset[i - 1]))
                    text.Append(' ');
                text.Append(asset[i]);
            }
            return text.ToString();
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

        private static string Safe(string value)
        {
            return string.IsNullOrEmpty(value) ? "(unnamed)" : value;
        }
    }
}
