using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.unity.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingTableMono : MonoBehaviour, ICrafter<IRecipe>
    {
        private const int SIZE = 3;

        private CraftingStation _craftingStation;
        private CraftGrid _craftGrid;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _craftingStation = new CraftingStation("Crafting Table");
            _craftGrid = new CraftGrid(SIZE, SIZE);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool HasResources(IRecipe recipe, int amount)
        {
            if (recipe is GridRecipe gridRecipe)
            {
                bool ok = true;
                gridRecipe.ForEach((req, x, y) =>
                {
                    if (!req.OK(this))
                    {
                        ok = false;
                        return;
                    }
                });

                return ok;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        public void UseResources(IRecipe recipe, int amount)
        {
            
        }
    }
}
