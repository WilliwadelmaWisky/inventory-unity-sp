using UnityEngine;
using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.unity.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class RecipeSO : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IRecipe Create();
    }
}
