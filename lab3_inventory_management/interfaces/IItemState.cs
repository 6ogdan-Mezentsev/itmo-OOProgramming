namespace lab3_inventory_management.states;
using models;

public interface IItemState
{ 
    void Use(Item item);
}