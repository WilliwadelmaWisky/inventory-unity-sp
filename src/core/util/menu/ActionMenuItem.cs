using System;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionMenuItem : IMenuItem
    {
        public string Name { get; }
        private readonly Action _onExecute;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="onExecute"></param>
        public ActionMenuItem(string name, Action onExecute)
        {
            Name = name;
            _onExecute = onExecute;
        }


        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            _onExecute();
        }
    }
}
