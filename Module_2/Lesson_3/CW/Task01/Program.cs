using System;
class ArithmeticProgression
{
    public int A0 { get; private set; }
    public int D { get; private set; }
    public static int count = 0;
    public static int count2;
    static ArithmeticProgression()
    {
        Console.WriteLine("static construct");
    }
    public ArithmeticProgression(int a0, int d)
    {
        A0 = a0; D = d;
        count++;
    }
    public ArithmeticProgression() : this(0, 0) { }
    public int this[int index]
    {
        get
        {
            return A0 + D * (index);
        }
        private set
        {
        }
    }
    ~ArithmeticProgression()
    {
        Console.WriteLine("Destroy object");
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine(1);
        Console.WriteLine(ArithmeticProgression.count2);
        Console.WriteLine(2);
        ArithmeticProgression progression = new ArithmeticProgression(2, 10);
        Console.WriteLine(progression[3]);
        Console.WriteLine(progression[5]);
        new ArithmeticProgression(2, 10);
        new ArithmeticProgression(2, 10);
        new ArithmeticProgression(2, 10);
        Console.WriteLine(ArithmeticProgression.count);
    }
}
