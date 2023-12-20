using UnityEngine;
using UnityEngine.UI;
using WWWisky.inventory.core;
using WWWisky.inventory.core.components;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(CraftingStationGUI), typeof(WindowGUI))]
    public class CraftingStationControllerGUI : MonoBehaviour
    {
        [Header("Optional")]
        [SerializeField] private Button CloseButton;

        protected CraftingStationGUI CraftingStationGUI { get; private set; }
        protected WindowGUI WindowGUI { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            CraftingStationGUI = GetComponent<CraftingStationGUI>();
            WindowGUI = GetComponent<WindowGUI>();

            CloseButton?.onClick.AddListener(CloseCraftingStationGUI);
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
            if (e is Event_CraftingStationAccess craftingStationAccessEvent)
                OpenCraftingStationGUI(craftingStationAccessEvent.CraftingStation);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="craftingStation"></param>
        public virtual void OpenCraftingStationGUI(ICraftingStation craftingStation)
        {
            CraftingStationGUI.Assign(craftingStation);
            WindowGUI.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CloseCraftingStationGUI()
        {
            WindowGUI.Hide();
        }
    }
}
