using System;
delegate double DelegateConvertTemperature(double param);
class TemperatureConverterImp
{
    public double FromCelciusToFarenheit(double t)
    {
        return 5 * (t - 32) / 9;
    }

    public double FromFarenheitToCelcius(double t)
    {
        return 9 * (t + 32) / 5;
    }
}

class StaticTempConverters
{
    public static double FromCelsiusToKelvin(double t)
    {
        return t + 273.15;
    }

    public static double FromKelvinToCelsius(double t)
    {
        return t - 273.15;
    }

    public static double FromCelsiusToRankin(double t)
    {
        return 9 * (t + 273.15) / 5;
    }

    public static double FromRankinToCelsius(double t)
    {
        return 5 * (t - 491.67) / 9;
    }

    public static double FromCelsiusToReaumur(double t)
    {
        return 4 * t / 5;
    }

    public static double FromReaumurToCelsius(double t)
    {
        return 5 * t / 4;
    }
}

class Program
{
    static void Main()
    {
        TemperatureConverterImp temp = new();
        DelegateConvertTemperature first = new(temp.FromCelciusToFarenheit);
        DelegateConvertTemperature second = new(temp.FromFarenheitToCelcius);
        Console.WriteLine(first(23));
        Console.WriteLine(second(23));
        Console.WriteLine();

        DelegateConvertTemperature[] convertTemperatures = {new(temp.FromCelciusToFarenheit),
                                                            new(StaticTempConverters.FromCelsiusToKelvin),
                                                            new(StaticTempConverters.FromCelsiusToRankin),
                                                            new(StaticTempConverters.FromCelsiusToReaumur)
                                                            };
        Console.Write("Введите температуру: ");
        string[] names = { "Цельсий", "Фаренгейт", "Кельвин", "Ранкин", "Реомюр" };
        double t = double.Parse(Console.ReadLine());
        Console.Write($"{names[0]}: {t:F3}");
        int counter = 1;
        foreach(var del in convertTemperatures)
        {
            Console.Write($"\n{names[counter]}: {del.Invoke(t):F3}");
            counter++;
        }
    }
}