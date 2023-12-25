using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(SlotGUI))]
    public class SlotActionGUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private SlotGUI _slotGUI;
        private Action _onSelect;
        private Action _onDeselect;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _slotGUI = GetComponent<SlotGUI>();
        }


        public void SetOnSelect(Action onSelect) => _onSelect = onSelect;
        public void SetOnDeselect(Action onDeselect) => _onDeselect = onDeselect;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_slotGUI == null || _slotGUI.Slot.IsEmpty)
                return;

            Debug.Log("Click");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            _onSelect?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            _onDeselect?.Invoke();
        }
    }
}
