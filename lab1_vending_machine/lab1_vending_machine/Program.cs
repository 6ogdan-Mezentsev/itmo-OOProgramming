using lab1_vending_machine.models;
using lab1_vending_machine.vending_machine; 
    
class Program
{
    static void Main(string[] args)
    {
        
        VendingMachine vm = new VendingMachine();
        vm.LoadData();

        while (true)
        {   
            Console.Write("Нажмите Enter для пользователя(или введите пароль администратора): ");
            var password = Console.ReadLine();
            var isAdmin = password == "1234";

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Показать товары");

                if (isAdmin)
                {
                    Console.WriteLine("2. Пополнить количество товара");
                    Console.WriteLine("3. Добавить товар");
                    Console.WriteLine("4. Удалить товар");
                    Console.WriteLine("5. Просмотреть баланс автомата");
                    Console.WriteLine("6. Обналичить баланс автомата");
                }
                else
                {
                    Console.WriteLine("2. Купить товар");
                }
                Console.WriteLine("exit. Выход");
            
                Console.Write("Команда: ");
                var command = Console.ReadLine();
        
                if (command == "1")
                {
                    vm.ShowProducts();
                }
                else if (command == "2")
                {
                    vm.ShowProducts();
                    Console.Write("Введите номер товара для покупки: ");
                    int index = int.Parse(Console.ReadLine() ?? "0");
                    
                    vm.BuyProduct(index);
                }
                else if (isAdmin && command == "2")
                {
                    vm.ShowProducts();
                    
                    Console.Write("Введите номер товара: ");
                    int index = int.Parse(Console.ReadLine() ?? "0");
                    
                    Console.Write("Введите количество для пополнения: ");
                    int quantity = int.Parse(Console.ReadLine() ?? "0");
                    
                    vm.IncreaseProductQuantity(index - 1, quantity); 
                }
                else if (isAdmin && command == "3")
                {
                    Console.Write("Название: ");
                    string name = Console.ReadLine() ?? "";

                    Console.Write("Цена: ");
                    int price = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Количество: ");
                    int quantity = int.Parse(Console.ReadLine() ?? "0");

                    vm.AddProduct(name, price, quantity);
                }
                else if (isAdmin && command == "4")
                {
                    vm.ShowProducts();
                    
                    Console.Write("Введите номер товара для удаления: ");
                    int index = int.Parse(Console.ReadLine() ?? "0");
                    
                    vm.RemoveProduct(index);
                }
                else if (isAdmin && command == "5")
                {
                    vm.ShowBalance();
                }
                else if (isAdmin && command == "6")
                {
                    vm.CashOutBalance();
                }
                else if (command == "exit")
                {
                    break;
                }
            }
        }
    }
}
