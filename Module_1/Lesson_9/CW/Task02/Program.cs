using System;
using System.Text;
class Program
{
    static string ConvertHex2Bin(string HexNumber)
    {
        string hextable = "123456789ABCDEF";
        int number = 0;
        for (int i = 0; i < HexNumber.Length; i ++)
        {
            number += (int)Math.Pow(16, i) * (hextable.IndexOf(HexNumber[^(i + 1)]) + 1);
            Console.WriteLine("" + number);
        } 
        StringBuilder binNumber = new StringBuilder();
        while (number > 0)
        {
            binNumber.Append(number % 2);
            number /= 2;
        }
        char[] result = binNumber.ToString().ToCharArray();
        Array.Reverse(result);
        return string.Join("", result);
    }
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(ConvertHex2Bin(input));
    }
}