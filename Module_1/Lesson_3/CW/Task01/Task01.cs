using System;
class Program
{
    static bool Func1(bool x, bool y)
    {
        return !(x && y) && !(x || !y);
    }
    static void Func2(bool x, bool y, out bool res)
    {
        res = !(x & y) & !(x | !y);
    }
    static void Main()
    {
        bool[] bl = { true, false };
        foreach (bool i in bl)
        {
            foreach (bool j in bl)
            {
                Func2(i, j, out bool f);
                Console.WriteLine($"x = {i}, y = {j}, res1 = {Func1(i, j)}, res2 = {f}");
            }
        }
    }
}
