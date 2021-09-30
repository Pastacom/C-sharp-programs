using System;

class Program
{
    static public void Print(char[] mas)
    {
        Console.WriteLine();
        foreach (var value in mas)
        {
            Console.Write(value);
        }
    }
    static void Main()
    {
        int.TryParse(Console.ReadLine(), out int k);
        char[] arr = new char[k];
        Random rng = new Random();
        for (int i = 0; i < k; i ++)
        {
            arr[i] = (char)rng.Next('A', 'Z' + 1);
        }
        Print(arr);
        char[] newArr = new char[k];
        Array.Copy(arr, newArr, k);
        Array.Sort(newArr);
        Print(newArr);
        Array.Reverse(newArr);
        Print(newArr);
    }
}