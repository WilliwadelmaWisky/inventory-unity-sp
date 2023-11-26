namespace WWWisky.inventory.core.contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IItem
    {
        string ID { get; }
        string Name { get; }
        IItemType Type { get; }

        bool IsEqual(IItem other);
    }
}
