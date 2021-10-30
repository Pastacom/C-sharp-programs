using System;

class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public Point(double x = 0, double y = 0)
    {
        X = x; Y = y;
    }
    public double R
    {
        get
        {
            return Math.Pow(X, 2) + Math.Pow(Y, 2);
        }
    }
    public double Fi
    {
        get
        {
            if (X > 0)
            {
                if (Y >= 0)
                {
                    return Math.Atan(Y / X);
                }
                if (Y < 0)
                {
                    return Math.Atan(Y / X) + Math.PI * 2;
                }
            }
            if (X < 0)
            {
                return Math.Atan(Y / X) + Math.PI;
            }
            else
            {
                if (Y > 0)
                {
                    return Math.PI / 2;
                }
                else if (Y < 0)
                {
                    return 3 * Math.PI / 2;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    public string PointData
    {
        get
        {
            return $"X = {X}, Y = {Y}, R = {R}, Fi = {Fi}";
        }
    }
}
class Program
{
    static void Main()
    {
        Point a, b, c, d;
        a = new Point(3, 2);
        b = new Point(1, 0);
        c = new Point();
        d = new Point();
        Console.WriteLine(a.PointData);
        Console.WriteLine(b.PointData);
        Console.WriteLine(c.PointData);
        double x, y;
        do
        {
            Console.Write("x = ");
            x = double.Parse(Console.ReadLine());
            Console.Write("y = ");
            y = double.Parse(Console.ReadLine());
            d.X = x; d.Y = y;
            Console.WriteLine(d.PointData);
        } while (!(x == 0 && y == 0));
    }
}
