using WWWisky.inventory.core.components;
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

        private readonly IItem _item;
        private readonly int _amount;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        public ItemRequirement(IItem item, int amount)
        {
            _item = item;
            _amount = amount;

            ID = _item.ID;
            Name = $"{_amount} {item.Name}s";
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
                int neededAmount = _amount;
                IInventory inventory = support.GetInventory();
                for (int i = 0; i < inventory.SlotCount; i++)
                {
                    if (inventory.IsEmpty(i) || !inventory.Get(i).Item.IsEqual(_item))
                        continue;

                    neededAmount -= inventory.Get(i).Amount;
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
                inventory.RemoveItem(_item, _amount);
            }
        }
    }
}
