using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int[] arr = { -1, 3, 10, 8, -20, 10 };
        Action<int> d1 = x => Console.Write($"{x} ");
        Array.ForEach(arr, d1);
        Console.WriteLine();
        Converter<int, int> d2 = x => x * 2;
        int[] arr2 = Array.ConvertAll(arr, d2);
        Array.ForEach(arr2, d1);
        Console.WriteLine();
        Predicate<int> d3 = (int x) => x > 0;
        int[] arr3 = Array.FindAll(arr, d3);
        Array.ForEach(arr3, d1);
        Console.WriteLine();
        Console.WriteLine(Array.Exists(arr, x => x < 0));
        Console.WriteLine(Array.Exists(arr3, x => x < 0));
        Console.WriteLine(Array.TrueForAll(arr, d3));
        Console.WriteLine(Array.TrueForAll(arr3, d3));
        // (x,y) -> -1, 0, 1
        // -1 - порядок не нарушен
        // 0 - порядок не имеет значения
        // 1 - порядок  нарушен
        Comparison<int> d4 = (x, y) => y.CompareTo(x);
        Array.Sort(arr, d4);
        Array.ForEach(arr, d1);
        Console.WriteLine();
        Func<int, double> d5 = (x) => x / 10.0;
        Console.WriteLine(d5(15));
        Func<int, int, bool> d6 = (x, y) => x > y;
        Console.WriteLine(d6(15, 10));
    }
}



