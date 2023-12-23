namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUseable
    {
        bool IsExpendedOnUse { get; }
        bool Use(ItemUseEvent e);
    }
}
