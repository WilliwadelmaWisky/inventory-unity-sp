namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICrafter<T>
    {
        bool CanCraft(T item, int amount);
        void Craft(T item, int amount);
    }
}
