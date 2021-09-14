using System;
class Program
{
    static void TriangleInequality(double a, double b, double c)
    {

        bool flag = (a < b + c) ? (b < a + c) ? (c < a + b) ? true : false : false : false;
        switch(flag)
        {
            case true:
                Console.WriteLine("Треугольник существует");
                break;
            case false:
                Console.WriteLine("Треугольник не существует");
                break;
        }
    }
    static void Main()
    {
        string st; double a; double b; double c;
        do
        {
            do
            {
                Console.Write("Введите сторону A: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out a) && (a > 0)));
            do
            {
                Console.Write("Введите сторону B: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out b) && (b > 0)));
            do
            {
                Console.Write("Введите сторону C: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out c) && (c > 0)));
            TriangleInequality(a, b, c);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
