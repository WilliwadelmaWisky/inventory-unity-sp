using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.util;
using WWWisky.inventory.core.items;
using WWWisky.inventory.core.recipes;
using WWWisky.inventory.unity.recipes;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.core.components.controls;

namespace WWWisky.inventory.unity.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class FurnaceMono : MonoBehaviour, ICrafter<IRecipe>
    {
        [SerializeField] private RecipeSO[] Recipes;

        public int Tier { get; private set; }

        private CraftingStation _craftingStation;
        private CraftQueue _craftQueue;
        private Inventory _inventory;
        private BurnableSlot _fuelSlot;
        private SlotTicker _slotTicker;

        
        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _craftingStation = new CraftingStation("Furnace");
            _craftQueue = new CraftQueue(OnRecipeCrafted);
            _inventory = new Inventory();
            Tier = 1;

            foreach (RecipeSO recipeSO in Recipes)
            {
                IRecipe recipe = recipeSO.Create();
                _craftingStation.Add(recipe);
            }

            _fuelSlot = new BurnableSlot();
            _slotTicker = new SlotTicker();
        }

        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            if (_fuelSlot.IsEmpty)
                return;

            double deltaTime = Time.deltaTime;
            _slotTicker.Tick(deltaTime, _fuelSlot);
            _craftQueue.Tick(deltaTime);
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
            recipe.ForEach((requirement, index) =>
            {
                if (!requirement.OK(this))
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
            _craftQueue.Enqueue(recipe, amount);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        private void OnRecipeCrafted(IRecipe recipe, int amount)
        {
            if (!HasResources(recipe, amount))
                return;

            CraftResult result = recipe.Craft();
            if (!result.Success)
                return;

            if (result.Craftable is IItem item)
            {
                _inventory.AddItem(item, amount * result.Quantity);
                recipe.ForEach((requirement, index) =>
                {
                    requirement.Use(this);
                });
            }
        }
    }
}
