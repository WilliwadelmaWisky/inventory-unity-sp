namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class EventSystem
    {
        public static EventSystem Current { get; } = new EventSystem();

        public delegate void EventReceiveDelegate(IEvent e);
        private event EventReceiveDelegate OnEventReceived;


        /// <summary>
        /// 
        /// </summary>
        public EventSystem()
        {
            OnEventReceived = null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void Broadcast(IEvent e)
        {
            if (e == null)
                return;

            OnEventReceived?.Invoke(e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onReceived"></param>
        public void AddListener(EventReceiveDelegate onReceived)
        {
            if (onReceived == null)
                return;

            OnEventReceived += onReceived;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onReceived"></param>
        public void RemoveListener(EventReceiveDelegate onReceived)
        {
            if (onReceived == null)
                return;

            OnEventReceived -= onReceived;
        }
    }
}
