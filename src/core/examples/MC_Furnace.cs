using WWWisky.inventory.core.components;

namespace WWWisky.inventory.core.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class MC_Furnace : CraftingStation
    {
        private const string STATION_ID = "mc_furnace";
        private const string STATTION_NAME = "Furnace";


        public MC_Furnace() : base(STATION_ID, STATTION_NAME)
        {

        }
    }
}
