using System.Collections.Generic;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVendor : IEnumerable<IVendible>, ISortable<IVendible>
    {
        string Name { get; }

        void Buy(IVendible vendible, int amount);
        void Sell(IVendible vendbile, int amount);
        void Access(ICustomer customer);
    }
}
