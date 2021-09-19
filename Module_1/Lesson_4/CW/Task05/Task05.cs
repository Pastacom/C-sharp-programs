using System;

class Program
{
    static double Total(double k, double r, uint n)
    {
        if (n == 0)
            return k;
        return Total(k * (1 + r / 100), r, n - 1);
    }
    static void Main()
    {
        string st; double k; double r; uint n;
        do
        {
            do
            {
                Console.Write("Введите значение k: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out k)));
            do
            {
                Console.Write("Введите значение r: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out r)));
            do
            {
                Console.Write("Введите значение n: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out n)));
            Console.WriteLine($"За {n} лет сумма составит: {Total(k, r, n)}");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
