using System;
using StackExchange.Redis;

public static class RedisClient
{
    private static ConnectionMultiplexer redis;
    private static IDatabase database;

    public static void Connect(string connectionString = "localhost")
    {
        redis = ConnectionMultiplexer.Connect("redis-16775.c293.eu-central-1-1.ec2.cloud.redislabs.com:16775,password=fN9aazT03T1o9UPSNuu3tmPiE8yCL2YC,ConnectTimeout=10000,allowAdmin=true");
        database = redis.GetDatabase();
    }

    public static string GetSet(string key, string value)
    {
        return database.StringGetSet(key, value);
    }

    public static bool Exist(string key)
    {
        return database.KeyExists(key);
    }

    public static void Set(string key, string value)
    {
        database.StringSet(key, value);
    }
    public static string Get(string key)
    {
        return database.StringGet(key);
    }
}