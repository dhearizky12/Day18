using System;
using System.Threading.Tasks;

public abstract class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public abstract Task<int> CalculateProfitAsync();
}

public class Pakaian : Product
{
    public override async Task<int> CalculateProfitAsync()
    {
        Console.WriteLine("Menghitung keuntungan Penjualan Pakaian...");
        await Task.Delay(3000); // Mensimulasikan penghitungan yang memakan waktu
        return (Price * Quantity) / 2;
    }
}

public class AlasKaki : Product
{
    public override async Task<int> CalculateProfitAsync()
    {
        Console.WriteLine("Menghitung keuntungan Penjualan Alas Kaki...");
        await Task.Delay(2000); // Mensimulasikan penghitungan yang memakan waktu
        return Price * Quantity;
    }
}

public class Program
{
    public static async Task Main()
    {
        Product clothing = new Pakaian { Name = "Jaket", Price = 150000, Quantity = 10 };
        Product foot = new AlasKaki { Name = "Sepatu Adidas", Price = 3000000, Quantity = 6 };

        int profitclothing = await clothing.CalculateProfitAsync(); // Menghitung keuntungan pakaian secara asynchronus

        Console.WriteLine($"Nama Item = {clothing.Name} Price = {clothing.Price} Quantity = {clothing.Quantity}");
        Console.WriteLine($"Keuntungan dari Penjualan {clothing.Name} adalah = {profitclothing}");
        await Task.Delay(2000);

        int profitFoot = await foot.CalculateProfitAsync(); // Menghitung keuntungan alas kaki secara asynchronus

        
        Console.WriteLine($"Nama Item = {foot.Name} Price = {foot.Price} Quantity = {foot.Quantity}");
        Console.WriteLine($"Keuntungan dari {foot.Name} adalah = {profitFoot}");
    }
}
