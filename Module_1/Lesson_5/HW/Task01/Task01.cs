using System;
class Program
{
    static bool Shift(ref char ch)
    {
        if ((int)'a' <= (int)ch && (int)ch <= (int)'z')
        {
            int code = (int)ch;
            for (int i = 0; i < 4; i ++)
            {
                code += 1;
            }
            code = code % (int)'z' < 5? code % (int)'z' + (int)'a' - 1 : code;
            ch = (char)code;
            return true;
        }
        else 
        {
            return false;
        }
        
        
    }

    static void Main()
    {
        char ch;
        do
        {
            do
            {
                Console.Write("Введите символ: ");
            } while (!(char.TryParse(Console.ReadLine(), out ch)));
            bool res = Shift(ref ch);
            if (res == true)
                Console.WriteLine($"Новый символ: {ch}");
            else
                Console.WriteLine("Неверный ввод");
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
