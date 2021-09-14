using System;
class Program
{
    static void IntFraction(decimal num)
    {
        Console.WriteLine($"Целая часть числа = {(int)num}");
        Console.WriteLine($"Дробная часть числа = {num - (int)num}");
    }
    static void PowSqrt(double num)
    {
        Console.WriteLine($"Квадрат числа равен = {(decimal)Math.Pow(num, 2)}");
        if (num > 0)
            Console.WriteLine($"Корень числа равен = {(decimal)Math.Sqrt(num)}");
    }
    static void Main()
    {
        string st; decimal num;
        do
        {
            do
            {
                Console.Write("Введите число: ");
                st = Console.ReadLine();
            } while (!(decimal.TryParse(st, out num)));
            IntFraction(num);
            PowSqrt((double)num);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
