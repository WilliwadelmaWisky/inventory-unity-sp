using UnityEngine;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemPickupMono : MonoBehaviour
    {
        [SerializeField] private ItemSO Item;
        [SerializeField] private int Amount;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldPosition"></param>
        /// <param name="itemSO"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public ItemPickupMono Spawn(Vector3 worldPosition, ItemSO itemSO, int amount)
        {
            ItemPickupMono pickup = Instantiate(this, worldPosition, Quaternion.identity);
            pickup.Item = itemSO;
            pickup.Amount = amount;

            return pickup;
        }
    }
}
