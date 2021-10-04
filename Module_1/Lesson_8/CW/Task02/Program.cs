using System;

class Program
{
    static void Generate(uint num)
    {
        double[] generatedArray = new double[num];
        Random rng = new Random();
        for (int i = 0; i < num; i++)
        {
            generatedArray[i] = rng.NextDouble() * rng.Next(-10, 10);
        }
        foreach (double elem in generatedArray)
            Console.Write($"{elem}, ");
        int[] intArray = new int[num];
        double[] doubleArray = new double[num];
        for (int i = 0; i < num; i++)
        {
            intArray[i] = (int)generatedArray[i];
            doubleArray[i] = generatedArray[i] - intArray[i];
        }
        Array.Sort(intArray);
        Array.Sort(doubleArray);
        Console.WriteLine();
        foreach (double elem in intArray)
            Console.Write($"{elem}, ");
        Console.WriteLine();
        foreach (double elem in doubleArray)
            Console.Write($"{elem}, ");

    }

    static void Main()
    {
        uint number;
        do
        {
            Console.Write("Введите значение: ");
        } while (!uint.TryParse(Console.ReadLine(), out number));
        Generate(number);
    }
}