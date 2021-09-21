using System;
class Program
{

    static void Sums(uint k)
    {
        for (int n = 1; n <= k; n++)
        {
            double s = 0; 
            for (int i = 1; i <= n; i++)
            {
                s += (i + 0.3) / (3 * i * i + 5);
            }
            Console.WriteLine($"S(n = {n}) = {s}");

        }
    }
    static void Main()
    {
        string st; uint k;
        do
        {
            do
            {
                Console.Write("Введите число: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out k)));
            Sums(k);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
