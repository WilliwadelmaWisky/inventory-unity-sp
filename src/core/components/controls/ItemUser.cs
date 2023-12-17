using WWWisky.inventory.core.util;
using WWWisky.inventory.core.items;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.core.components.controls
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

			if (slot.Item is IUseable useable)
				return useable.Use(ItemUseEvent.Default);

			return false;
		}
	}
}
