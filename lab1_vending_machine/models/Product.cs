namespace lab1_vending_machine.models;

public class Product(string name, int price, int quantity)
{
    public string Name { get; set; } = name;
    public int Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
    
    public void ReduceQuantity(int amount = 1)
    {
        if (Quantity >= amount)
            Quantity -= amount;
    }
    
    public void IncreaseQuantity(int amount = 1)
    {
        Quantity += amount;
    }
}