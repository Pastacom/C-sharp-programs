using System;

namespace Task05
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите катет a: ");
            if (!float.TryParse(Console.ReadLine(), out float a_side))
            {
                Console.WriteLine("Неверный формат входных данных");
            }
            Console.Write("Введите катет b: ");
            if (!float.TryParse(Console.ReadLine(), out float b_side))
            {
                Console.WriteLine("Неверный формат входных данных");
            }
            Console.WriteLine("Гипотенуза c = " + (Math.Pow(Math.Pow(a_side, 2.0) + Math.Pow(b_side, 2.0), 0.5)));
        }
    }
}
