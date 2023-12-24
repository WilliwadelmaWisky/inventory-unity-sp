using TMPro;
using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class StorageGUI : InventoryGUI
    {
        [SerializeField] private TextMeshProUGUI NameText;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        public override void Assign(IInventory inventory)
        {
            base.Assign(inventory);

            IStorage storage = (IStorage)inventory;
            string nameString = storage != null ? storage.Name : "Storage";
            NameText.SetText(nameString);
        }
    }
}
