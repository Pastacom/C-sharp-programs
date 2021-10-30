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
}
class Program
{
    static void Main()
    {
        ConsolePlate cp = new ConsolePlate();
        ConsolePlate[] somePlates =
        {
            new ConsolePlate ('*', ConsoleColor.Red, ConsoleColor.White),
            cp,
            new ConsolePlate((char)90, ConsoleColor.Green, ConsoleColor.Green)
        };
        foreach (ConsolePlate conPl in somePlates)
        {
            Console.ForegroundColor = conPl.PlateForegroundColor;
            Console.BackgroundColor = conPl.PlateBackgroundColor;
            Console.Write(conPl.PlateChar);
        }
        somePlates[2].PlateBackgroundColor = ConsoleColor.DarkGray;
        Console.WriteLine();
        foreach (ConsolePlate conPl in somePlates)
        {
            Console.ForegroundColor = conPl.PlateForegroundColor;
            Console.BackgroundColor = conPl.PlateBackgroundColor;
            Console.Write(conPl.PlateChar);
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }
}
