using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string str = " " + Console.ReadLine() + " ";
        Regex regex = new Regex(@"\s[a-zA-Zа-яА-Я]{4}\s");
        var matches = regex.Matches(str);
        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
        str = Console.ReadLine();
        regex = new Regex(@"\w*[aа]{1}");
        matches = regex.Matches(str);
        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
        str = Console.ReadLine();
        regex = new Regex(@"\d+");
        matches = regex.Matches(str);
        int maxlength = 0;
        foreach (Match match in matches)
        {
            maxlength = Math.Max(maxlength, match.Length);
        }
        Console.WriteLine(maxlength);
    }
}