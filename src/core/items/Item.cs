using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core.items
{
    /// <summary>
    /// 
    /// </summary>
    public class Item : IItem
	{
        public string ID { get; }
		public string Name { get; }
        public IItemType Type { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public Item(string id, string name, IItemType type)
		{
            ID = id;
			Name = name;
            Type = type;
		}
		

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool IsEqual(IItem other) => ID.Equals(other.ID);
    }
}