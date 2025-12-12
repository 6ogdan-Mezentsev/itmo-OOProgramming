namespace lab4_orders_manage_system.strategies;


public class FastDeliveryStrategy : IDeliveryStrategy
{
    private const decimal PricePerMinute = 1.5m;

    public decimal CalculateDeliveryCost(int deliveryMinutes, decimal baseCost)
    {
        return deliveryMinutes * PricePerMinute;
    }
}
