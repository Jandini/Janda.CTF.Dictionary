using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Janda.CTF.Dictionary.Demo
{
    internal class DictionaryDemo : IDictionaryDemo
    {
        readonly IDictionaryService _dictionary;
        readonly ILogger<DictionaryDemo> _logger;

        public DictionaryDemo(IDictionaryService dictionary, ILogger<DictionaryDemo> logger)
        {
            _dictionary = dictionary;
            _logger = logger;
        }

        public void Run()
        {
            var words = _dictionary.GetWords();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var word in words)
            {            
                if (!word.StartsWith('#'))
                {

                }
            }            


            _logger.LogTrace("Word enumeration completed in {stopwatch}", stopwatch.Elapsed);
        }
    }
}