using Microsoft.Extensions.Caching.Distributed;
using System.Security;
using System.Text.Json;
using Taboo.ExternalServices.Abstracts;

namespace Taboo.ExternalServices.Implements
{
    public class RedisService(IDistributedCache _redis) : ICacheService
    {
        public async Task<T?> GetAsync<T>(string key)
        {
           string? data = await _redis.GetStringAsync(key);
            if (data == null) return default(T);
            return JsonSerializer.Deserialize<T>(data);
        }

        public async Task SetAsync<T>(string key, T data,int seconds = 30)
        {
            string json = JsonSerializer.Serialize(data);
            DistributedCacheEntryOptions opt = new DistributedCacheEntryOptions();
            opt.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(seconds);
            await _redis.SetStringAsync(key, json,opt);
        }
    }
}
