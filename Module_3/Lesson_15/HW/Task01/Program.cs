using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    private static readonly Random Random = new Random();
    private static async Task<double> Integral(Func<double, double> func, int a, int b, int n)
    {
        int correct = 0; int minX = a, maxX = b;
        int maxY = (int)Math.Max(func(a), func(b)) + 1;
        for (int i = 0; i < n; i++)
        {
            await Task.Run(() =>
            {
                double x = Random.Next(minX, maxX) + Random.NextDouble();
                double y = Random.Next(0, maxY) + Random.NextDouble();
                if (y <= func(x)) { correct++; }
            });

        }
        return (double)correct / n * (maxX - minX) * maxY;
    }
    public static async Task Main(string[] args)
    {
        var l = int.Parse(Console.ReadLine());
        var r = int.Parse(Console.ReadLine());

        List<double> tasks = new();
        for (var i = l; i <= r; i += 2)
        {
            await Task.Run(async () =>
            {
                var integral = await Integral(x => x * x, i, i + 2, Random.Next(0, 1000));
                tasks.Add(integral);
            });
        }

        Array.ForEach(tasks.ToArray(), Console.WriteLine);

    }
}