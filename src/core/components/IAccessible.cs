namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAccessible<T>
    {
        void Access(T accessor);
        void Exit(T accessor);
    }
}
