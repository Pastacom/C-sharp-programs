using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            RedisClient.Connect();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        string command, storageName, productName;
        Console.WriteLine(@"Input command (add/get/exist/exit)");
        while ((command = Console.ReadLine()) != "exit")
        {
            Console.Write("Input storage name: ");
            storageName = Console.ReadLine();
            switch (command)
            {
                case "add":
                    Console.Write("Input product name: ");
                    productName = Console.ReadLine();

                    RedisClient.Add($"TaskSet_{storageName}", productName);
                    Console.WriteLine("Ok.");
                    break;

                case "exist":
                    Console.Write("Input product name: ");
                    productName = Console.ReadLine();

                    if (RedisClient.ExistSet($"TaskSet_{storageName}"))
                    {
                        if(RedisClient.Exist($"TaskSet_{storageName}", productName))
                        {
                            Console.WriteLine("Товар есть на этом складе.");
                        }
                        else
                        {
                            Console.WriteLine("Товара нет на этом складе.");
                        } 
                    }
                    else
                    {
                        Console.WriteLine("Такого склада не существует.");
                    }
                    break;

                case "get":
                    string[] keys = RedisClient.GetKeys($"TaskSet_{storageName}");
                    foreach (var key in keys)
                    {
                        Console.WriteLine($"product: {key}");
                    }
                    break;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

    }
}