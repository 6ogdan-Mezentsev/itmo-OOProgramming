namespace lab3_inventory_management.Tests;
using Xunit;

using lab3_inventory_management.builders;
using lab3_inventory_management.models;


public class BuildersAndInventoryTests
{
    [Fact]
    public void AddBuiltWeaponToInventory_ShouldWork()
    {
        var inventory = new Inventory();
        var builder = new WeaponBuilder();
        builder.SetName("Sword");
        builder.SetDescription("Legendary sword");
        builder.SetDamage(10);
        
        var weapon = (Weapon)builder.Build();

        inventory.Add(weapon);

        Assert.Contains(weapon, inventory.Items);
        Assert.Single(inventory.Items);
        Assert.Equal("Sword", inventory.Items[0].Name);
        Assert.Equal("Legendary sword", inventory.Items[0].Description);
    }
}