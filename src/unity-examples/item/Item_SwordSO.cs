using UnityEngine;
using WWWisky.inventory.core;

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


    /// <summary>
    /// 
    /// </summary>
    public class Item_Sword : Item, IUseable, IVendible, ICraftable
    {
        public float Cost { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        public Item_Sword(string id, string name, float cost) : base(id, name, ItemType.Equipment)
        {
            Cost = cost;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Item_Sword(ID, Name, Cost);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Use(ItemUseEvent e)
        {
            throw new System.NotImplementedException();
        }
    }
}
