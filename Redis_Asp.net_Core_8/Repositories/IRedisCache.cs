namespace Redis_Asp.net_Core_8.Repositories
{
    public interface IRedisCache
    {
        T? GetData<T>(string key);
        void SetData<T>(string key, T value);
    }
}
