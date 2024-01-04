using System;
using System.Collections.Generic;
using System.Collections;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Recipe : IRecipe
	{
		public string ID { get; }
		public string Name { get; }

		private readonly ICraftable _craftable;
		private readonly List<IRequirement> _requirementList;
		private readonly HashSet<string> _requirementIDSet;
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="craftable"></param>
		public Recipe(string id, string name, ICraftable craftable)
		{
			ID = id;
			Name = name;
			_craftable = craftable;
			_requirementList = new List<IRequirement>();
			_requirementIDSet = new HashSet<string>();
		}


        public IEnumerator<IRequirement> GetEnumerator() => _requirementList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="requirement"></param>
        public void Add(IRequirement requirement)
        {
			if (requirement == null || _requirementIDSet.Contains(requirement.ID))
				return;

			_requirementList.Add(requirement);
			_requirementIDSet.Add(requirement.ID);
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="onLoop"></param>
		public void ForEach(Action<IRequirement, int> onLoop)
        {
			for (int i = 0; i < _requirementList.Count; i++)
				onLoop(_requirementList[i], i);
        }


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public CraftResult Craft()
        {
			ICraftable craftable = (ICraftable)_craftable.Clone();
			CraftResult result = new CraftResult(true, craftable, 1);
			return result;
        }
    }
}