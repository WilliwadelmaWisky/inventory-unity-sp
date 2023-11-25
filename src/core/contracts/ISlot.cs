using System;
using System.Collections.Generic;
using System.Text;

namespace WWWisky.inventory.core.contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISlot<T>
    {
        T Item { get; }
        int Amount { get; }
    }
}
