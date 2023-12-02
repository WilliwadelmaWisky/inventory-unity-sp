using System.Collections.Generic;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class Vendor
    {
        private readonly List<IVendible> _vendibleList;
        private readonly HashSet<string> _vendibleIDSet;


        /// <summary>
        /// 
        /// </summary>
        public Vendor()
        {
            _vendibleList = new List<IVendible>();
            _vendibleIDSet = new HashSet<string>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        public void Add(IVendible vendible)
        {
            if (_vendibleIDSet.Contains(vendible.ID))
                return;

            _vendibleList.Add(vendible);
            _vendibleIDSet.Add(vendible.ID);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        /// <param name="customer"></param>
        public void Buy(IVendible vendible, int amount, ICustomer<IVendible> customer)
        {
            if (!customer.CanBuy(vendible, amount))
                return;

            customer.Buy(vendible, amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="amount"></param>
        /// <param name="customer"></param>
        public void Buy(int index, int amount, ICustomer<IVendible> customer)
        {
            IVendible vendible = _vendibleList[index];
            Buy(vendible, amount, customer);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        /// <param name="customer"></param>
        public void Sell(IVendible vendible, int amount, ICustomer<IVendible> customer)
        {
            customer.Sell(vendible, amount);
        }
    }
}
