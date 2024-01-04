using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(InventoryMono))]
    public class CustomerMono : MonoBehaviour
    {
        public ICustomer Customer { get; private set; }
        private IWallet _wallet;


        /// <summary>
        /// 
        /// </summary>
        void Start()
        {
            _wallet = new Wallet(1000);
            InventoryMono inventoryMono = GetComponent<InventoryMono>();
            Customer = new Customer(inventoryMono.Inventory, _wallet);
        }
    }
}
