using System.Collections;
using System.Collections.Generic;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class Vendor : IVendor
    {
        public string Name { get; }
        protected ICustomer<IVendible> CurrentCustomer { get; private set; }

        private readonly List<IVendible> _vendibleList;
        private readonly HashSet<string> _vendibleIDSet;


        /// <summary>
        /// 
        /// </summary>
        public Vendor(string name)
        {
            Name = name;
            CurrentCustomer = null;
            _vendibleList = new List<IVendible>();
            _vendibleIDSet = new HashSet<string>();
        }


        public IEnumerator<IVendible> GetEnumerator() => _vendibleList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


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
        public void Buy(IVendible vendible, int amount)
        {
            if (CurrentCustomer == null || !CurrentCustomer.CanBuy(vendible, amount))
                return;

            CurrentCustomer.Buy(vendible, amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        public void Sell(IVendible vendible, int amount)
        {
            if (CurrentCustomer == null)
                return;

            CurrentCustomer.Sell(vendible, amount);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<IVendible> comparer)
        {
            _vendibleList.Sort(comparer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public void Access(ICustomer<IVendible> customer)
        {
            CurrentCustomer = customer;
        }
    }
}
