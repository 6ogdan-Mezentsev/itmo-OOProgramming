namespace lab3_inventory_management.builders;
using models;
using interfaces;

public class QuestItemBuilder : IItemBuilder
{
    private string _name;
    private string _description;

    public void SetName(string name) => _name = name;
    public void SetDescription(string description) => _description = description;

    public Item Build()
    {
        return new QuestItem(_name, _description);
    }
}