using WWWisky.inventory.core.events;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components.controls
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemUser
    {
		private readonly object _user;
		private readonly IInventory _inventory;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="user"></param>
		/// <param name="inventory"></param>
		public ItemUser(object user, IInventory inventory)
        {
			_user = user;
			_inventory = inventory;
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public bool Use(int index)
		{
			if (_inventory.IsEmpty(index))
				return false;

			IItem item = _inventory.Get(index).Item;
			if (item is IUseable useable)
				return useable.Use(ItemUseEvent.Default);

			return false;
		}
	}
}
