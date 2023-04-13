using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
//using System.Windows.Forms;

public class Program
{
    public static async Task Main()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await ProcessImageAsync1();
        Console.WriteLine("Proses resize picture selesai.");

        Thread.Sleep(5000);

        await ProcessImageAsync2();
        Console.WriteLine("Proses greyscale gambar input selesai.");

        stopwatch.Stop();

        Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");

    }

    public static async Task ProcessImageAsync1()
    {
        using (var image = Image.Load("C:/Users/Formulatrix/Desktop/need purchase lagi.png"))
        {
            image.Mutate(x => x.Resize(new ResizeOptions { Size = new Size(800, 600) }));
            await image.SaveAsync("output.jpg");
        }
    }

     public static async Task ProcessImageAsync2()
    {
        using (var image2 = Image.Load("C:/Users/Formulatrix/Desktop/need purchase lagi.png"))
        {
            image2.Mutate(x => x.Grayscale());
            await image2.SaveAsync("outputgreyscale.jpg");
        }
    }
}
