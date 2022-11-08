using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Caching;

namespace InMemoryCaching.Cache
{
    public class CustomMemoryCache : ICustomMemoryCache
    {
        private readonly IMemoryCache _cache;

        public CustomMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }
        public T GetValue<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public void SetValue(string key, object value)
        {
            _cache.Set(key, value, TimeSpan.FromMinutes(1));
        }
    }
}
