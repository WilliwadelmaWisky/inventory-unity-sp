using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core.components;
using WWWisky.inventory.unity.gui.controls;

namespace WWWisky.inventory.unity.gui.components
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingStationGUI : MonoBehaviour
    {
        [SerializeField] private RecipeGUI RecipePrefab;
        [SerializeField] private ListGUI RecipeList;

        private ICraftingStation _craftingStation;
        private IObjectPool<IElementGUI> _recipePool;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _recipePool = new ObjectPool<IElementGUI>(() => (IElementGUI)RecipePrefab.Clone());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="craftingStation"></param>
        public void Assign(ICraftingStation craftingStation)
        {
            _craftingStation = craftingStation;

            Refresh();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            RecipeList.Clear().ForEach(slotGUI => _recipePool.Release(slotGUI));
            _craftingStation.ForEach((recipe, index) =>
            {
                RecipeGUI recipeGUI = (RecipeGUI)_recipePool.Get();
                RecipeList.Add(recipe, recipeGUI);
                recipeGUI.OnClicked += () => OnRecipeClicked(recipeGUI);
                recipeGUI.transform.SetSiblingIndex(index);
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeGUI"></param>
        private void OnRecipeClicked(RecipeGUI recipeGUI)
        {
            if (recipeGUI == null)
                return;

            Debug.Log($"Click: {recipeGUI.Recipe.Name}");
        }
    }
}
