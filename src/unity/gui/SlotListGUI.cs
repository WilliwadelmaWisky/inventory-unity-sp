using System.Collections.Generic;
using UnityEngine;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotListGUI : MonoBehaviour
    {
        private List<ISlotGUI> _slotList;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _slotList = new List<ISlotGUI>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="slotGUI"></param>
        public void Add(ISlot slot, ISlotGUI slotGUI)
        {
            slotGUI.Clear();
            slotGUI.Assign(slot);
            _slotList.Add(slotGUI);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        /// <returns></returns>
        public ISlotGUI Remove(ISlotGUI slotGUI)
        {
            int index = _slotList.FindIndex(s => s.Equals(slotGUI));
            return Remove(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ISlotGUI Remove(int index)
        {
            if (index < 0 || index >= _slotList.Count)
                return null;

            ISlotGUI slotGUI = _slotList[index];
            _slotList.RemoveAt(index);
            return slotGUI;
        }


        /// <summary>
        /// 
        /// </summary>
        public List<ISlotGUI> Clear()
        {
            List<ISlotGUI> slotGUIList = new List<ISlotGUI>(_slotList);
            _slotList.Clear();
            return slotGUIList;
        }
    }
}
