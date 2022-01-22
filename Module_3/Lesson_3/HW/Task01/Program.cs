using System;

public delegate void CoordChanged(Dot param);

public class Dot
{
    public event CoordChanged OnCoordChanged;
    public double X { get; private set; }
    public double Y { get; private set; }

    public Dot(double x, double y)
    {
        X = x; Y = y;
    }
    
    public void DotFlow()
    {
        Random rng = new();
        for(int i = 0; i < 10; i++)
        {
            X = rng.Next(-9, 10) + rng.NextDouble() * (rng.Next(0, 2) == 0 ? -1 : 1);
            Y = rng.Next(-9, 10) + rng.NextDouble() * (rng.Next(0, 2) == 0 ? -1 : 1);
            Console.WriteLine($"({X:F3}, {Y:F3})");
            if (X < 0 && Y < 0)
            {
                OnCoordChanged?.Invoke(this);
            }
        }
    }
}



class Program
{
    static void PrintInfo(Dot A)
    {
        Console.WriteLine($"X = {A.X:F3}, Y = {A.Y:F3}");
    }
    static void Main()
    {
        Console.Write("X = ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Y = ");
        double y = double.Parse(Console.ReadLine());
        Dot D = new(x, y);
        D.OnCoordChanged += PrintInfo;
        D.DotFlow();
    }
}
