using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;

namespace HansenEquipmentManager
{
    public sealed class CharacterView
    {
        public UnitEntityData Unit;
        public BuildRuleSet Rules;
        public string Summary;
    }

    public static class CharacterAnalyzer
    {
        private static readonly Dictionary<string, string> Aliases = new Dictionary<string, string>
        {
            { "Strength", "STR" },
            { "Dexterity", "DEX" },
            { "Constitution", "CON" },
            { "Intelligence", "INT" },
            { "Wisdom", "WIS" },
            { "Charisma", "CHA" },
            { "AC", "ArmorClass" },
            { "BonusCasterLevel", "CasterLevel" }
        };

        public static int Weight(BuildRuleSet rules, string signal)
        {
            if (rules == null || rules.weights == null || string.IsNullOrEmpty(signal))
                return 0;
            int value;
            if (rules.weights.TryGetValue(signal, out value))
                return value;
            string alias;
            if (Aliases.TryGetValue(signal, out alias) && rules.weights.TryGetValue(alias, out value))
                return value;
            return 0;
        }

        public static List<CharacterView> Analyze(IList<BuildRuleSet> rules)
        {
            var views = new List<CharacterView>();
            foreach (var unit in GameParty())
            {
                var match = Select(unit, rules);
                views.Add(new CharacterView
                {
                    Unit = unit,
                    Rules = match,
                    Summary = Summarize(unit, match)
                });
            }
            return views;
        }

        public static string Report(IList<CharacterView> views)
        {
            var text = new StringBuilder();
            text.AppendLine("Character analysis");
            foreach (var view in views)
                text.AppendLine(view.Summary);
            return text.ToString();
        }

        private static BuildRuleSet Select(UnitEntityData unit, IList<BuildRuleSet> rules)
        {
            BuildRuleSet best = null;
            int bestScore = 0;
            if (rules == null)
                return null;
            foreach (var rule in rules)
            {
                int score = Score(unit, rule);
                if (score > bestScore)
                {
                    best = rule;
                    bestScore = score;
                }
            }
            if (best != null)
                return best;
            return rules.FirstOrDefault(rule => rule.match == null ||
                (string.IsNullOrEmpty(rule.match.classContains) && string.IsNullOrEmpty(rule.match.mythicContains)));
        }

        private static int Score(UnitEntityData unit, BuildRuleSet rule)
        {
            if (rule.match == null)
                return 0;
            int score = 0;
            if (!string.IsNullOrEmpty(rule.match.classContains))
                score += EquipmentScanner.ClassMatchScore(unit, rule.match.classContains);
            if (!string.IsNullOrEmpty(rule.match.mythicContains))
                score += EquipmentScanner.MythicMatchScore(unit, rule.match.mythicContains);
            return score;
        }

        private static string Summarize(UnitEntityData unit, BuildRuleSet rules)
        {
            var pair = EquipmentScanner.ClassAndMythic(unit);
            return Safe(unit.CharacterName)
                + " | " + pair.Item1
                + " | mythic " + pair.Item2
                + " | STR " + Stat(unit, StatType.Strength)
                + " DEX " + Stat(unit, StatType.Dexterity)
                + " CON " + Stat(unit, StatType.Constitution)
                + " INT " + Stat(unit, StatType.Intelligence)
                + " WIS " + Stat(unit, StatType.Wisdom)
                + " CHA " + Stat(unit, StatType.Charisma)
                + " | build " + (rules == null ? "none" : rules.id);
        }

        private static int Stat(UnitEntityData unit, StatType type)
        {
            if (unit.Stats == null)
                return 0;
            var stat = unit.Stats.GetStat(type);
            return stat == null ? 0 : stat.ModifiedValue;
        }

        public static IEnumerable<UnitEntityData> ActiveParty()
        {
            var party = Kingmaker.Game.Instance.Player.Party;
            if (party == null)
                return new UnitEntityData[0];
            return party.Where(unit => unit != null && unit.Body != null);
        }

        private static IEnumerable<UnitEntityData> GameParty()
        {
            return ActiveParty();
        }

        private static string Safe(string value)
        {
            return string.IsNullOrEmpty(value) ? "(unnamed)" : value;
        }
    }
}
