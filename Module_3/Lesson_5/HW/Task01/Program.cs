using System;

internal interface IFunction
{
    double Function(double x);
}

delegate double Calculate(double x);

class F : IFunction
{
    public Calculate Calculate { get; init; }

    public F(Calculate calculate)
    {
        Calculate = calculate;
    }

    public double Function(double x)
    {
        return Calculate(x); 
    } 
}

class G
{
    public F Func1 { get; init; }
    public F Func2 { get; init; }

    public G(F func1, F func2)
    {
        Func1 = func1;
        Func2 = func2;
    }

    public double GF(double x0)
    {
       return Func1.Function(Func2.Function(x0));
    }
}

class Program
{
    static void Main()
    {
        F func1 = new(x => Math.Pow(x, 2) - 4);
        F func2 = new(x => Math.Sin(x));
        G complexFunc = new(func1, func2);
        for (int i = 0; i <= 16; i ++)
        {
            Console.WriteLine($"G({i}pi/16) = {complexFunc.GF(i*Math.PI/16):F4}");
        }
    }
}
