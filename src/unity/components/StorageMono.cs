using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class StorageMono : MonoBehaviour
    {
        [SerializeField] private string Name;
        [SerializeField, Min(1)] private int SlotCount = 30;
        [SerializeField] private ItemSO[] Items;

        private Storage _storage;
        private ItemTransfer _itemTransfer;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _storage = new Storage(Name, SlotCount);
            _itemTransfer = new ItemTransfer();

            foreach (ItemSO itemSO in Items)
            {
                IItem item = itemSO.Create();
                _storage.AddItem(item, 1);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessor"></param>
        public void Access(IItemHolder accessor)
        {
            _storage.Access(accessor);
        }
    }
}
