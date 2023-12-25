using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionMenuMono : MonoBehaviour
    {
        private const KeyCode USE_KEY = KeyCode.E;
        private const KeyCode DROP_KEY = KeyCode.O;

        public ISlot CurrentSlot { get; private set; }
        public IInventory TransferInventory { get; private set; }

        private ActionMenu _actionMenu;
        private ActionMenuItem _useAction;
        private ActionMenuItem _transferAction;
        private ActionMenuItem _dropAction;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            CurrentSlot = null;
            TransferInventory = null;
            _actionMenu = new ActionMenu();

            ItemUser itemUser = new ItemUser(gameObject);
            _useAction = new ActionMenuItem($"Use [{USE_KEY}]", () => itemUser.Use(CurrentSlot));
            _actionMenu.Add(_useAction);

            ItemTransfer itemTransfer = new ItemTransfer();
            _transferAction = new ActionMenuItem($"Transfer [{USE_KEY}]", () => itemTransfer.Transfer(CurrentSlot, TransferInventory));
            _actionMenu.Add(_transferAction);

            ItemDropper itemDropper = new ItemDropper(gameObject);
            _dropAction = new ActionMenuItem($"Drop [{DROP_KEY}]", () => itemDropper.Drop(CurrentSlot));
            _actionMenu.Add(new ActionMenuItem("Cancel", () => { }));
        }

        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            if (CurrentSlot == null)
                return;

            if (Input.GetKeyDown(USE_KEY))
            {
                ActionMenuItem menuItem = TransferInventory == null ? _useAction : _transferAction;
                menuItem.Execute();
            }

            if (Input.GetKeyDown(DROP_KEY))
                _dropAction.Execute();
        }
        

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            CurrentSlot = null;
            TransferInventory = null;
        }


        public void SetSlot(ISlot slot) => CurrentSlot = slot;
        public void SetTransferInventory(IInventory inventory) => TransferInventory = inventory;
    }
}
