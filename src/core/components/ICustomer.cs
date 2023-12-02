namespace WWWisky.inventory.core.components
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomer<T>
    {
        bool CanBuy(T item, int amount);
        void Buy(T item, int amount);
        void Sell(T item, int amount);
    }
}
