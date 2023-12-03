using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.util
{
    /// <summary>
    /// 
    /// </summary>
    public struct CraftResult
    {
        public static CraftResult Failure { get; } = new CraftResult(false, null, 0);

        public bool Success { get; }
        public ICraftable Craftable { get; }
        public int Quantity { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="craftable"></param>
        /// <param name="quantity"></param>
        public CraftResult(bool success, ICraftable craftable, int quantity)
        {
            Success = success;
            Craftable = craftable;
            Quantity = quantity;
        }
    }
}
