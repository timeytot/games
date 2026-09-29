using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HansenEquipmentManager
{
    public static class ProfileLoader
    {
        public static List<EquipmentProfile> Load(string modDirectory)
        {
            var dir = Path.Combine(modDirectory, "Profiles");
            var profiles = new List<EquipmentProfile>();
            if (!Directory.Exists(dir))
                throw new InvalidOperationException("Profiles folder is missing: " + dir);

            foreach (var file in Directory.GetFiles(dir, "*.json"))
            {
                var profile = JsonConvert.DeserializeObject<EquipmentProfile>(File.ReadAllText(file));
                if (profile == null || string.IsNullOrEmpty(profile.id))
                    throw new InvalidOperationException("Profile has no id: " + file);
                if (profile.rules == null)
                    profile.rules = new List<EquipmentRule>();
                if (string.IsNullOrEmpty(profile.displayName))
                    profile.displayName = profile.id;
                profiles.Add(profile);
            }

            profiles.Sort((a, b) => string.Compare(a.displayName, b.displayName, StringComparison.Ordinal));
            if (profiles.Count == 0)
                throw new InvalidOperationException("No profiles were found in " + dir);
            return profiles;
        }

        public static List<BuildRuleSet> LoadRules(string modDirectory)
        {
            var dir = Path.Combine(modDirectory, "BuildRules");
            var rules = new List<BuildRuleSet>();
            if (!Directory.Exists(dir))
                return rules;
            foreach (var file in Directory.GetFiles(dir, "*.json"))
            {
                var rule = JsonConvert.DeserializeObject<BuildRuleSet>(File.ReadAllText(file));
                if (rule == null || string.IsNullOrEmpty(rule.id))
                    throw new InvalidOperationException("Build rule has no id: " + file);
                if (rule.weights == null)
                    rule.weights = new Dictionary<string, int>();
                if (string.IsNullOrEmpty(rule.displayName))
                    rule.displayName = rule.id;
                rules.Add(rule);
            }
            return rules;
        }
    }
}
