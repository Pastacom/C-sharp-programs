using System;
class Program
{
    static void InSector(double x, double y)
    {
        if (x >= 0 && y <= x && (Math.Pow(x, 2) + Math.Pow(y, 2) <= 4))
            Console.WriteLine(true);
        else
            Console.WriteLine(false);
    }
    static void Main()
    {
        string st; double x; double y;
        do
        {
            do
            {
                Console.Write("Введите координату x: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out x)));
            do
            {
                Console.Write("Введите координату y: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out y)));
            InSector(x, y);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
