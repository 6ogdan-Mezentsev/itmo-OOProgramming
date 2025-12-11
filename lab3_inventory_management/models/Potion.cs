namespace lab3_inventory_management.models;

public class Potion(string name, string description, int healAmount) : Item(name, description)
{
    public int HealAmount {get; } =  healAmount;
}