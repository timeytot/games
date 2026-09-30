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
        private static string PickCharacter = "";
        private static string PickSlot = "PrimaryHand";
        private static string PickBlueprint = "";
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
            GUILayout.Label("Detected: " + Detection);
            GUILayout.Label(Status);
            GUILayout.Label("Type the character, slot, and blueprint from the list. Only that item is equipped.");
            PickCharacter = GUILayout.TextField(PickCharacter, GUILayout.Width(420));
            PickSlot = GUILayout.TextField(PickSlot, GUILayout.Width(420));
            PickBlueprint = GUILayout.TextField(PickBlueprint, GUILayout.Width(420));

            if (GUILayout.Button("Scan Party", GUILayout.Width(420)))
                RunSafe(ScanParty);
            if (GUILayout.Button("Generate Equipment List", GUILayout.Width(420)))
                RunSafe(GenerateList);
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
                text.AppendLine(SafeName(unit.CharacterName) + ": " + pair.Item1);
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
            string list = EquipmentAdvisor.EquipmentList(party);
            WriteReport("Equipment List", list);
            Status = "List is in the mod log. Nothing was equipped.";
        }

        private static void EquipSelected()
        {
            RequireGame();
            if (string.IsNullOrEmpty(PickCharacter) || string.IsNullOrEmpty(PickSlot) || string.IsNullOrEmpty(PickBlueprint))
                throw new InvalidOperationException("Type a character, a slot, and a blueprint first.");
            var unit = EquipmentScanner.FindUnit(PickCharacter.Trim(), null);
            if (unit == null)
                throw new InvalidOperationException("Character was not found: " + PickCharacter);
            var slot = EquipmentScanner.SlotOf(unit, PickSlot.Trim());
            if (slot == null)
                throw new InvalidOperationException("Slot was not found: " + PickSlot);
            var item = EquipmentAdvisor.FindSelectedItem(PickBlueprint.Trim());
            if (item == null)
                throw new InvalidOperationException("Item was not found: " + PickBlueprint);
            var plan = new PlannedAction
            {
                Status = PlanStatus.Ready,
                ItemId = item.UniqueId,
                Rule = new EquipmentRule
                {
                    character = unit.CharacterName,
                    unitId = unit.UniqueId,
                    slot = PickSlot.Trim(),
                    blueprint = item.Blueprint.name
                }
            };
            string result = EquipmentExecutor.Execute(new List<PlannedAction> { plan });
            WriteReport("Equip Selected", result);
            Status = "Selected item processed. See the mod log.";
        }

        private static void ExportReport()
        {
            if (Report.Length == 0)
                throw new InvalidOperationException("Generate the equipment list before exporting.");
            string path = Path.Combine(ModDirectory, "report.txt");
            File.WriteAllText(path, Report.ToString());
            Log.Log("Exported " + path);
            Status = "Report written to report.txt.";
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
