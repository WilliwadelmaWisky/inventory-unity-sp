namespace WWWisky.inventory.core.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRequirement
    {
        string ID { get; }
        string Name { get; }

        bool OK(object crafter);
        void Use(object crafter);
    }
}
