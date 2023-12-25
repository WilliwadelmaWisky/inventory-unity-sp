using UnityEngine;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotSelectorGUI : MonoBehaviour
    {
        private InventoryGUI _inventoryGUI;
        private SlotGUI _slotGUI;
        private ActionMenuMono _actionMenu;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _inventoryGUI = GetComponent<InventoryGUI>();
            _inventoryGUI.OnSlotCreated += OnSlotCreated;
        }

        /// <summary>
        /// 
        /// </summary>
        void OnDestroy()
        {
            if (_inventoryGUI == null)
                return;

            _inventoryGUI.OnSlotCreated -= OnSlotCreated;   
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        private void OnSlotCreated(SlotGUI slotGUI)
        {
            if (!slotGUI.TryGetComponent(out SlotActionGUI selectGUI))
                return;

            selectGUI.SetOnSelect(() => Select(slotGUI));
            selectGUI.SetOnDeselect(() => Deselect());
        }


        public void SetActionMenu(ActionMenuMono actionMenu) => _actionMenu = actionMenu;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        public void Select(SlotGUI slotGUI)
        {
            if (slotGUI == null || _slotGUI == slotGUI)
                return;

            _slotGUI = slotGUI;
            _actionMenu.SetSlot(slotGUI.Slot);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Deselect()
        {
            _slotGUI = null;
            _actionMenu.SetSlot(null);
        }
    }
}
