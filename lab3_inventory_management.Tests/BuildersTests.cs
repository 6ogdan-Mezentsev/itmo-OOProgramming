namespace lab3_inventory_management.Tests;
using Xunit;

using lab3_inventory_management.builders;
using lab3_inventory_management.models; 


public class BuildersTests
{
    [Fact]
    public void WeaponBuilder_ShouldBuildWeaponSuccessfully()
    {
        var builder = new WeaponBuilder();
        builder.SetName("Sword");
        builder.SetDescription("Legendary sword");
        builder.SetDamage(10);

        var weapon = (Weapon)builder.Build();

        Assert.Equal("Sword", weapon.Name);
        Assert.Equal("Legendary sword", weapon.Description);
        Assert.Equal(10, weapon.Damage);
    }

    [Fact]
    public void ArmorBuilder_ShouldBuildArmorSuccessfully()
    {
        var builder = new ArmorBuilder();
        builder.SetName("Iron Armor");
        builder.SetDescription("Very heavy armor");
        builder.SetDefense(50);

        var armor = (Armor)builder.Build();

        Assert.Equal("Iron Armor", armor.Name);
        Assert.Equal("Very heavy armor", armor.Description);
        Assert.Equal(50, armor.Defense);
    }
    
    [Fact]
    public void PotionBuilder_ShouldBuildPotionSuccessfully()
    {
        var builder = new PotionBuilder();
        builder.SetName("Health Potion");
        builder.SetDescription("Restores 30 HP");
        builder.SetHealAmount(30);

        var potion = (Potion)builder.Build();

        Assert.Equal("Health Potion", potion.Name);
        Assert.Equal("Restores 30 HP", potion.Description);
        Assert.Equal(30, potion.HealAmount);
    }
    
    [Fact]
    public void QuestItemBuilder_ShouldBuildQuestItemCorrectly()
    {
        var builder = new QuestItemBuilder();
        builder.SetName("Item");
        builder.SetDescription("Description");

        var questItem = (QuestItem)builder.Build();

        Assert.Equal("Item", questItem.Name);
        Assert.Equal("Description", questItem.Description);
    }
}