using Janda.Workbench;

namespace Janda.CTF.Dictionary.Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            // No error is reported !!!
            // WorkbenchConsole.Run<IDictionaryDemo, DictionaryDemo>((service) => service.Run());


            // Exception thrown: 'System.InvalidOperationException' in Microsoft.Extensions.DependencyInjection.dll
            WorkbenchConsole.Run<IDictionaryDemo, DictionaryDemo>((service) => service.Run(), 
                (services) => services.AddDictionaryServices());


            //new WorkbenchConsole()
            //    .WithServices((services) => services
            //        .AddTransient<IDictionaryDemo, DictionaryDemo>()
            //        .AddDictionary())

            //    .Run((provider) => provider.GetRequiredService<IDictionaryDemo>().Run());
        }
    }
}
