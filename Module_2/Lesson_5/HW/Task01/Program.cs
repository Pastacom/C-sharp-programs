using System;

public class Shape
{
    public const double PI = Math.PI;
    protected double _x, _y;

    public Shape()
    {
    }

    public Shape(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public virtual double Area()
    {
        return _x * _y;
    }
}

public class Circle : Shape
{
    public Circle(double r) : base(r, 0)
    {
    }

    public override double Area()
    {
        return PI * _x * _x;
    }
}

public class Sphere : Shape
{
    public Sphere(double r) : base(r, 0)
    {
    }

    public override double Area()
    {
        return 4 * PI * _x * _x;
    }
}

public class Cylinder : Shape
{
    public Cylinder(double r, double h) : base(r, h)
    {
    }

    public override double Area()
    {
        return 2 * PI * _x * _x + 2 * PI * _x * _y;
    }
}
class Program
{
    static void Main()
    {
        Random rng = new Random();
        int n1 = rng.Next(3, 6); int n2 = rng.Next(3, 6); int n3 = rng.Next(3, 6);
        Shape[] shapes = new Shape[n1 + n2 + n3];
        Console.WriteLine("До перемешивания:\n");
        for (int i = 0; i < n1; i++)
        {
            int r = rng.Next(1, 100);
            shapes[i] = new Circle(r);
            Console.WriteLine($"{shapes[i].GetType()}: R = {r}, Area = {shapes[i].Area()}");
        }
        for (int i = n1; i < n1 + n2; i++)
        {
            int r = rng.Next(1, 100);
            int h = rng.Next(1, 100);
            shapes[i] = new Cylinder(r, h);
            Console.WriteLine($"{shapes[i].GetType()}: R = {r}, H = {h}, Area = {shapes[i].Area()}");
        }
        for (int i = n1 + n2; i < n1 + n2 + n3; i++)
        {
            int r = rng.Next(1, 100);
            shapes[i] = new Sphere(r);
            Console.WriteLine($"{shapes[i].GetType()}: R = {r}, Area = {shapes[i].Area()}");
        }
        Array.Sort(shapes, Shuffler);
        Console.WriteLine("\nПосле перемешивания:\n");
        Print(shapes);
        Array.Sort(shapes, Comparator);
        Console.WriteLine("\nПосле сортировки:\n");
        Print(shapes);
    }
    public static void Print(Shape[] shapes)
    {
        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType()}: Area = {shape.Area()}");
        }
    }
    public static int Shuffler(Shape a, Shape b)
    {
        Random rng = new Random();
        return rng.Next(-1, 1);
    }
    public static int Comparator(Shape a, Shape b)
    {
        Object[] shapes = {typeof(Circle), typeof(Cylinder), typeof(Sphere)};
        if (Array.IndexOf(shapes, a.GetType()) < Array.IndexOf(shapes, b.GetType()))
        {
            return -1;
        }
        return 1;
    }
}
