namespace lab3_inventory_management.Tests;

using Xunit;

using lab3_inventory_management.states;
using lab3_inventory_management.models; 

public class StatesTests
{
    [Fact]
    public void Potion_Use_ShouldChangeStateToUsed()
    {
        var potion = new Potion("Health Potion", "Restores 30 HP", 30);
        Assert.IsType<UsableState>(potion.State);

        potion.Use();

        Assert.IsType<UsedState>(potion.State);
    }

    [Fact]
    public void Weapon_EquipAndUnequip_ShouldChangeStateCorrectly()
    {
        var weapon = new Weapon("Sword", "Legendary sword", 10);
        Assert.IsType<UnequippedState>(weapon.State);

        weapon.Use();
        Assert.IsType<EquippedState>(weapon.State);

        weapon.Use();
        Assert.IsType<UnequippedState>(weapon.State);
    }
}