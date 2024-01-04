using System;
using System.Collections.Generic;

namespace WWWisky.inventory.core
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
