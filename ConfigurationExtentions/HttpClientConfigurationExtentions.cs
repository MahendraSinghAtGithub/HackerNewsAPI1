using HackerNewsAPI.Constants;
using Microsoft.Net.Http.Headers;

namespace HackerNewsAPI.ConfigurationExtentions
{
    public static class HttpClientConfigurationExtentions
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var hackerApiBaseAddress = configuration.GetSection(Constants.Constants.HackerApiHttpClient).Value;
            services.AddHttpClient(HttpClientNames.HackerNewsApi, client =>
            {
                client.BaseAddress = new Uri(hackerApiBaseAddress);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

            });

            return services;
        }
    }
}
