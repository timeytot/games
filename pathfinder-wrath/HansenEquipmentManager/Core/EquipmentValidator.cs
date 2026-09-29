using Kingmaker.Items;
using Kingmaker.Items.Slots;

namespace HansenEquipmentManager
{
    public static class EquipmentValidator
    {
        public static bool CanApply(ItemSlot slot, ItemEntity item, out string reason)
        {
            if (slot == null)
            {
                reason = "slot missing";
                return false;
            }
            if (item == null)
            {
                reason = "item missing";
                return false;
            }
            if (!slot.CanInsertItem(item))
            {
                reason = "CanInsertItem=false";
                return false;
            }
            reason = null;
            return true;
        }

        public static bool Equipped(ItemSlot slot, string blueprint)
        {
            return slot != null &&
                   slot.MaybeItem != null &&
                   slot.MaybeItem.Blueprint != null &&
                   slot.MaybeItem.Blueprint.name == blueprint;
        }
    }
}
