using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVendor : IEnumerable<IVendible>, ISortable<IVendible>
    {
        string Name { get; }

        void Buy(IVendible vendible, int amount);
        void Access(ICustomer customer);
    }
}
