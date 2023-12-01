using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.controls;

namespace WWWisky.inventory.unity.components
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryMono : MonoBehaviour
    {
        [SerializeField, Min(2)] private int SlotCount = 30;

        private Inventory _inventory;
        private ItemUser _itemUser;
        private ItemDropper _itemDropper;
        private ItemTransfer _itemTransfer;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _inventory = new Inventory(SlotCount);
            _itemUser = new ItemUser(this.gameObject, _inventory);
            _itemDropper = new ItemDropper(this.gameObject, _inventory);
            _itemTransfer = new ItemTransfer(_inventory);
        }
    }
}
