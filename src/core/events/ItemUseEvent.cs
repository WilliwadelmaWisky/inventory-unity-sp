using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWWisky.inventory.core.events
{
    public class ItemUseEvent
    {
        public static ItemUseEvent Default { get; } = new ItemUseEvent(null, 0);

        public Inventory Inventory { get; }
        public int SlotIndex { get; }


        public ItemUseEvent(Inventory inventory, int slotIndex)
        {
            Inventory = inventory;
            SlotIndex = slotIndex;
        }
    }
}
