namespace HansenEquipmentManager
{
    // Slot labels for Advisor Mode. The old party-wide Recommend pass had no caller.
    public static class PartyOptimizer
    {
        public static string SlotLabel(string slot)
        {
            switch (slot)
            {
                case "PrimaryHand": return "Primary Hand";
                case "SecondaryHand": return "Secondary Hand";
                case "Armor": return "Armor";
                case "Head": return "Head";
                case "Neck": return "Neck";
                case "Belt": return "Belt";
                case "Feet": return "Boots";
                case "Gloves": return "Gloves";
                case "Wrist": return "Wrist";
                case "Shoulders": return "Cloak";
                case "Glasses": return "Glasses";
                case "Shirt": return "Shirt";
                case "Ring1": return "Ring 1";
                case "Ring2": return "Ring 2";
                default: return slot;
            }
        }
    }
}
