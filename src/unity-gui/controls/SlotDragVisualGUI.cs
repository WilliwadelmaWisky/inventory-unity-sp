using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class SlotDragVisualGUI : MonoBehaviour
    {
        [SerializeField] private Image IconImage;

        public static SlotDragVisualGUI Current { get; private set; }

        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            if (Current != null)
            {
                Destroy(this);
                return;
            }

            Current = this;
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.blocksRaycasts = false;
            Hide();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        public void Show(Vector3 position, Vector2 size, Sprite icon)
        {
            _rectTransform.position = position;
            _rectTransform.sizeDelta = size;

            IconImage.sprite = icon;
            _canvasGroup.alpha = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Hide()
        {
            _canvasGroup.alpha = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="delta"></param>
        public void Move(Vector3 delta)
        {
            _rectTransform.position += delta;
        }
    }
}
