using System;
using System.Collections.Generic;
class Point
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public Point(double x, double y) { (X, Y) = (x, y); }
    public double Distance(Point point)
    {
        return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
    }
    public override string ToString()
    {
        return $"Point ({X},{Y})";
    }
}

class Circle : IComparable<Circle>
{
    public double Rad { get; private set; }
    public Point Center { get; private set; }
    public Circle(double x, double y, double rad){ (Rad, Center) = (rad, new Point(x, y)); }
    public override string ToString()
    {
        return $"Окружность с центром {Center} и радиусом {Rad}";
    }
    public int CompareTo(Circle circle)
    {
        if (Rad * Center.Distance(new Point(0, 0)) > circle.Rad * circle.Center.Distance(new Point(0, 0)))
            return 1;
        else
            return 0;
    }
}

struct PointStruct
{
    public double X{ get; private set; }
    public double Y{ get; private set; }
    public PointStruct(double x, double y){ (X, Y) = (x, y); }
    public double Distance(PointStruct point)
    {
        return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
    }
}
struct CircleStruct
{
    public double Rad { get; private set; }
    public Point Center { get; private set; }
    public CircleStruct(double x, double y, double rad) { (Rad, Center) = (rad, new Point(x, y)); }
}

class Program
{
    static void Main()
    {
        Random rng = new();
        List<Circle> circles = new();
        for(int i = 0; i < 10; i++)
        {
            circles.Add(new Circle(rng.Next(-10, 11), rng.Next(-10, 11), rng.Next(-10, 10) + rng.NextDouble()));
            Console.WriteLine(circles[^1]);
        }
        circles.Sort((circle1, circle2) => (circle1.Rad * circle1.Center.Distance(new Point(0, 0))).CompareTo(circle2.Rad * circle2.Center.Distance(new Point(0, 0))));
        Console.WriteLine("\n\n");
        foreach (var circle in circles)
        {
            Console.WriteLine(circle);
        }
        circles.Sort();
        Console.WriteLine("\n\n");
        foreach (var circle in circles)
        {
            Console.WriteLine(circle);
        }
    }
}
