using UnityEngine;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SlotGUI : MonoBehaviour, ISlotGUI
    {
        public ISlot Slot { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        public virtual void Assign(ISlot slot)
        {
            Slot = slot;
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Clear()
        {
            Slot = null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return Instantiate(this);
        }
    }
}
