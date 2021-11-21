using System;
using System.IO;
using System.Runtime.Serialization;
class MyException : Exception
{
    public MyException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {
        try
        {
            int a = 1;
            int b = 0;
            Console.WriteLine(a/b);
        }
        catch(DivideByZeroException)
        {
            Console.WriteLine("Нельзя делить на ноль!");
        }


        try
        {
            int[] array = new int[10];
            Console.WriteLine(array[11]);
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Индекс за границами массива.");
        }


        try
        {
            File.ReadAllText("somestuff");
        }
        catch(FileNotFoundException)
        {
            Console.WriteLine("Не существует такого файла.");
        }


        try
        {
            Directory.Delete("somestuff");
        }
        catch(DirectoryNotFoundException)
        {
            Console.WriteLine("Не существует директории с таким именем.");
        }


        try
        {
            string str = "somestuff";
            int a = int.Parse(str);
        }
        catch(FormatException)
        {
            Console.WriteLine("Невозможно преобразовать такую строку в число.");
        }


        try
        {
            string st = "somestuff";
            while (true)
            {
                st += st + st + st;
            }
        }
        catch(OutOfMemoryException)
        {
            Console.WriteLine("Нехватка памяти.");
        }


        try
        {
            object str = "somestuff";
            int a = (int)str;
        }
        catch(InvalidCastException)
        {
            Console.WriteLine("Неправильное приведение типа.");
        }


        try
        {
            string str = null;
            Console.WriteLine("somestuff".IndexOf(str));
        }
        catch(ArgumentNullException)
        {
            Console.WriteLine("В метод передан аргумент, имеющий значение null.");
        }


        try
        {
            double a = double.NaN;
            Console.WriteLine(Math.Sign(a));

        }
        catch(ArithmeticException)
        {
            Console.WriteLine("Нельзя найти знак типа не число.");
        }


        try
        {
            int[] array = null;
            Console.WriteLine(array.Length);
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Массив имел значение null.");
        }
        try
        {
            Exception exception = new MyException("Что-то пошло не так.");
            throw exception;
        }
        catch(MyException exception)
        {
            Console.Write($"Наше исключение. Сообщение исключения: {exception.Message}");
        }
    }
}