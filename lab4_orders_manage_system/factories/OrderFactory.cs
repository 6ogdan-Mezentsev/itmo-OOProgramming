namespace lab4_orders_manage_system.factories;

using lab4_orders_manage_system.builders;
using lab4_orders_manage_system.strategies;
using lab4_orders_manage_system.decorators;

public static class OrderFactory
{
    public static OrderBuilder CreateStandardOrder()
    {
        return new OrderBuilder().UseDeliveryStrategy(new StandardDeliveryStrategy());
    }
    
    public static OrderBuilder CreateFastDeliveryOrder()
    {
        var standardDeliveryStrategy = new StandardDeliveryStrategy();
        var fastDeliveryStrategy = new FastDeliveryCostDecorator(standardDeliveryStrategy);
        
        return new OrderBuilder().UseDeliveryStrategy(standardDeliveryStrategy);
    }
}
