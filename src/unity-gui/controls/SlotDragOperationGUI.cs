using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotDragOperationGUI : MonoBehaviour
    {
        public static SlotDragOperationGUI Current { get; private set; }

        public SlotGUI SlotGUI { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            if (Current != null)
            {
                Destroy(this);
                return;
            }

            Current = this;
        }


        public void Create(SlotGUI slotGUI)
        {
            SlotGUI = slotGUI;
        }


        public void Destroy()
        {
            SlotGUI = null;
        }
    }
}
