
namespace HackerNewsAPI.Service
{
    public interface IMemoryCacheService
    {
        /// <summary>
        /// Get the Data from memory from memory cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagName"></param>
        /// <returns></returns>
        T GetDataFromMemoryCache<T>(string tagName);

        /// <summary>
        /// Setup data into cache 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sotoriesData"></param>
        /// <param name="tagName"></param>
        /// <param name="time"></param>
        void SetupInMemoryInMemoryCache<T>(T sotoriesData, string tagName, DateTimeOffset time);
    }
}