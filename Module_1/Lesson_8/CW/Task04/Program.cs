using System;

class Program
{
    static void Main()
    {
        int number;
        do
        {
            Console.Write("Введите значение: ");
        } while (!int.TryParse(Console.ReadLine(), out number));
        Random rng = new Random();
        int[][] b = new int[number][];
        for (int i = 0; i < b.Length; i++)
            b[i] = new int[rng.Next(5, 16)];
        for (int i = 0; i < b.Length; i++, Console.WriteLine())
            for (int j = 0; j < b[i].Length; j++)
            {
                b[i][j] = rng.Next(-10, 11);
                Console.Write(b[i][j] + " ");
            }
        for (int i = 0; i < b.Length; i++)
        {
            Array.Sort(b[i], (x, y) => y.CompareTo(x));
        }
        Array.Sort(b, (x, y) => y.Length.CompareTo(x.Length));
    }
}