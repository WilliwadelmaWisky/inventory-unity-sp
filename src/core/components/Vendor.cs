using System;
using System.Collections.Generic;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.core.items;
using WWWisky.inventory.core.util;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class Vendor : IInventory
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

        public int SlotCount => throw new NotImplementedException();


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

        public AddItemResult AddItem(IItem item, int amount)
        {
            throw new NotImplementedException();
        }

        public AddItemResult AddItem(IItem item, int amount, int index)
        {
            throw new NotImplementedException();
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

        public void ForEach(Action<ISlot, int> onLoop)
        {
            throw new NotImplementedException();
        }

        public ISlot Get(int index)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty(int index)
        {
            throw new NotImplementedException();
        }

        public RemoveItemResult RemoveItem(IItem item, int amount)
        {
            throw new NotImplementedException();
        }

        public RemoveItemResult RemoveItem(IItem item, int amount, int index)
        {
            throw new NotImplementedException();
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

        public void Sort(IComparer<ISlot> comparer)
        {
            throw new NotImplementedException();
        }
    }
}
