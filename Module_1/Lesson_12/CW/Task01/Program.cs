using System;
using System.Linq;
class Program
{
    static bool Palindrome(int number)
    {
        string st = number.ToString();
        if (st[0..(st.Length / 2 + st.Length % 2)] == string.Join("", st[(st.Length / 2)..].Reverse().ToArray()))
        {
            return true;
        }
        return false;
    }
    static int Sum(int number)
    {
        int result = 0;
        while (number > 0)
        {
            result += number % 10;
            number /= 10;
        }
        return result;
    }
    static int MaxNumber(int number)
    {
        int result = 0;
        while (number > 0)
        {
            result = Math.Max(result, number % 10);
            number /= 10;
        }
        return result;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Random rng = new Random();
        for(int i = 0; i < n; i ++)
        {
            arr[i] = rng.Next(1, 10001);
            Console.Write(arr[i] + " ");
        }
        var result = from elem in arr
                     where (elem % 3 == 0) && (elem.ToString().Length == 2)
                     select elem;
        Console.WriteLine();
        foreach (int elem in result)
            Console.Write(elem + " ");
        result = from elem in arr
                 where Palindrome(elem)
                 orderby elem
                 select elem;
        Console.WriteLine();
        foreach (int elem in result)
            Console.Write(elem + " ");
        result = arr.OrderBy(elem => Sum(elem)).ThenBy(elem => elem);
        Console.WriteLine();
        foreach (int elem in result)
            Console.Write(elem + " ");
        result = from elem in arr
                 where elem.ToString().Length == 4
                 select elem;
        Console.WriteLine();
        Console.WriteLine(result.Count() > 0 ? result.Sum() : "Нету чисел длиной 4");
        result = from elem in arr
                 where elem.ToString().Length == 2
                 select elem;
        Console.WriteLine(result.Count() > 0? result.Min(): "Нету чисел длиной 2");
        result = from elem in arr
                 select MaxNumber(elem);
        foreach (int elem in result)
            Console.Write(elem + " ");
    }
}