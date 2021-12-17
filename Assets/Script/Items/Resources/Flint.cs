namespace Script.Items.Resources
{
    public class Flint : Item
    {
        public Flint(string name = "Flint", 
            int id = 1, 
            bool canBeStacked = true, 
            int maxQuantity = 32) 
            : base(name, id, canBeStacked, maxQuantity)
        { }

        public override object Clone()
        {
            return new Flint();
        }
    }
}