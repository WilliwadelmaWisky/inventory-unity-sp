using System.Collections.Generic;
using UnityEngine;

namespace WWWisky.inventory.unity.items
{
    /// <summary>
    /// 
    /// </summary>
    public class IconRegistry
    {
        private readonly Dictionary<string, Sprite> _iconDictionary;


        /// <summary>
        /// 
        /// </summary>
        public IconRegistry()
        {
            _iconDictionary = new Dictionary<string, Sprite>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sprite Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !_iconDictionary.ContainsKey(id))
                return null;

            return _iconDictionary[id];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public bool Register(string id, Sprite icon)
        {
            if (string.IsNullOrEmpty(id) || icon == null || _iconDictionary.ContainsKey(id))
                return false;

            _iconDictionary.Add(id, icon);
            return true;
        }
    }
}
