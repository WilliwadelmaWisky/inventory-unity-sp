using System;
using System.Collections.Generic;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingStation : ICraftingStation
	{
        public string Name { get; }

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
			_recipeList = new List<IRecipe>();
			_recipeIDSet = new HashSet<string>();
		}


		public bool Contains(IRecipe recipe) => _recipeIDSet.Contains(recipe.ID);


		/// <summary>
		/// 
		/// </summary>
		/// <param name="onLoop"></param>
		public void ForEach(Action<IRecipe, int> onLoop)
        {
			for (int i = 0; i < RecipeCount; i++)
				onLoop(_recipeList[i], i);
        }
		

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
		public virtual void Craft(IRecipe recipe, int amount, ICrafter<IRecipe> crafter)
		{
			if (!crafter.HasResources(recipe, amount) || !Contains(recipe))
				return;

			crafter.UseResources(recipe, amount);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="amount"></param>
		/// <param name="crafter"></param>
		public void Craft(int index, int amount, ICrafter<IRecipe> crafter)
        {
			IRecipe recipe = _recipeList[index];
			Craft(recipe, amount, crafter);
        }
    }
}