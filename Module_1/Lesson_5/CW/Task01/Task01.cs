using System;
class Program
{

    static void Sums(uint number, out uint sumEven, out uint sumOdd)
    {
        sumEven = 0; sumOdd = 0;
        while (number > 0)
        {
            sumEven += number % 10;
            number /= 10;
            sumOdd += number % 10;
            number /= 10;
        }
    }
    static void Main()
    {
        string st; uint number;
        do
        {
            do
            {
                Console.Write("Введите число: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out number)));
            Sums(number, out uint sumEven, out uint sumOdd);
            Console.WriteLine($"Сумма четных = {sumEven}, сумма нечетных = {sumOdd}");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
