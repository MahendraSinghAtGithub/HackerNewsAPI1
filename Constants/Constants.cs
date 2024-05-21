namespace HackerNewsAPI.Constants
{
    public static class Constants
    {
        public static string HackerApiHttpClient => "AppSettings:HttpClients:HackerNewsApi:BaseUrl";
    }
    public static class HttpClientNames
    {
        public static string HackerNewsApi => "HackerNewsApi";
    }


    public static class HackerNewsEndpoints
    {
        public static string GetNewStories => "v0/newstories.json";
        public static string GetStoryById(int id) => $"v0/item/{id}.json";
    }
}
