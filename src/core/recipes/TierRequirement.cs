namespace WWWisky.inventory.core.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public class TierRequirement : IRequirement
    {
        public string ID { get; }
        public string Name { get; }

        private readonly int _tier;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tier"></param>
        public TierRequirement(string id, int tier)
        {
            ID = id;
            _tier = tier;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        /// <returns></returns>
        public bool OK(object crafter)
        {
            if (crafter is ISupportTierRequirements support)
                return support.Tier >= _tier;

            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="crafter"></param>
        public void Use(object crafter)
        {
            
        }
    }
}
