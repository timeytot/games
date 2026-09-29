using System.Collections.Generic;

namespace HansenEquipmentManager
{
    public sealed class EquipmentProfile
    {
        public string id;
        public string displayName;
        public ProfileMatch match;
        public List<EquipmentRule> rules;
    }

    public sealed class ProfileMatch
    {
        public string classContains;
        public string mythicContains;
    }

    public sealed class EquipmentRule
    {
        public string character;
        public string unitId;
        public string slot;
        public string blueprint;
        public string donor;
        public string donorUnitId;
    }

    public enum PlanStatus
    {
        Ready,
        AlreadyCorrect,
        NeedsChoice,
        Missing,
        Blocked
    }

    public sealed class PlannedAction
    {
        public EquipmentRule Rule;
        public PlanStatus Status;
        public string Current;
        public string Detail;
        public string ItemId;
    }

    public sealed class BuildRuleSet
    {
        public string id;
        public string displayName;
        public ProfileMatch match;
        public Dictionary<string, int> weights;
    }

    public sealed class EquipmentRecommendation
    {
        public string Character;
        public string UnitId;
        public string Slot;
        public string Blueprint;
        public string ItemId;
        public int Score;
        public string Conflict;
        public bool AlreadyWorn;
    }
}
