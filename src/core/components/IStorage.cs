using WWWisky.inventory.core.components;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStorage : IInventory
    {
        string Name { get; }
    }
}
