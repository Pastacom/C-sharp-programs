using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку:");
        string st = Console.ReadLine();
        string[] words = st.Split(" ");
        int counter = 0;
        foreach (string word in words)
        {
            if (word != "" && word.Length > 4)
            {
                counter += 1;
            }
        }
        Console.WriteLine($"Ответ: {counter}");
    }
}