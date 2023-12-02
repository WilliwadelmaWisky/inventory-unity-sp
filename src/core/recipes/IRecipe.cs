using System;
using WWWisky.inventory.core.containers;

namespace WWWisky.inventory.core.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRecipe
    {
        string ID { get; }
        string Name { get; }

        void Add(IRequirement requirement);
        void ForEach(Action<IRequirement, int> onLoop);
        CraftResult Craft();
    }
}
