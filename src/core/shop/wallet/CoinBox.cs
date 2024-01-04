using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class CoinBox
    {
        private readonly Dictionary<Coin, int> _coinDictionary;


        /// <summary>
        /// 
        /// </summary>
        public CoinBox()
        {
            _coinDictionary = new Dictionary<Coin, int>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float Value()
        {
            int totalValue = 0;
            _coinDictionary.Keys.ForEach(coin => totalValue += coin.Value);
            return totalValue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="coin"></param>
        public void Add(Coin coin)
        {
            if (coin.Value <= 0)
                return;

            if (!_coinDictionary.ContainsKey(coin))
                _coinDictionary.Add(coin, 0);
            _coinDictionary[coin]++;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="coin"></param>
        public void Remove(Coin coin)
        {
            if (!_coinDictionary.ContainsKey(coin))
                return;

            _coinDictionary[coin]--;
        }
    }
}
