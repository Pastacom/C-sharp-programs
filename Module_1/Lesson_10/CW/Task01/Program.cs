using System;

class Program
{
    static char[] Series(int k, int ration)
    {
        char[] arr = new char[k];
        int letterCount = (int)(k * ration / 100.0);
        Random rnd = new Random();
        for (int i = 0; i < letterCount; i++)
        {
            arr[i] = (char)rnd.Next('a', 'z' + 1);
        }
        for (int i = letterCount; i < k; i++)
        {
            arr[i] = (char)rnd.Next('0', '9' + 1);
        }
        return arr;
    }
    static void Main()
    {
        int n = 10;
        int per = 30;
        Array.ForEach(Series(n, per), x => Console.WriteLine(x + " "));
    }
}
