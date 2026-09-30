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
        private static string Detection = "Not scanned yet";
        private static string LatestList = "";
        private static int CharacterPick;
        private static int SlotPick;
        private static int BlueprintPick;
        private static bool CharacterOpen;
        private static bool SlotOpen;
        private static bool BlueprintOpen;
        private static readonly StringBuilder Report = new StringBuilder();

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
            GUILayout.Label("Detected: " + Detection);
            if (GUILayout.Button("Scan Party", GUILayout.Width(420)))
                RunSafe(ScanParty);
            GUILayout.Label("Equipment List");
            if (GUILayout.Button("Generate Equipment List", GUILayout.Width(420)))
                RunSafe(GenerateList);
            GUILayout.Label("Actions");
            GUILayout.Label("Choose one listed item. Only that item is equipped.");
            CharacterPick = DrawPicker("Character", CharacterPick, ref CharacterOpen, CharacterNames(), true);
            SlotPick = DrawPicker("Slot", SlotPick, ref SlotOpen, SlotLabels(), true);
            BlueprintPick = DrawPicker("Item", BlueprintPick, ref BlueprintOpen, ItemLabels(), false);
            if (GUILayout.Button("Equip Selected", GUILayout.Width(420)))
                RunSafe(EquipSelected);
            if (GUILayout.Button("Export Report", GUILayout.Width(420)))
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
            LatestList = EquipmentAdvisor.EquipmentList(party);
            WriteReport("Equipment List", LatestList);
            Status = "List is in the mod log. Nothing was equipped.";
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
            var item = EquipmentAdvisor.FindSelectedItem(blueprint);
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
            Status = "Selected item processed. See the mod log.";
        }

        private static void ExportReport()
        {
            if (string.IsNullOrEmpty(LatestList))
                throw new InvalidOperationException("Generate the equipment list before exporting.");
            string path = Path.Combine(ModDirectory, "report.txt");
            File.WriteAllText(path, "Hansen Equipment Manager Report\nTime: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n" + LatestList);
            Log.Log("Exported " + path);
            Status = "Report written to report.txt.";
        }

        private static int DrawPicker(string label, int index, ref bool open, IList<string> options, bool resetsBlueprint)
        {
            string current = options == null || options.Count == 0 || index < 0 || index >= options.Count ? "(none)" : options[index];
            if (GUILayout.Button(label + ": " + current, GUILayout.Width(420)))
                open = !open;
            if (!open || options == null)
                return index;
            for (int i = 0; i < options.Count; i++)
            {
                if (!GUILayout.Button("  " + options[i], GUILayout.Width(400)))
                    continue;
                open = false;
                if (resetsBlueprint)
                    BlueprintPick = 0;
                return i;
            }
            return index;
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

        private static List<string> ItemLabels()
        {
            var names = new List<string>();
            string character = Selected(CharacterNames(), CharacterPick);
            string slot = Selected(EquipmentAdvisor.SlotNames, SlotPick);
            foreach (var pick in EquipmentAdvisor.Picks)
            {
                if (pick.Character != character || pick.Slot != slot)
                    continue;
                string label = string.IsNullOrEmpty(pick.DisplayName) ? pick.Blueprint : pick.DisplayName + "  (" + pick.Blueprint + ")";
                if (!names.Contains(label))
                    names.Add(label);
            }
            return names;
        }

        private static string SelectedBlueprint()
        {
            var matches = new List<EquipmentAdvisor.AdvisorPick>();
            string character = Selected(CharacterNames(), CharacterPick);
            string slot = Selected(EquipmentAdvisor.SlotNames, SlotPick);
            foreach (var pick in EquipmentAdvisor.Picks)
            {
                if (pick.Character == character && pick.Slot == slot)
                    matches.Add(pick);
            }
            if (BlueprintPick < 0 || BlueprintPick >= matches.Count)
                return null;
            return matches[BlueprintPick].Blueprint;
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
