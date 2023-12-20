using System;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public interface IElementGUI : ICloneable
    {
        void Assign(object data);
        void Clear();
    }
}
