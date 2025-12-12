namespace lab4_orders_manage_system.strategies;


public interface IDeliveryStrategy
{
    decimal CalculateDeliveryCost(int deliveryMinutes, decimal baseCost);
}