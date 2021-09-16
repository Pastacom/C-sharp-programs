using System;
class Program
{
    static void GFunc(double x, double y)
    {
        if (x < y && x > 0)
            Console.WriteLine("" + (Math.Sin(y) + x));
        else if (x > y && x < 0)
            Console.WriteLine("" + (y - Math.Cos(x)));
        else
            Console.WriteLine("" + (0.5 * x * y));
    }
    static void Main()
    {
        string st; double x; double y;
        do
        {
            do
            {
                Console.Write("Введите значение x: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out x)));
            do
            {
                Console.Write("Введите значение y: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out y)));
            GFunc(x, y);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
