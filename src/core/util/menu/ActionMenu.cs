using System.Collections;
using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionMenu : IActionMenu
    {
        private readonly List<IMenuItem> _itemList;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public ActionMenu(params ActionMenuItem[] items)
        {
            _itemList = new List<IMenuItem>();
            foreach (ActionMenuItem menuItem in items)
                Add(menuItem);
        }


        public IEnumerator<IMenuItem> GetEnumerator() => _itemList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(ActionMenuItem item)
        {
            if (item == null)
                return;

            _itemList.Add(item);
        }
    }
}
