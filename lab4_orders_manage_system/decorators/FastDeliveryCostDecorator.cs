namespace lab4_orders_manage_system.decorators;

using lab4_orders_manage_system.strategies;

public class FastDeliveryCostDecorator(IDeliveryStrategy innerStrategy) : IDeliveryStrategy
{
    readonly IDeliveryStrategy _innerStrategy =  innerStrategy;
    public decimal CalculateDeliveryCost(int deliveryMinutes, decimal baseCost)
    {
        var original = _innerStrategy.CalculateDeliveryCost(deliveryMinutes, baseCost);
        return original * 1.2m;
    }
}
