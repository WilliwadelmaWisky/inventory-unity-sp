using WWWisky.inventory.core.items;
using WWWisky.inventory.core.items.types;

namespace WWWisky.inventory.core.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class Item_Sword : Item
    {
        public Item_Sword(string id, string name) : base(id, name, new Equipment())
        {

        }
    }
}
