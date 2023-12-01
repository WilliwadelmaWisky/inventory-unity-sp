using WWWisky.inventory.core.components;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class MC_Inventory : Inventory
    {
        protected override IInventorySlot CreateSlot() => new Slot();


        /// <summary>
        /// 
        /// </summary>
        public class Slot : InventorySlot
        {
            public override bool IsAcceptable(IItem item) => true;
            public override int GetStackSize(IItem item) => (item is IStackable) ? 64 : 1;
        }
    }
}
