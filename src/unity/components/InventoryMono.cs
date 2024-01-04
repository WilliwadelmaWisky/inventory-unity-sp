using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryMono : MonoBehaviour
    {
        [SerializeField, Min(2)] protected int SlotCount = 30;
        [SerializeField] private ItemSO[] Items;

        public IInventory Inventory { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            Inventory = Create();

            foreach (ItemSO itemSO in Items)
            {
                IItem item = itemSO.Create();
                Inventory.AddItem(item, 1);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual IInventory Create() => new Inventory(SlotCount);
    }
}
