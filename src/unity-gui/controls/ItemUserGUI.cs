using UnityEngine;
using WWWisky.inventory.core.components.controls;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemUserGUI : MonoBehaviour
    {
        private ItemUser _itemUser;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            
        }


        public void Assign(ItemUser itemUser)
        {
            _itemUser = itemUser;
        }
    }
}
