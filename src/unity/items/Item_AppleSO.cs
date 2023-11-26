using UnityEngine;
using WWWisky.inventory.core.contracts;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.unity.items
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu]
    public class Item_AppleSO : ItemSO
    {
        [SerializeField] private string ID;
        [SerializeField] private string Name;
        [SerializeField] private Sprite Icon;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IItem Create() => new Item_Apple(ID, Name);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="registry"></param>
        public override void RegisterIcon(IconRegistry registry) => registry.Register(ID, Icon);
    }
}
