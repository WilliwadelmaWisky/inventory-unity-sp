using WWWisky.inventory.core.contracts;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core
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


        public void Buy(IVendible vendible, int amount)
        {

        }


        public void Sell(IVendible vendible, int amount)
        {

        }
    }
}
