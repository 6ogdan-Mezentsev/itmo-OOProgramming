namespace lab3_inventory_management.states;
using models; 
    
public class UnequippedState : IItemState
{
    public void Use(Item item)
    {
        item.State = new EquippedState();
    }
}