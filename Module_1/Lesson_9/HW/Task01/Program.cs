using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку:");
        string st = Console.ReadLine();
        string[] words = st.Split(" ");
        foreach (string word in words)
        {
            if (word != "")
            {
                Console.Write(word + " ");
            }
        }
    }
}
