namespace lab4_orders_manage_system.builders;

using lab4_orders_manage_system.models;
using lab4_orders_manage_system.strategies;

public class OrderBuilder
{
    private readonly List<Dish> _dishes = [];
    private IDeliveryStrategy _deliveryStrategy;
    private int _deliveryMinutes;

    public OrderBuilder AddDish(Dish dish)
    {
        _dishes.Add(dish);
        return this;
    }
    
    public OrderBuilder UseDeliveryStrategy(IDeliveryStrategy strategy)
    {
        _deliveryStrategy = strategy;
        return this;    
    }
    
    public OrderBuilder SetDeliveryTime(int minutes)
    {
        _deliveryMinutes = minutes;
        return this;
    }
    
    public Order Build()
    {
        var order = new Order
        {
            DeliveryStrategy = _deliveryStrategy,
            DeliveryMinutes = _deliveryMinutes
        };

        foreach (var dish in _dishes)
            order.AddDish(dish);

        return order;
    }
}