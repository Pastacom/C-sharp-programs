using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Random rng = new();
        using (StreamWriter writer = new("Numbers.txt"))
        {
            for (int i = 0; i < 10; i++)
            {
                writer.Write((char)rng.Next(1, 101));
            }
        }
        int[] arr = new int[10];
        using (StreamReader reader = new("Numbers.txt"))
        {
            for (int i = 0; i < 10; i++)
            {
                arr[i] = reader.Read();
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();
            var n = int.Parse(Console.ReadLine());
            var dif = int.MaxValue;
            var index = 0;

            for (var i = 0; i < 10; i++)
            {
                if (Math.Abs(n - arr[i]) < dif)
                {
                    dif = Math.Abs(n - arr[i]);
                    index = i;
                }
            }
            arr[index] = n;
        }

        using (StreamWriter writer = new("Numbers.txt"))
        {
            for (int i = 0; i < 10; i++)
            {
                writer.Write((char)arr[i]);
            }
        }

        using (StreamReader reader = new("Numbers.txt"))
        {
            for (int i = 0; i < 10; i++)
            {
                arr[i] = reader.Read();
                Console.Write($"{arr[i]} ");
            }
        }
    }
}