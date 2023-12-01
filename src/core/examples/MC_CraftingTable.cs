using WWWisky.inventory.core.components;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.core.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class MC_CraftingTable : CraftingStation
    {
        private const string STATION_ID = "mc_craftingtable";
        private const string STATTION_NAME = "Crafting Table";

        private readonly CraftGrid _craftGrid;


        public MC_CraftingTable() : base(STATION_ID, STATTION_NAME)
        {
            _craftGrid = new CraftGrid(3, 3);
        }
    }
}
