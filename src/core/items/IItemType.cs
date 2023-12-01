using System;

namespace WWWisky.inventory.core.items
{
    /// <summary>
    /// 
    /// </summary>
    public interface IItemType : IComparable<IItemType>
    {
        string Name { get; }
    }
}
