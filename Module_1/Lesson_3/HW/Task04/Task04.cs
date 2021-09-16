using System;
using System.Linq;
class Program
{
    static void ClassroomMin(uint x, uint y, uint z)
    {
        Console.WriteLine($"Минимальный номер аудитории на этаже {x.ToString()[0]} - это {Math.Min(x % 100, Math.Min(y % 100, z % 100))}");
    }
    static void Main()
    {
        string st; uint x; uint y; uint z; bool flag = true;
        do
        {
            do
            {
                Console.Write("Введите номер первой аудитории: ");
                st = Console.ReadLine();
            } while (!(uint.TryParse(st, out x) && st.Length == 3));
            do
            {
                Console.Write("Введите номер второй аудитории: ");
                st = Console.ReadLine();
                flag = true;
                if (st[0] != x.ToString()[0])
                {
                    Console.WriteLine("\n***Аудитории должны быть на одном этаже***\n");
                    flag = false;
                }
            } while (!(uint.TryParse(st, out y) && st.Length == 3 && flag));
            do
            {
                Console.Write("Введите номер третьей аудитории: ");
                st = Console.ReadLine();
                flag = true;
                if (st[0] != x.ToString()[0])
                {
                    Console.WriteLine("\n***Аудитории должны быть на одном этаже***\n");
                    flag = false;
                }
            } while (!(uint.TryParse(st, out z) && st.Length == 3 && flag));
            ClassroomMin(x, y, z);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
