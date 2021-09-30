using System;

class Program
{
    static void Shuffle(ref int[] arr)
    {
        Random rng = new Random();
        for (int i = 0; i < 100; i++)
        {
            int a = rng.Next(0, 100);
            int b = rng.Next(0, 100);
            int c = arr[a];
            arr[a] = arr[b];
            arr[b] = c;
        }
        int x = rng.Next(0, 100);
        int y = rng.Next(0, 100);
        Console.WriteLine($"Удаляю число: {arr[x]}");
        arr[x] = arr[y];
        Console.WriteLine($"Дублирую число: {arr[y]}");
    }

    static void Main()
    {
        int[] arr = new int[100];
        for (int i = 0; i < 100; i++)
            arr[i] = i + 1;
        Shuffle(ref arr);
        int sm = 0, dublicated = 0, deleted = 0;
        int[] mas = new int[100];
        for (int i = 0; i < 100; i++)
        {
            sm += arr[i];
            if (mas[arr[i] - 1] == 0)
            {
                mas[arr[i] - 1] = 1;
            }
            else
                dublicated = arr[i];
        }

        Console.WriteLine($"Дубликат = {dublicated}\nУдаленное число = {5050 - (sm - dublicated)}");

    }
}