using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core.components;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingStationGUI : MonoBehaviour
    {
        [SerializeField] private SlotGUI SlotPrefab;
        [SerializeField] private SlotListGUI SlotList;

        private ICraftingStation _craftingStation;
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
        /// <param name="craftingStation"></param>
        public void Assign(ICraftingStation craftingStation)
        {
            _craftingStation = craftingStation;
        }
    }
}
