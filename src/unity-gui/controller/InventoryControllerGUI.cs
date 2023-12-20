using UnityEngine;
using UnityEngine.UI;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(InventoryGUI), typeof(WindowGUI))]
    public class InventoryControllerGUI : MonoBehaviour
    {
        [Header("Optional")]
        [SerializeField] private Button CloseButton;

        protected InventoryGUI InventoryGUI { get; private set; }
        protected WindowGUI WindowGUI { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            InventoryGUI = GetComponent<InventoryGUI>();
            WindowGUI = GetComponent<WindowGUI>();

            CloseButton?.onClick.AddListener(CloseInventoryGUI);
            EventSystem.Current.AddListener(OnEventReceived);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDestroy()
        {
            EventSystem.Current.RemoveListener(OnEventReceived);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEventReceived(IEvent e)
        {
            if (e is Event_StorageAccess storageAccessEvent)
            {
                OpenInventoryGUI(storageAccessEvent.Accessor.GetInventory());
                return;
            }

            if (e is Event_CraftingStationAccess craftingStationAccessEvent)
            {
                if (craftingStationAccessEvent.Crafter is IItemHolder itemHolder)
                    OpenInventoryGUI(itemHolder.GetInventory());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        public virtual void OpenInventoryGUI(IInventory inventory)
        {
            InventoryGUI.Assign(inventory);
            WindowGUI.Show();

            WindowContainerGUI.Current?.Add(WindowGUI);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CloseInventoryGUI()
        {
            WindowGUI.Hide();

            WindowContainerGUI.Current?.Remove(WindowGUI);
        }
    }
}
