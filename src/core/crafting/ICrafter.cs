namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICrafter
    {
        IInventory Inventory { get; }

        bool CanCraft(IRecipe recipe, int amount);
        bool Craft(IRecipe recipe, int amount);
    }
}
