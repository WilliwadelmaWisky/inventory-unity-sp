using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.unity.gui.controls
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class RecipeGUI : MonoBehaviour, IElementGUI
    {
        public event Action OnClicked;

        [SerializeField] private Image IconImage;
        [SerializeField] private TextMeshProUGUI NameText;

        public IRecipe Recipe { get; private set; }

        private Button _button;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Click);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        public void Assign(object data)
        {
            if (!(data is IRecipe recipe))
                return;

            Recipe = recipe;
            IconImage.sprite = IconRegistry.Current.Get(Recipe.ID);
            NameText.SetText(Recipe.Name);
        }


        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            Recipe = null;
            OnClicked = null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return Instantiate(this);
        }


        /// <summary>
        /// 
        /// </summary>
        private void Click()
        {
            OnClicked?.Invoke();
        }
    }
}
