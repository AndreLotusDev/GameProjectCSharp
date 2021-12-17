using System;
using System.Collections.Generic;
using System.Linq;
using Script.Items;

namespace Script.Player
{
    public class PlayerInventory
    {
        public List<ItemInfoAndQuantity> ItemsHolder = new List<ItemInfoAndQuantity>();
        public int MaxInventorySize { get; private set; }

        public void SetInventorySize(int sizeOfTheInventory)
        {
            MaxInventorySize = sizeOfTheInventory;
        }

        public void AddItem(Item genericItem)
        {
            if (MaxInventorySize == 0)
                throw new Exception("Inventory size it's empty");
            
            if (ItsFullTheInventory()) //Do droping animation
                return;
            
            var existThisItem = CheckIfExistItem(genericItem);

            if(genericItem.CanBeStacked is false)
            {
                InsertANewItem(genericItem);
                return;
            }
            
            if(existThisItem)
            {
                WhereToAdd(genericItem);
                return;
            }

            InsertANewItem(genericItem);

        }
        
        public bool ItsFullTheInventory()
        {
            var sizeOfInventoryBeingUsed = ItemsHolder.Count;
            
            if (sizeOfInventoryBeingUsed == MaxInventorySize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private bool CheckIfExistItem(Item genericItemToCheck)
        {
            var alreadyExistThisItem = ItemsHolder
                .Any(item => item.Item.Id == genericItemToCheck.Id);

            return alreadyExistThisItem;
        }

        private void WhereToAdd(Item genericItemToAdd)
        {
            var lastItemWithThisId = ItemsHolder
                .FindLast(itemQuantityInfo => itemQuantityInfo.Item.Id == genericItemToAdd.Id);
            var positionToTryToAdd = ItemsHolder.IndexOf(lastItemWithThisId);
            
            TryAttInventoryItemInfoQuantityOrAdd(genericItemToAdd, positionToTryToAdd);
        }

        private void TryAttInventoryItemInfoQuantityOrAdd(Item genericItemToAdd, int positionToAdd)
        {
            var itemAndQuantity = ItemsHolder[positionToAdd];

            itemAndQuantity.TryToAttQuantityItems(1, this);
        }

        /// <summary>
        /// Should not be used, only be handlers classes, use addItem instead
        /// </summary>
        /// <param name="genericItemToAdd"></param>
        public void InsertANewItem(Item genericItemToAdd)
        {
            var itemToInsertAsNew = new ItemInfoAndQuantity(genericItemToAdd, 1);
            
            ItemsHolder.Add(itemToInsertAsNew);
        }
        
    }
}