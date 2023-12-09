using System.Collections.Generic;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class Equipment
    {
        private readonly List<EquipmentSlot> _slots;


        /// <summary>
        /// 
        /// </summary>
        public Equipment()
        {
            _slots = new List<EquipmentSlot>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        public void AddSlot(EquipmentSlot slot) => _slots.Add(slot);
    }
}
