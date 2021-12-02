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
        Console.WriteLine(@"Input command (add/remove/show) 
Or input empty line to exit");
        while ((command = Console.ReadLine()) != "exit")
        {
            string productName;
            switch (command)
            {
                case "add":
                    Console.Write("Input product name: ");
                    productName = Console.ReadLine();

                    RedisClient.AddOne($"TaskInt_{productName}");
                    Console.WriteLine("Ok.");
                    break;

                case "remove":
                    Console.Write("Input product name: ");
                    productName = Console.ReadLine();

                    if (RedisClient.Exist($"TaskInt_{productName}"))
                    {
                        RedisClient.RemoveOne($"TaskInt_{productName}");
                        Console.WriteLine("Ok.");
                    }
                    else
                    {
                        Console.WriteLine("This product is not in warehouse.");
                    }
                    break;

                case "show":
                    string[] keys = RedisClient.GetKeys("TaskInt_");
                    foreach (var key in keys)
                    {
                        long count = RedisClient.GetAsLong(key);
                        Console.WriteLine($"{key.Replace("TaskInt_", "")}: {count} items.");
                    }
                    break;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

    }
}