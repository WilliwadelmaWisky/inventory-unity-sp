using UnityEngine;
using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.unity.items
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ItemSO : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IItem Create();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="registry"></param>
        public abstract void RegisterIcon(IconRegistry registry);
    }
}
