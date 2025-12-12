namespace lab4_orders_manage_system.states;

using lab4_orders_manage_system.models;


public class CompletedState : IOrderState
{
    public string Name => "Completed order";

    public void ChangeStateToNext(Order order) {}
}