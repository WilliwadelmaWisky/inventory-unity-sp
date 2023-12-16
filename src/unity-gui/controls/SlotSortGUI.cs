using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.unity.gui.controls;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotSortGUI : MonoBehaviour
    {
        [SerializeField] private ListGUI SlotList;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            
        }


        public IComparer<ISlot> GetComparer() => null;
        public Predicate<ISlot> GetPredicate() => null;
    }
}
