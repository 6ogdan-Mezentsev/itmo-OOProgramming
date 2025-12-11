namespace lab3_inventory_management.interfaces;
using models;

public interface IInventory
{
    void Add(Item item);
    void Remove(Item item);
    IReadOnlyList<Item> Items { get; }
}