namespace lab3_inventory_management.states;
using models;

public class UsableState : IItemState
{
    public void Use(Item item)
    {
        item.State = new UsedState();
    }
}