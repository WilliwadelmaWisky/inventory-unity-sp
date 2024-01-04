using System;
using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class TieredCraftingStation : CraftingStation
    {
        public int TierIndex { get; private set; }

        private readonly List<Tier> _tierList;

        public Tier CurrentTier => _tierList[TierIndex];


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public TieredCraftingStation(string name) : base(name)
        {
            _tierList = new List<Tier>();
            TierIndex = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tier"></param>
        public void AddTier(Tier tier) => _tierList.Add(tier);


        /// <summary>
        /// 
        /// </summary>
        public void Upgrade()
        {
            if (TierIndex >= _tierList.Count - 1)
                return;

            TierIndex++;
            foreach (IRecipe recipe in CurrentTier)
                Add(recipe);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tierIndex"></param>
        public void Upgrade(int tierIndex)
        {
            int upgradeCount = Math.Min(tierIndex - TierIndex, _tierList.Count - 1 - TierIndex);
            for (int i = 0; i < upgradeCount; i++)
                Upgrade();
        }
    }
}
