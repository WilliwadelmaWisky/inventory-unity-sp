using UnityEngine;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.unity.gui.controls
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SlotGUI : MonoBehaviour, IElementGUI
    {
        public ISlot Slot { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        public virtual void Assign(object data)
        {
            if (!(data is ISlot slot))
                return;

            Slot = slot;
            Slot.OnUpdated += OnSlotUpdated;
            OnSlotUpdated();
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Clear()
        {
            if (Slot == null)
                return;

            Slot.OnUpdated -= OnSlotUpdated;
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


        /// <summary>
        /// 
        /// </summary>
        protected abstract void OnSlotUpdated();
    }
}
