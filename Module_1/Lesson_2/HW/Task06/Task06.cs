using System;
using System.Globalization;
class Program
{
    static void Calculation(decimal budget, decimal percentage, uint currency)
    {
        string res;
        switch (currency)
        { 
            case 1:
                res = (budget * (percentage / 100)).ToString("C", new CultureInfo("en-US"));
                Console.WriteLine("На игры будет выделено: " + res);
                break;
            case 2:
                res = (budget * (percentage / 100)).ToString("C", new CultureInfo("fr-FR"));
                Console.WriteLine("На игры будет выделено: " + res);
                break;
            case 3:
                res = (budget * (percentage / 100)).ToString("C", new CultureInfo("ru-RU"));
                Console.WriteLine("На игры будет выделено: " + res);
                break;
        }
        
    }
    static void Main()
    {
        string st; decimal budget; decimal percentage; uint currency;
        do
        {
            do
            {
                Console.Write("Валюты:\n1. Доллары\n2. Евро\n3. Рубли\nВведите цифру, под которым находится нужная вам валюта: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out currency) && (0 < currency) && (currency < 4)));
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
            Calculation(budget, percentage, currency);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
