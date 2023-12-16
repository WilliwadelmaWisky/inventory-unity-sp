using System;
using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.unity.gui.controls;

namespace WWWisky.inventory.unity.gui.components
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryGUI : MonoBehaviour
    {
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
        public void Assign(IInventory inventory)
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
                    AddSlot(slot, index);
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        private void AddSlot(ISlot slot, int index)
        {
            SlotGUI slotGUI = (SlotGUI)_slotPool.Get();
            SlotList.Add(slot, slotGUI);
            slotGUI.transform.SetSiblingIndex(index);
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
