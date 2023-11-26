using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core.items.types
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Consumable : IItemType
    {
        public string Name { get; } = "Consumable";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IItemType other) => Name.CompareTo(other.Name);
    }
}
