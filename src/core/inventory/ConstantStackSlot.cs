using System;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstantStackSlot : Slot
    {
        public int StackSize { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stackSize"></param>
        public ConstantStackSlot(int stackSize = 100) : base()
        {
            StackSize = Math.Max(1, stackSize);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override int GetStackSize(IItem item) => (item is IStackable) ? StackSize : 1;
    }
}
