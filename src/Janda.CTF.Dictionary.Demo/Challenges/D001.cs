using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Janda.CTF.Dictionary.Demo
{
    public class D001 : IChallenge
    {
        private readonly ILogger<D001> _logger;
        readonly IDictionaryService _dictionary;

        public D001(ILogger<D001> logger, IDictionaryService dictionary)
        {
            _logger = logger;
            _dictionary = dictionary;
        }

        public void Run()
        {
            var words = _dictionary.GetWords();
            var stopwatch = new Stopwatch();
            var counter = 0;
            stopwatch.Start();

            foreach (var word in words)
            {
                if (!word.StartsWith('#'))
                {
                    counter++;
                }
            }

            _logger.LogTrace("{count} words enumeration completed in {stopwatch}", counter, stopwatch.Elapsed);
        }
    }
}
