using System;


class Point2D
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point2D(int x = 0, int y = 0)
    {
        X = x; Y = y;
    }
    public double Distance ()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
    public double Distance(Point2D point)
    {
        return Math.Sqrt((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y));
    }
    public static Point2D operator+(Point2D p1, Point2D p2)
    {
        return new Point2D(p1.X + p2.X, p1.Y + p2.Y);
    }
    public static Point2D operator +(Point2D p1, int a)
    {
        return new Point2D(p1.X + a, p1.Y + a);
    }
    public static Point2D operator +(int a, Point2D p1)
    {
        return new Point2D(p1.X + a, p1.Y + a);
    }
    public static Point2D operator -(Point2D p1, Point2D p2)
    {
        return new Point2D(p1.X - p2.X, p1.Y - p2.Y);
    }
    public override string ToString()
    {
        return X + " " + Y;
    }
}

class Program
{
    static void Main()
    {
        Point2D point1 = new Point2D(5, 10);
        Point2D point2 = new Point2D(20, 30);
        point2.X = 100;
        Console.WriteLine(point1.X);
        Console.WriteLine(point1.Y);
        Console.WriteLine(point1.Distance());
        Console.WriteLine(point2.X);
        Console.WriteLine(point2.Y);
        Console.WriteLine(point2.Distance());
        Console.WriteLine(point1.Distance(point2));
        Console.WriteLine(point2.Distance(point1));
        Console.WriteLine(point2 + point1);
        Console.WriteLine(point2 - point1);
        Console.WriteLine(point2 + 5);
        Console.WriteLine(5 + point2);
    }
}
