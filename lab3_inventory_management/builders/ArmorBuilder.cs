namespace lab3_inventory_management.builders;
using models;
using interfaces;

public class ArmorBuilder : IItemBuilder
{
    private string _name;
    private string _description;
    private int _defense;

    public void SetName(string name) => _name = name;
    public void SetDescription(string description) => _description = description;
    public void SetDefense(int defense) => _defense = defense;

    public Item Build()
    {
        return new Armor(_name, _description, _defense);
    }
}