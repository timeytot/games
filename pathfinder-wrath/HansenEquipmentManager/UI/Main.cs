using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kingmaker;
using UnityEngine;
using UnityModManagerNet;

namespace HansenEquipmentManager
{
    public static class Main
    {
        private static UnityModManager.ModEntry.ModLogger Log;
        private static string ModDirectory;
        private static List<EquipmentProfile> Profiles = new List<EquipmentProfile>();
        private static int ProfileIndex;
        private static List<BuildRuleSet> BuildRules = new List<BuildRuleSet>();
        private static string Status = "Scan the party first. Nothing is equipped automatically.";
        private static string MainName = "(not scanned)";
        private static string Detection = "";
        private static string LatestList = "";
        private static string ListStatus = "";
        private static int CharacterPick = -1;
        private static int SlotPick = -1;
        private static int BlueprintPick = -1;
        private static bool CharacterOpen;
        private static bool SlotOpen;
        private static Vector2 ItemScroll;
        private static Vector2 CharacterMenuScroll;
        private static Vector2 SlotMenuScroll;
        private static readonly StringBuilder Report = new StringBuilder();
        private const float FieldWidth = 640f;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Log = modEntry.Logger;
            ModDirectory = modEntry.Path;
            modEntry.OnGUI = OnGUI;
            try
            {
                Profiles = ProfileLoader.Load(ModDirectory);
                BuildRules = ProfileLoader.LoadRules(ModDirectory);
                Log.Log("Hansen Equipment Manager loaded " + Profiles.Count + " profiles and " + BuildRules.Count + " build rules.");
            }
            catch (Exception ex)
            {
                Status = "PROFILE LOAD FAILED: " + ex.Message;
                Log.Error(ex.ToString());
            }
            return true;
        }

        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            GUILayout.Label("Hansen Equipment Manager");
            GUILayout.Label(Status);
            GUILayout.Label("Party");
            GUILayout.Label("Main Character:");
            GUILayout.Label(MainName);
            if (!string.IsNullOrEmpty(Detection))
                GUILayout.Label(Detection);
            GUILayout.Label("Selected Character:");
            DrawSelectedCharacter();
            if (GUILayout.Button("Scan Party", GUILayout.Width(FieldWidth)))
                RunSafe(ScanParty);
            GUILayout.Label("Equipment List");
            if (GUILayout.Button("Generate Equipment List", GUILayout.Width(FieldWidth)))
                RunSafe(GenerateList);
            if (!string.IsNullOrEmpty(ListStatus))
                GUILayout.Label(ListStatus);
            GUILayout.Label("Select Equipment");
            int nextCharacter = DrawDropdown("Character", CharacterPick, ref CharacterOpen, CharacterNames(), ref SlotOpen, ref CharacterMenuScroll);
            if (nextCharacter != CharacterPick)
            {
                CharacterPick = nextCharacter;
                SlotPick = -1;
                BlueprintPick = -1;
                SlotOpen = false;
            }
            int nextSlot = DrawDropdown("Slot", SlotPick, ref SlotOpen, SlotLabels(), ref CharacterOpen, ref SlotMenuScroll);
            if (nextSlot != SlotPick)
            {
                SlotPick = nextSlot;
                BlueprintPick = -1;
            }
            DrawItemChoice();
            DrawSelection();
            DrawPreview();
            bool itemChosen = SelectedPick(PicksForSelection()) != null;
            GUI.enabled = itemChosen;
            if (GUILayout.Button(itemChosen ? "Equip Selected Item" : "Select an item first", GUILayout.Width(FieldWidth)))
                RunSafe(EquipSelected);
            GUI.enabled = true;
            GUILayout.Label("Report");
            if (GUILayout.Button("Export Report", GUILayout.Width(FieldWidth)))
                RunSafe(ExportReport);
        }

        private static void ScanParty()
        {
            RequireGame();
            var suggested = EquipmentScanner.Suggest(Profiles);
            if (suggested != null)
            {
                int index = Profiles.FindIndex(profile => profile.id == suggested.id);
                if (index >= 0)
                    ProfileIndex = index;
            }
            var main = EquipmentScanner.MainCharacter();
            if (main != null)
            {
                var pair = EquipmentScanner.ClassAndMythic(main);
                MainName = SafeName(main.CharacterName);
                Detection = pair.Item1 + " / " + pair.Item2;
            }
            var text = new StringBuilder();
            text.AppendLine("Active party");
            foreach (var unit in CharacterAnalyzer.ActiveParty())
            {
                var pair = EquipmentScanner.ClassAndMythic(unit);
                text.AppendLine(SafeName(unit.CharacterName));
                text.AppendLine("Class: " + pair.Item1);
                text.AppendLine("Archetype: " + EquipmentScanner.ArchetypeLine(unit));
                text.AppendLine("Mythic: " + pair.Item2);
                NoteEmpty(text, unit, "PrimaryHand");
                NoteEmpty(text, unit, "SecondaryHand");
                NoteEmpty(text, unit, "Armor");
                NoteEmpty(text, unit, "Head");
                NoteEmpty(text, unit, "Neck");
            }
            WriteReport("Scan Party", text.ToString());
            Status = "Party scanned. Nothing was equipped.";
        }

        private static void GenerateList()
        {
            RequireGame();
            var party = CharacterAnalyzer.Analyze(BuildRules);
            RememberList(party);
            WriteReport("Equipment List", LatestList);
            int characters = party == null ? 0 : party.Count;
            ListStatus = "Generated: " + characters + " characters, " + (characters * EquipmentAdvisor.SlotNames.Length) + " slots";
            CharacterPick = -1;
            SlotPick = -1;
            BlueprintPick = -1;
            CharacterOpen = false;
            SlotOpen = false;
            Status = "Equipment list generated. Nothing was equipped.";
        }

        private static void EquipSelected()
        {
            RequireGame();
            string character = Selected(CharacterNames(), CharacterPick);
            string slotName = Selected(EquipmentAdvisor.SlotNames, SlotPick);
            string blueprint = SelectedBlueprint();
            if (character == null || slotName == null || blueprint == null)
                throw new InvalidOperationException("Generate the equipment list, then choose a character, slot, and item.");
            var unit = EquipmentScanner.FindUnit(character, null);
            if (unit == null)
                throw new InvalidOperationException("Character was not found: " + character);
            var slot = EquipmentScanner.SlotOf(unit, slotName);
            if (slot == null)
                throw new InvalidOperationException("Slot was not found: " + slotName);
            var selected = SelectedPick(PicksForSelection());
            if (selected != null && selected.Current && slot.MaybeItem != null && slot.MaybeItem.UniqueId == selected.ItemId)
                throw new InvalidOperationException("That item is already equipped.");
            string previousId = null;
            string previousBlueprint = null;
            string previousName = null;
            if (slot.MaybeItem != null && slot.MaybeItem.Blueprint != null)
            {
                previousId = slot.MaybeItem.UniqueId;
                previousBlueprint = slot.MaybeItem.Blueprint.name;
                previousName = EquipmentAdvisor.DisplayName(slot.MaybeItem);
            }
            var item = selected != null && !string.IsNullOrEmpty(selected.ItemId)
                ? EquipmentAdvisor.FindById(selected.ItemId)
                : null;
            if (item == null)
                item = EquipmentAdvisor.FindSelectedItem(blueprint);
            if (item == null)
                throw new InvalidOperationException("Item was not found: " + blueprint);
            var plan = new PlannedAction
            {
                Status = PlanStatus.Ready,
                ItemId = item.UniqueId,
                Rule = new EquipmentRule
                {
                    character = unit.CharacterName,
                    unitId = unit.UniqueId,
                    slot = slotName,
                    blueprint = item.Blueprint.name
                }
            };
            string result = EquipmentExecutor.Execute(new List<PlannedAction> { plan });
            WriteReport("Equip Selected", result);
            if (result.IndexOf("SUCCESS", StringComparison.Ordinal) >= 0)
            {
                var party = CharacterAnalyzer.Analyze(BuildRules);
                RememberList(party);
                EquipmentAdvisor.IncludeDisplaced(character, slotName, previousId, previousBlueprint, previousName);
                BlueprintPick = -1;
                int count = party == null ? 0 : party.Count;
                ListStatus = "Generated: " + count + " characters, " + (count * EquipmentAdvisor.SlotNames.Length) + " slots";
                Status = "Equipped this item. The previous item is now under Available.";
            }
            else
                Status = "Equip did not finish. See the mod log.";
        }

        private static void RememberList(System.Collections.Generic.IList<CharacterView> party)
        {
            LatestList = EquipmentAdvisor.EquipmentList(party);
        }

        private static void ExportReport()
        {
            if (string.IsNullOrEmpty(LatestList))
                throw new InvalidOperationException("Generate the equipment list before exporting.");
            string path = Path.Combine(ModDirectory, "report.txt");
            File.WriteAllText(path, "Hansen Equipment Manager Report\nVersion: Advisor Mode\nTime: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n" + LatestList);
            Log.Log("Exported " + path);
            Status = "Report written to report.txt.";
        }

        private static int DrawDropdown(string label, int index, ref bool open, IList<string> options, ref bool otherOpen, ref Vector2 scroll)
        {
            string current = options == null || options.Count == 0 || index < 0 || index >= options.Count ? "(select)" : options[index];
            if (GUILayout.Button(label + ": " + current + "  ▼", GUILayout.Width(FieldWidth)))
            {
                open = !open;
                if (open)
                    otherOpen = false;
            }
            if (!open || options == null || options.Count == 0)
                return index;
            float height = Math.Min(168f, 28f * options.Count);
            scroll = GUILayout.BeginScrollView(scroll, GUILayout.Width(FieldWidth), GUILayout.Height(height));
            int chosen = index;
            for (int i = 0; i < options.Count; i++)
            {
                if (!GUILayout.Button(options[i], GUILayout.Width(FieldWidth - 24)))
                    continue;
                open = false;
                chosen = i;
            }
            GUILayout.EndScrollView();
            return chosen;
        }

        private static void DrawItemChoice()
        {
            var picks = PicksForSelection();
            GUILayout.Label("Current");
            int currentIndex = -1;
            for (int i = 0; i < picks.Count; i++)
            {
                if (!picks[i].Current)
                    continue;
                currentIndex = i;
                break;
            }
            if (currentIndex < 0)
                GUILayout.Label("(empty)");
            else
            {
                var worn = picks[currentIndex];
                if (GUILayout.Button("[CURRENT] " + worn.DisplayName, GUILayout.Width(FieldWidth)))
                    BlueprintPick = currentIndex;
            }
            var note = EquippedNote();
            if (note != null)
                GUILayout.Label("Already equipped copies: " + note.DisplayName + " x" + note.Copies);
            GUILayout.Label("Available");
            ItemScroll = GUILayout.BeginScrollView(ItemScroll, GUILayout.Width(FieldWidth), GUILayout.Height(96));
            bool any = false;
            for (int i = 0; i < picks.Count; i++)
            {
                if (picks[i].Current)
                    continue;
                any = true;
                if (GUILayout.Button(picks[i].DisplayName, GUILayout.Width(FieldWidth - 24)))
                    BlueprintPick = i;
            }
            if (!any)
                GUILayout.Label("(none)");
            GUILayout.EndScrollView();
        }

        private static EquipmentAdvisor.EquippedCopyNote EquippedNote()
        {
            string character = Selected(CharacterNames(), CharacterPick);
            string slot = Selected(EquipmentAdvisor.SlotNames, SlotPick);
            foreach (var note in EquipmentAdvisor.EquippedCopies)
            {
                if (note.Character == character && note.Slot == slot)
                    return note;
            }
            return null;
        }

        private static void DrawSelection()
        {
            var pick = SelectedPick(PicksForSelection());
            string slot = Selected(EquipmentAdvisor.SlotNames, SlotPick);
            GUILayout.Label("Selected Item:");
            if (pick == null)
                GUILayout.Label("No item selected");
            else
            {
                GUILayout.Label("Name: " + pick.DisplayName);
                GUILayout.Label("Source: " + (string.IsNullOrEmpty(pick.Sources) ? "(unknown)" : pick.Sources));
            }
            if (slot != null)
                GUILayout.Label("Role: " + RoleLabel(slot));
        }

        private static string RoleLabel(string slot)
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

        private static void DrawPreview()
        {
            var pick = SelectedPick(PicksForSelection());
            string current = CurrentItemName();
            string slotName = Selected(EquipmentAdvisor.SlotNames, SlotPick);
            GUILayout.Label("Preview:");
            GUILayout.Label("Slot: " + (slotName == null ? "(select a slot)" : PartyOptimizer.SlotLabel(slotName)));
            GUILayout.Label("Current: " + current);
            GUILayout.Label("New: " + (pick == null ? "No item selected" : pick.DisplayName));
            if (current != "(empty)" && current != "(none)" && pick != null && pick.DisplayName != current)
                GUILayout.Label("Warning: Replacing current equipment");
        }

        private static void DrawSelectedCharacter()
        {
            string name = Selected(CharacterNames(), CharacterPick);
            if (name == null || Game.Instance == null || Game.Instance.Player == null)
            {
                GUILayout.Label("(select)");
                return;
            }
            GUILayout.Label(name);
            var unit = EquipmentScanner.FindUnit(name, null);
            if (unit == null)
                return;
            var pair = EquipmentScanner.ClassAndMythic(unit);
            GUILayout.Label(pair.Item1 + " / " + pair.Item2);
        }

        private static string CurrentItemName()
        {
            if (Game.Instance == null || Game.Instance.Player == null)
                return "(none)";
            string character = Selected(CharacterNames(), CharacterPick);
            string slotName = Selected(EquipmentAdvisor.SlotNames, SlotPick);
            if (character == null || slotName == null)
                return "(none)";
            var unit = EquipmentScanner.FindUnit(character, null);
            var slot = unit == null ? null : EquipmentScanner.SlotOf(unit, slotName);
            if (slot == null || slot.MaybeItem == null)
                return "(empty)";
            return EquipmentAdvisor.DisplayName(slot.MaybeItem);
        }

        private static List<string> CharacterNames()
        {
            var names = new List<string>();
            foreach (var pick in EquipmentAdvisor.Picks)
            {
                if (!names.Contains(pick.Character))
                    names.Add(pick.Character);
            }
            return names;
        }

        private static List<string> SlotLabels()
        {
            var labels = new List<string>();
            foreach (var slot in EquipmentAdvisor.SlotNames)
                labels.Add(PartyOptimizer.SlotLabel(slot));
            return labels;
        }

        private static List<EquipmentAdvisor.AdvisorPick> PicksForSelection()
        {
            var matches = new List<EquipmentAdvisor.AdvisorPick>();
            string character = Selected(CharacterNames(), CharacterPick);
            string slot = Selected(EquipmentAdvisor.SlotNames, SlotPick);
            foreach (var pick in EquipmentAdvisor.Picks)
            {
                if (pick.Character == character && pick.Slot == slot)
                    matches.Add(pick);
            }
            return matches;
        }

        private static EquipmentAdvisor.AdvisorPick SelectedPick(List<EquipmentAdvisor.AdvisorPick> matches)
        {
            if (matches == null || BlueprintPick < 0 || BlueprintPick >= matches.Count)
                return null;
            return matches[BlueprintPick];
        }

        private static string SelectedBlueprint()
        {
            var pick = SelectedPick(PicksForSelection());
            return pick == null ? null : pick.Blueprint;
        }

        private static string Selected(IList<string> options, int index)
        {
            if (options == null || index < 0 || index >= options.Count)
                return null;
            return options[index];
        }

        private static void NoteEmpty(StringBuilder text, Kingmaker.EntitySystem.Entities.UnitEntityData unit, string slot)
        {
            string current = EquipmentScanner.Describe(EquipmentScanner.SlotOf(unit, slot));
            if (current == "empty" || current == "missing")
                text.AppendLine("Missing " + PartyOptimizer.SlotLabel(slot));
        }

        private static string SafeName(string value)
        {
            return string.IsNullOrEmpty(value) ? "(unnamed)" : value;
        }

        private static void WriteReport(string title, string body)
        {
            Report.AppendLine("== " + title + " ==");
            Report.AppendLine(body);
            foreach (var line in body.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                Log.Log(line);
        }

        private static void RunSafe(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Status = "FAILED: " + ex.Message;
                Log.Error(ex.ToString());
            }
        }

        private static void RequireGame()
        {
            if (Game.Instance == null || Game.Instance.Player == null)
                throw new InvalidOperationException("No loaded game.");
        }

        private static EquipmentProfile Current()
        {
            if (Profiles == null || Profiles.Count == 0)
                return null;
            if (ProfileIndex < 0 || ProfileIndex >= Profiles.Count)
                ProfileIndex = 0;
            return Profiles[ProfileIndex];
        }

        private static string CurrentName()
        {
            var profile = Current();
            return profile == null ? "(none)" : profile.displayName;
        }
    }
}
