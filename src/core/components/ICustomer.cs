﻿using WWWisky.inventory.core.items;

namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomer
    {
        bool CanBuy(IVendible vendible, int amount);
        void Buy(IVendible vendible, int amount);
        void Sell(IVendible vendible, int amount);
    }
}
