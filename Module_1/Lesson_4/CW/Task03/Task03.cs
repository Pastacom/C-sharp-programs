using System;

class Program
    {
        static uint Counter(uint n)
        {
            if (n == 0)
                return 0;
            else
                return 1 + Counter(n / 10);

        }
    static void Main()
    {
        string st; uint n;
        do
        {
            do
            {
                Console.Write("Введите значение n: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out n) && n > 0));
            Console.WriteLine($"Число {n} состоит из {Counter(n)} цифр(ы)");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}