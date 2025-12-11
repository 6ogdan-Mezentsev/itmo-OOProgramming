namespace lab3_inventory_management.models;
using states;

public abstract class Item
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public IItemState State { get; set; } = new UsableState();

    protected Item(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Use()
    {
        State.Use(this);
    }
}