using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingStationMono : MonoBehaviour
    {
        [SerializeField] protected string Name;
        [SerializeField] private RecipeSO[] Recipes; 

        public ICraftingStation CraftingStation { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            CraftingStation = Create();

            foreach (RecipeSO recipeSO in Recipes)
            {
                IRecipe recipe = recipeSO.Create();
                CraftingStation.Add(recipe);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual ICraftingStation Create() => new CraftingStation(Name);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        public void Access(ICrafter crafter)
        {
            CraftingStation.Access(crafter);
        }
    }
}
