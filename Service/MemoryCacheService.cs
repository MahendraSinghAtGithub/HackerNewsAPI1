using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsAPI.Service
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetDataFromMemoryCache<T>(string tagName)
        {
            return _memoryCache.Get<T>("Stories");
        }

        public void SetupInMemoryInMemoryCache<T>(T sotoriesData, string tagName, DateTimeOffset time)
        {
            _memoryCache.Set(tagName, sotoriesData, time);
        }
    }
}
