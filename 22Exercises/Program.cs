using System;
using System.Diagnostics;
using System.Threading;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

public class Program
{
    public static void Main()
    {

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        //crate a new thread
       Thread editgambar1 = new Thread (ProcessImageAsync1);
       Thread editgambar2 = new Thread (ProcessImageAsync2);

        // Start the thread
		editgambar1.Start();
         Thread.Sleep(5000);
        editgambar2.Start();
      
        Console.WriteLine("Main thread exiting.");
         Thread.Sleep(1000);
         stopwatch.Stop();

        Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");

    }

    public static void ProcessImageAsync1()
    {
        using (var image = Image.Load("C:/Users/Formulatrix/Desktop/need purchase lagi.png"))
        {
            image.Mutate(x => x.Resize(new ResizeOptions { Size = new Size(800, 600) }));
            image.SaveAsync("output.jpg");
            Console.WriteLine ("edit gambar 1") ;
               Thread.Sleep(3000);
        }
    }

     public static void ProcessImageAsync2()
    {
        using (var image2 = Image.Load("C:/Users/Formulatrix/Desktop/need purchase lagi.png"))
        {
            image2.Mutate(x => x.Grayscale());
            image2.SaveAsync("outputgreyscale.jpg");
            Console.WriteLine ("edit gambar 2") ;
               Thread.Sleep(5000);
        }
    }
}
