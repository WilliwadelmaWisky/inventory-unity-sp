using System;
using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryGUI : MonoBehaviour
    {
        public event Action<SlotGUI> OnSlotCreated;

        [SerializeField] private SlotGUI SlotPrefab;
        [SerializeField] private ListGUI SlotList;
        [Header("Optional")]
        [SerializeField] private SlotSortGUI SlotSort;

        private IInventory _inventory;
        private IObjectPool<IElementGUI> _slotPool;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _slotPool = new ObjectPool<IElementGUI>(() => (IElementGUI)SlotPrefab.Clone());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="onSlotClicked"></param>
        public virtual void Assign(IInventory inventory)
        {
            _inventory = inventory;

            Refresh();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Refresh() => Refresh(slot => true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        private void Refresh(Predicate<ISlot> match)
        {
            SlotList.Clear().ForEach(slotGUI => _slotPool.Release(slotGUI));
            _inventory.ForEach((slot, index) => 
            {
                if (match(slot))
                    CreateSlot(slot, index);
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        private void CreateSlot(ISlot slot, int index)
        {
            SlotGUI slotGUI = (SlotGUI)_slotPool.Get();
            SlotList.Add(slot, slotGUI);
            slotGUI.transform.SetSiblingIndex(index);

            OnSlotCreated?.Invoke(slotGUI);
        }


        /// <summary>
        /// 
        /// </summary>
        public void Sort()
        {
            if (SlotSort == null)
                return;

            _inventory.Sort(SlotSort.GetComparer());
            Refresh(SlotSort.GetPredicate());
        }
    }
}
