namespace lab4_orders_manage_system.models;

using lab4_orders_manage_system.states;
using lab4_orders_manage_system.strategies;


public class Order
{
    public List<Dish> Dishes { get; } = [];
    public IOrderState State { get; set; } = new NewState();
    public IDeliveryStrategy DeliveryStrategy { get; set; }
    public int DeliveryMinutes { get; set; }
    
    public void AddDish(Dish dish)
    {
        Dishes.Add(dish);
    }
    
    public void NextState()
    {
        State.ChangeStateToNext(this);
    }
    
    public decimal CalculateTotal()
    {
        decimal dishesSum = Dishes.Sum(d => d.Price);
        decimal deliveryCost = DeliveryStrategy.CalculateDeliveryCost(DeliveryMinutes, dishesSum);
        return dishesSum + deliveryCost;
    }
}

