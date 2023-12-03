namespace WWWisky.inventory.core.util
{
    /// <summary>
    /// 
    /// </summary>
    public struct Tuple<T>
    {
        public T Value { get; }
        public int Amount { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="amount"></param>
        public Tuple(T value, int amount)
        {
            Value = value;
            Amount = amount;
        }
    }
}
