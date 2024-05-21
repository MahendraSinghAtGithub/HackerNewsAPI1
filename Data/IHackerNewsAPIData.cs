using HackerNewsAPI.Modal;

namespace HackerNewsAPI.Data
{
    public interface IHackerNewsAPIData
    {
        /// <summary>
        /// Getting the list of new stories Id's
        /// </summary>
        /// <returns></returns>
        Task<List<int>> GetListOfNewStories();

        /// <summary>
        /// Getting the Story by the Id
        /// </summary>
        /// <returns></returns>
        Task<Story> GetStoryById(int id);
    }
}