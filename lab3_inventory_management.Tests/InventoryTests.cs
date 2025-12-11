namespace lab3_inventory_management.Tests;
using Xunit;

using lab3_inventory_management.models; 


public class InventoryTests
{
    [Fact]
    public void AddItem_ShouldAddItemToInventory()
    {
        var inventory = new Inventory();
        var sword = new Weapon("Sword", "Legendary sword", 10);

        inventory.Add(sword);

        Assert.Single(inventory.Items);
        Assert.Contains(sword, inventory.Items);
        Assert.Equal("Sword", inventory.Items[0].Name);
        Assert.Equal("Legendary sword", inventory.Items[0].Description);
    }
    
    [Fact]
    public void RemoveItem_ShouldRemoveItemFromInventory()
    {
        var inventory = new Inventory();
        var sword = new Weapon("Sword", "Legendary sword", 10);

        inventory.Add(sword);
        inventory.Remove(sword);

        Assert.Empty(inventory.Items);
    }
}