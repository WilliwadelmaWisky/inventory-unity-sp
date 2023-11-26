using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core.containers
{
    /// <summary>
    /// 
    /// </summary>
    public struct RemoveItemResult
    {
        public static RemoveItemResult Failure { get; } = new RemoveItemResult(false, null, 0);

        public bool Success { get; }
        public IItem Item { get; }
        public int Amount { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        public RemoveItemResult(bool success, IItem item, int amount)
        {
            Success = success;
            Item = item;
            Amount = amount;
        }
    }
}
