namespace lab1_vending_machine.vending_machine;

using lab1_vending_machine.models;

using System.Text.Json;

public class VendingMachine
{
    private List<Product> _products = new();
    private int _machineBalance = 0;
    private string _filePath = "/Users/6ogdanmezentsev/Desktop/ITMO learn/2 курс/labs_prog/lab1_vending_machine/lab1_vending_machine/models/vending_machine_data.json";
    
    public int GetProductCount()
    {
        return _products.Count; 
    }
    
    public Product? GetProductByIndex(int index)
    {
        if (index < 0 || index >= _products.Count)
            return null;
        return _products[index];
    }
    
    public void ShowProducts()
    {
        Console.WriteLine("=== Список товаров ===");
        
        if (_products.Count == 0)
        {
            Console.WriteLine("Пока нет товаров.");
            return;
        }
        
        for (int i = 0; i < _products.Count; i++)
        {
            var product = _products[i];
            Console.WriteLine($"{i + 1}. {product.Name} - {product.Price} руб. (осталось {product.Quantity})");
        }
    }
    
    public void AddProduct(string name, int price, int quantity)
    {
        _products.Add(new Product(name, price, quantity));
        Console.WriteLine($"Товар {name} добавлен.");
        
        SaveData(); 
    }

    public void RemoveProduct(int index)
    {
        var product = _products[index - 1];
        _products.RemoveAt(index - 1);
        Console.WriteLine($"Товар {product.Name} удален.");
        
        SaveData(); 
    }

    public void IncreaseProductQuantity(int index, int amount)
    {
        if (index >= 0 && index < _products.Count)
        {
            _products[index].IncreaseQuantity(amount);
            Console.WriteLine($"Товар {_products[index].Name} пополнен на {amount}. Текущее кол-во: {_products[index].Quantity} шт.");
        }
        
        SaveData();   
    }

    public void BuyProduct(int index)
    {
        var product = GetProductByIndex(index - 1);
        
        if (product == null)
        {
            Console.WriteLine("Неверный номер товара.");
            return;
        }
        
        if (product.Quantity == 0)
        {
            Console.WriteLine("Товара нет в наличии.");
            return;
        }
        
        int userBalance = 0;
        Console.WriteLine($"Цена товара: {product.Price} рублей");
        while (userBalance < product.Price)
        {
            Console.Write("Вставьте монету (1, 2, 5, 10): ");
            string? input = Console.ReadLine();

            if (Enum.TryParse<Coins>(input, out Coins coin))
            {
                userBalance += (int)coin;
                Console.WriteLine($"Внесено: {userBalance} рублей");
            }
            else
            {
                Console.WriteLine("Неверная монета. Попробуйте снова.");
            }
        }
        
        Console.WriteLine($"Вы купили {product.Name}!");
        if (userBalance > product.Price)
            Console.WriteLine($"Ваша сдача: {userBalance - (int)product.Price} рублей");
        
        product.ReduceQuantity(1);
        
        _machineBalance += product.Price;
        
        SaveData(); 
    }
    
    public void ShowBalance()
    {
        Console.WriteLine($"Баланс автомата: {_machineBalance} рублей");
    }
    
    public void CashOutBalance()
    {
        Console.WriteLine($"Администратор снял {_machineBalance} рублей из автомата.");
        _machineBalance = 0;
        
        SaveData(); 
    }
    
    
    public void SaveData()
    {
        var data = new VendingMachineData
        {
            Products = _products,
            MachineBalance = _machineBalance
        };
        
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public void LoadData()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            var data = JsonSerializer.Deserialize<VendingMachineData>(json);
            if (data != null)
            {
                _products = data.Products;
                _machineBalance = data.MachineBalance;
            }
        }
    }
}

