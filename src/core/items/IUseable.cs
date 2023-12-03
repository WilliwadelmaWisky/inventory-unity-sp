using WWWisky.inventory.core.util;

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
