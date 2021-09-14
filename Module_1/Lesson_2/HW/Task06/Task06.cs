using System;
using System.Globalization;
class Program
{
    static void Calculation(decimal budget, decimal percentage)
    {
        string res = (budget * (percentage / 100)).ToString("C", new CultureInfo("en-US"));
        Console.WriteLine("На игры будет выделено: " + res);
    }
    static void Main()
    {
        string st; decimal budget; decimal percentage;
        do
        {
            do
            {
                Console.Write("Введите свой бюджет: ");
                st = Console.ReadLine();
            } while (!(decimal.TryParse(st, out budget) && (budget > 0)));
            do
            {
                Console.Write("Введите процент выделяемый на игры: ");
                st = Console.ReadLine();
            } while (!(decimal.TryParse(st, out percentage) && (percentage > 0)));
            Calculation(budget, percentage);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
