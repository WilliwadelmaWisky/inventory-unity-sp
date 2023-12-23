using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.examples
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class Item_AppleSO : ItemSO
    {
        [SerializeField] private float Cost;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IItem OnCreate(string id, string name)
        {
            return new Item_Apple(id, name, Cost);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class Item_Apple : Item, IStackable, IUseable, ICraftable, IVendible
    {
        public int StackSize { get; } = 5;
        public bool IsExpendedOnUse { get; } = true;
        public float Cost { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        public Item_Apple(string id, string name, float cost) : base(id, name, ItemType.Consumable)
        {
            Cost = cost;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Item_Apple(ID, Name, Cost);
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
