namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class EquipmentSlot : Slot
    {
        private readonly EquippableType _equippableType;
        private readonly ISlot[] _auqmentSlots;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="equippableType"></param>
        public EquipmentSlot(EquippableType equippableType)
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
                return equippable.EquippableType == _equippableType;
            return false;
        }
    }
}
