using System;


class Point2D
{
    int x, y;
    public int X
    {
        get { return x; } // доступ
        set { x = value; } // запись
    }
    public int Y 
    {
        get { return y; }
        private set { y = value; } // перезаписать y нельзя
    }
}

class Program
{
    static void Main()
    {
        Point2D point1 = new Point2D();
        Point2D point2 = new Point2D();
        point2.X = 10;
        Console.WriteLine(point1.X);
        Console.WriteLine(point1.Y);
        Console.WriteLine(point2.X);
        Console.WriteLine(point2.Y);
    }
}
