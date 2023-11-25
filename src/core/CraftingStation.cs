using System;
using System.Collections.Generic;
using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core
{
	/// <summary>
	/// 
	/// </summary>
	public class CraftingStation : ICraftingStation
	{
		public string ID { get; }
        public string Name { get; }

		private readonly List<IRecipe> _recipeList;
		private readonly HashSet<string> _recipeIDSet;

		public int RecipeCount => _recipeList.Count;
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		public CraftingStation(string id, string name)
		{
			ID = id;
            Name = name;
			_recipeList = new List<IRecipe>();
			_recipeIDSet = new HashSet<string>();
		}


		public bool Contains(IRecipe recipe) => _recipeIDSet.Contains(recipe.ID);
		public virtual bool IsEqual(ICraftingStation other) => ID.Equals(other.ID);


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
		public bool AddRecipe(IRecipe recipe)
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
		
		
		public void Craft(IRecipe recipe, int amount)
		{
			if (recipe == null || amount <= 0)
				return;
			

		}
    }
}