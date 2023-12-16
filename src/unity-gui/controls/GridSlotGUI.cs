using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WWWisky.inventory.unity.items;

namespace WWWisky.inventory.unity.gui.controls
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class GridSlotGUI : SlotGUI
    {
        [SerializeField] private Image IconImage;
        [SerializeField] private TextMeshProUGUI AmountText;

        private CanvasGroup _canvasGroup;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void OnSlotUpdated()
        {
            _canvasGroup.blocksRaycasts = !Slot.IsEmpty;
            _canvasGroup.alpha = Slot.IsEmpty ? 0 : 1;
            if (Slot.IsEmpty)
                return;

            IconImage.sprite = IconRegistry.Current.Get(Slot.Item.ID);
            AmountText.SetText($"x{Slot.Amount}");
            AmountText.gameObject.SetActive(Slot.Amount > 1);
        }
    }
}
