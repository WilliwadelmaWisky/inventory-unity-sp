using System.Collections;
using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Tier : IEnumerable<IRecipe>
    {
        private readonly List<IRecipe> _recipeList;
        private readonly HashSet<string> _recipeIDSet;


        /// <summary>
        /// 
        /// </summary>
        public Tier()
        {
            _recipeList = new List<IRecipe>();
            _recipeIDSet = new HashSet<string>();
        }


        public IEnumerator<IRecipe> GetEnumerator() => _recipeList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        public void Add(IRecipe recipe)
        {
            if (recipe == null || _recipeIDSet.Contains(recipe.ID))
                return;

            _recipeList.Add(recipe);
            _recipeIDSet.Add(recipe.ID);
        }
    }
}
