using System;
class Program
{
    static void GFunc(double x)
    {
        if (x <= 0.5)
            Console.WriteLine("" + 1);
        else
            Console.WriteLine("" + (Math.Sin(Math.PI * (x - 1) / 2.0)));
    }
    static void Main()
    {
        string st; double x;
        do
        {
            do
            {
                Console.Write("Введите значение x: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out x)));
            GFunc(x);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
