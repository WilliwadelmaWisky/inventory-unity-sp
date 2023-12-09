using System.Collections.Generic;
using UnityEngine;

namespace WWWisky.inventory.unity.items
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class IconRegistry : MonoBehaviour
    {
        [SerializeField] private Sprite Default;

        internal static IconRegistry Current { get; private set; }
        private Dictionary<string, Sprite> _iconDictionary;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            if (Current != null)
            {
                Debug.LogWarning("[Debug] Found duplicate of IconRegistry!!!");
                Destroy(this);
                return;
            }

            Current = this;
            _iconDictionary = new Dictionary<string, Sprite>();
            DontDestroyOnLoad(gameObject);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Sprite Get(string key)
        {
            if (string.IsNullOrEmpty(key) || !_iconDictionary.ContainsKey(key))
                return Default;

            return _iconDictionary[key];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public bool Register(string key, Sprite icon)
        {
            if (string.IsNullOrEmpty(key) || icon == null || _iconDictionary.ContainsKey(key))
                return false;

            _iconDictionary.Add(key, icon);
            return true;
        }
    }
}
