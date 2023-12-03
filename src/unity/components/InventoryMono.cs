using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.controls;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.unity.components
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryMono : MonoBehaviour, ICrafter<IRecipe>
    {
        [SerializeField, Min(2)] private int SlotCount = 30;

        private Inventory _inventory;
        private CraftingStation _craftingStation;
        private Equipment _equipment;
        private ItemUser _itemUser;
        private ItemDropper _itemDropper;
        private ItemTransfer _itemTransfer;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _inventory = new Inventory(SlotCount);
            _craftingStation = new CraftingStation("Inventory");
            _equipment = new Equipment();

            _itemUser = new ItemUser(this.gameObject, _inventory);
            _itemDropper = new ItemDropper(this.gameObject, _inventory);
            _itemTransfer = new ItemTransfer(_inventory);
        }


        public bool CanCraft(IRecipe item, int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Craft(IRecipe item, int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
