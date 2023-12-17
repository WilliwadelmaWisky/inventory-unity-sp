using System.Collections.Generic;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.core.items;
using WWWisky.inventory.core.util;

namespace WWWisky.inventory.core.components
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
