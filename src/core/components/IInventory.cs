using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInventory : IEnumerable<ISlot>, ISortable<ISlot>
    {
        int SlotCount { get; }

        AddItemResult AddItem(IItem item, int amount);
        RemoveItemResult RemoveItem(IItem item, int amount);
    }
}
