namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Event_VendorAccess : Event
    {
        public IVendor Vendor { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="vendor"></param>
        public Event_VendorAccess(object source, IVendor vendor) : base(source, EventType.Default)
        {
            Vendor = vendor;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendor"></param>
        public Event_VendorAccess(IVendor vendor) : this(vendor, vendor) { }
    }
}
