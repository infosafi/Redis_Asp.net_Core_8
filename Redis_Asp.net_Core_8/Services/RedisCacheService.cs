using Microsoft.Extensions.Caching.Distributed;
using Redis_Asp.net_Core_8.Repositories;
using System.Text.Json;

namespace Redis_Asp.net_Core_8.Services
{
    public class RedisCacheService(IDistributedCache? cache) : IRedisCache
    {

        public T? GetData<T>(string key)
        {
           var data= cache?.GetString(key);
            if(data is null)
                return default(T?);

            return JsonSerializer.Deserialize<T>(data);
        }

        public void SetData<T>(string key, T value)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5), // Cache for 10 minutes
                SlidingExpiration = TimeSpan.FromMinutes(5) // Cache will expire if no activity within 5 minutes
            };

            cache?.SetString(key,JsonSerializer.Serialize(value),options);
        }
    }
}
