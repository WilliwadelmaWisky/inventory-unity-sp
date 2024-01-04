using System;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Wallet : IWallet
    {
        public long Value { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Wallet(uint value = 0)
        {
            Value = value;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Add(uint value) => Value += Math.Min(value, long.MaxValue - Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Remove(uint value) => Value -= Math.Min(value, Value);
    }
}
