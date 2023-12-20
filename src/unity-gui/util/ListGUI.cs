using System.Collections.Generic;
using UnityEngine;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class ListGUI : MonoBehaviour
    {
        private List<IElementGUI> _elementList;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _elementList = new List<IElementGUI>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="elementGUI"></param>
        public void Add(object data, IElementGUI elementGUI)
        {
            elementGUI.Clear();
            elementGUI.Assign(data);
            (elementGUI as MonoBehaviour).transform.SetParent(transform);
            _elementList.Add(elementGUI);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementGUI"></param>
        /// <returns></returns>
        public IElementGUI Remove(IElementGUI elementGUI)
        {
            int index = _elementList.FindIndex(s => s.Equals(elementGUI));
            return Remove(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IElementGUI Remove(int index)
        {
            if (index < 0 || index >= _elementList.Count)
                return null;

            IElementGUI elementGUI = _elementList[index];
            _elementList.RemoveAt(index);
            return elementGUI;
        }


        /// <summary>
        /// 
        /// </summary>
        public List<IElementGUI> Clear()
        {
            List<IElementGUI> elementList = new List<IElementGUI>(_elementList);
            _elementList.Clear();

            foreach (IElementGUI element in elementList)
                element.Clear();

            return elementList;
        }
    }
}
