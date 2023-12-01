using WWWisky.inventory.core.containers;

namespace WWWisky.inventory.core.components.controls
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemTransfer
    {
        private readonly IInventory _inventory;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        public ItemTransfer(IInventory inventory)
        {
            _inventory = inventory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Transfer(int index, IInventory target)
        {
            if (_inventory.IsEmpty(index))
                return false;

            IInventorySlot slot = _inventory.Get(index);
            AddItemResult result = target.AddItem(slot.Item, slot.Amount);

            if (!result.Success)
                return false;

            _inventory.RemoveItem(slot.Item, result.Amount, index);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="target"></param>
        /// <param name="targetIndex"></param>
        /// <returns></returns>
        public bool Transfer(int index, IInventory target, int targetIndex)
        {
            if (_inventory.IsEmpty(index))
                return false;

            IInventorySlot slot = _inventory.Get(index);
            if (target.IsEmpty(targetIndex))
            {
                AddItemResult result = target.AddItem(slot.Item, slot.Amount, index);
                if (!result.Success)
                    return false;

                _inventory.RemoveItem(slot.Item, result.Amount);
                return true;
            }

            IInventorySlot targetSlot = target.Get(targetIndex);
            if (!slot.IsAcceptable(targetSlot.Item) || !targetSlot.IsAcceptable(slot.Item))
                return false;
            if (slot.Amount > targetSlot.GetStackSize(slot.Item) || targetSlot.Amount > slot.GetStackSize(targetSlot.Item))
                return false;

            RemoveItemResult clearResult = targetSlot.Clear();
            target.AddItem(slot.Item, slot.Amount, targetIndex);
            _inventory.AddItem(clearResult.Item, clearResult.Amount, index);
            return true;
        }
    }
}
