namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Customer : ICustomer
    {
        public IInventory Inventory { get; }
        private IWallet Wallet { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        public Customer(IInventory inventory, IWallet wallet)
        {
            Inventory = inventory;
            Wallet = wallet;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        protected int GetTotalCost(IVendible vendible, int amount) => vendible.Cost * amount;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool CanBuy(IVendible vendible, int amount) => Wallet.Value >= GetTotalCost(vendible, amount);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Buy(IVendible vendible, int amount)
        {
            if (!CanBuy(vendible, amount))
                return false;

            Add((IVendible)vendible.Clone(), amount);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="amount"></param>
        protected virtual void Add(IVendible vendible, int amount)
        {
            if (vendible is IItem item)
                Inventory.AddItem(item, amount);
        }
    }
}
