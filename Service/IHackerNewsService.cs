using HackerNewsAPI.Modal;
using HackerNewsAPI.Modal.DTO;

namespace HackerNewsAPI.Service
{
    public interface IHackerNewsService
    {
        /// <summary>
        /// Getting The Latest 200 stories
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StoryDTO>> GetNewStories();       
        
    }
}