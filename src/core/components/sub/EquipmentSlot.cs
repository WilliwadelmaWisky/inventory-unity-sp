using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components.sub
{
    /// <summary>
    /// 
    /// </summary>
    public class EquipmentSlot : Slot
    {
        private readonly IEquippableType _equippableType;
        private readonly ISlot[] _auqmentSlots;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="equippableType"></param>
        public EquipmentSlot(IEquippableType equippableType)
        {
            _equippableType = equippableType;
            _auqmentSlots = new ISlot[0];
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
