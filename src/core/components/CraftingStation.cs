using System;
using System.Collections;
using System.Collections.Generic;
using WWWisky.inventory.core.recipes;
using WWWisky.inventory.core.util;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingStation : ICraftingStation
	{
        public string Name { get; }
        protected ICrafter<IRecipe> CurrentCrafter { get; private set; }

		private readonly List<IRecipe> _recipeList;
		private readonly HashSet<string> _recipeIDSet;

		public int RecipeCount => _recipeList.Count;
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public CraftingStation(string name)
		{
            Name = name;
            CurrentCrafter = null;
			_recipeList = new List<IRecipe>();
			_recipeIDSet = new HashSet<string>();
		}


        public IEnumerator<IRecipe> GetEnumerator() => _recipeList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
		public bool Contains(IRecipe recipe) => _recipeIDSet.Contains(recipe.ID);
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="recipe"></param>
		/// <returns></returns>
		public bool Add(IRecipe recipe)
        {
			if (recipe == null || Contains(recipe))
				return false;

            _recipeList.Add(recipe);
			_recipeIDSet.Add(recipe.ID);
			return true;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="recipe"></param>
		/// <returns></returns>
		public bool Remove(IRecipe recipe)
        {
			if (recipe == null || !Contains(recipe))
				return false;

			if (_recipeList.Remove(recipe))
			{
				_recipeIDSet.Remove(recipe.ID);
				return true;
			}

			return false;
        }
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="recipe"></param>
		/// <param name="amount"></param>
		/// <param name="crafter"></param>
		public virtual void Craft(IRecipe recipe, int amount)
		{
			if (CurrentCrafter == null || !CurrentCrafter.HasResources(recipe, amount) || !Contains(recipe))
				return;

            CurrentCrafter.UseResources(recipe, amount);
            CraftResult result = recipe.Craft();
            if (!result.Success)
                return;

            CurrentCrafter.OnCrafted(result.Craftable, result.Quantity);
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        public void Access(ICrafter<IRecipe> crafter)
        {
            CurrentCrafter = crafter;
        }
    }
}