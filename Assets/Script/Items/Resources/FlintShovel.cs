using Script.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Items.Resources
{
    public class FlintShovel : Item
    {
        public FlintShovel(string name = "Flint Shovel",
            int id = 2,
            bool canBeStacked = false,
            int maxQuantity = 1) 
        : base(name, id, canBeStacked, maxQuantity)
        {}

        public override object Clone()
        {
            return new FlintShovel();
        }
    }
}
