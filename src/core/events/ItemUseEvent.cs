using WWWisky.inventory.core.components;

namespace WWWisky.inventory.core.events
{
    public class ItemUseEvent
    {
        public static ItemUseEvent Default { get; } = new ItemUseEvent(null, 0);

        public IInventory Inventory { get; }
        public int SlotIndex { get; }


        public ItemUseEvent(IInventory inventory, int slotIndex)
        {
            Inventory = inventory;
            SlotIndex = slotIndex;
        }
    }
}
