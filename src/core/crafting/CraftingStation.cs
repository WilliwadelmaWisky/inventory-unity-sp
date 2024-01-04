using System.Collections;
using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingStation : ICraftingStation
	{
        public string Name { get; }
        protected ICrafter CurrentCrafter { get; private set; }

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
		public void Add(IRecipe recipe)
        {
			if (recipe == null || Contains(recipe))
				return;

            _recipeList.Add(recipe);
			_recipeIDSet.Add(recipe.ID);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="recipe"></param>
		public void Remove(IRecipe recipe)
        {
			if (recipe == null || !Contains(recipe))
				return;

            _recipeList.Remove(recipe);
            _recipeIDSet.Remove(recipe.ID);
        }
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="recipe"></param>
		/// <param name="amount"></param>
		/// <param name="crafter"></param>
		public virtual void Craft(IRecipe recipe, int amount)
		{
			if (CurrentCrafter == null || !Contains(recipe))
				return;

            CurrentCrafter.Craft(recipe, amount);
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        public void Access(ICrafter crafter)
        {
            CurrentCrafter = crafter;

            IEvent e = new Event_CraftingStationAccess(this, CurrentCrafter);
            EventSystem.Current.Broadcast(e);
        }
    }
}