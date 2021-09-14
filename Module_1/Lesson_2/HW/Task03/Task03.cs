using System;
class Program
{
    static void RootsFinder(double a, double b, double c)
    {
        double discriminant = Math.Pow(b, 2) - 4 * a * c;
        switch(discriminant)
        {
            case < 0:
                Console.WriteLine("Уравнение не имеет корней!");
                break;
            case 0:
                double root = -b / (2 * a);
                Console.WriteLine($"Уравнение имеет один корень; x = {root}");
                break;
            case > 0:
                double root_1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                double root_2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Уравнение имеет два корня; x1 = {root_1}, x2 = {root_2}");
                break;
        }
        
    }
    static void Main()
    {
        string st; double a; double b; double c;
        do
        {
            do
            {
                Console.Write("Введите коэффициент A: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out a)));
            do
            {
                Console.Write("Введите коэффициент B: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out b)));
            do
            {
                Console.Write("Введите коэффициент C: ");
                st = Console.ReadLine();
            } while (!(double.TryParse(st, out c)));
            RootsFinder(a, b, c);
            Console.WriteLine("Для выхода нажмите Esc. Для продолжения нажмите любую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
