using System;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICraftingStation
    {
        string Name { get; }

        void ForEach(Action<IRecipe, int> onLoop);
        void Craft(IRecipe recipe, int amount, ICrafter<IRecipe> crafter);
    }
}
