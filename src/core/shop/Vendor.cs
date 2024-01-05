using System.Collections;
using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Vendor : IVendor
    {
        public string Name { get; }
        public ICustomer Customer { get; private set; }

        private readonly IInventory _inventory;
        private readonly List<IVendible> _vendibleList;


        /// <summary>
        /// 
        /// </summary>
        public Vendor(string name, IInventory inventory)
        {
            Name = name;
            _inventory = inventory;
            _vendibleList = new List<IVendible>();
            Customer = null;
        }


        public IEnumerator<IVendible> GetEnumerator() => _vendibleList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <returns></returns>
        private int GetTotalAmount(IVendible vendible)
        {
            if (_inventory == null || !(vendible is IItem item))
                return -1;

            int totalAmount = 0;
            foreach (ISlot slot in _inventory)
            {
                if (!slot.IsEmpty && slot.Item.IsEqual(item))
                    totalAmount += slot.Amount;
            }

            return totalAmount;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private bool CanBuy(IVendible vendible, int amount)
        {
            int totalAmount = GetTotalAmount(vendible);
            return totalAmount == -1 || totalAmount >= amount;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        public void Buy(IVendible vendible, int amount)
        {
            if (Customer == null || !CanBuy(vendible, amount) || !Customer.Buy(vendible, amount))
                return;

            if (_inventory != null && vendible is IItem item)
                _inventory.RemoveItem(item, amount);
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
        public void Access(ICustomer customer)
        {
            Customer = customer;
            _vendibleList.Clear();

            foreach (ISlot slot in _inventory)
            {
                if (!slot.IsEmpty && slot.Item is IVendible vendible)
                    _vendibleList.Add(vendible);
            }

            Event_VendorAccess e = new Event_VendorAccess(this);
            EventSystem.Current.Broadcast(e);
        }
    }
}
