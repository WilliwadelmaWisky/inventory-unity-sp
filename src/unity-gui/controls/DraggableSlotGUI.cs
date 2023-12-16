using UnityEngine;
using UnityEngine.EventSystems;
using WWWisky.inventory.unity.gui.controls;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(SlotGUI))]
    public class DraggableSlotGUI : MonoBehaviour, IDraggable
    {
        [SerializeField] private PointerEventData.InputButton DragButton = PointerEventData.InputButton.Left;

        private SlotGUI _slotGUI;
        private bool _isDragging;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _slotGUI = GetComponent<SlotGUI>();
            _isDragging = false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_slotGUI.Slot.IsEmpty || eventData.button != DragButton)
                return;

            _isDragging = true;
            Debug.Log("OnBeginDrag");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!_isDragging)
                return;

            _isDragging = false;
            Debug.Log("OnEndDrag");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            if (!_isDragging)
                return;

            Debug.Log("OnDrag");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
        }
    }
}
