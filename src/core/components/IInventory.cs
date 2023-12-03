using System;
using WWWisky.inventory.core.util;
using WWWisky.inventory.core.items;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInventory
    {
        int SlotCount { get; }

        bool IsEmpty(int index);
        IInventorySlot Get(int index);
        void ForEach(Action<IInventorySlot, int> onLoop);

        AddItemResult AddItem(IItem item, int amount);
        AddItemResult AddItem(IItem item, int amount, int index);

        RemoveItemResult RemoveItem(IItem item, int amount);
        RemoveItemResult RemoveItem(IItem item, int amount, int index);
    }
}
