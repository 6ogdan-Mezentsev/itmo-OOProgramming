using lab4_orders_manage_system.models;

namespace lab4_orders_manage_system.states;


public interface IOrderState
{
    string Name { get; }
    void ChangeStateToNext(Order order);
}
