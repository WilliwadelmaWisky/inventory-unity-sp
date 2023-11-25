using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core.containers
{
    /// <summary>
    /// 
    /// </summary>
    public struct AddItemResult
    {
        public static AddItemResult Failure { get; } = new AddItemResult(false, null, 0);

        public bool Success { get; }
        public IItem Item { get; }
        public int Amount { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        public AddItemResult(bool success, IItem item, int amount)
        {
            Success = success;
            Item = item;
            Amount = amount;
        }
    }
}
