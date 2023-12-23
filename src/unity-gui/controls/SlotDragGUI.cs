using UnityEngine;
using UnityEngine.EventSystems;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(SlotGUI))]
    public class SlotDragGUI : MonoBehaviour, IDraggable
    {
        [SerializeField] private PointerEventData.InputButton DragButton = PointerEventData.InputButton.Left;

        private RectTransform _rectTransform;
        private SlotGUI _slotGUI;
        private bool _isDragging;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
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

            SlotDragOperationGUI.Current.Create(_slotGUI);
            Sprite icon = IconRegistry.Current.Get(_slotGUI.Slot.Item.ID);
            SlotDragVisualGUI.Current.Show(transform.position, _rectTransform.sizeDelta, icon);
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

            SlotDragOperationGUI.Current.Destroy();
            SlotDragVisualGUI.Current.Hide();
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
            SlotDragVisualGUI.Current.Move(eventData.delta);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (SlotDragOperationGUI.Current.SlotGUI == null || SlotDragOperationGUI.Current.SlotGUI == _slotGUI)
                return;

            Debug.Log("OnDrop");

            ItemTransfer itemTransfer = new ItemTransfer();
            itemTransfer.Transfer(SlotDragOperationGUI.Current.SlotGUI.Slot, _slotGUI.Slot);
        }
    }
}
