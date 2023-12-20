using UnityEngine;
using UnityEngine.UI;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotSelectorGUI : MonoBehaviour
    {
        [Header("Optional")]
        [SerializeField] private Button UseButton;
        [SerializeField] private Button DropButton;
        [SerializeField] private Button TransferButton;

        private SlotGUI _slotGUI;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        public void Select(SlotGUI slotGUI)
        {
            if (_slotGUI == slotGUI)
                return;

            _slotGUI = slotGUI;
        }
    }
}
