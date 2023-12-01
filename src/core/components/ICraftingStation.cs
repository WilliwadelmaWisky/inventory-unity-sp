namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICraftingStation
    {
        string ID { get; }
        string Name { get; }

        bool IsEqual(ICraftingStation other);
    }
}
