using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

public static class RedisClient
{
    private static ConnectionMultiplexer redis;
    private static IDatabase database;
    private static IServer server;

    public static void Connect(string connectionString = "localhost")
    {
        redis = ConnectionMultiplexer.Connect("redis-16775.c293.eu-central-1-1.ec2.cloud.redislabs.com:16775,password=fN9aazT03T1o9UPSNuu3tmPiE8yCL2YC,ConnectTimeout=10000,allowAdmin=true");
        database = redis.GetDatabase();
        server = redis.GetServer("redis-16775.c293.eu-central-1-1.ec2.cloud.redislabs.com", 16775);
    }

    public static void Add(string key, string version)
    {
        if (Exist(key))
        {
            database.ListRightPush(key + "b", Get(key));
            if (database.ListLength(key + "b") > 5)
            {
                database.ListLeftPop(key + "b");
            }
            database.StringSet(key, version);
        }
        else
        {
            database.StringSet(key, version);
        }
    }

    public static void Back(string key)
    {
        if (Exist(key+"b"))
        {
            if(database.ListLength(key + "b") > 0)
            {
                database.StringSet(key, database.ListRightPop(key + "b"));
            }
            else
            {
                database.KeyDelete(key);
                database.KeyDelete(key + "b");
                Console.WriteLine("Приложение удалено.");
            }
        }
        else
        {
            database.KeyDelete(key);
            Console.WriteLine("Приложение удалено.");
        }
    }

    public static bool Exist(string key)
    {
        return database.KeyExists(key);
    }

    public static string Get(string key)
    {
        if (Exist(key))
        {
            return database.StringGet(key);
        }
        else
        {
            return "Не существует такого приложения.";
        }
    }
}