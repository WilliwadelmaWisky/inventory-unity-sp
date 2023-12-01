using WWWisky.inventory.core.events;

namespace WWWisky.inventory.core.items
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUseable
    {
        bool Use(ItemUseEvent e);
    }
}
