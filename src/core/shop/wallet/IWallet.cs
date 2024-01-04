namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWallet
    {
        long Value { get; }

        void Add(uint value);
        void Remove(uint value);
    }
}
