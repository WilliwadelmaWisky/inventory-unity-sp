﻿using WWWisky.inventory.core.util;
using WWWisky.inventory.core.items;
using System;

namespace WWWisky.inventory.core.components.sub
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISlot
    {
        event Action OnUpdated;

        IItem Item { get; }
        int Amount { get; }
        bool IsEmpty { get; }

        bool IsAcceptable(IItem item);
        int GetStackSize(IItem item);

        AddItemResult Add(IItem item, int amount);
        RemoveItemResult Remove(IItem item, int amount);
        RemoveItemResult Clear();
    }
}
