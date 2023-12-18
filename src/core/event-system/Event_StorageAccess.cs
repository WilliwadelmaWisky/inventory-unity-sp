namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Event_StorageAccess : Event
    {
        public IStorage Storage { get; }
        public IItemHolder Accessor { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="storage"></param>
        /// <param name="accessor"></param>
        public Event_StorageAccess(object source, IStorage storage, IItemHolder accessor) : base(source, EventType.Default)
        {
            Storage = storage;
            Accessor = accessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="accessor"></param>
        public Event_StorageAccess(IStorage storage, IItemHolder accessor) : this(storage, storage, accessor) { }
    }
}
