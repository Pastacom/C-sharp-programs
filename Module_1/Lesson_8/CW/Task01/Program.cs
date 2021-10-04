using System;
class Program
{
    static void Print(int[] arr)
    {
        Console.WriteLine();
        foreach (int elem in arr)
            Console.Write($"{elem}, ");
    }
    static int EvenOdd(int a, int b)
    {
        if ((a % 2 != 0) && (b % 2 == 0))
        {
            return 1;
        }
        else if ((a % 2 == 0) && (b % 2 != 0))
            return -1;
        else
            return 0;
    }
    static int Len(int a, int b)
    {
        string x = a.ToString();
        string y = b.ToString();
        if (x.Length > y.Length)
            return 1;
        else if (x.Length < y.Length)
            return -1;
        else
            return 0;
    }
    static int Sum(int a, int b)
    {
        int res1 = 0, res2 = 0;
        while (a > 0)
        {
            res1 += a % 10;
            a /= 10;
        }
        while (b > 0)
        {
            res2 += b % 10;
            b /= 10;
        }
        if (res1 > res2)
            return 1;
        else if (res1 < res2)
            return -1;
        else
            return 0;
    }
    static void Transform(uint n)
    {
        int[] mas = new int[n];
        Random rng = new Random();
        for (int i = 0; i < n; i++)
            mas[i] = rng.Next(0, 1001);
        Print(mas);
        Array.Sort(mas, EvenOdd);
        Print(mas);
        Array.Sort(mas, Len);
        Print(mas);
        Array.Sort(mas, Sum);
        Print(mas);
    }
    static void Main()
    {
        uint number;
        do
        {
            Console.Write("Введите значение: ");
        } while (!uint.TryParse(Console.ReadLine(), out number));
        Transform(number);

    }
}