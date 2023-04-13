using System;
using System.Threading.Tasks;
using System.Diagnostics;

public class Program
{
    public static async Task Main()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Task <int> task1 = Task.Run(() => CalculateSquare(5)); // Menghitung kuadrat dari 5 secara asynchronus
        Task<int> task2 = Task.Run(() => CalculateCube(3)); // Menghitung kubus dari 3 secara asynchronus

        int result1 = await task1; // Menunggu task1 selesai dan mengambil hasilnya
        int result2 = await task2; // Menunggu task2 selesai dan mengambil hasilnya

        Console.WriteLine($"Hasil kuadrat dari 5 adalah {result1}"); 
        Console.WriteLine($"Hasil kubus dari 3 adalah {result2}"); 

        stopwatch.Stop();

        Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
    }

    private static int CalculateSquare(int num)
    {
        Console.WriteLine("Menghitung kuadrat...");
        Task.Delay(3000).Wait(); // Menunggu 3 detik untuk mensimulasikan penghitungan yang memakan waktu
        return num * num;
    }

    private static int CalculateCube(int num)
    {
        Console.WriteLine("Menghitung kubus...");
        Task.Delay(2000).Wait(); // Menunggu 2 detik untuk mensimulasikan penghitungan yang memakan waktu
        return num * num * num;
    }
}
