using UnityEngine;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.unity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class RecipeSO : ScriptableObject
    {
        [SerializeField] private string ID;
        [SerializeField] private string Name;
        [SerializeField] private Sprite Icon;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IRecipe Create()
        {
            IconRegistry.Current.Register(ID, Icon);
            return OnCreate(ID, Name);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected abstract IRecipe OnCreate(string id, string name);
    }
}
