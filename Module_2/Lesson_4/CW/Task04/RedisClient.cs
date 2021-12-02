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

    public static void Add(string storage, string product)
    {
        database.SetAdd(storage, product);
    }

    public static bool ExistSet(string key)
    {
        return database.KeyExists(key);
    }
    public static bool Exist(string storage, string product)
    {
        return database.SetContains(storage, product);
    }

    public static string[] GetKeys(string storage)
    {
        return database.SetMembers(storage)
            .Select(x => x.ToString())
            .ToArray();
    }
}