using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICrafter<T>
    {
        bool HasResources(T recipe, int amount);
        void UseResources(T recipe, int amount);
        void OnCrafted(ICraftable craftable, int amount);
    }
}
