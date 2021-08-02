using Microsoft.Extensions.DependencyInjection;

namespace Janda.CTF
{
    public static class DictionaryServiceExtensions
    {
        public static IServiceCollection AddDictionaryServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IDictionaryService, DictionaryService>()
                .AddTransient<IDictionaryFileService, DictionaryFileService>()
                .AddTransient<IDictionaryDirectoryService, DictionaryDirectoryService>();
        }

        public static IServiceCollection AddDictionary(this IServiceCollection services)
        {
            return services.AddTransient<IDictionaryService, DictionaryService>();
        }

        public static IServiceCollection AddDictionaryFile(this IServiceCollection services)
        {
            return services.AddTransient<IDictionaryFileService, DictionaryFileService>();
        }

        public static IServiceCollection AddDictionaryDirectory(this IServiceCollection services)
        {
            return services.AddTransient<IDictionaryDirectoryService, DictionaryDirectoryService>();
        }        
    }
}
