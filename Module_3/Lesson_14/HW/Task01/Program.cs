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
            nums[i] = rng.Next(-1000, 1001);
            Console.Write($"{nums[i]}, ");
        }

        var z1 = from g in nums
                 select g * g;
        var z1_2 = nums.Select(g => g * g);

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        foreach (var num in z1)
            Console.Write($"{num}, ");
        Console.WriteLine("\n\n");
        foreach (var num in z1_2)
            Console.Write($"{num}, ");


        var z2 = from g in nums
                 where g > 0 && g / 100 == 0
                 select g;
        var z2_2 = nums.Where(g => g > 0 && g / 100 == 0);

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        foreach (var num in z2)
            Console.Write($"{num}, ");
        Console.WriteLine("\n\n");
        foreach (var num in z2_2)
            Console.Write($"{num}, ");


        var z3 = from g in nums
                 where Math.Abs(g) % 2 == 0
                 orderby g descending
                 select g;
        var z3_2 = nums.Where(g => Math.Abs(g) % 2 == 0).OrderByDescending(g => g);

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        Console.Write($"{z3.Count()}: ");
        foreach (var num in z3)
            Console.Write($"{num}, ");
        Console.WriteLine("\n\n");
        Console.Write($"{z3_2.Count()}: ");
        foreach (var num in z3_2)
            Console.Write($"{num}, ");


        var z4 = from g in nums
                 group g by (Math.Abs(g).ToString().Length) into h
                 select h;
        var z4_2 = nums.GroupBy(g => Math.Abs(g).ToString().Length);

        Console.WriteLine($"\n+{new string('-', 50)}+\n");
        foreach (var num in z4)
        {
            Console.WriteLine($"\n{num.Key}: ");
            foreach(var value in num)
            {
                Console.Write($"{value}, ");
            }
        }
        Console.WriteLine("\n\n");
        foreach (var num in z4_2)
        {
            Console.WriteLine($"\n{num.Key}: ");
            foreach (var value in num)
            {
                Console.Write($"{value}, ");
            }
        }

    }
}
