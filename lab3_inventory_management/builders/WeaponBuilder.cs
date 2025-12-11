namespace lab3_inventory_management.builders;
using models;
using interfaces;

public class WeaponBuilder : IItemBuilder
{
    private string _name;
    private string _description;
    private int _damage;

    public void SetName(string name) => _name = name;
    public void SetDescription(string description) => _description = description;
    public void SetDamage(int damage) => _damage = damage;

    public Item Build()
    {
        return new Weapon(_name, _description, _damage);
    }
}