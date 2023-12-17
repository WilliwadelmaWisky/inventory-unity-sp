using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WWWisky.inventory.core.items;
using WWWisky.inventory.unity.gui.controls;
using WWWisky.inventory.unity.items;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class VendibleGUI : MonoBehaviour, IElementGUI, IPointerClickHandler
    {
        public event Action OnClicked;

        [SerializeField] private Image IconImage;
        [SerializeField] private TextMeshProUGUI NameText;
        [SerializeField] private TextMeshProUGUI CostText;

        public IVendible Vendible { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Assign(object data)
        {
            if (!(data is IVendible vendible))
                return;

            Vendible = vendible;
            IconImage.sprite = IconRegistry.Current.Get(Vendible.ID);
            NameText.SetText(Vendible.Name);
            CostText.SetText($"${Vendible.Cost}");

            gameObject.SetActive(true);
        }


        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            if (Vendible == null)
                return;

            Vendible = null;
            OnClicked = null;
            gameObject.SetActive(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone() => Instantiate(this);


        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke();
        }
    }
}
