namespace WebAPI.Interfaces
{
    public interface IRedisCache
    {
        Task<T?> GetCacheData<T>(string key) where T : class;
        Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expirationTime);
        Task<object> RemoveCacheData(string key);
    }
}