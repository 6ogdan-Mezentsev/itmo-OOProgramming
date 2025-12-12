namespace lab4_orders_manage_system;

using lab4_orders_manage_system.builders;
using lab4_orders_manage_system.decorators;
using lab4_orders_manage_system.models;
using lab4_orders_manage_system.strategies;
using lab4_orders_manage_system.factories;


public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Создание заказа ===");
        
        var pizza = new Dish("Паста", 450m);
        var cola = new Dish("Пицца", 700m);
        
        // создаем заказ с быстрой доставкой через фабрику
        // var orderBuilder = OrderFactory.CreateFastDeliveryOrder();
        
        var standard = new StandardDeliveryStrategy();
        
        var fastDelivery = new FastDeliveryCostDecorator(standard);
        
        var order = new OrderBuilder()
            .AddDish(pizza)
            .AddDish(cola)
            .SetDeliveryTime(30)
            .UseDeliveryStrategy(fastDelivery) 
            // .UseDeliveryStrategy(standard)
            .Build();
        
        var totalPrice = order.CalculateTotal();
        
        Console.WriteLine("Заказ создан!");
        Console.WriteLine($"Блюд: {order.Dishes.Count}");
        Console.WriteLine($"Статус: {order.State.GetType().Name}");
        Console.WriteLine($"Итоговая стоимость: {totalPrice} руб.");
    }
}
