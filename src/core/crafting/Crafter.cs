namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Crafter : ICrafter
    {
        public IInventory Inventory { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        public Crafter(IInventory inventory)
        {
            Inventory = inventory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Craft(IRecipe recipe, int amount)
        {
            if (!CanCraft(recipe, amount))
                return false;

            foreach (IRequirement requirement in recipe)
                requirement.Use(this);

            CraftResult result = recipe.Craft();
            if (!result.Success)
                return false;

            Add(result.Craftable, result.Quantity);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="craftable"></param>
        /// <param name="quantity"></param>
        protected virtual void Add(ICraftable craftable, int quantity)
        {
            if (craftable is IItem item)
                Inventory.AddItem(item, quantity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool CanCraft(IRecipe recipe, int amount)
        {
            foreach (IRequirement requirement in recipe)
            {
                if (!requirement.OK(this))
                    return false;
            }

            return true;
        }
    }
}
