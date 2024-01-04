using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISortable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparer"></param>
        void Sort(IComparer<T> comparer);
    }
}
