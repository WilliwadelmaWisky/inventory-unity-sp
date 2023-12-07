using System;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISlotGUI : ICloneable
    {
        void Clear();
        void Assign(ISlot slot);
    }
}
