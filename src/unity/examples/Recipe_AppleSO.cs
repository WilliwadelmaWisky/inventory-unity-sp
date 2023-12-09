using UnityEngine;
using WWWisky.inventory.core.items;
using WWWisky.inventory.core.recipes;
using WWWisky.inventory.unity.items;
using WWWisky.inventory.unity.recipes;

namespace WWWisky.inventory.unity.examples
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class Recipe_AppleSO : RecipeSO
    {
        [SerializeField] private Item_AppleSO Apple;
        [SerializeField] private ItemSO[] Requirements;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override IRecipe OnCreate(string id, string name)
        {
            ICraftable craftable = (ICraftable)Apple.Create();
            Recipe recipe = new Recipe(id, name, craftable);

            for (int i = 0; i < Requirements.Length; i++)
            {
                IItem item = Requirements[i].Create();
                recipe.Add(new ItemRequirement(item, 1));
            }

            return recipe;
        }
    }
}
