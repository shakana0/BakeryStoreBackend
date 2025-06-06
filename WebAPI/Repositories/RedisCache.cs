using Newtonsoft.Json;
using StackExchange.Redis;
using WebAPI.Interfaces;

namespace WebAPI.Repositories
{
    public class RedisCache : IRedisCache
    {
        private readonly IDatabase _database;

        public RedisCache(IConnectionMultiplexer connectionMultiplexer)
        {
            _database = connectionMultiplexer.GetDatabase();
        }


        public async Task<T?> GetCacheData<T>(string key) where T : class
        {
            var value = await _database.StringGetAsync(key);
            if (value.IsNullOrEmpty)
            {
                Console.WriteLine($"No data found for key: {key}");
                return default;
            }
            try
            {
                var deserializedData = JsonConvert.DeserializeObject<T?>(value);
                if (deserializedData == null)
                {
                    Console.WriteLine($"failed to deserialize JSON for key: {value}");
                }
                else
                {
                    Console.WriteLine($"Successfully deserialized: {key}");
                }

                return deserializedData;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON deserialization error: {ex.Message}");
                return default;
            }
        }


        public async Task<object> RemoveCacheData(string key)
        {
            bool _isKeyExists = await _database.KeyExistsAsync(key);
            if (_isKeyExists)
            {
                await _database.KeyDeleteAsync(key);
            }
            return false;
        }

        public async Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.UtcNow);
            var serializedValue = JsonConvert.SerializeObject(value);

            var isSet = await _database.StringSetAsync(key, serializedValue, expiryTime);

            if (isSet)
            {
                Console.WriteLine($"Redis Cache Stored: Key = {key}");
            }
            else
            {
                Console.WriteLine($"Redis Cache Failed: Key = {key}");
            }

            return isSet;
        }

    }
}