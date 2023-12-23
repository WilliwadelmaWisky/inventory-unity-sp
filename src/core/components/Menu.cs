using System;
using System.Collections;
using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Menu : IEnumerable<Menu.MenuItem>
    {
        private readonly List<MenuItem> _itemList;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public Menu(params MenuItem[] items)
        {
            _itemList = new List<MenuItem>();
            foreach (MenuItem menuItem in items)
                Add(menuItem);
        }


        public IEnumerator<MenuItem> GetEnumerator() => _itemList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(MenuItem item)
        {
            if (item == null)
                return;

            _itemList.Add(item);
        }


        /// <summary>
        /// 
        /// </summary>
        public class MenuItem
        {
            public string Name { get; }
            private readonly Action _onExecute;


            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <param name="onExecute"></param>
            public MenuItem(string name, Action onExecute)
            {
                Name = name;
                _onExecute = onExecute;
            }


            /// <summary>
            /// 
            /// </summary>
            public void Execute()
            {
                _onExecute();
            }
        }
    }
}
