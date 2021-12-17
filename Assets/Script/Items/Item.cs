using System;
using UnityEditorInternal.Profiling.Memory.Experimental;

namespace Script.Items
{
    public abstract class Item : ICloneable
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public bool CanBeStacked { get ; private set; }

        public int MaxQuantity { get; private set; }
        
        protected Item(string name, int id, bool canBeStacked, int maxQuantity)
        {
            Name = name;
            Id = id;
            CanBeStacked = canBeStacked;
            MaxQuantity = maxQuantity;
        }

        public virtual object Clone()
        {
            return this;
        }
    }
}