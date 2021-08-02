namespace Janda.CTF.Dictionary.Demo
{
    class Program
    {
        [CTF(Name = "Dictionary Demo")]
        static void Main(string[] args) => CTF.Run(args, (service) => service
            .AddDictionary());
    }
}

