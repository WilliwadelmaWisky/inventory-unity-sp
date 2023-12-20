namespace WWWisky.inventory.core
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
