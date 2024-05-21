using HackerNewsAPI.Data;
using HackerNewsAPI.Service;
using Microsoft.Net.Http.Headers;

namespace HackerNewsAPI.ConfigurationExtentions
{
    public static class RegisterServicesConfigurationExtentions
    {
        public static IServiceCollection addDIServices(this IServiceCollection services)
        {
            services.AddScoped<IHackerNewsAPIData, HackerNewsAPIData>();
            services.AddScoped<IMemoryCacheService,MemoryCacheService>();
            services.AddScoped<IHackerNewsService, HackerNewsService>();
            return services;
        }
    }
}
