using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kingmaker;
using Newtonsoft.Json;
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
        private static string Status = "Scan the party first.";
        private static string Detection = "Not scanned yet";
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
            GUILayout.Label("Plan: " + CurrentName());
            GUILayout.Label(Status);

            if (GUILayout.Button("Switch Plan", GUILayout.Width(420)) && Profiles.Count > 0)
            {
                ProfileIndex = (ProfileIndex + 1) % Profiles.Count;
                Status = "Plan switched. Generate a plan again before equipping.";
            }
            if (GUILayout.Button("Scan Party", GUILayout.Width(420)))
                RunSafe(ScanParty);
            if (GUILayout.Button("Generate Plan", GUILayout.Width(420)))
                RunSafe(BuildPlan);
            if (GUILayout.Button("Review Changes", GUILayout.Width(420)))
                RunSafe(ShowChanges);
            if (GUILayout.Button("Confirm and Equip", GUILayout.Width(420)))
                RunSafe(ConfirmEquip);
            if (GUILayout.Button("Check Equipment", GUILayout.Width(420)))
                RunSafe(CheckEquipment);
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
            Status = "Party scan is in the mod log. Nothing was equipped.";
        }

        private static void BuildPlan()
        {
            RequireGame();
            var party = CharacterAnalyzer.Analyze(BuildRules);
            var rows = PartyOptimizer.Recommend(party);
            var saved = new SavedRecommendationFile
            {
                profileId = Current() == null ? "" : Current().id,
                rows = rows
            };
            File.WriteAllText(RecommendationPath(), JsonConvert.SerializeObject(saved, Formatting.Indented));
            var text = new StringBuilder();
            text.AppendLine(CharacterAnalyzer.Report(party));
            text.AppendLine(PartyOptimizer.Report(rows));
            text.AppendLine("Plan saved. Nothing was equipped.");
            WriteReport("Generate Plan", text.ToString());
            Status = "Plan generated. Nothing was equipped. Review the changes before equipping.";
        }

        private static void ShowChanges()
        {
            var saved = ReadRecommendation();
            WriteReport("Review Changes", PartyOptimizer.ChangeList(saved.rows));
            Status = "Changes are in the mod log. Nothing was equipped.";
        }

        private static void ConfirmEquip()
        {
            RequireGame();
            var saved = ReadRecommendation();
            if (Current() != null && saved.profileId != Current().id)
                throw new InvalidOperationException("The plan was switched. Generate a plan again.");
            var plans = PartyOptimizer.ToPlans(saved.rows);
            if (plans.Count == 0)
                throw new InvalidOperationException("This plan has no changes to apply.");
            string result = EquipmentExecutor.Execute(plans);
            File.AppendAllText(Path.Combine(ModDirectory, "equip-log.txt"), System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + result + "\n");
            WriteReport("Confirm and Equip", result);
            Status = "Equip finished. A short note was added to equip-log.txt.";
        }

        private static void CheckEquipment()
        {
            RequireGame();
            string result = "No plan to check.";
            string path = RecommendationPath();
            if (File.Exists(path))
            {
                var saved = JsonConvert.DeserializeObject<SavedRecommendationFile>(File.ReadAllText(path));
                if (saved != null && saved.rows != null)
                    result = EquipmentExecutor.VerifySaved(saved.rows);
            }
            WriteReport("Check Equipment", result);
            File.WriteAllText(Path.Combine(ModDirectory, "report.txt"), Report.ToString());
            Status = "Check saved once to report.txt.";
        }

        private static SavedRecommendationFile ReadRecommendation()
        {
            string path = RecommendationPath();
            if (!File.Exists(path))
                throw new InvalidOperationException("Generate a plan first.");
            var saved = JsonConvert.DeserializeObject<SavedRecommendationFile>(File.ReadAllText(path));
            if (saved == null || saved.rows == null)
                throw new InvalidOperationException("The saved plan is empty. Generate it again.");
            return saved;
        }

        private static string RecommendationPath()
        {
            return Path.Combine(ModDirectory, "lastRecommendation.json");
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
