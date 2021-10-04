using System;

class Program
{
    static void Main()
    {
        int n = 5, m = 3;
        int[,] a = new int[n, m];
        Random rng = new Random();
        for (int i = 0; i < a.GetLength(0); i++, Console.WriteLine())
            for (int j = 0; j < a.GetLength(1); j++)
            {
                a[i, j] = rng.Next(-10, 11);
                Console.WriteLine(a[i, j] + " ");
            }
        int[][] b = new int[n][];
        for (int i = 0; i < b.Length; i++)
            b[i] = new int[rng.Next(5, 11)];
        for (int i = 0; i < b.Length; i++, Console.WriteLine())
            for (int j = 0; j < b[i].Length; j++)
            {
                b[i][j] = rng.Next(-10, 10);
                Console.Write(b[i][j] + " ");
            }
    }
}