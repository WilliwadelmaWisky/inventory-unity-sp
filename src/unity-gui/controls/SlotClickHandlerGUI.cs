using UnityEngine;
using UnityEngine.EventSystems;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotClickHandlerGUI : MonoBehaviour
    {
        private const float MAX_DOUBLE_CLICK_INTERVALL = 0.2f;

        private ClickData _lastClickData;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _lastClickData = ClickData.Empty;   
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotGUI"></param>
        /// <param name="clickButton"></param>
        public void OnSlotClicked(SlotGUI slotGUI, PointerEventData.InputButton clickButton)
        {
            float clickTime = Time.time;
            if (_lastClickData.SlotGUI != null)
            {
                if (_lastClickData.SlotGUI == slotGUI && _lastClickData.ClickButton == clickButton && clickTime <= _lastClickData.ClickTime + MAX_DOUBLE_CLICK_INTERVALL)
                    Debug.Log("Double click!");
            }

            Debug.Log("Click: " + slotGUI.Slot.Item.Name + ", button: " + clickButton);
            _lastClickData = new ClickData(slotGUI, clickButton, clickTime);
        }


        /// <summary>
        /// 
        /// </summary>
        public struct ClickData
        {
            public static ClickData Empty { get; } = new ClickData(null, PointerEventData.InputButton.Left, 0);

            public SlotGUI SlotGUI { get; }
            public PointerEventData.InputButton ClickButton { get; }
            public float ClickTime { get; }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="slotGUI"></param>
            /// <param name="clickButton"></param>
            /// <param name="clickTime"></param>
            public ClickData(SlotGUI slotGUI, PointerEventData.InputButton clickButton, float clickTime)
            {
                SlotGUI = slotGUI;
                ClickButton = clickButton;
                ClickTime = clickTime;
            }
        }
    }
}
