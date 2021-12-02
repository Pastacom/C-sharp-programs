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

        string command;
        Console.WriteLine(@"Input command (add/back/get/exit)");
        while ((command = Console.ReadLine()) != "exit")
        {
            string version, name;
            Console.Write("Input name of app: ");
            name = Console.ReadLine();
            switch (command)
            {
                case "add":
                    Console.Write("Input new version: ");
                    version = Console.ReadLine();

                    RedisClient.Add($"TaskVersion_{name}", version);
                    Console.WriteLine("Ok.");
                    break;

                case "back":
                    if (RedisClient.Exist($"TaskVersion_{name}"))
                    {
                        RedisClient.Back($"TaskVersion_{name}");
                        Console.WriteLine("Ok.");
                    }
                    else
                    {
                        Console.WriteLine("Приложения не существует.");
                    }
                    break;

                case "get":
                    Console.WriteLine(RedisClient.Get($"TaskVersion_{name}"));
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

    }
}