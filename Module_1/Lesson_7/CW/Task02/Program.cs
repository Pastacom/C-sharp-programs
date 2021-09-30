using System;

class Program
{
    static void Shuffle(ref int[] arr)
    {
        Random rng = new Random();
        for (int i = 0; i < 100; i ++)
        {
            int a = rng.Next(0, 100);
            int b = rng.Next(0, 100);
            int c = arr[a];
            arr[a] = arr[b];
            arr[b] = c;
        }
    }

    static void Main()
    {
        int[] arr = new int[100];
        for (int i = 0; i < 100; i++)
            arr[i] = i + 1;
        Shuffle(ref arr);
        Console.WriteLine();
        Console.WriteLine();
        Array.Resize(ref arr, 99);
        int sm = 0;
        for (int i = 0; i < 99; i++)
        {
            sm += arr[i];
        }
        Console.WriteLine(5050 - sm);

    }
}