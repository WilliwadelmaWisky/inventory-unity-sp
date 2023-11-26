using System;

namespace WWWisky.inventory.core.contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IItemType : IComparable<IItemType>
    {
        string Name { get; }
    }
}
