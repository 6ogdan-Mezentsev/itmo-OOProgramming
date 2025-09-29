namespace lab1_vending_machine.models;

public class VendingMachineData
{
    public List<Product> Products { get; set; } = new();
    public int MachineBalance { get; set; } = 0;
}