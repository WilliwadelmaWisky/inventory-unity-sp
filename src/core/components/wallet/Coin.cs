using System;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public struct Coin : IComparable<Coin>
    {
        public static Coin BRONZE { get; } = new Coin(1);
        public static Coin SILVER { get; } = new Coin(10);
        public static Coin GOLD { get; } = new Coin(100);
        public static Coin PLATINUM { get; } = new Coin(1000);

        public int Value { get; }


        /// <summary>
        /// 
        /// </summary>
        private Coin(int value) => Value = value;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Coin other) => Value.CompareTo(other.Value);
    }
}
