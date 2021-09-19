using System;

class Program
    {
        static uint Ackermann(uint m, uint n)
        {
            if (m == 0)
                return n + 1;
            else if (m > 0 && n == 0)
                return Ackermann(m - 1, 1);
            else
                return Ackermann(m - 1, Ackermann(m, n - 1));
        }
    static void Main()
    {
        string st; uint n; uint m;
        do
        {
            do
            {
                Console.Write("Введите значение m: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out m)));
            do
            {
                Console.Write("Введите значение n: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out n)));
            Console.WriteLine($"A({m},{n}) = {Ackermann(m, n)}");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
