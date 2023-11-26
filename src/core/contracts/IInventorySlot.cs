using WWWisky.inventory.core.containers;

namespace WWWisky.inventory.core.contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInventorySlot
    {
        IItem Item { get; }
        int Amount { get; }
        bool IsEmpty { get; }

        AddItemResult Add(IItem item, int amount);
        RemoveItemResult Remove(IItem item, int amount);
        RemoveItemResult Clear();
    }
}
