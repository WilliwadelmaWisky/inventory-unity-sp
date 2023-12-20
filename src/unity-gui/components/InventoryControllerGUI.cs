using UnityEngine;
using UnityEngine.UI;
using WWWisky.inventory.core;
using WWWisky.inventory.core.components;

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
                InventoryGUI.Assign(storageAccessEvent.Accessor.GetInventory());
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
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CloseInventoryGUI()
        {
            WindowGUI.Hide();
        }
    }
}
