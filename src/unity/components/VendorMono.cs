using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorMono : MonoBehaviour
    {
        [SerializeField] protected string Name;

        public IVendor Vendor { get; private set; }
        private InventoryMono _inventoryMono;


        /// <summary>
        /// 
        /// </summary>
        void Start()
        {
            _inventoryMono = GetComponent<InventoryMono>();
            Vendor = Create();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        protected virtual IVendor Create() => new Vendor(Name, _inventoryMono?.Inventory);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public void Access(ICustomer customer)
        {
            Vendor.Access(customer);
        }
    }
}
