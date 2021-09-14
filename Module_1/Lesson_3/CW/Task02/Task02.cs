using System;
class Program
{
    static void Func1()
    {
        for (int i = 1; i < 11; i++)
            Console.WriteLine("" + Math.Pow(i, 2));

    }
    static void Func2()
    {
        int i = 1;
        while (i < 11)
        {
            Console.WriteLine("" + Math.Pow(i, 2));
            i += 1;
        }
    }
    static void Func3()
    {
        int i = 1;
        do
        {
            Console.WriteLine("" + Math.Pow(i, 2));
            i += 1;
        } while (i < 11);

    }
    static void Main()
    {
        Func1();
        Func2();
        Func3();
    }
}
