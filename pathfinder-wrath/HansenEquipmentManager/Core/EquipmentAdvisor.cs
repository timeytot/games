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
        public static readonly List<EquippedCopyNote> EquippedCopies = new List<EquippedCopyNote>();
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
            EquippedCopies.Clear();
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
                string archetype = EquipmentScanner.ArchetypeLine(unit);
                string shown = rules.id == "Default" && archetype != "none"
                    ? archetype + " (not configured)"
                    : FriendlyBuild(rules.id);
                text.AppendLine(shown);
                if (!string.Equals(shown, rules.id, StringComparison.Ordinal))
                    text.AppendLine("ID: " + rules.id);
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

        public static void IncludeDisplaced(string character, string slot, string itemId, string blueprint, string displayName)
        {
            if (string.IsNullOrEmpty(character) || string.IsNullOrEmpty(slot) || string.IsNullOrEmpty(blueprint))
                return;
            int insertAt = -1;
            for (int i = 0; i < Picks.Count; i++)
            {
                var pick = Picks[i];
                if (pick.Character != character || pick.Slot != slot)
                    continue;
                if (string.Equals(pick.ItemId, itemId, StringComparison.Ordinal) || string.Equals(pick.Blueprint, blueprint, StringComparison.Ordinal))
                    return;
                if (pick.Current)
                    insertAt = i + 1;
                else if (insertAt < 0)
                    insertAt = i;
            }
            if (insertAt < 0)
                insertAt = Picks.Count;
            Picks.Insert(insertAt, new AdvisorPick
            {
                Character = character,
                Slot = slot,
                Blueprint = blueprint,
                DisplayName = string.IsNullOrEmpty(displayName) ? blueprint : displayName,
                Copies = 1,
                Sources = "Previous equipment",
                Current = false,
                ItemId = itemId
            });
        }

        public static ItemEntity FindById(string itemId)
        {
            if (string.IsNullOrEmpty(itemId) || Kingmaker.Game.Instance == null || Kingmaker.Game.Instance.Player == null)
                return null;
            return Kingmaker.Game.Instance.Player.Inventory.Items
                .FirstOrDefault(item => item != null && item.UniqueId == itemId);
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
            text.AppendLine("Current:");
            if (itemSlot == null || itemSlot.MaybeItem == null || itemSlot.MaybeItem.Blueprint == null)
                text.AppendLine("(empty)");
            else
            {
                Picks.Add(new AdvisorPick
                {
                    Character = NameOf(view.Unit),
                    Slot = slot,
                    Blueprint = itemSlot.MaybeItem.Blueprint.name,
                    DisplayName = DisplayName(itemSlot.MaybeItem),
                    Copies = 1,
                    Sources = NameOf(view.Unit),
                    Current = true,
                    ItemId = itemSlot.MaybeItem.UniqueId
                });
                text.AppendLine("[CURRENT] " + DisplayName(itemSlot.MaybeItem));
                text.AppendLine("ID: " + itemSlot.MaybeItem.Blueprint.name);
            }
            text.AppendLine("Available:");
            string wornBlueprint = itemSlot == null || itemSlot.MaybeItem == null || itemSlot.MaybeItem.Blueprint == null
                ? null
                : itemSlot.MaybeItem.Blueprint.name;
            var different = new List<Candidate>();
            Candidate sameAsWorn = null;
            foreach (var row in Candidates(view, slot))
            {
                if (wornBlueprint != null && row.Item.Blueprint.name == wornBlueprint)
                    sameAsWorn = row;
                else
                    different.Add(row);
            }
            var ranked = different.Take(3).ToList();
            if (sameAsWorn != null)
            {
                EquippedCopies.Add(new EquippedCopyNote
                {
                    Character = NameOf(view.Unit),
                    Slot = slot,
                    DisplayName = DisplayName(sameAsWorn.Item),
                    Copies = sameAsWorn.Copies
                });
            }
            if (ranked.Count == 0)
                text.AppendLine("none");
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
                text.AppendLine("   Role: " + RoleOf(slot));
                text.AppendLine("   Tags: " + row.Tags);
                rank++;
            }
            if (sameAsWorn != null)
                text.AppendLine("Already equipped copies: " + DisplayName(sameAsWorn.Item) + " x" + sameAsWorn.Copies);
            return text.ToString();
        }

        private static string RoleOf(string slot)
        {
            switch (slot)
            {
                case "PrimaryHand": return "Weapon";
                case "SecondaryHand": return "Shield";
                case "Armor": return "Armor";
                case "Ring1":
                case "Ring2": return "Ring";
                default: return PartyOptimizer.SlotLabel(slot);
            }
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
                string source = SourceOf(item);
                if (!row.Sources.Contains(source))
                    row.Sources.Add(source);
            }
            return groups.Values.OrderByDescending(row => row.Sort).ThenBy(row => row.Item.Blueprint.name).ToList();
        }

        private static string SourceOf(ItemEntity item)
        {
            if (item.HoldingSlot == null || item.Wielder == null)
                return "Inventory";
            var player = Kingmaker.Game.Instance.Player;
            if (player != null && player.AllCharacters != null)
            {
                foreach (var unit in player.AllCharacters)
                {
                    if (unit != null && unit.Descriptor != null && ReferenceEquals(unit.Descriptor, item.Wielder) && !string.IsNullOrEmpty(unit.CharacterName))
                        return unit.CharacterName;
                }
            }
            return "Outside Party";
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

        private static string FriendlyBuild(string id)
        {
            if (string.IsNullOrEmpty(id))
                return id;
            var text = new StringBuilder();
            for (int i = 0; i < id.Length; i++)
            {
                char c = id[i];
                if (c == '_' || c == '-')
                {
                    text.Append(' ');
                    continue;
                }
                if (i > 0 && char.IsUpper(c) && char.IsLower(id[i - 1]))
                    text.Append(' ');
                text.Append(c);
            }
            return text.ToString();
        }

        private static int SortKey(CharacterView view, ItemEntity item, string slot)
        {
            if (slot == "PrimaryHand")
                return ItemEvaluator.IsTwoHanded(item) ? 0 : 200;
            int key = ItemMatchesBuild(item, view) ? 2 : 0;
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
            public bool Current;
            public string ItemId;
        }

        public sealed class EquippedCopyNote
        {
            public string Character;
            public string Slot;
            public string DisplayName;
            public int Copies;
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
