using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core.components;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryGUI : MonoBehaviour
    {
        [SerializeField] private SlotGUI SlotPrefab;
        [SerializeField] private SlotListGUI SlotList;

        private IInventory _inventory;
        private IObjectPool<ISlotGUI> _slotPool;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _slotPool = new ObjectPool<ISlotGUI>(() => (ISlotGUI)SlotPrefab.Clone());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        public void Assign(IInventory inventory)
        {
            _inventory = inventory;

            Refresh();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            SlotList.Clear().ForEach(slotGUI => _slotPool.Release(slotGUI));
            _inventory.ForEach((slot, index) =>
            {
                ISlotGUI slotGUI = _slotPool.Get();
                SlotList.Add(slot, slotGUI);
            });
        }
    }
}
