namespace WWWisky.inventory.core
{
    interface ISerializable
    {
        string Serialize();
        void Deserialize(string s);
    }
}
