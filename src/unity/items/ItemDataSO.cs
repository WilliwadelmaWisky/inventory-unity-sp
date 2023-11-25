using UnityEngine;

namespace WWWisky.inventory.unity
{
    public class ItemDataSO : ScriptableObject
    {
        [SerializeField] private string ID;
        [SerializeField] private string Name;


        public string GetID() => ID;
        public string GetName() => Name;
    }
}
