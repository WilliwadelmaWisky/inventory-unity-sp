using System;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.unity.gui.controls;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class StorageGUI : MonoBehaviour
    {
        [SerializeField] private SlotGUI SlotPrefab;
        [SerializeField] private ListGUI SlotList;
        [Header("Optional")]
        [SerializeField] private TextMeshProUGUI NameText;
        [SerializeField] private SlotSortGUI SlotSort;

        private IObjectPool<IElementGUI> _slotPool;
        private IStorage _storage;


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
        /// <param name="storage"></param>
        public virtual void Assign(IStorage storage)
        {
            _storage = storage;
            
            NameText?.SetText(storage.Name);
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
            _storage.ForEach((slot, index) =>
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
            slotGUI.OnClicked += () => OnSlotClicked(slotGUI);
            slotGUI.transform.SetSiblingIndex(index);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        private void OnSlotClicked(SlotGUI slotGUI)
        {
            if (slotGUI == null || slotGUI.Slot.IsEmpty)
                return;

            Debug.Log("Transfer: " + slotGUI.Slot.Item.Name);

        }


        /// <summary>
        /// 
        /// </summary>
        public void Sort()
        {
            if (SlotSort == null)
                return;

            _storage.Sort(SlotSort.GetComparer());
            Refresh(SlotSort.GetPredicate());
        }
    }
}
