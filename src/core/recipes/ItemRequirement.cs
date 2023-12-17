using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemRequirement : IRequirement
    {
        public string ID { get; }
        public string Name { get; }
        public IItem Item { get; }
        public int Amount { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        public ItemRequirement(IItem item, int amount)
        {
            Item = item;
            Amount = amount;

            ID = Item.ID;
            Name = $"{Amount} {item.Name}s";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        /// <returns></returns>
        public bool OK(object crafter)
        {
            if (crafter is ISupportItemRequirements support)
            {
                int neededAmount = Amount;
                IInventory inventory = support.GetInventory();
                foreach (ISlot slot in inventory)
                {
                    if (slot.IsEmpty || !slot.Item.IsEqual(Item))
                        continue;

                    neededAmount -= slot.Amount;
                    if (neededAmount <= 0)
                        return true;
                }
            }

            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        public void Use(object crafter)
        {
            if (crafter is ISupportItemRequirements support)
            {
                IInventory inventory = support.GetInventory();
                inventory.RemoveItem(Item, Amount);
            }
        }
    }
}
