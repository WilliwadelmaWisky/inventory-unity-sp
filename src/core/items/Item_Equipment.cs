using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWWisky.inventory.core.events;

namespace WWWisky.inventory.core.items
{
    public class Item_Equipment : Item, IUseable
    {



        public Item_Equipment(string id, string name) : base(id, name)
        {

        }


        public bool Use(ItemUseEvent e)
        {
            return false;
        }
    }
}
