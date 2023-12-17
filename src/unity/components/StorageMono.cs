using UnityEngine;
using WWWisky.inventory.core;
using WWWisky.inventory.core.components.controls;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class StorageMono : MonoBehaviour
    {
        [SerializeField, Min(1)] private int SlotCount = 30;
        [SerializeField] private ItemSO[] Items;

        private Storage _storage;
        private ItemTransfer _itemTransfer;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _storage = new Storage("Storage", SlotCount);
            _itemTransfer = new ItemTransfer();
        }
    }
}
