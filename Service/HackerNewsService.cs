using AutoMapper;
using HackerNewsAPI.Constants;
using HackerNewsAPI.Data;
using HackerNewsAPI.Modal;
using HackerNewsAPI.Modal.DTO;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Security;

namespace HackerNewsAPI.Service
{
    public class HackerNewsService : IHackerNewsService
    {
        public readonly IHackerNewsAPIData _newsAPI;
        public readonly IMemoryCacheService _memoryCache;
        public readonly IMapper _mapper;
        public HackerNewsService(IHackerNewsAPIData newsAPI,IMemoryCacheService memoryCache,IMapper mapper)
        {
            _memoryCache = memoryCache;
            _mapper = mapper;
            _newsAPI = newsAPI;
        }


        public async Task<IEnumerable<StoryDTO>> GetNewStories()
        {


            var storiesCacheData = _memoryCache.GetDataFromMemoryCache<List<StoryDTO>>("Stories");
            if (storiesCacheData != null)
            {
                return storiesCacheData;
            }
            else
            {
                //Geting list of Stories id's
                var listOfTopStories = await _newsAPI.GetListOfNewStories();

                var stories = new List<Story>();

                //Creating tasks to pull the story by id
                var tasks = listOfTopStories.Select(async id =>
                {
                    Story story = await _newsAPI.GetStoryById(id);
                    stories.Add(story);
                });


                //Wait untill all tasks completed
                await Task.WhenAll(tasks.ToArray());


                //Mapping the story to storydto
                var storiesData = _mapper.Map<List<StoryDTO>>(stories);


                //memorycache expiration time
                var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

                //Saving the stories data to memory for 5 mins
                _memoryCache.SetupInMemoryInMemoryCache<List<StoryDTO>>(storiesData, "Stories", expirationTime);

                return storiesData;
            }

        }
    }
}
