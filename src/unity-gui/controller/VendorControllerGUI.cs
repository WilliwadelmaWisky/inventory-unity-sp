using UnityEngine;
using UnityEngine.UI;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(VendorGUI), typeof(WindowGUI))]
    public class VendorControllerGUI : MonoBehaviour
    {
        [Header("Optional")]
        [SerializeField] private Button CloseButton;

        protected VendorGUI VendorGUI { get; private set; }
        protected WindowGUI WindowGUI { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            VendorGUI = GetComponent<VendorGUI>();
            WindowGUI = GetComponent<WindowGUI>();

            CloseButton?.onClick.AddListener(CloseVendorGUI);
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
            if (e is Event_VendorAccess vendorAccessEvent)
                OpenVendorGUI(vendorAccessEvent.Vendor);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendor"></param>
        public virtual void OpenVendorGUI(IVendor vendor)
        {
            VendorGUI.Assign(vendor);
            WindowGUI.Show();

            WindowContainerGUI.Current?.Add(WindowGUI);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CloseVendorGUI()
        {
            WindowGUI.Hide();

            WindowContainerGUI.Current?.Remove(WindowGUI);
        }
    }
}
