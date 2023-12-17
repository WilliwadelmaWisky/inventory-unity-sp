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
    public class Item_SwordSO : ItemSO
    {
        [SerializeField] private float Cost;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override IItem OnCreate(string id, string name)
        {
            return new Item_Sword(id, name, Cost);
        }
    }
}
