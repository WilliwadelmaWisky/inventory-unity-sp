using UnityEngine;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowContainerGUI : MonoBehaviour
    {
        public static WindowContainerGUI Current { get; private set; }

        private Canvas _canvas;


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
            _canvas = GetComponentInParent<Canvas>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowGUI"></param>
        public void Add(WindowGUI windowGUI)
        {
            windowGUI.transform.SetParent(transform);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowGUI"></param>
        public void Remove(WindowGUI windowGUI)
        {
            windowGUI.transform.SetParent(_canvas.transform);
        }
    }
}
