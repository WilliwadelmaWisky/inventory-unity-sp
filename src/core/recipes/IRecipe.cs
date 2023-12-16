using System;
using System.Collections.Generic;
using WWWisky.inventory.core.util;

namespace WWWisky.inventory.core.recipes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRecipe : IEnumerable<IRequirement>
    {
        string ID { get; }
        string Name { get; }

        void Add(IRequirement requirement);
        void ForEach(Action<IRequirement, int> onLoop);
        CraftResult Craft();
    }
}
