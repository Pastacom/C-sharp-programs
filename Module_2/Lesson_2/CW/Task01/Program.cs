using System;

class MyComplex
{
    public double Re { get;}
    public double Im { get;}
    public MyComplex(double xre, double xim)
    { Re = xre; Im = xim; }
    public static MyComplex operator ++(MyComplex mc)
    {
        return new MyComplex(mc.Re + 1, mc.Im + 1);
    }
    public static MyComplex operator --(MyComplex mc)
    {
        return new MyComplex(mc.Re - 1, mc.Im - 1);
    }
    public double Mod() { return Math.Abs(Re * Re + Im * Im); }
    static public bool operator true(MyComplex f)
    {
        if (f.Mod() > 1.0) return true;
        return false;
    }
    static public bool operator false(MyComplex f)
    {
        if (f.Mod() <= 1.0) return true;
        return false;
    }
    static public MyComplex operator +(MyComplex a, MyComplex b)
    {
        return new MyComplex(a.Re + b.Re, a.Im + b.Im);
    }
    static public MyComplex operator -(MyComplex a, MyComplex b)
    {
        return new MyComplex(a.Re - b.Re, a.Im - b.Im);
    }
    static public MyComplex operator *(MyComplex a, MyComplex b)
    {
        return new MyComplex(a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + a.Re * b.Im);
    }
    static public MyComplex operator /(MyComplex a, MyComplex b)
    {
        return new MyComplex((a.Re * b.Re + a.Im * b.Im)/(Math.Pow(b.Re, 2) + Math.Pow(b.Im, 2)), (a.Im * b.Re - a.Re * b.Im)/ (Math.Pow(b.Re, 2) + Math.Pow(b.Im, 2)));
    }
    public override string ToString()
    {
        return Re + "+" + Im + "i";
    }
}
class Program
{
    static void Main(string[] args)
    {
        MyComplex comlex1 = new MyComplex(10, 20);
        MyComplex comlex2 = new MyComplex(2, 3);
        Console.WriteLine(comlex1 + comlex2);
        Console.WriteLine(comlex1 - comlex2);
        Console.WriteLine(comlex1 * comlex2);
        Console.WriteLine(comlex1 / comlex2);
    }
}
