using HackerNewsAPI.Constants;
using HackerNewsAPI.Modal;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security;

namespace HackerNewsAPI.Data
{
    public class HackerNewsAPIData : IHackerNewsAPIData
    {
        private readonly IHttpClientFactory _httpClient;
        public HackerNewsAPIData(IHttpClientFactory httpClientFactory) { _httpClient = httpClientFactory; }

        public async Task<List<int>> GetListOfNewStories()
        {
            using (var httpClient = _httpClient.CreateClient(HttpClientNames.HackerNewsApi))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, HackerNewsEndpoints.GetNewStories);
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadAsStringAsync();
                    var listOfTopStories = JsonConvert.DeserializeObject<List<int>>(model);
                    if (listOfTopStories.Count > 200)
                        return listOfTopStories.Take(200).ToList();

                    return listOfTopStories;
                }
                else
                {
                    var ex = new SecurityException("Unable to get stories.");
                }
            }
            return null;
        }

        public async Task<Story> GetStoryById(int id)
        {
            using (var httpClient = _httpClient.CreateClient(HttpClientNames.HackerNewsApi))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, HackerNewsEndpoints.GetStoryById(id));
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadAsStringAsync();
                    var story = JsonConvert.DeserializeObject<Story>(model);
                    return story;
                }
                else
                {
                    var ex = new SecurityException("Unable to get story.");
                }
            }
            return null;
        }
    }
}
