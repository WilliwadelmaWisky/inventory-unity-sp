using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            _canvasGroup.alpha = 1;
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void OnSlotUpdated()
        {
            _canvasGroup.blocksRaycasts = !Slot.IsEmpty;
            IconImage.gameObject.SetActive(!Slot.IsEmpty);
            AmountText.gameObject.SetActive(false);
            if (Slot.IsEmpty)
                return;

            IconImage.sprite = IconRegistry.Current.Get(Slot.Item.ID);
            AmountText.SetText($"x{Slot.Amount}");
            AmountText.gameObject.SetActive(Slot.Amount > 1);
        }
    }
}
