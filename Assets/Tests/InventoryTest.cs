using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Script.Items.Resources;
using NUnit.Framework;
using Script.Items.Resources;
using Script.Player;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTest
{
    private PlayerInventory inventory = new PlayerInventory();
    
    [SetUp]
    public void Init()
    {
        inventory.SetInventorySize(10);
    }

    [Test]
    public void Should_Not_Allow_To_Have_Items_Non_Stackable_Two_Times_In_Same_Slot()
    {
        //Arrange
        FlintShovel flintShovel = new FlintShovel();
        const int ITERATE_TEN_TIMES_TO_FULL_THE_INVENTARY = 10;
        const int INVENTORY_IN_FULL_SIZE = 10;

        //Act
        for (int i = 0; i <= ITERATE_TEN_TIMES_TO_FULL_THE_INVENTARY; i++)
        {
            inventory.AddItem(flintShovel);
        }

        //Assert
        Assert.AreEqual(INVENTORY_IN_FULL_SIZE,inventory.ItemsHolder.Count);
    }

    [Test]
    public void Check_If_Breaks_The_Game_When_Inventory_Size_Is_Zero()
    {
        //Arrange
        FlintShovel flintShovel = new FlintShovel();
        const int NON_CONFIGURATED = 0;
        inventory.SetInventorySize(NON_CONFIGURATED);
        
        //Act/Assert
        Assert.Throws<Exception>(() => inventory.AddItem(flintShovel));
    }

    [Test]
    public void Add_Two_Items_Non_Stackable_With_One_Stackable_Check_The_Quantity()
    {
        //Arange 
        FlintShovel flintShovel = new FlintShovel();
        Flint flint = new Flint();
        const int EXPECTED_SIZE_OF_INVENTORY = 3;

        //Act
        inventory.SetInventorySize(10);
        inventory.AddItem(flintShovel);
        inventory.AddItem(flint);
        inventory.AddItem(flint);
        inventory.AddItem(flintShovel);

        //Assert
        Assert.AreEqual(EXPECTED_SIZE_OF_INVENTORY, inventory.ItemsHolder.Count);
    }
    
    [Test]
    public void Check_If_Items_Stackables_Keep_Being_stackable()
    {
        //Arange 
        FlintShovel flintShovel = new FlintShovel();
        Flint flint = new Flint();
        const int EXPECTED_SIZE_OF_INVENTORY = 3;
        const int SHOULD_HAVE_TWO_FLINTS = 2;

        //Act
        inventory.SetInventorySize(10);
        inventory.AddItem(flintShovel);
        inventory.AddItem(flint);
        inventory.AddItem(flint);
        inventory.AddItem(flintShovel);

        //Assert
        var quantityOfFlint =
            inventory.ItemsHolder.FirstOrDefault(itemPlusInfo => itemPlusInfo.Item.Id == flint.Id);
        
        Assert.AreEqual(SHOULD_HAVE_TWO_FLINTS, quantityOfFlint.Quantity);
    }

    [Test]
    public void Check_If_They_Add_In_A_New_Slot_After_Fulling_A_Max_Stack()
    {
        //Arrange
        Flint flint = new Flint();
        const int NUMBER_OF_TIMES_TO_ITERATE_AS_THE_MAX_SIZE_STACK = 33;
        const int NUMBER_OF_SLOTS_BEING_CONSUMED = 2;
        inventory.SetInventorySize(10);

        //Act
        for (int i = 0; i <= NUMBER_OF_TIMES_TO_ITERATE_AS_THE_MAX_SIZE_STACK; i++)
        {
            inventory.AddItem(flint);
        }

        //Assert
        var numberOfSlotsWithFlint =
            inventory.ItemsHolder.Where(itemPlusInfo => itemPlusInfo.Item.Id == flint.Id).Count();

        Assert.AreEqual(NUMBER_OF_SLOTS_BEING_CONSUMED, numberOfSlotsWithFlint);
    }
    

}
