using System;
using System.Collections;
using System.Collections.Generic;

class Fibbonacci
{
    static int First { get; set; } = 0;
    static int Second { get; set; } = 1;
    public static IEnumerable Enumerator(int n)
    {
        for (int i = 0; i < n; i++)
        {
            (First, Second) = (Second, First + Second);
            yield return First;
        }
    }
}
class TriangleNums
{
    public static IEnumerable Enumerator(int n)
    {
        for (int i = 0; i < n; ++i)
        {
            yield return 0.5 * i * (i + 1);
        }
    }
}


class Program
{
    static void Main()
    {
        List<int> fi = new();
        List<double> triangle = new();
        int m = int.Parse(Console.ReadLine());
        foreach(int num in Fibbonacci.Enumerator(m))
        {
            Console.Write($"{num} ");
            fi.Add(num);
        }
        Console.WriteLine();
        foreach (double num in TriangleNums.Enumerator(m))
        {
            Console.Write($"{num} ");
            triangle.Add(num);
        }
        Console.WriteLine();
        for(int i = 0; i < fi.Count; i++)
        {
            Console.Write($"{fi[i] + triangle[i]} ");
        }
    }
}
