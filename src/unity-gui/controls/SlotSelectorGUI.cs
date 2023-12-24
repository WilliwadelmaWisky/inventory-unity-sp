using System;
using UnityEngine;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotSelectorGUI : MonoBehaviour
    {
        public event Action<SlotGUI> OnSelectionChanged;

        private InventoryGUI _inventoryGUI;
        private SlotGUI _slotGUI;


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
        void Update()
        {
            if (_slotGUI == null)
                return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Use/Transfer");
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("Drop");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        private void OnSlotCreated(SlotGUI slotGUI)
        {
            if (!slotGUI.TryGetComponent(out SlotSelectGUI selectGUI))
                return;

            selectGUI.SetOnSelect(() => Select(slotGUI));
            selectGUI.SetOnDeselect(() => Select(null));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        public void Select(SlotGUI slotGUI)
        {
            if (_slotGUI == slotGUI)
                return;

            _slotGUI = slotGUI;
            Debug.Log("Select: " + slotGUI);
        }
    }
}
