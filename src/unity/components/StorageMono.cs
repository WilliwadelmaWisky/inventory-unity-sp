using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.controls;

namespace WWWisky.inventory.unity.components
{
    /// <summary>
    /// 
    /// </summary>
    public class StorageMono : MonoBehaviour
    {
        private Inventory _inventory;
        private ItemTransfer _itemTransfer;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _inventory = new Inventory();
            _itemTransfer = new ItemTransfer(_inventory);
        }
    }
}
