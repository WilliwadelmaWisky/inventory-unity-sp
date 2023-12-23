using UnityEngine;
using UnityEngine.UI;
using WWWisky.inventory.core;
using static WWWisky.inventory.unity.gui.InventoryGUI;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(InventoryGUI), typeof(WindowGUI))]
    public class InventoryControllerGUI : MonoBehaviour
    {
        [Header("Optional")]
        [SerializeField] private Button CloseButton;

        protected InventoryGUI InventoryGUI { get; private set; }
        protected WindowGUI WindowGUI { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            InventoryGUI = GetComponent<InventoryGUI>();
            WindowGUI = GetComponent<WindowGUI>();

            CloseButton?.onClick.AddListener(CloseInventoryGUI);
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
            {
                OpenInventoryGUI(storageAccessEvent.Accessor.GetInventory(), (slotGUI, clickButton) =>
                {
                    if (clickButton == UnityEngine.EventSystems.PointerEventData.InputButton.Right)
                    {
                        ItemTransfer itemTransfer = new ItemTransfer();
                        itemTransfer.Transfer(slotGUI.Slot, storageAccessEvent.Storage);
                    }
                });
                return;
            }

            if (e is Event_CraftingStationAccess craftingStationAccessEvent)
            {
                if (craftingStationAccessEvent.Crafter is IItemHolder itemHolder)
                {
                    OpenInventoryGUI(itemHolder.GetInventory(), (slotGUI, clickButton) =>
                    {
                        if (clickButton == UnityEngine.EventSystems.PointerEventData.InputButton.Right)
                        {
                            ItemUser itemUser = new ItemUser(itemHolder);
                            itemUser.Use(slotGUI.Slot);
                        }
                    });
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
        public virtual void OpenInventoryGUI(IInventory inventory, SlotClickDelegate onSlotClicked)
        {
            InventoryGUI.Assign(inventory, onSlotClicked);
            WindowGUI.Show();

            WindowContainerGUI.Current?.Add(WindowGUI);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CloseInventoryGUI()
        {
            WindowGUI.Hide();

            WindowContainerGUI.Current?.Remove(WindowGUI);
        }



        private void StorageMenu(object target, SlotGUI slotGUI, IStorage storage)
        {
            Menu menu = new Menu();

            ItemTransfer itemTransfer = new ItemTransfer();
            menu.Add(new Menu.MenuItem("Transfer [E]", () => itemTransfer.Transfer(slotGUI.Slot, storage)));

            ItemDropper itemDropper = new ItemDropper(target);
            menu.Add(new Menu.MenuItem("Drop [O]", () => itemDropper.Drop(slotGUI.Slot)));

            menu.Add(new Menu.MenuItem("Cancel", () => { }));

            ActionMenuGUI.Current.Show(menu, slotGUI.transform.position);
        }
        private void InventoryMenu(object target, SlotGUI slotGUI)
        {
            Menu menu = new Menu();

            ItemUser itemUser = new ItemUser(target);
            menu.Add(new Menu.MenuItem("Use [E]", () => itemUser.Use(slotGUI.Slot)));

            ItemDropper itemDropper = new ItemDropper(target);
            menu.Add(new Menu.MenuItem("Drop [O]", () => itemDropper.Drop(slotGUI.Slot)));

            menu.Add(new Menu.MenuItem("Cancel", () => { }));

            ActionMenuGUI.Current.Show(menu, slotGUI.transform.position);
        }
    }
}
