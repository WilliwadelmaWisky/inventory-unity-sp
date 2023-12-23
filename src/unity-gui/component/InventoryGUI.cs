using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryGUI : MonoBehaviour
    {
        public delegate void SlotClickDelegate(SlotGUI slotGUI, PointerEventData.InputButton clickButton);

        [SerializeField] private SlotGUI SlotPrefab;
        [SerializeField] private ListGUI SlotList;
        [Header("Optional")]
        [SerializeField] private SlotSortGUI SlotSort;

        private IInventory _inventory;
        private SlotClickDelegate _onSlotClicked;
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
        public void Assign(IInventory inventory, SlotClickDelegate onSlotClicked)
        {
            _inventory = inventory;
            _onSlotClicked = onSlotClicked;

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
            slotGUI.OnClicked += (clickButton) => OnSlotClicked(slotGUI, clickButton);
            slotGUI.transform.SetSiblingIndex(index);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        private void OnSlotClicked(SlotGUI slotGUI, PointerEventData.InputButton clickButton)
        {
            if (slotGUI == null || slotGUI.Slot.IsEmpty)
                return;

            Debug.Log("Click: " + slotGUI.Slot.Item.Name);
            _onSlotClicked?.Invoke(slotGUI, clickButton);
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
