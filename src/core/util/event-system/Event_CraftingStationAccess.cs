namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Event_CraftingStationAccess : Event
    {
        public ICraftingStation CraftingStation { get; }
        public ICrafter Crafter { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="craftingStation"></param>
        /// <param name="crafter"></param>
        public Event_CraftingStationAccess(object source, ICraftingStation craftingStation, ICrafter crafter) : base(source, EventType.Default)
        {
            CraftingStation = craftingStation;
            Crafter = crafter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="craftingStation"></param>
        /// <param name="crafter"></param>
        public Event_CraftingStationAccess(ICraftingStation craftingStation, ICrafter crafter) : this(craftingStation, craftingStation, crafter) { }
    }
}
