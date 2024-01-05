using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVendor : IEnumerable<IVendible>, ISortable<IVendible>, IAccessible<ICustomer>
    {
        string Name { get; }
        ICustomer Customer { get; }

        void Buy(IVendible vendible, int amount);
    }
}
