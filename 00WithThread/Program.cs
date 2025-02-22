﻿using System;
using System.Diagnostics;
using System.Threading;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Starting program.");
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var task1 = new Thread(DoTaskOne);
        var task2 = new Thread(DoTaskTwo);

        task1.Start();
        task2.Start();

        task1.Join();
        task2.Join();

        stopwatch.Stop();

        Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
    }

    public static void DoTaskOne()
    {
        Console.WriteLine("Starting task 1.");
        string x = "Hello";
        for (int i = 0; i < 100000; i++)
        {
            x += i + " ";
        }
        Console.WriteLine("Task 1 complete.");
    }

    public static void DoTaskTwo()
    {
        Console.WriteLine("Starting task 2.");
        string x = "Hello";
        for (int i = 0; i < 100000; i++)
        {
            x += i + " ";
        }
        Console.WriteLine("Task 2 complete.");
    }
}
