using WWWisky.inventory.core.items;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.core.components
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
