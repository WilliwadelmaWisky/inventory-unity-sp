using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingTableMono : CraftingStationMono
    {
        private const int SIZE = 3;

        private CraftGrid _craftGrid;


        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            _craftGrid = new CraftGrid(SIZE, SIZE);
        }
    }
}
