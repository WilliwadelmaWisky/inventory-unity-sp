using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core.components;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorGUI : MonoBehaviour
    {
        [SerializeField] private SlotGUI SlotPrefab;
        [SerializeField] private SlotListGUI SlotList;

        private Vendor _vendor;
        private IObjectPool<ISlotGUI> _slotPool;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _slotPool = new ObjectPool<ISlotGUI>(() => (ISlotGUI)SlotPrefab.Clone());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendor"></param>
        public void Assign(Vendor vendor)
        {
            _vendor = vendor;
        }
    }
}
