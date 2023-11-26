using WWWisky.inventory.core.contracts;
using WWWisky.inventory.core.events;
using WWWisky.inventory.core.items.types;

namespace WWWisky.inventory.core.items
{
    /// <summary>
    /// 
    /// </summary>
    public class Item_Apple : Item, IStackable, IUseable
    {
        public int StackSize { get; } = 100;


        public Item_Apple(string id, string name) : base(id, name, new Consumable())
        {

        }


        public bool Use(ItemUseEvent e)
        {
            return false;
        }
    }
}
