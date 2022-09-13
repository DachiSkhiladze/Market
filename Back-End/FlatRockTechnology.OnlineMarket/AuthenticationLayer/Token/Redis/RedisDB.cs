using FlatRockTechnology.OnlineMarket.Models.Redis;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthenticationLayer.Token.Redis
{
    public class RedisDB : IRedisDB
    {
        private readonly IDatabase cache;
        public RedisDB()
        {
            cache = lazyConnection.Value.GetDatabase();
        }

        public async Task InsertAsync(string refreshToken, RedisTokenValueModel value)
        {
            string jsonValue = JsonSerializer.Serialize(value);
            var entryInRedis = await cache.StringSetAsync(refreshToken, jsonValue);
        }

        public async Task<RedisTokenValueModel?> GetAsync(string refreshToken)
        {
            var jsonValue = await cache.StringGetAsync(refreshToken);
            if (jsonValue.IsNullOrEmpty)
            {
                return null;
            }
            RedisTokenValueModel? valueObject;
            valueObject = JsonSerializer.Deserialize<RedisTokenValueModel>(json: jsonValue);
            return valueObject;
        }

        public async Task DeleteAsync(string refreshToken)
        {
            await cache.KeyDeleteAsync(refreshToken);
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = "shoptoken.redis.cache.windows.net:6380,password=pJH6zdeta7K4TWFKzJpvD1RWvLe4uKs77AzCaGALTKg=,ssl=True,abortConnect=False";
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}