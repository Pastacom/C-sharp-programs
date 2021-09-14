using System;
class Program
{
    static void Reverse(string st)
    {
        char[] ls = st.ToCharArray();
        Array.Reverse(ls);
        string res =  string.Join("", ls);
        Console.WriteLine($"Число в обратном порядке: {res}");
    }
    static void Main()
    {
        string st;
        do
        {
            do
            {
                Console.Write("Введите 4-х значное число: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out uint num) && (st.Length == 4)));
            Reverse(st);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
