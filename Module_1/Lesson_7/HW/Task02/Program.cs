using System;

class Program
{
    static void Transform(uint n)
    {
        int[] mas = new int[n];
        Random rng = new Random();
        for (int i = 0; i < n; i++)
            mas[i] = rng.Next(-10, 11);
        foreach (int elem in mas)
            Console.Write($"{elem}, ");
        Console.WriteLine();
        uint k = 0;
        for (int i = 0; i < n; i++)
        {
            if (mas[k] % 2 == 0)
            {
                int change = mas[k];
                for (uint j = k; j < n - 1; j++)
                    mas[j] = mas[j + 1];
                mas[n - 1] = change;
            }
            else
                k++;
        }
        for (int i = 0; i < k; i++)
            Console.Write($"{mas[i]}, ");
        Console.WriteLine($"\nКоличество совершенных операций: {n-k}");
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
