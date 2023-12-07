using System;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public class GridRecipe
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requirement"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public delegate void GridCallback(IRequirement requirement, int x, int y);

        public string ID { get; }
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }

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
            Width = size;
            Height = size;
            _requirementGrid = new IRequirement[size, size];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="requirement"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Set(IRequirement requirement, int x, int y)
        {
            if (x < 0 || x >= _requirementGrid.GetLength(0) || y < 0 || y >= _requirementGrid.GetLength(1))
                return;

            _requirementGrid[x, y] = requirement;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onLoop"></param>
        public void ForEach(GridCallback onLoop)
        {
            for (int x = 0; x < _requirementGrid.GetLength(0); x++)
            {
                for (int y = 0; y < _requirementGrid.GetLength(1); y++)
                    onLoop(_requirementGrid[x, y], x, y);
            }
        }
    }
}
