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
        private static List<PlannedAction> PreviewPlans;
        private static string PreviewProfileId;
        private static List<BuildRuleSet> BuildRules = new List<BuildRuleSet>();
        private static List<EquipmentRecommendation> PendingRecommendations;
        private static string Status = "Load a save, then Scan Party.";
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
            GUILayout.Label("Profile: " + CurrentName());
            GUILayout.Label(Status);
            GUILayout.Label("Scan, preview, then equip. Weapon sets are not edited.");

            if (GUILayout.Button("Next Profile", GUILayout.Width(420)) && Profiles.Count > 0)
            {
                ProfileIndex = (ProfileIndex + 1) % Profiles.Count;
                PreviewPlans = null;
                Status = "Profile selected: " + CurrentName() + ". Preview again before equipping.";
            }
            if (GUILayout.Button("Scan Party", GUILayout.Width(420)))
                RunSafe(ScanParty);
            if (GUILayout.Button("Preview", GUILayout.Width(420)))
                RunSafe(Preview);
            if (GUILayout.Button("Equip Selected", GUILayout.Width(420)))
                RunSafe(Equip);
            if (GUILayout.Button("Verify", GUILayout.Width(420)))
                RunSafe(Verify);
            if (GUILayout.Button("Export Report", GUILayout.Width(420)))
                RunSafe(ExportReport);
            if (GUILayout.Button("Recommend", GUILayout.Width(420)))
                RunSafe(Recommend);
            if (GUILayout.Button("Apply", GUILayout.Width(420)))
                RunSafe(ApplyRecommendation);
            if (GUILayout.Button("Cancel", GUILayout.Width(420)))
            {
                PendingRecommendations = null;
                Status = "Recommendation cancelled. Nothing was equipped.";
            }
        }

        private static void ScanParty()
        {
            RequireGame();
            var text = new StringBuilder();
            text.AppendLine(EquipmentScanner.DescribeParty());
            var suggested = EquipmentScanner.Suggest(Profiles);
            if (suggested == null)
            {
                text.AppendLine("Suggested profile: none");
            }
            else
            {
                text.AppendLine("Suggested profile: " + suggested.id);
                int index = Profiles.FindIndex(profile => profile.id == suggested.id);
                if (index >= 0)
                    ProfileIndex = index;
            }
            var main = EquipmentScanner.MainCharacter();
            text.AppendLine(EquipmentScanner.CandidateReport(EquipmentScanner.SlotOf(main, "PrimaryHand")));
            WriteReport("SCAN", text.ToString());
            Status = "Scan written to the log. Suggested profile: " + (suggested == null ? "none" : suggested.displayName);
        }

        private static void Preview()
        {
            RequireGame();
            var profile = Current();
            if (profile == null)
                throw new InvalidOperationException("No profile is loaded.");
            PreviewPlans = EquipmentScanner.Preview(profile);
            PreviewProfileId = profile.id;
            var text = new StringBuilder();
            text.AppendLine("Preview " + profile.displayName);
            foreach (var plan in PreviewPlans)
            {
                text.AppendLine(plan.Rule.character + " " + plan.Rule.slot);
                text.AppendLine("Current: " + plan.Current);
                text.AppendLine("New: " + plan.Rule.blueprint);
                text.AppendLine("Reason: " + plan.Detail);
                text.AppendLine("Action: " + plan.Status);
                text.AppendLine("");
            }
            WriteReport("PREVIEW", text.ToString());
            Status = "Preview ready for " + profile.displayName + ". Equip Selected changes only Ready rows.";
        }

        private static void Equip()
        {
            RequireGame();
            var profile = Current();
            if (profile == null || PreviewPlans == null || PreviewProfileId != profile.id)
                throw new InvalidOperationException("Preview this profile before Equip Selected.");
            string result = EquipmentExecutor.Execute(PreviewPlans);
            PreviewPlans = EquipmentScanner.Preview(profile);
            WriteReport("EQUIP", result);
            Status = "Equip finished. See the log, then Verify.";
        }

        private static void Verify()
        {
            RequireGame();
            var profile = Current();
            if (profile == null)
                throw new InvalidOperationException("No profile is loaded.");
            string result = EquipmentExecutor.Verify(profile);
            WriteReport("VERIFY", result);
            Status = "Verify written to the log.";
        }

        private static void Recommend()
        {
            RequireGame();
            var party = CharacterAnalyzer.Analyze(BuildRules);
            PendingRecommendations = PartyOptimizer.Recommend(party);
            var text = new StringBuilder();
            text.AppendLine(CharacterAnalyzer.Report(party));
            text.AppendLine(PartyOptimizer.Report(PendingRecommendations));
            text.AppendLine("Apply equips the rows above. Cancel discards them.");
            WriteReport("RECOMMEND", text.ToString());
            Status = "Recommendation ready. Nothing was equipped. Use Apply or Cancel.";
        }

        private static void ApplyRecommendation()
        {
            RequireGame();
            if (PendingRecommendations == null)
                throw new InvalidOperationException("Recommend before Apply.");
            string result = EquipmentExecutor.Execute(PartyOptimizer.ToPlans(PendingRecommendations));
            PendingRecommendations = null;
            WriteReport("APPLY", result);
            Status = "Recommendation applied. See the log.";
        }

        private static void ExportReport()
        {
            string path = Path.Combine(ModDirectory, "report.txt");
            File.WriteAllText(path, Report.ToString());
            Log.Log("Exported " + path);
            Status = "Report exported to " + path;
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
