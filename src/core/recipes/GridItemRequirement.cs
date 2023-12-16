using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class GridItemRequirement : IRequirement
    {
        public string ID { get; } = "grid_req";
        public string Name { get; } = "Grid Requirement";

        private ItemRequirement[,] _requirementGrid;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public GridItemRequirement(ItemRequirement[,] requirementGrid)
        {
            _requirementGrid = requirementGrid;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        /// <returns></returns>
        public bool OK(object crafter)
        {
            if (!(crafter is ISupportGridItemRequirements support))
                return false;

            CraftGrid craftGrid = support.GetGrid();
            if (craftGrid.Width != _requirementGrid.GetLength(0) || craftGrid.Height != _requirementGrid.GetLength(1))
                return false;

            bool isOK = true;
            craftGrid.ForEach((slot, x, y) =>
            {
                if (slot.IsEmpty || !slot.Item.IsEqual(_requirementGrid[x, y].Item) || slot.Amount < _requirementGrid[x, y].Amount)
                {
                    isOK = false;
                    return;
                }
            });

            return isOK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        public void Use(object crafter)
        {
            throw new NotImplementedException();
        }
    }
}
