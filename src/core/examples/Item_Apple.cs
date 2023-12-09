using WWWisky.inventory.core.util;
using WWWisky.inventory.core.items.types;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class Item_Apple : Item, IStackable, IUseable, ICraftable
    {
        public int StackSize { get; } = 5;


        public Item_Apple(string id, string name) : base(id, name, new Consumable())
        {

        }


        public bool Use(ItemUseEvent e)
        {
            return false;
        }


        public object Clone()
        {
            return new Item_Apple(ID, Name);
        }
    }
}
