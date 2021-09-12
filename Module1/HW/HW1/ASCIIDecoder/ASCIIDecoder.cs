using System;

namespace ASCIIDecoder
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите код символа в таблице ASCII: ");
            string st = Console.ReadLine();
            if (int.TryParse(st, out int code) && ((32 <= code ) && (code <= 127)))
            {
                Console.WriteLine("" + (char)code);
            }
            else
            {
                Console.WriteLine("Неверный формат входных данных");
            }
        }
    }
}
