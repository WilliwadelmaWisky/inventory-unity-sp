using System;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Wallet : IWallet<int>
    {
        public int Money { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public Wallet()
        {
            Money = 0;
        }


        public int GetValue() => Money;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void Add(int amount)
        {
            if (amount <= 0)
                return;

            Money += Math.Min(amount, int.MaxValue - Money);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void Remove(int amount)
        {
            if (amount <= 0)
                return;

            Money -= Math.Min(Money, amount);
        }
    }
}
