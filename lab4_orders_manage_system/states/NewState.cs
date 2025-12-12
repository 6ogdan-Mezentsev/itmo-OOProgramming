namespace lab4_orders_manage_system.states;

using lab4_orders_manage_system.models;


public class NewState : IOrderState
{
    public string Name => "New Order";

    public void ChangeStateToNext(Order order)
    {
        order.State = new DeliveringState();
    }
}
