namespace lab3_inventory_management.Tests;

using Xunit;
using lab3_inventory_management.models;
using lab3_inventory_management.interfaces;


public class ImproveItemsTests
{
    [Fact]
    public void Weapon_Improve_ShouldIncreaseDamage()
    {
        var weapon = new Weapon("Sword", "Legendary sword", 10);
        weapon.Improve();
        Assert.Equal(15, weapon.Damage);
    }

    [Fact]
    public void Armor_Improve_ShouldIncreaseDefense()
    {
        var armor = new Armor("Iron Armor", "Very heavy armor", 50);
        armor.Improve();
        Assert.Equal(55, armor.Defense);
    }
}
