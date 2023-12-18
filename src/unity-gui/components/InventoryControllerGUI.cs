using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(InventoryGUI))]
    public class InventoryControllerGUI : MonoBehaviour
    {
        private InventoryGUI _inventoryGUI;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _inventoryGUI = GetComponent<InventoryGUI>();

            EventSystem.Current.Listen(e =>
            {
                if (e is Event_StorageAccess storageAccessEvent)
                {
                    _inventoryGUI.Assign(storageAccessEvent.Accessor.GetInventory());
                }
            });
        }
    }
}
