using System;

public class ConsolePlate
{
    char _plateChar;
    ConsoleColor _plateForegroundColor;
    ConsoleColor _plateBackgroundColor;
    public ConsolePlate(char plateChar = 'A', ConsoleColor plateForeColor = ConsoleColor.White,
    ConsoleColor plateBackColor = ConsoleColor.Black)
    {
        PlateChar = plateChar;
        PlateForegroundColor = plateForeColor;
        PlateBackgroundColor = plateBackColor;
    }
    public char PlateChar
    {
        set
        {
            if (value >= 'A' && value <= 'Z')
                _plateChar = value;
            else
                _plateChar = 'A';
        }
        get { return _plateChar; }
    }
    public ConsoleColor PlateForegroundColor
    {
        set
        {
            if (value != _plateBackgroundColor)
                _plateForegroundColor = value;
        }
        get { return _plateForegroundColor; }
    }
    public ConsoleColor PlateBackgroundColor
    {
        set
        {
            if (value != _plateForegroundColor)
                _plateBackgroundColor = value;
        }
        get { return _plateBackgroundColor; }
    }
    public void ChangeColor()
    {
        Console.ForegroundColor = PlateForegroundColor;
        Console.BackgroundColor = PlateBackgroundColor;
    }
}
class Program
{
    static void Main()
    {
        ConsolePlate cp1 = new ConsolePlate('X', ConsoleColor.White, ConsoleColor.DarkRed);
        ConsolePlate cp2 = new ConsolePlate('O', ConsoleColor.White, ConsoleColor.Magenta);
        int n;
        do
        {
            Console.Write("Введите размер поля: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n >= 35);
        bool flag = true;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (flag)
                {
                    cp1.ChangeColor();
                    Console.Write(cp1.PlateChar);
                }
                else
                {
                    cp2.ChangeColor();
                    Console.Write(cp2.PlateChar);
                }
                flag = !flag;
            }
            if (n % 2 == 0)
                flag = !flag;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
    }
}
