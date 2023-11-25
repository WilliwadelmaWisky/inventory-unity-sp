using System;
using System.Collections.Generic;
using System.Text;

namespace WWWisky.inventory.core.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftGrid
    {


        private readonly InventorySlot[,] _slotGrid;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public CraftGrid(int width, int height)
        {
            width = Math.Max(width, 1);
            height = Math.Max(height, 1);
            _slotGrid = new InventorySlot[width, height];

            for (int i = 0; i < width * height; i++)
                _slotGrid[i % 3, i / 3] = new InventorySlot();
        }
    }
}
