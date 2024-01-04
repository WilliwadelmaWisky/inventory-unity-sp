using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(InventoryMono))]
    public class CrafterMono : MonoBehaviour
    {
        public ICrafter Crafter { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        void Start()
        {
            InventoryMono inventoryMono = GetComponent<InventoryMono>();
            Crafter = new Crafter(inventoryMono.Inventory);
        }
    }
}
