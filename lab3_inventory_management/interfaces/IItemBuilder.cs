namespace lab3_inventory_management.interfaces;
using models;

public interface IItemBuilder
{
    void SetName(string name);
    void SetDescription(string description);
    Item Build();
}