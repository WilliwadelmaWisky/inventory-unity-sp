using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStorage : IInventory
    {
        string Name { get; }

        void Access(IItemHolder itemHolder);
    }
}
