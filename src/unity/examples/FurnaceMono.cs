using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.containers;
using WWWisky.inventory.core.items;
using WWWisky.inventory.core.recipes;
using WWWisky.inventory.unity.recipes;

namespace WWWisky.inventory.unity.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class FurnaceMono : MonoBehaviour, ICrafter<IRecipe>
    {
        [SerializeField] private RecipeSO[] Recipes;

        private CraftingStation _craftingStation;
        private CraftQueue _craftQueue;
        private Inventory _inventory;

        private InventorySlot _fuelSlot;

        
        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _craftingStation = new CraftingStation("Furnace");
            _craftQueue = new CraftQueue();
            _inventory = new Inventory();

            foreach (RecipeSO recipeSO in Recipes)
            {
                IRecipe recipe = recipeSO.Create();
                _craftingStation.Add(recipe);
            }

            _fuelSlot = new InventorySlot();
        }

        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            if (_fuelSlot.IsEmpty)
                return;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool CanCraft(IRecipe recipe, int amount)
        {
            bool canCraft = true;
            recipe.ForEach((requirement, index) =>
            {
                
            });

            return canCraft;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        public void Craft(IRecipe recipe, int amount)
        {
            CraftResult result = recipe.Craft();
            if (!result.Success)
                return;

            if (result.Craftable is IItem item)
            {
                _inventory.AddItem(item, amount * result.Quantity);
                recipe.ForEach((requirement, index) =>
                {
                    //_inventory.RemoveItem()
                });
            }
        }
    }
}
