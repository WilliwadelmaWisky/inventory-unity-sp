﻿using UnityEngine;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.examples
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingTableMono : MonoBehaviour, ICrafter
    {
        private const int SIZE = 3;

        private CraftingStation _craftingStation;
        private CraftGrid _craftGrid;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _craftingStation = new CraftingStation("Crafting Table");
            _craftGrid = new CraftGrid(SIZE, SIZE);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool HasResources(IRecipe recipe, int amount)
        {
            foreach (IRequirement requirement in recipe)
            {
                if (!requirement.OK(this))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        public void UseResources(IRecipe recipe, int amount)
        {
            foreach (IRequirement requirement in recipe)
                requirement.Use(this);
        }

        public void OnCrafted(ICraftable craftable, int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
