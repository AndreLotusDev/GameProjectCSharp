using Script.Player;
using UnityEditor;

namespace Script.Items
{
    public class ItemInfoAndQuantity
    {
        public Item Item { get; private set; }
        public int Quantity { get; private set; }

        public ItemInfoAndQuantity(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public void SetItem(Item item)
        {
            Item = item;
        }

        public void TryToAttQuantityItems(int quantityToAdd, PlayerInventory inventory)
        {
            var shouldPlace = ShouldStackInAnotherPlaceOfTheInventory(quantityToAdd);
            if (shouldPlace)
            {
                var itemClonedToBeANewOne = Item.Clone();
                inventory.InsertANewItem(Item);
            }

            if (shouldPlace is false)
            {
                AttQuantity(quantityToAdd);
            }

        }

        private bool ShouldStackInAnotherPlaceOfTheInventory(int quantityToAdd)
        {
            var quantityTemp = Quantity;
            var quantityToAtt = quantityTemp += quantityToAdd;
            if (Item.CanBeStacked && Item.MaxQuantity <= quantityToAtt)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AttQuantity(int quantityToAdd)
        {
            Quantity += quantityToAdd;
        }
        
        
    }
}