using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку:");
        string st = Console.ReadLine();
        char[] vowels = { 'а', 'и', 'е', 'ё', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        string[] words = st.Split(" ");
        int counter = 0;
        foreach (string word in words)
        {
            if (word != "" && string.Join("", vowels).Contains(word.ToLower()[0]))
            {
                counter += 1;
            }
        }
        Console.WriteLine($"Ответ: {counter}");
    }
}