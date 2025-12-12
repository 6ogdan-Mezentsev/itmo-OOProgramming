namespace lab4_orders_manage_system.states;

using lab4_orders_manage_system.models;


public class CookingState : IOrderState
{
    public string Name => "Cooking order";

    public void ChangeStateToNext(Order order)
    {
        order.State = new DeliveringState();
    }
}
