using System;
using System.Text;
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

    static string Line(char[] series)
    {
        string[] letters = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять"};
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < series.Length; i++)
        {
            if (series[i] >= '0' && series[i] <= '9')
            {
                sb.Append(letters[series[i] - '0'] + " ");
            }
            else
            {
                sb.Append(series[i] + " ");
            }
        }
        return sb.ToString();
    }
    static void Main()
    {
        int n = 10;
        int per = 30;
        char[] arr = Series(n, per);
        Array.ForEach(arr, x => Console.WriteLine(x + " "));
        Console.WriteLine(Line(arr));
    }
}
