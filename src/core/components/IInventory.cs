using System;
using WWWisky.inventory.core.util;
using WWWisky.inventory.core.items;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInventory : ISortable<ISlot>
    {
        int SlotCount { get; }

        bool IsEmpty(int index);
        ISlot Get(int index);
        void ForEach(Action<ISlot, int> onLoop);

        AddItemResult AddItem(IItem item, int amount);
        AddItemResult AddItem(IItem item, int amount, int index);

        RemoveItemResult RemoveItem(IItem item, int amount);
        RemoveItemResult RemoveItem(IItem item, int amount, int index);
    }
}
