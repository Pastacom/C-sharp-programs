using System;
using System.Text;
class Program
{
    static void Main()
    {
        char[] letters = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'};
        string input = Console.ReadLine();
        string[] strings = input.Split(';');
        for (int i = 0; i < strings.Length; i++)
        {
            string[] words = strings[i].Split(' ');
            StringBuilder result = new StringBuilder();
            for (int j = 0; j < words.Length; j ++)
            {
                words[j] = words[j].ToUpper();
                for (int z = 0; z < words[j].Length; z ++)
                {             
                    if (string.Join("", letters).Contains(words[j][z]))
                    {
                        result.Append(words[j][z]);
                        words[j] = words[j].ToUpper();
                        break;
                    }
                    else
                    {
                        result.Append(words[j][z]);
                        words[j] = words[j].ToLower();
                    }
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}