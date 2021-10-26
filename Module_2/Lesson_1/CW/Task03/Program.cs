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
        Polygon poly1 = new Polygon(4, 2);
        Polygon poly2 = new Polygon(6, 4);
        Console.WriteLine(poly1.PolygonData());
        Console.WriteLine(poly2.PolygonData());
    }
}
