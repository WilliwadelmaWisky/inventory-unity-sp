using System;
using WWWisky.inventory.core.util;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components.sub
{
    /// <summary>
    /// 
    /// </summary>
    public class InventorySlot : IInventorySlot
	{
		public IItem Item { get; private set; }
		public int Amount { get; private set; }
		public bool IsEmpty { get; private set; }
		
		
		/// <summary>
		/// 
		/// </summary>
		public InventorySlot()
		{
			Item = null;
			Amount = 0;
			IsEmpty = true;
		}
		
		
		public virtual bool IsAcceptable(IItem item) => true;
		public virtual int GetStackSize(IItem item)
        {
			if (item is IStackable stackable)
				return stackable.StackSize;

			return 1;
        }
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		public AddItemResult Add(IItem item, int amount)
		{
			if (item == null || amount <= 0 || !IsAcceptable(item))
				return AddItemResult.Failure;

			if (IsEmpty)
			{
				Item = item;
				Amount = Math.Min(amount, GetStackSize(item));
				IsEmpty = false;
				return new AddItemResult(true, Item, Amount);
			}

			if (Item.IsEqual(item) && Amount < GetStackSize(item))
			{
				int addAmount = Math.Min(amount, GetStackSize(item) - Amount);
				Amount += addAmount;
				return new AddItemResult(true, Item, addAmount);
			}

			return AddItemResult.Failure;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		public RemoveItemResult Remove(IItem item, int amount)
		{
			if (IsEmpty || !Item.IsEqual(item))
				return RemoveItemResult.Failure;

			int removeAmount = Math.Min(amount, Amount);
			Amount -= removeAmount;
			RemoveItemResult result = new RemoveItemResult(true, Item, removeAmount);

			if (Amount <= 0)
			{
				Item = null;
				IsEmpty = true;
			}
				
			return result;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public RemoveItemResult Clear()
        {
			return Remove(Item, Amount);
        }
	}
}