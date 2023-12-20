using UnityEngine;
using UnityEngine.UI;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(StorageGUI), typeof(WindowGUI))]
    public class StorageControllerGUI : MonoBehaviour
    {
        [Header("Optional")]
        [SerializeField] private Button CloseButton;

        protected StorageGUI StorageGUI { get; private set; }
        protected WindowGUI WindowGUI { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            StorageGUI = GetComponent<StorageGUI>();
            WindowGUI = GetComponent<WindowGUI>();

            CloseButton?.onClick.AddListener(CloseStorageGUI);
            EventSystem.Current.AddListener(OnEventReceived);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDestroy()
        {
            EventSystem.Current.RemoveListener(OnEventReceived);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEventReceived(IEvent e)
        {
            if (e is Event_StorageAccess storageAccessEvent)
                OpenStorageGUI(storageAccessEvent.Storage);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        public virtual void OpenStorageGUI(IStorage storage)
        {
            StorageGUI.Assign(storage);
            WindowGUI.Show();

            WindowContainerGUI.Current?.Add(WindowGUI);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CloseStorageGUI()
        {
            WindowGUI.Hide();

            WindowContainerGUI.Current?.Remove(WindowGUI);
        }
    }
}
