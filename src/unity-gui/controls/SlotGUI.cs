using UnityEngine;
using UnityEngine.EventSystems;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SlotGUI : MonoBehaviour, IElementGUI, IPointerClickHandler
    {
        public delegate void ClickDelegate(PointerEventData.InputButton clickButton);
        public event ClickDelegate OnClicked;

        public ISlot Slot { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        public virtual void Assign(object data)
        {
            if (!(data is ISlot slot))
                return;

            Slot = slot;
            Slot.OnUpdated += OnSlotUpdated;
            OnSlotUpdated();

            gameObject.SetActive(true);
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Clear()
        {
            if (Slot == null)
                return;

            Slot.OnUpdated -= OnSlotUpdated;
            Slot = null;
            OnClicked = null;

            gameObject.SetActive(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return Instantiate(this);
        }


        /// <summary>
        /// 
        /// </summary>
        protected abstract void OnSlotUpdated();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (Slot == null)
                return;

            OnClicked?.Invoke(eventData.button);
        }
    }
}
