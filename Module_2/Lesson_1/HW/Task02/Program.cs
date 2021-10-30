using System;
using System.Collections.Generic;
class Polygon
{
    public int Edges { get; set; }
    public double Radius { get; set; }
    public Polygon(int edges = 0, double radius = 0)
    {
        Edges = edges; Radius = radius;
    }
    public double Perimeter
    {
        get
        {
            return Math.Round(Edges * 2 * Radius * Math.Tan(Math.PI / Edges), 5);
        }
    }
    public double Square
    {
        get
        {
            return Math.Round(Radius * Perimeter / 2, 5);
        }
    }
    public (string, string) PolygonData()
    {
        return ($"Количество сторон:{Edges}, Радиус вписанной окружности = {Radius}, Периметр = {Perimeter}, Площадь = ", $"{Square}");
    }
}
// МОДЕРНИЗИРОВАННАЯ ВЕРСИЯ СО СВЯЗНЫМ СПИСКОМ
class Program
{
    static void Main()
    {
        int edges;
        double radius, max = -1, min = -1;
        LinkedList<Polygon> polygons = new LinkedList<Polygon>();
        do
        {
            Console.Write("Edges = ");
            edges = int.Parse(Console.ReadLine());
            Console.Write("Radius = ");
            radius = double.Parse(Console.ReadLine());
            if(!(edges == 0 && radius == 0))
            {
                Polygon poly = new Polygon(edges, radius);
                min = min != -1 ? Math.Min(min, poly.Square) : poly.Square;
                max = max != -1 ? Math.Max(max, poly.Square) : poly.Square;
                polygons.AddLast(poly);
            }
        } while (!(edges == 0 && radius == 0));
        for (LinkedListNode<Polygon> poly = polygons.First; poly != null; poly = poly.Next)
        {
            (string, string) result = poly.ValueRef.PolygonData();
            Console.Write(result.Item1);
            if(poly.ValueRef.Square == min)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (poly.ValueRef.Square == max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(result.Item2);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
