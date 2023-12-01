using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class Vendor
    {
        private readonly Inventory _inventory;


        public Vendor()
        {
            _inventory = new Inventory(2);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        public void Add(IVendible vendible)
        {
            if (vendible is IItem item)
                _inventory.AddItem(item, 1);
        }
    }
}
