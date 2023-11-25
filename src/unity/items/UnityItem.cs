using WWWisky.inventory.core.items;

namespace WWWisky.inventory.unity
{
    public class UnityItem : Item
    {
        private readonly ItemDataSO _itemDataSO;


        public UnityItem(ItemDataSO dataSO) : base(dataSO.GetID(), dataSO.GetName())
        {
            _itemDataSO = dataSO;
        }
    }
}
