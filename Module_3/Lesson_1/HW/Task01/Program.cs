using System;

delegate int Cast(double number);

class Program
{
    static void Main()
    {
        Cast first = delegate (double firstParam)
        {
            return (int)firstParam + (int)firstParam % 2;
        };
        Console.WriteLine(first(57.23123));
        Console.WriteLine(first(2.9));
        Console.WriteLine(first(3.0));
        Console.WriteLine(first(8321.0201));
        Console.WriteLine("\n");

        Cast second = delegate (double secondParam)
        {
            return int.Parse($"{secondParam:E}"[($"{secondParam:E}".IndexOf('E') + 1)..]);
        };

        Console.WriteLine(second(37128.041));
        Console.WriteLine(second(3.23231));
        Console.WriteLine(second(0.503));
        Console.WriteLine(second(0.0002));
        Console.WriteLine("\n");

        Cast multiCast = first + second;

        Console.WriteLine(multiCast(57.23123));
        Console.WriteLine(multiCast(2.9));
        Console.WriteLine(multiCast(37128.041));
        Console.WriteLine(multiCast(0.0002));
        Console.WriteLine("\n");

        Cast lambda1 = n => (int)n + (int)n % 2;
        Console.WriteLine(lambda1(57.23123));
        Console.WriteLine(lambda1(2.9));
        Console.WriteLine(lambda1(3.0));
        Console.WriteLine(lambda1(8321.0201));
        Console.WriteLine("\n");

        Cast lambda2 = k => int.Parse($"{k:E}"[($"{k:E}".IndexOf('E') + 1)..]);
        Console.WriteLine(second(37128.041));
        Console.WriteLine(second(3.23231));
        Console.WriteLine(second(0.503));
        Console.WriteLine(second(0.0002));
        Console.WriteLine("\n");

        multiCast += lambda1;
        multiCast += lambda2;
        foreach (var func in multiCast.GetInvocationList())
        {
            Console.WriteLine(func.DynamicInvoke(3.3));
        }
        Console.WriteLine("\n");

        multiCast -= lambda1;
        foreach (var func in multiCast.GetInvocationList())
        {
            Console.WriteLine(func.DynamicInvoke(3.3));
        }
        Console.WriteLine("\n");

        multiCast -= first;
        foreach (var func in multiCast.GetInvocationList())
        {
            Console.WriteLine(func.DynamicInvoke(3.3));
        }

    }
}
