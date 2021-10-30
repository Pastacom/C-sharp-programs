using System;

class Fraction
{
    public int Num { get; }
    public int Den { get; }
    public Fraction(int n, int d)
    {
        if (n >= 0 && d > 0) { Num = n; Den = d; return; }
        if (n >= 0 && d < 0) { Num = -n; Den = -d; return; }
        if (n <= 0 && d > 0) { Num = n; Den = d; return; }
        if (n <= 0 && d < 0) { Num = -n; Den = -d; return; }
        Console.WriteLine("Нулевой знаменатель: {0}/{1}", n, d);
        return;
    }
    public override string ToString()
    {
        return String.Format("{0}/{1}", Num, Den);
    }
    static public Fraction operator -(Fraction f)
    {
        return new Fraction(-f.Num, f.Den);
    }
    static public Fraction operator +(Fraction f1, Fraction f2)
    {
        int n = f1.Num * f2.Den + f1.Den * f2.Num;
        int d = f1.Den * f2.Den;
        return new Fraction(n, d);
    }
    static public bool operator <(Fraction f1, Fraction f2)
    {
        if (f1.Num * f2.Den < f1.Den * f2.Num) return true;
        else return false;
    }
    static public bool operator >(Fraction f1, Fraction f2)
    {
        if (f1.Num * f2.Den > f1.Den * f2.Num) return true;
        else return false;
    }
}
class Program
{
    static void Main()
    {
        Fraction a = new Fraction(1, 4);
        Console.WriteLine(a);
        Console.WriteLine(-a);
        Fraction b = new Fraction(3, 5);
        Console.WriteLine(a + b);
        Fraction c;
        if (a > b)
        {
            c = a;
        }
        else
        {
            c = b;
        }
        Console.WriteLine(c);
    }
}
