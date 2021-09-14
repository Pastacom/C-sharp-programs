using System;
class Program
{
    static string MaxNum(string st)
    {
        string res = "";
        char[] nums = st.ToCharArray();
        int[] code = new int[3];
        for (int i = 0; i < 3; i ++)
        {
            code[i] = (int)nums[i];
        }
        Array.Sort(code);
        Array.Reverse(code);
        foreach (int cd in code)
        {
            res += (char)cd;
        }
        return res;
    }
    static void Main()
    {
        string st;
        do
        {
            do
            {
                Console.Write("Введите число: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out uint num) && (st.Length == 3)));
            Console.WriteLine($"Максимальное число, которое можно получить - это {MaxNum(st)}");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
