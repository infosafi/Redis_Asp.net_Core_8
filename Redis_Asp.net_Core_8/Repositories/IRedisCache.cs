namespace Redis_Asp.net_Core_8.Repositories
{
    public interface IRedisCache
    {
        // Getting data from Redis Cache
        T? GetData<T>(string key);
        // Set Data in Redis Cache
        void SetData<T>(string key, T value);
    }
}
