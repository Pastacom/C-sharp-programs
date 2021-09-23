using System;
class Program
{
    static void GcdLcm(uint a, uint b, out uint gcd, out uint lcm)
    {
        uint c = 0; gcd = 0; lcm = 0; uint x = a; uint y = b;
        while (b != 0)
        {
            c = a;
            a = b;
            b = c % a;
        }
        gcd = a > b ? a : b;
        lcm = x * y / gcd;
    }
    static void Main()
    {
        uint a; uint b;
        do
        {
            do
            {
                Console.Write("Введите значение первого числа: ");
            } while (!(uint.TryParse(Console.ReadLine(), out a)));
            do
            {
                Console.Write("Введите значение второго числа: ");
            } while (!(uint.TryParse(Console.ReadLine(), out b)));
            GcdLcm(a, b, out uint gcd, out uint lcm);
            Console.WriteLine($"НОД({a}, {b}) = {gcd}\nНОК({a}, {b}) = {lcm}");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
