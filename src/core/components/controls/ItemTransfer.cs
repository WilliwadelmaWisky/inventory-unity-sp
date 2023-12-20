namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemTransfer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Transfer(ISlot slot, IInventory target)
        {
            if (slot.IsEmpty)
                return false;

            AddItemResult result = target.AddItem(slot.Item, slot.Amount);
            if (!result.Success)
                return false;

            slot.Remove(slot.Item, result.Amount);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool Transfer(ISlot a, ISlot b)
        {
            if (a.IsEmpty)
                return false;

            if (b.IsEmpty || a.Item.IsEqual(b.Item))
            {
                AddItemResult result = b.Add(a.Item, a.Amount);
                if (!result.Success)
                    return false;

                a.Remove(a.Item, result.Amount);
                return true;
            }

            if (!a.IsAcceptable(b.Item) || !b.IsAcceptable(a.Item))
                return false;
            if (a.Amount > b.GetStackSize(a.Item) || b.Amount > a.GetStackSize(b.Item))
                return false;

            RemoveItemResult clearResult = b.Clear();
            b.Add(a.Item, a.Amount);
            a.Add(clearResult.Item, clearResult.Amount);
            return true;
        }
    }
}
