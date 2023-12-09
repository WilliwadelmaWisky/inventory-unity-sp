using UnityEngine;
using WWWisky.inventory.core.examples;
using WWWisky.inventory.core.items;
using WWWisky.inventory.unity.items;

namespace WWWisky.inventory.unity.examples
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class Item_AppleSO : ItemSO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IItem OnCreate(string id, string name) => new Item_Apple(id, name);
    }
}
