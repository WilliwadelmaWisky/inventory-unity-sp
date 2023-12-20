using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorMono : MonoBehaviour
    {
        [SerializeField] private string Name;
        [SerializeField] private ItemSO[] Items;

        private Vendor _vendor;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _vendor = new Vendor(Name);

            foreach (ItemSO itemSO in Items)
            {
                IItem item = itemSO.Create();
                if (item is IVendible vendible)
                    _vendor.Add(vendible);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public void Access(ICustomer customer)
        {
            _vendor.Access(customer);
        }
    }
}
