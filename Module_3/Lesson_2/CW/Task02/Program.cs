using System;

class Converter
{
    public string Convert(string str, ConvertRule cr)
    {
        return cr.Invoke(str);
    }
}
delegate string ConvertRule(string param);
class Program
{
    public static string RemoveDigits(string str)
    {
        char[] arr = str.ToCharArray();
        Predicate<char> p = (char x) => !"123456789".Contains(x);
        return string.Join("", Array.FindAll(arr, p));
    }

    public static string RemoveSpaces(string str)
    {
        char[] arr = str.ToCharArray();
        Predicate<char> p = (char x) => x != ' ';
        return string.Join("", Array.FindAll(arr, p));
    }

    static void Main()
    {
        Converter converter = new();
        ConvertRule first = new(RemoveDigits);
        ConvertRule second = new(RemoveSpaces);
        string[] str = { "12hello2 34!", "abcd lde13" };
        foreach (var st in str)
        {
            Console.WriteLine(converter.Convert(st, first));
            Console.WriteLine(converter.Convert(st, second));
            Console.WriteLine();
        }
        Console.WriteLine("*****************");
        ConvertRule third = first;
        third += second;
        foreach (var st in str)
        {
            Console.WriteLine(converter.Convert(st, third));
            Console.WriteLine();
        }
        Console.WriteLine("*****************");
        foreach (var st in str)
        {
            foreach (ConvertRule del in third.GetInvocationList())
            {
                Console.WriteLine(converter.Convert(st, del));

            }
            Console.WriteLine();
        }


    }
}