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
        [SerializeField] private GameObject ButtonPrefab;

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
        /// <param name="actionMenu"></param>
        public void Show(ActionMenu actionMenu, Vector3 position)
        {
            if (actionMenu == null)
                return;

            actionMenu.ForEach((menuItem, index) =>
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
