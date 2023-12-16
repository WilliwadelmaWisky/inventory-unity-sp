using System;
using UnityEngine;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class WindowGUI : MonoBehaviour
    {
        protected CanvasGroup CanvasGroup { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();

            Hide();
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Show()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.blocksRaycasts = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Hide()
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.blocksRaycasts = false;
        }
    }
}
