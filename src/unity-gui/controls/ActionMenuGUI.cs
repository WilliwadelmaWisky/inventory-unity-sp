using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class ActionMenuGUI : MonoBehaviour
    {
        public static ActionMenuGUI Current { get; private set; }

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
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        public void Show(Menu menu, Vector3 position)
        {
            if (menu == null)
                return;

            menu.ForEach((menuItem, index) =>
            {
                Debug.Log("ActionMenuGUI - create menuitem not implemented: " + menuItem.Name);
            });

            _rectTransform.position = position;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Hide()
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0;
        }
    }
}
