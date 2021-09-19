using System;
class Program
{
    static void Main()
    {
        string st; double a; double delta;
        do
        {
            double s = 0;
            do
            {
                Console.Write("Введите значение A: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out a)));
            do
            {
                Console.Write("Введите значение Delta: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out delta)));
            for (int i = 0; (i + 1) * delta <= a; i++)
            {
                s += ((Math.Pow(i * delta, 2)) + (Math.Pow((i + 1) * delta, 2))) / 2 * delta;
                Console.WriteLine($"Площадь под графиком функции равна {s}");
            }
            if (a % delta != 0)
                s += (Math.Pow(a - a % delta, 2) + Math.Pow(a, 2)) / 2 * delta;
            Console.WriteLine($"Площадь под графиком функции равна {s}");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");    
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
