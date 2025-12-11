namespace lab3_inventory_management.models;
using states;
using interfaces;

public class Armor : Item, IUpgradeable
{
    public int Defense { get; private set; }
    
    public Armor(string name, string description, int defense) : base(name, description)
    {
        Defense = defense;
        State = new UnequippedState();
    }

    public void Improve()
    {
        Defense += 5;
    }
}