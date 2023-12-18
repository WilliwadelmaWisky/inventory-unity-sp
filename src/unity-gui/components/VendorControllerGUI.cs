using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(VendorGUI))]
    public class VendorControllerGUI : MonoBehaviour
    {
        private VendorGUI _vendorGUI;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _vendorGUI = GetComponent<VendorGUI>();

            EventSystem.Current.Listen(e =>
            {
                if (e is Event_VendorAccess vendorAccessEvent)
                    _vendorGUI.Assign(vendorAccessEvent.Vendor);
            });
        }
    }
}
