using System;

class Polygon
{
    public int Edges { get; set; }
    public double Radius { get; set; }
    public Polygon(int edges = 0, double radius = 0)
    {
        Edges = edges; Radius = radius;
    }
    private double Perimeter
    {
        get
        {
            return Math.Round(Edges * 2 * Radius * Math.Tan(Math.PI / Edges), 5);
        }
    }
    private double Square
    {
        get
        {
            return Math.Round(Radius * Perimeter / 2, 5);
        }
    }
    public string PolygonData()
    {
        return $"Количество сторон:{Edges}, Радиус вписанной окружности = {Radius}, Периметр = {this.Perimeter}, Площадь = {this.Square}";
    }
}
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Polygon[] arr = new Polygon[n];
        for(int i = 0; i < n; i ++)
        {
            arr[i] = new Polygon(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Console.WriteLine();
            Console.WriteLine(arr[i].PolygonData());
        }
    }
}
