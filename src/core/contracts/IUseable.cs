using WWWisky.inventory.core.events;

namespace WWWisky.inventory.core.contracts
{
    public interface IUseable
    {
        bool Use(ItemUseEvent e);
    }
}
