namespace WWWisky.inventory.core.items
{
    public class Item : IItem
	{
        public string ID { get; }
		public string Name { get; }


        public Item(string id, string name)
		{
            ID = id;
			Name = name;
		}
		

        public virtual bool IsEqual(IItem other) => ID.Equals(other.ID);
    }
}