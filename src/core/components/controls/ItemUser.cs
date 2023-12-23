namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemUser
    {
		private readonly object _user;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="user"></param>
		public ItemUser(object user)
        {
			_user = user;
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public bool Use(ISlot slot)
		{
			if (slot == null || slot.IsEmpty)
                return false;

            if (Use(slot.Item))
            {
                IUseable useable = (IUseable)slot.Item;
                if (useable.IsExpendedOnUse)
                    slot.Remove(slot.Item, 1);

                return true;
            }

			return false;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Use(IItem item)
        {
            if (item == null || !(item is IUseable useable))
                return false;

            return useable.Use(ItemUseEvent.Default);
        }
	}
}
