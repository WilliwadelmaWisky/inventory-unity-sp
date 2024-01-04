using System;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVendible : ICloneable
    {
        string ID { get; }
        string Name { get; }
        int Cost { get; }
    }
}
