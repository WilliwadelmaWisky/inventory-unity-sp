using UnityEngine;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.contracts;
using WWWisky.inventory.unity.recipes;

namespace WWWisky.inventory.unity.components
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingStationMono : MonoBehaviour
    {
        [SerializeField] private string ID;
        [SerializeField] private string Name;
        [SerializeField] private RecipeSO[] Recipes; 

        private CraftingStation _craftingStation;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _craftingStation = new CraftingStation(ID, Name);

            foreach (RecipeSO recipeSO in Recipes)
            {
                IRecipe recipe = recipeSO.Create();
                _craftingStation.Add(recipe);
            }
        }
    }
}
