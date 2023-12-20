using System;
using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.recipes;
using WWWisky.inventory.unity.gui.controls;

namespace WWWisky.inventory.unity.gui
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
        public void Refresh() => Refresh(recipe => true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        public void Refresh(Predicate<IRecipe> match)
        {
            RecipeList.Clear().ForEach(slotGUI => _recipePool.Release(slotGUI));
            _craftingStation.ForEach((recipe, index) =>
            {
                if (match(recipe))
                    AddRecipe(recipe, index);
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="index"></param>
        private void AddRecipe(IRecipe recipe, int index)
        {
            RecipeGUI recipeGUI = (RecipeGUI)_recipePool.Get();
            RecipeList.Add(recipe, recipeGUI);
            recipeGUI.OnClicked += () => OnRecipeClicked(recipeGUI);
            recipeGUI.transform.SetSiblingIndex(index);
        }


        /// <summary>
        /// 
        /// </summary>
        public void Sort()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeGUI"></param>
        private void OnRecipeClicked(RecipeGUI recipeGUI)
        {
            if (recipeGUI == null)
                return;

            Debug.Log($"Craft: {recipeGUI.Recipe.Name}");
            _craftingStation.Craft(recipeGUI.Recipe, 1);
        }
    }
}
