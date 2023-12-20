namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICrafter
    {
        bool HasResources(IRecipe recipe, int amount);
        void UseResources(IRecipe recipe, int amount);
        void OnCrafted(ICraftable craftable, int amount);
    }
}
