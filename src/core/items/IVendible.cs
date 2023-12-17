using System;

namespace WWWisky.inventory.core.items
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVendible : ICloneable
    {
        string ID { get; }
        string Name { get; }
        float Cost { get; }
    }
}
