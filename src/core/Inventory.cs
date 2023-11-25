using System;
using System.Collections.Generic;
using WWWisky.inventory.core.containers;
using WWWisky.inventory.core.contracts;
using WWWisky.inventory.core.events;

namespace WWWisky.inventory.core
{
	/// <summary>
	/// 
	/// </summary>
	public class Inventory
	{
		public event Action<IItem, int> OnItemAdded;
		public event Action<IItem, int> OnItemRemoved;
		public event Action<InventorySlot, int> OnSlotUpdated;
		
		private InventorySlot[] _slots;

		public int SlotCount => _slots.Length;
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotCount"></param>
		public Inventory(int slotCount = 30)
		{
			slotCount = Math.Min(1, slotCount);
			_slots = new InventorySlot[slotCount];
			for (int i = 0; i < slotCount; i++)
				Set(i, CreateSlot());
		}
		
		
		public InventorySlot Get(int index) => _slots[index];
		public bool IsEmpty(int index) => Get(index).IsEmpty();
		protected void Set(int index, InventorySlot slot) => _slots[index] = slot;
		protected virtual InventorySlot CreateSlot() => new InventorySlot();


		/// <summary>
		/// 
		/// </summary>
		/// <param name="onLoop"></param>
		public void ForEach(Action<InventorySlot, int> onLoop)
        {
			for (int i = 0; i < SlotCount; i++)
				onLoop(_slots[i], i);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotCount"></param>
		/// <returns></returns>
		protected bool Resize(int slotCount)
        {
			if (slotCount < 0 || slotCount == SlotCount)
				return false;

			InventorySlot[] oldSlots = _slots;
			_slots = new InventorySlot[slotCount];
			for (int i = 0; i < Math.Min(slotCount, oldSlots.Length); i++)
				Set(i, oldSlots[i]);

			for (int i = oldSlots.Length; i < SlotCount; i++)
				Set(i, CreateSlot());

			return true;
        }
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		public AddItemResult AddItem(IItem item, int amount)
		{
			if (item == null || amount <= 0)
				return AddItemResult.Failure;

			int amountToAdd = amount;
			for (int i = 0; i < SlotCount && amountToAdd > 0; i++)
			{
				AddItemResult result = AddItemToIndex(item, amountToAdd, i);
				amountToAdd = result.Amount;

				if (result.Success && amountToAdd >= amount)
					return AddItemResult.Failure;
			}
				
			OnItemAdded?.Invoke(item, amount - amountToAdd);
			return new AddItemResult(true, item, amount - amountToAdd);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public AddItemResult AddItemToIndex(IItem item, int amount, int index)
		{
			if (item == null || amount <= 0)
				return AddItemResult.Failure;

			InventorySlot slot = Get(index);
			AddItemResult result = slot.Add(item, amount);

			if (result.Success)
				OnSlotUpdated?.Invoke(slot, index);

			return result;
		}
		
		
		public bool RemoveItem(IItem item, int amount, out int leftOver)
		{
			if (item != null && amount > 0)
			{
				int removeAmount = amount;
				for (int i = 0; i < SlotCount && removeAmount > 0; i++)
					RemoveItemFromIndex(item, removeAmount, i, out removeAmount);
				
				leftOver = removeAmount;
				OnItemRemoved?.Invoke(item, amount - leftOver);
				return removeAmount < amount;
			}
			
			leftOver = amount;
			return false;
		}
		public bool RemoveItemFromIndex(IItem item, int amount, int index, out int leftOver)
		{
			if (item != null && amount > 0 && index >= 0 && index < SlotCount)
			{
				InventorySlot slot = _slots[index];
				return slot.Remove(item, amount, out leftOver);
			}
			
			leftOver = amount;
			return false;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public bool Use(int index)
        {
			if (IsEmpty(index))
				return false;

			IItem item = Get(index).Item;
			if (item is IUseable useable)
				return useable.Use(ItemUseEvent.Default);

			return false;
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="comparer"></param>
		public void Sort(IComparer<InventorySlot> comparer)
        {
			Array.Sort(_slots, comparer);
        }
	}
}