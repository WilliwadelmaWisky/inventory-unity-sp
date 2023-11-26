using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core.items.types
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Equipment : IItemType
    {
        public string Name { get; } = "Equipment";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IItemType other) => Name.CompareTo(other.Name);
    }
}
