using System;

class Program
{
    static double Polinom(double x)
    {
        double res = x * (x * (x * (12 * x + 9) - 3) + 2) - 4;
        return res;
    }
    static void Main()
    {
        double arg;
        do
        {
            do
            {
                Console.Write("Введите значение x: ");
            } while (!double.TryParse(Console.ReadLine(), out arg));
            Console.WriteLine($"F(x) = {Polinom(arg)}");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
