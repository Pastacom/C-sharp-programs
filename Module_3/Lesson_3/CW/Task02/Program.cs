using System;
public delegate void SquareSizedChanged(double param);
class Square
{
    double x1, y1, x2, y2;
    public event SquareSizedChanged OnSizeChanged;
    public Square(double x1, double x2, double y1, double y2)
        => (this.x1, this.x2, this.y1, this.y2) = (x1, x2, y1, y2);
    public double X1
    {
        get => x1;
        set
        {
            x1 = value;
            OnSizeChanged?.Invoke(Math.Abs(x2 - x1));
        }
    }
    public double Y1
    {
        get => y1;
        set
        {
            y1 = value;
            OnSizeChanged?.Invoke(Math.Abs(y2 - y1));
        }
    }
    public double X2
    {
        get => x2;
        set
        {
            x2 = value;
            OnSizeChanged?.Invoke(Math.Abs(x2 - x1));
        }
    }
    public double Y2
    {
        get => y2;
        set
        {
            y2 = value;
            OnSizeChanged?.Invoke(Math.Abs(y2 - y1));
        }
    }
}
class Program
{
    private static void SquareConsoleInfo(double side)
    {
        Console.WriteLine($"{side:F3}");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Первая точка: ");
        Console.Write("X = ");
        var x1 = double.Parse(Console.ReadLine());
        Console.Write("Y = ");
        var y1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Вторая точка: ");
        Console.Write("X = ");
        var x2 = double.Parse(Console.ReadLine());
        Console.Write("Y = ");
        var y2 = double.Parse(Console.ReadLine());
        var S = new Square(x1, x2, y1, y2);
        S.OnSizeChanged += SquareConsoleInfo;
        do
        {
            Console.Write("X = ");
            S.X2 = double.Parse(Console.ReadLine());
            Console.Write("Y = ");
            S.Y2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Esc для выхода");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}