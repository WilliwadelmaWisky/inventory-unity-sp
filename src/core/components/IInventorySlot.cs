﻿using WWWisky.inventory.core.containers;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInventorySlot
    {
        IItem Item { get; }
        int Amount { get; }
        bool IsEmpty { get; }

        AddItemResult Add(IItem item, int amount);
        RemoveItemResult Remove(IItem item, int amount);
        RemoveItemResult Clear();
    }
}
