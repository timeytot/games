using System;
using System.Collections.Generic;
using System.Text;
using Kingmaker.Items.Slots;

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
            if (plans == null)
            {
                report.AppendLine("FAILED: no plan to execute");
                return report.ToString();
            }
            foreach (var plan in plans)
            {
                if (plan == null || plan.Rule == null)
                {
                    failed++;
                    report.AppendLine("FAILED:\nCharacter:\nSlot:\nBlueprint:\nReason: empty plan");
                    continue;
                }
                if (plan.Status == PlanStatus.AlreadyCorrect || plan.Status != PlanStatus.Ready)
                {
                    skipped++;
                    continue;
                }
                try
                {
                    if (ExecuteOne(plan, report))
                        equipped++;
                    else
                        failed++;
                }
                catch (Exception ex)
                {
                    failed++;
                    report.AppendLine(Fail(plan, ex.Message));
                }
            }

            report.AppendLine("Done. Equipped " + equipped + ", skipped " + skipped + ", failed " + failed + ".");
            return report.ToString();
        }

        private static bool ExecuteOne(PlannedAction plan, StringBuilder report)
        {
            report.AppendLine("Item " + Safe(plan.Rule.character) + " " + Safe(plan.Rule.slot) + " " + Safe(plan.Rule.blueprint));
            var target = EquipmentScanner.FindUnit(plan.Rule.character, plan.Rule.unitId);
            report.AppendLine("Target unit: " + (target == null ? "not found" : "found"));
            if (target == null)
            {
                report.AppendLine(Fail(plan, "character is not in the active party"));
                return false;
            }

            var slot = EquipmentScanner.SlotOf(target, plan.Rule.slot);
            report.AppendLine("Target slot: " + (slot == null ? "not found" : "found"));
            if (slot == null)
            {
                report.AppendLine(Fail(plan, "slot does not exist"));
                return false;
            }

            if (EquipmentScanner.IsUnequipBlueprint(plan.Rule.blueprint))
                return ExecuteUnequip(plan, slot, report);

            var item = EquipmentScanner.FindPlannedItem(plan);
            report.AppendLine("Source item: " + (item == null ? "not found" : "found"));
            if (item == null)
            {
                report.AppendLine(Fail(plan, "item is not in inventory"));
                return false;
            }

            bool canInsert = false;
            try
            {
                canInsert = slot.CanInsertItem(item);
            }
            catch (Exception ex)
            {
                report.AppendLine("CanInsertItem: false");
                report.AppendLine(Fail(plan, ex.Message));
                return false;
            }
            report.AppendLine("CanInsertItem: " + (canInsert ? "true" : "false"));
            if (!canInsert)
            {
                report.AppendLine(Fail(plan, "CanInsertItem=false"));
                return false;
            }

            if (item.HoldingSlot == null)
            {
                report.AppendLine("RemoveItem: not needed");
            }
            else
            {
                bool removed = false;
                try
                {
                    removed = item.HoldingSlot.RemoveItem();
                }
                catch (Exception ex)
                {
                    report.AppendLine("RemoveItem: failed");
                    report.AppendLine(Fail(plan, ex.Message));
                    return false;
                }
                report.AppendLine("RemoveItem: " + (removed ? "success" : "failed"));
                if (!removed)
                {
                    report.AppendLine(Fail(plan, "could not remove the previous holder"));
                    return false;
                }
            }

            if (slot.HasItem)
            {
                bool cleared = false;
                try
                {
                    cleared = slot.RemoveItem();
                }
                catch (Exception ex)
                {
                    report.AppendLine("RemoveItem: failed");
                    report.AppendLine(Fail(plan, ex.Message));
                    return false;
                }
                report.AppendLine("Clear target slot: " + (cleared ? "success" : "failed"));
                if (!cleared)
                {
                    report.AppendLine(Fail(plan, "could not clear the target slot"));
                    return false;
                }
            }

            bool inserted = false;
            try
            {
                inserted = slot.InsertItem(item) && EquipmentValidator.Equipped(slot, plan.Rule.blueprint);
            }
            catch (Exception ex)
            {
                report.AppendLine("InsertItem: failed");
                report.AppendLine(Fail(plan, ex.Message));
                return false;
            }
            report.AppendLine("InsertItem: " + (inserted ? "success" : "failed"));
            if (!inserted)
            {
                report.AppendLine(Fail(plan, "verification failed after InsertItem"));
                return false;
            }
            report.AppendLine("SUCCESS " + Safe(plan.Rule.character) + " " + Safe(plan.Rule.slot) + " " + Safe(plan.Rule.blueprint));
            return true;
        }

        private static bool ExecuteUnequip(PlannedAction plan, ItemSlot slot, StringBuilder report)
        {
            report.AppendLine("Unequip: clear slot without insert");
            if (!slot.HasItem)
            {
                report.AppendLine("Clear target slot: already empty");
                report.AppendLine("SUCCESS " + Safe(plan.Rule.character) + " " + Safe(plan.Rule.slot) + " unequip");
                return true;
            }

            bool cleared = false;
            try
            {
                cleared = slot.RemoveItem();
            }
            catch (Exception ex)
            {
                report.AppendLine("RemoveItem: failed");
                report.AppendLine(Fail(plan, ex.Message));
                return false;
            }
            report.AppendLine("Clear target slot: " + (cleared ? "success" : "failed"));
            if (!cleared || slot.HasItem)
            {
                report.AppendLine(Fail(plan, "could not unequip the target slot"));
                return false;
            }
            report.AppendLine("SUCCESS " + Safe(plan.Rule.character) + " " + Safe(plan.Rule.slot) + " unequip");
            return true;
        }

        private static string Fail(PlannedAction plan, string reason)
        {
            string character = plan == null || plan.Rule == null ? "" : plan.Rule.character;
            string slot = plan == null || plan.Rule == null ? "" : plan.Rule.slot;
            string blueprint = plan == null || plan.Rule == null ? "" : plan.Rule.blueprint;
            return "FAILED:\nCharacter: " + character + "\nSlot: " + slot + "\nBlueprint: " + blueprint + "\nReason: " + reason;
        }

        private static string Safe(string value)
        {
            return value ?? "";
        }
    }
}
