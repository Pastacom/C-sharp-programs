using System;
using StackExchange.Redis;

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

        string query;
        int i = 0;
        while (i++ < 10)
        {
            Console.WriteLine("Введите данные: ");
            query = Console.ReadLine();

            string[] inputLines = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = inputLines[0];
            string newVersion = inputLines[1];

            if (RedisClient.Exist(name))
            {
                Console.WriteLine(RedisClient.GetSet(name, newVersion));
            }
            else
            {
                RedisClient.Set(name, newVersion);
                Console.WriteLine("Приложение было добавлено.");
            }
        }
    }
}