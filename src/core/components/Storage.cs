using WWWisky.inventory.core.components;
using WWWisky.inventory.core.components.sub;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Storage : Inventory, IStorage
    {
        private const int STACK_SIZE = 10000;

        public string Name { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="slotCount"></param>
        public Storage(string name, int slotCount = 30) : base(slotCount)
        {
            Name = name;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override ISlot CreateSlot() => new ConstantStackSlot(STACK_SIZE);
    }
}
