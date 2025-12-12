namespace lab4_orders_manage_system.states;

using lab4_orders_manage_system.models;


public class DeliveringState : IOrderState
{
    public string Name => "Delivering order";

    public void ChangeStateToNext(Order order)
    {
        order.State = new CookingState();
    }
}
