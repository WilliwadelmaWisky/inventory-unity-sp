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
