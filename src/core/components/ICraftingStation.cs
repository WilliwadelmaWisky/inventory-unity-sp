using System.Collections.Generic;
using WWWisky.inventory.core.recipes;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICraftingStation : IEnumerable<IRecipe>
    {
        string Name { get; }

        void Craft(IRecipe recipe, int amount);
        void Access(ICrafter crafter);
    }
}
