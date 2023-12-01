using System;
using System.Collections.Generic;
using System.Text;
using WWWisky.inventory.core.containers;

namespace WWWisky.inventory.core.contracts
{
    public interface IRecipe
    {
        string ID { get; }
        string Name { get; }
        CraftResult Craft();
    }
}
