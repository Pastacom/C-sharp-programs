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

    public static void AddOne(string key)
    {
        if (Exist(key))
        {
            database.StringIncrement(key);
        }
        else
        {
            database.StringSet(key, 1);
        }
    }

    public static void RemoveOne(string key)
    {
        if (database.StringDecrement(key) <= 0)
        {
            database.KeyDelete(key);
        }
    }

    public static bool Exist(string key)
    {
        return database.KeyExists(key);
    }

    public static long GetAsLong(string key)
    {
        return (long)database.StringGet(key);
    }

    public static string[] GetKeys(string keyBeginning = "")
    {
        return server.Keys(pattern: $"{keyBeginning}*")
            .Select(x => x.ToString())
            .ToArray();
    }
}