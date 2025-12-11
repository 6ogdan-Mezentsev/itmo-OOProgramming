namespace lab3_inventory_management.builders;
using models;
using interfaces;

public class PotionBuilder : IItemBuilder
{
    private string _name;
    private string _description;
    private int _healAmount;

    public void SetName(string name) => _name = name;
    public void SetDescription(string description) => _description = description;
    public void SetHealAmount(int healAmount) => _healAmount = healAmount;

    public Item Build()
    {
        return new Potion(_name, _description, _healAmount);
    }
}
