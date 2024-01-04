namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Event : IEvent
    {
        public object Source { get; }
        public EventType Type { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="eventType"></param>
        public Event(object source, EventType eventType)
        {
            Source = source;
            Type = eventType;
        }
    }
}
