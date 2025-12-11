namespace lab3_inventory_management.models;
using interfaces;

public class Inventory : IInventory
{
    private readonly List<Item> _items = new();
    public IReadOnlyList<Item> Items => _items;
    
    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
    }
}