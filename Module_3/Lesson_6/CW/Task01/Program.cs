using System;

class Point
{
    public double X { get;}
    public double Y { get;}

    public Point(double x, double y) => (X, Y) = (x, y);

    public double Distance(Point point)
    {
        return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
    }
}


class TriangleComp
{
    public Point A { get;}
    public Point B { get;}
    public Point C { get;}

    public double AB { get;}
    public double AC { get;}
    public double BC { get;}
    public double Area { get; private set; }
    public TriangleComp(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        A = new Point(x1, y1);
        B = new Point(x2, y2);
        C = new Point(x3, y3);
        AB = A.Distance(B);
        AC = A.Distance(C);
        BC = B.Distance(C);
        SetArea();
    }

    private void SetArea()
    {
        double p = (AB + AC + BC) / 2;
        Area = Math.Sqrt(p * (p - AB) * (p - AC) * (p - BC));
    }

    public TriangleComp(Point a, Point b, Point c)
    {
        A = a;
        B = b;
        C = c;
        AB = A.Distance(B);
        AC = A.Distance(C);
        BC = B.Distance(C);
    }

    private static double Sign(Point p0, Point p1, Point p2)
    {
        return (p1.X - p0.X) * (p2.Y - p1.Y) - (p2.X - p1.X) * (p1.Y - p0.Y);
    }
    public bool CheckPoint(Point point)
    {
        double sign1 = Sign(point, A, B);
        double sign2 = Sign(point, B, C);
        double sign3 = Sign(point, C, A);
        return (sign1 >= 0 && sign2 >= 0 && sign3 >= 0) || (sign1 <= 0 && sign2 <= 0 && sign3 <= 0);
    }
}

    class Program
{
    static void Main()
    {
        TriangleComp triangle = new(new Point(0, 0), new Point(0, 1), new Point(1, 0));
        Point[] points = {new Point(1, 1), new Point(0.5, 0.5), new Point(1, 0)};
        foreach(var point in points)
        {
            if (triangle.CheckPoint(point))
            {
                Console.WriteLine("Точка лежит в треугольнике");
            }
            else
            {
                Console.WriteLine("Точка не лежит в треугольнике");
            }
        }
    }
}