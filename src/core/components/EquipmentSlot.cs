using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class EquipmentSlot : InventorySlot
    {
        private readonly IEquippableType _equippableType;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="equippableType"></param>
        public EquipmentSlot(IEquippableType equippableType)
        {
            _equippableType = equippableType;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool IsAcceptable(IItem item)
        {
            if (item is IEquippable equippable)
                return equippable.EquippableType.Name.Equals(_equippableType.Name);
            return false;
        }
    }
}
