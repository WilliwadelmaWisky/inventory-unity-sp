using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.core.util;

namespace WWWisky.inventory.core.components.controls
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotTicker
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="slot"></param>
        public void Tick(double deltaTime, ISlot slot)
        {
            if (slot.IsEmpty)
                return;

            if (slot.Item is ITickable tickable)
                tickable.Tick(deltaTime);
        }
    }
}
