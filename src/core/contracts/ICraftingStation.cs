using System;
using System.Collections.Generic;
using System.Text;

namespace WWWisky.inventory.core.contracts
{
    public interface ICraftingStation
    {
        string ID { get; }
        string Name { get; }
        bool IsEqual(ICraftingStation other);
    }
}
