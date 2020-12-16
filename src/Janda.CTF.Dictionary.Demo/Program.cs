using Janda.Workbench;

namespace Janda.CTF.Dictionary.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkbenchConsole.Run<IDictionaryDemo, DictionaryDemo>(args, (service) => service.Run(), 
               (services) => services.AddDictionary());

        }
    }
}

