using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components.sub
{
    /// <summary>
    /// 
    /// </summary>
    public class BurnableSlot : Slot
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool IsAcceptable(IItem item) => item is IBurnable;
    }
}
