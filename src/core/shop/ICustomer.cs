namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomer
    {
        bool CanBuy(IVendible vendible, int amount);
        bool Buy(IVendible vendible, int amount);
    }
}
