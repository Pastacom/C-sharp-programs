using System;
using System.Linq;
abstract class Something
{
    
}
class Lentil : Something
{
    Random rng = new Random();
    public double Weight{ get; }
    public Lentil ()
    {
        Weight = rng.NextDouble() * 2;
    }
    public override string ToString()
    {
        return $"{GetType()}, Weight = {Weight}";
    }
}
class Ashes : Something
{
    Random rng = new Random();
    public double Volume { get; }
    public Ashes()
    {
        Volume = rng.NextDouble();
    }
    public override string ToString()
    {
        return $"{GetType()}, Volume = {Volume}";
    }
}
class Program
{
    static void Main()
    {
        Random rng = new Random();
        int n = int.Parse(Console.ReadLine());
        Something[] array = new Something[n];
        for (int i = 0; i < n; i++)
        {
            if (rng.Next(0, 2) == 1)
            {
                array[i] = new Lentil();
            }
            else
            {
                array[i] = new Ashes();
            }
        }
        Console.WriteLine("До разбиения:\n");
        Print(array);
        Array.Sort(array, Comparator);
        Console.WriteLine("\nПосле разбиения:\n");
        int count = array.Count(a => typeof(Lentil) == a.GetType());
        Something[] lentils = (Something[])array[..count].Clone(); 
        Something[] ashes = (Something[])array[count..].Clone();
        Print(lentils);
        Console.WriteLine("\n");
        Print(ashes);
    }
    public static void Print(Something[] array)
    {
        foreach (var element in array)
        {
            Console.WriteLine(element);
        }
    }
    public static int Comparator(Something a, Something b)
    {
        Object[] shapes = { typeof(Lentil), typeof(Ashes)};
        if (Array.IndexOf(shapes, a.GetType()) < Array.IndexOf(shapes, b.GetType()))
        {
            return -1;
        }
        return 1;
    }
}
