using System.Collections.Generic;
using System.Text;
using Kingmaker.EntitySystem.Entities;

namespace HansenEquipmentManager
{
    public static class EquipmentExecutor
    {
        public static string Execute(IList<PlannedAction> plans)
        {
            var report = new StringBuilder();
            int equipped = 0;
            int skipped = 0;
            int failed = 0;
            foreach (var plan in plans)
            {
                if (plan.Status == PlanStatus.AlreadyCorrect)
                {
                    skipped++;
                    report.AppendLine("SKIP " + Label(plan) + " already equipped");
                    continue;
                }
                if (plan.Status != PlanStatus.Ready)
                {
                    skipped++;
                    report.AppendLine("SKIP " + Label(plan) + " " + plan.Status + " " + plan.Detail);
                    continue;
                }

                var target = EquipmentScanner.FindUnit(plan.Rule.character, plan.Rule.unitId);
                var slot = EquipmentScanner.SlotOf(target, plan.Rule.slot);
                var item = EquipmentScanner.FindPlannedItem(plan);
                string reason;
                if (!EquipmentValidator.CanApply(slot, item, out reason))
                {
                    failed++;
                    report.AppendLine("FAIL " + Label(plan) + " " + reason + ". Nothing was removed.");
                    continue;
                }

                if (item.HoldingSlot != null && !item.HoldingSlot.RemoveItem())
                {
                    failed++;
                    report.AppendLine("FAIL " + Label(plan) + " donor RemoveItem returned false");
                    continue;
                }
                if (slot.HasItem && !slot.RemoveItem())
                {
                    failed++;
                    report.AppendLine("FAIL " + Label(plan) + " target RemoveItem returned false");
                    continue;
                }
                if (!slot.InsertItem(item) || !EquipmentValidator.Equipped(slot, plan.Rule.blueprint))
                {
                    failed++;
                    report.AppendLine("FAIL " + Label(plan) + " InsertItem verification failed");
                    continue;
                }

                equipped++;
                report.AppendLine("SUCCESS " + Label(plan));
            }

            report.AppendLine("Done. Equipped " + equipped + ", skipped " + skipped + ", failed " + failed + ".");
            return report.ToString();
        }

        public static string Verify(EquipmentProfile profile)
        {
            var report = new StringBuilder();
            report.AppendLine("Verify " + profile.displayName);
            foreach (var rule in profile.rules)
            {
                UnitEntityData target = EquipmentScanner.FindUnit(rule.character, rule.unitId);
                var slot = EquipmentScanner.SlotOf(target, rule.slot);
                bool ok = EquipmentValidator.Equipped(slot, rule.blueprint);
                report.AppendLine((ok ? "OK " : "MISSING ") + rule.character + " " + rule.slot + " " + rule.blueprint
                    + " current=" + EquipmentScanner.Describe(slot));
            }
            return report.ToString();
        }

        private static string Label(PlannedAction plan)
        {
            return plan.Rule.character + " / " + plan.Rule.slot + " / " + plan.Rule.blueprint;
        }
    }
}
