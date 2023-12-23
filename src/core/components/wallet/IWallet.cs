namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWallet<T>
    {
        int GetValue();
        void Add(T obj);
        void Remove(T obj);
    }
}
