using System;

namespace Task04
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите U: ");
            if (!float.TryParse(Console.ReadLine(), out float voltage))
                {
                Console.WriteLine("Неверный формат входных данных");
                    }
            Console.Write("Введите R: ");
            if (!float.TryParse(Console.ReadLine(), out float resistance))
            {
                Console.WriteLine("Неверный формат входных данных");
            }
            Console.WriteLine("I = " + (voltage / resistance));
            Console.WriteLine("P = " + (Math.Pow(voltage, 2.0) / resistance));
        }
    }
}
