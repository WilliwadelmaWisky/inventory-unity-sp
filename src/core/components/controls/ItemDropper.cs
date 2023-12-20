namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemDropper
    {
        private readonly object _user;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="inventory"></param>
        public ItemDropper(object user)
        {
            _user = user;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        public void Drop(ISlot slot)
        {
            if (slot.IsEmpty)
                return;

            slot.Clear();
        }
    }
}
