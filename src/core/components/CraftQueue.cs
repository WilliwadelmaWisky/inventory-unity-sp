using System;
using System.Collections.Generic;
using System.Text;
using WWWisky.inventory.core.contracts;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftQueue
    {
        private readonly Queue<IRecipe> _recipeQueue;


        public CraftQueue()
        {
            _recipeQueue = new Queue<IRecipe>();
        }
    }
}
