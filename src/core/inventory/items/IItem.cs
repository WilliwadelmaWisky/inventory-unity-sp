namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IItem
    {
        string ID { get; }
        string Name { get; }
        ItemType Type { get; }

        bool IsEqual(IItem other);
    }
}
