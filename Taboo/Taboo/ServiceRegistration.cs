using Microsoft.Extensions.Caching.Memory;
using Taboo.Services.Abstracts;
using Taboo.Services.Implements;

namespace Taboo
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IWordsService, WordService>();
            services.AddScoped<IBannedWordService, BannedWordService>();
            services.AddScoped<IGamesService, GameService>();
            
            return services;
        }
    }
}
