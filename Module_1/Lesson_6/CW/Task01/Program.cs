using System;

class Program
{
    static bool Transform(ref uint num)
    {
        uint a = num % 10, b = (num % 100 - a) / 10, c = (num % 1000 - b - a) / 100;
        if (a > b)
        {
            if (b > c)
                num = a * 100 + b * 10 + c;
            else if (a > c)
                num = a * 100 + c * 10 + b;
            else
                num = c * 100 + a * 10 + b;
        }
        else
        {
            if (a > c)
                num = b * 100 + a * 10 + c;
            else if (b > c)
                num = b * 100 + c * 10 + a;
            else
                num = c * 100 + b * 10 + a;
        }
        return true;
    }
    static void Main()
    {
        uint number;
        do
        {
            Console.Write("Введите значение: ");
        } while (!uint.TryParse(Console.ReadLine(), out number));
        Transform(ref number);
        Console.WriteLine(number);
    }
}
