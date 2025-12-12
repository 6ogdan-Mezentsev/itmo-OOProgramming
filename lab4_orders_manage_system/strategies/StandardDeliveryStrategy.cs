namespace lab4_orders_manage_system.strategies;


public class StandardDeliveryStrategy : IDeliveryStrategy
{
    private const decimal PricePerMinute = 1m;

    public decimal CalculateDeliveryCost(int deliveryMinutes, decimal baseCost)
    {
        return deliveryMinutes * PricePerMinute;
    }
}
