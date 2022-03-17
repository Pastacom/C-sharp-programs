using System;
using System.Linq;
class Program
{
    static void Main()
    {
        Random rng = new();
        Console.Write("Введите число элементов: ");
        int n = int.Parse(Console.ReadLine());
        var nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = rng.Next(-10000, 10001);
            Console.Write($"{nums[i]}, ");
        }

        var z1 = from g in nums
                 select g.ToString()[^1];
        var z1_2 = nums.Select(g => g.ToString()[^1]);

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        foreach (var num in z1)
            Console.Write($"{num}, ");
        Console.WriteLine("\n\n");
        foreach (var num in z1_2)
            Console.Write($"{num}, ");


        var z2 = from g in nums
                 orderby g.ToString()[^1]
                 select g;
        var z2_2 = nums.OrderBy(g => g.ToString()[^1]).Select(g => g);

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        foreach (var num in z2)
            Console.Write($"{num}, ");
        Console.WriteLine("\n\n");
        foreach (var num in z2_2)
            Console.Write($"{num}, ");


        var z3 = from g in nums
                 where g % 2 == 0 && g > 0
                 select g;
        var z3_2 = nums.Where(g => g % 2 == 0 && g > 0).Select(g => g);

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        Console.Write($"{z3.Count()}: ");
        foreach (var num in z3)
            Console.Write($"{num}, ");
        Console.WriteLine("\n\n");
        Console.Write($"{z3_2.Count()}: ");
        foreach (var num in z3_2)
            Console.Write($"{num}, ");


        var z4 = (from g in nums
                 where Math.Abs(g) % 2 == 0
                 select g).Sum();
        var z4_2 = (nums.Where(g => Math.Abs(g) % 2 == 0).Select(g => g)).Sum();

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        Console.WriteLine(z4);
        Console.WriteLine(z4_2);

        var z5 = from g in nums
                 orderby Math.Abs(g).ToString()[0], g.ToString()[^1]
                 select g;
        var z5_2 = nums.OrderBy(g => Math.Abs(g).ToString()[0]).ThenBy(g => g.ToString()[^1]).Select(g => g);

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        foreach (var num in z5)
            Console.Write($"{num}, ");
        Console.WriteLine("\n\n");
        foreach (var num in z5_2)
            Console.Write($"{num}, ");

    }
}
