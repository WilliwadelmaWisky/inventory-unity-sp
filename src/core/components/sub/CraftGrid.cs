using System;

namespace WWWisky.inventory.core.components.sub
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftGrid
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public delegate void GridCallback(ISlot slot, int x, int y);

        public int Width { get; }
        public int Height { get; }
        private readonly ISlot[,] _slotGrid;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public CraftGrid(int width, int height)
        {
            Width = Math.Max(width, 1);
            Height = Math.Max(height, 1);
            _slotGrid = new ISlot[Width, Height];

            for (int i = 0; i < Width * Height; i++)
                _slotGrid[i % 3, i / 3] = CreateSlot();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual ISlot CreateSlot() => new Slot();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onLoop"></param>
        public void ForEach(GridCallback onLoop)
        {
            for (int x = 0; x < _slotGrid.GetLength(0); x++)
            {
                for (int y = 0; y < _slotGrid.GetLength(1); y++)
                    onLoop(_slotGrid[x, y], x, y);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public ISlot Get(int x, int y) => _slotGrid[x, y];
    }
}
