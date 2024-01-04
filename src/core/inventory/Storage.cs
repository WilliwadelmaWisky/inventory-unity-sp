namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Storage : Inventory, IStorage
    {
        private const int STACK_SIZE = 10000;

        public string Name { get; }
        public IItemHolder CurrentAccessor { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="slotCount"></param>
        public Storage(string name, int slotCount = 30) : base(slotCount)
        {
            Name = name;
            CurrentAccessor = null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override ISlot CreateSlot() => new ConstantStackSlot(STACK_SIZE);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessor"></param>
        public void Access(IItemHolder accessor)
        {
            CurrentAccessor = accessor;

            Event_StorageAccess e = new Event_StorageAccess(this, CurrentAccessor);
            EventSystem.Current.Broadcast(e);
        }
    }
}
