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

        private IInventory _inventory;
        private ICraftingStation _craftingStation;
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool HasResources(IRecipe recipe, int amount)
        {
            bool canCraft = true;
            recipe.ForEach((req, index) =>
            {
                if (!req.OK(this))
                {
                    canCraft = false;
                    return;
                }
            });

            return canCraft;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        public void UseResources(IRecipe recipe, int amount)
        {
            recipe.ForEach((req, index) =>
            {
                req.Use(this);
            });
        }
    }
}
