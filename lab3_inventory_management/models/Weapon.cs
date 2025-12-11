namespace lab3_inventory_management.models;
using states; 
using interfaces;
    
public class Weapon: Item, IUpgradeable
{
    public int Damage { get; private set; }
    
    public Weapon(string name, string description, int damage) : base(name, description)
    {
        Damage = damage;
        State = new UnequippedState();
    }
    
    public void Improve()
    {
        Damage += 5;
    }
}

