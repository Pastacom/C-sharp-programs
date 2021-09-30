using System;

class Program
{
    static void Transform(uint n)
    {
        int[] mas = new int[n];
        Random rng = new Random();
        for (int i = 0; i < n; i++)
            mas[i] = rng.Next(0, 10);
        foreach (int elem in mas)
            Console.Write($"{elem}, ");
        Console.WriteLine();
        uint k = n;
        for (int i = 0; i < n - 1; i++)
        {
            if ((mas[i] + mas[i + 1]) % 3 == 0)
            {
                mas[i] = mas[i] * mas[i + 1];
                for (int j = i + 1; j < n - 1; j++)
                    mas[j] = mas[j + 1];
                k--;
            }
        }
        for (int i = 0; i < k; i++)
            Console.Write($"{mas[i]}, ");
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
