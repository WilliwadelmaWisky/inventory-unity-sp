using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core.components;
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
        public void Refresh()
        {
            SlotList.Clear().ForEach(slotGUI => _slotPool.Release(slotGUI));
            _inventory.ForEach((slot, index) =>
            {
                IElementGUI elementGUI = _slotPool.Get();
                SlotList.Add(slot, elementGUI);
                (elementGUI as MonoBehaviour).transform.SetSiblingIndex(index);
            });
        }
    }
}
