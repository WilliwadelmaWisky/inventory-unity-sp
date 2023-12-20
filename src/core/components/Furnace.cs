namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Furnace
    {
        private Inventory _fuelInventory;
        private Inventory _inputInventory;
        private Inventory _outputInventory;


        public Furnace()
        {
            _fuelInventory = new Inventory(1);
            _inputInventory = new Inventory(10);
            _outputInventory = new Inventory(10);
        }
    }
}
