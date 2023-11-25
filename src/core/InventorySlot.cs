using System;
using WWWisky.inventory.core.containers;
using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core
{
	/// <summary>
	/// 
	/// </summary>
	public class InventorySlot : IInventorySlot
	{
		public IItem Item { get; private set; }
		public int Amount { get; private set; }
		
		
		/// <summary>
		/// 
		/// </summary>
		public InventorySlot()
		{
			Item = null;
			Amount = 0;
		}
		
		
		public bool IsEmpty() => Item == null || Amount <= 0;
		public virtual bool IsAcceptable(IItem item) => item != null;
		public virtual int GetStackSize(IItem item) => 1;
		
		
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

			if (IsEmpty())
			{
				Item = item;
				Amount = Math.Min(amount, GetStackSize(item));
				return new AddItemResult(true, Item, amount - Amount);
			}

			if (Item.IsEqual(item) && Amount < GetStackSize(item))
			{
				int addAmount = Math.Min(amount, GetStackSize(item) - Amount);
				Amount += addAmount;
				return new AddItemResult(true, Item, amount - addAmount);
			}

			return AddItemResult.Failure;
		}


		public bool Remove(IItem item, int amount, out int leftOver)
		{
			if (!IsEmpty() && Item.IsEqual(item) && amount > 0)
			{
				int removeAmount = Math.Min(amount, Amount);
				Amount -= removeAmount;
				leftOver = amount - removeAmount;
				
				if (Amount <= 0)
					Item = null;
				
				return true;
			}
			
			leftOver = amount;
			return false;
		}


		public void Clear()
        {

        }
	}
}