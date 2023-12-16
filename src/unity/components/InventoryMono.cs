using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.controls;
using WWWisky.inventory.core.recipes;
using WWWisky.inventory.unity.recipes;

namespace WWWisky.inventory.unity.components
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryMono : MonoBehaviour, ICrafter<IRecipe>
    {
        [SerializeField, Min(2)] private int SlotCount = 30;
        [SerializeField] private RecipeSO[] Recipes;

        private IInventory _inventory;
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

            _itemUser = new ItemUser(gameObject, _inventory);
            _itemDropper = new ItemDropper(gameObject, _inventory);
            _itemTransfer = new ItemTransfer(_inventory);

            foreach (RecipeSO recipeSO in Recipes)
            {
                IRecipe recipe = recipeSO.Create();
                _craftingStation.Add(recipe);
            }
        }


        public IInventory GetInventory() => _inventory;
        public ICraftingStation GetCraftingStation() => _craftingStation;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool HasResources(IRecipe recipe, int amount)
        {
            foreach (IRequirement requirement in recipe)
            {
                if (!requirement.OK(this))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        public void UseResources(IRecipe recipe, int amount)
        {
            foreach (IRequirement requirement in recipe)
                requirement.Use(this);
        }
    }
}
