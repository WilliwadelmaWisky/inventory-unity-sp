using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.core.components.controls
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemDropper
    {
        private readonly object _user;
        private readonly IInventory _inventory;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="inventory"></param>
        public ItemDropper(object user, IInventory inventory)
        {
            _user = user;
            _inventory = inventory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void Drop(int index)
        {
            if (_inventory.IsEmpty(index))
                return;

            ISlot slot = _inventory.Get(index);
            slot.Clear();
        }
    }
}
