using System;
abstract class RightFigure
{
    public int Side { get; private set; }
    public RightFigure(int s)
    {
        Side = s;
    }
    public abstract double Area { get; }
    public abstract int Perimetr();
    public override string ToString()
    {
        return $"Side = {Side} Area = {Area:f2} P = {Perimetr()}";
    }
}
class RightTriangle : RightFigure
{
    public RightTriangle(int s) : base(s) { }
    public override double Area
    {
        get
        {
            return Side * Side * Math.Sqrt(3) / 4;
        }
    }
    public override int Perimetr()
    {
        return 3 * Side;
    }
}
class Square : RightFigure
{
    public Square(int s) : base(s) { }
    public override double Area
    {
        get
        {
            return Side * Side;
        }
    }
    public override int Perimetr()
    {
        return 4 * Side;
    }
}
class Program
{
    public static void Main()
    {
        RightFigure triangle = new RightTriangle(10);
        Console.WriteLine(triangle.Area);
        Console.WriteLine(triangle.Perimetr());
        RightTriangle triangle2 = new RightTriangle(10);
        Console.WriteLine(triangle2.Area);
        Console.WriteLine(triangle2.Perimetr());
        RightFigure square = new Square(10);
        Console.WriteLine(square.Area);
        Console.WriteLine(square.Perimetr());
        Square square2 = new Square(10);
        Console.WriteLine(square2.Area);
        Console.WriteLine(square2.Perimetr());
        Random random = new Random();
        RightFigure[] figures = new RightFigure[10];
        for (int i = 0; i < 5; i++)
            figures[i] = new RightTriangle(random.Next(10));
        for (int i = 5; i < 10; i++)
            figures[i] = new Square(random.Next(10));
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(figures[i]);
        }
    }
}