using System;
using System.Collections;
using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Inventory : IInventory
	{
		public event Action OnResized;

		private ISlot[] _slots;

		public int SlotCount => _slots.Length;
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotCount"></param>
		public Inventory(int slotCount = 30)
		{
			slotCount = Math.Max(1, slotCount);
			_slots = new ISlot[slotCount];
			for (int i = 0; i < slotCount; i++)
				Set(i, CreateSlot());
		}


        public IEnumerator<ISlot> GetEnumerator() => ((IEnumerable<ISlot>)_slots).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public ISlot Get(int index) => _slots[index];
		public bool IsEmpty(int index) => Get(index).IsEmpty;
		protected void Set(int index, ISlot slot) => _slots[index] = slot;
		protected virtual ISlot CreateSlot() => new Slot();


		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotCount"></param>
		/// <returns></returns>
		public bool Resize(int slotCount)
        {
			if (slotCount < 0 || slotCount == SlotCount)
				return false;

			ISlot[] oldSlots = _slots;
			_slots = new ISlot[slotCount];
			for (int i = 0; i < Math.Min(slotCount, oldSlots.Length); i++)
				Set(i, oldSlots[i]);

			for (int i = oldSlots.Length; i < SlotCount; i++)
				Set(i, CreateSlot());

			OnResized?.Invoke();
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
            for (int i = 0; i < SlotCount; i++)
            {
                ISlot slot = Get(i);
                if (slot.IsEmpty || !slot.Item.IsEqual(item) || slot.Amount >= slot.GetStackSize(item))
                    continue;

                AddItemResult result = AddItem(item, amountToAdd, i);
                amountToAdd -= result.Amount;
            }

			for (int i = 0; i < SlotCount && amountToAdd > 0; i++)
			{
				AddItemResult result = AddItem(item, amountToAdd, i);
				amountToAdd -= result.Amount;
			}
			
			return new AddItemResult(amountToAdd < amount, item, amount - amountToAdd);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public AddItemResult AddItem(IItem item, int amount, int index)
		{
			if (item == null || amount <= 0)
				return AddItemResult.Failure;

			ISlot slot = Get(index);
			AddItemResult result = slot.Add(item, amount);
			return result;
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		public RemoveItemResult RemoveItem(IItem item, int amount)
		{
			if (item == null || amount <= 0)
				return RemoveItemResult.Failure;

			int amountToRemove = amount;
			for (int i = 0; i < SlotCount && amountToRemove > 0; i++)
            {
			 	RemoveItemResult result = RemoveItem(item, amountToRemove, i);
				amountToRemove -= result.Amount;
			}
				
			return new RemoveItemResult(amountToRemove < amount, item, amount - amountToRemove);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public RemoveItemResult RemoveItem(IItem item, int amount, int index)
		{
			if (item == null || amount <= 0)
				return RemoveItemResult.Failure;

			ISlot slot = Get(index);
			RemoveItemResult result = slot.Remove(item, amount);
			return result;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="comparer"></param>
		public void Sort(IComparer<ISlot> comparer)
        {
            if (comparer == null)
                return;

			Array.Sort(_slots, comparer);
        }
    }
}