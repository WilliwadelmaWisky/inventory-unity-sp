using System;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public class GridRecipe
    {
        public string ID { get; }
        public string Name { get; }

        private readonly ICraftable _craftable;
        private readonly IRequirement[,] _requirementGrid;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="craftable"></param>
        /// <param name="size"></param>
        public GridRecipe(string id, string name, ICraftable craftable, int size)
        {
            ID = id;
            Name = name;
            _craftable = craftable;

            size = Math.Max(1, size);
            _requirementGrid = new IRequirement[size, size];
        }
    }
}
