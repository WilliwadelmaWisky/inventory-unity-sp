using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingStationMono : MonoBehaviour
    {
        [SerializeField] private string Name;
        [SerializeField] private RecipeSO[] Recipes; 

        private CraftingStation _craftingStation;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _craftingStation = new CraftingStation(Name);

            foreach (RecipeSO recipeSO in Recipes)
            {
                IRecipe recipe = recipeSO.Create();
                _craftingStation.Add(recipe);
            }
        }
    }
}
