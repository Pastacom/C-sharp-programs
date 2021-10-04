using System;

class Program
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Введите значение: ");
        } while (!int.TryParse(Console.ReadLine(), out n));
        int[,] a = new int[n, n];
        int number = 1, k = 0;
        a[n / 2, n / 2] = n * n;
        for (int i = 0; i < n / 2; i ++)
        { 
            for (int j = 0; j < n - k; j ++)
            {
                a[i, i + j] = number;
                number += 1;
            }
            for (int j = i + 1; j < n - i; j ++)
            {
                a[j, n - i - 1] = number;
                number += 1;
            }
            for (int j = i + 1; j < n - i; j++)
            {
                a[n - i - 1, n - j - 1] = number;
                number += 1;
            }
            for (int j = i + 1; j < n - i - 1; j++)
            {
                a[n - j - 1, i] = number;
                number += 1;
            }
            k += 2;
        }
        for (int i = 0; i < a.GetLength(0); i++, Console.WriteLine())
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write($"{{0, {-(n * n).ToString().Length - 1}}}", a[i, j]);
            }

    }
}
