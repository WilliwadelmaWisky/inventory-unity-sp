using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core.components;
using WWWisky.inventory.unity.gui.controls;

namespace WWWisky.inventory.unity.gui.components
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorGUI : MonoBehaviour
    {
        [SerializeField] private SlotGUI SlotPrefab;
        [SerializeField] private ListGUI SlotList;

        private Vendor _vendor;
        private IObjectPool<SlotGUI> _slotPool;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _slotPool = new ObjectPool<SlotGUI>(() => (SlotGUI)SlotPrefab.Clone());
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
