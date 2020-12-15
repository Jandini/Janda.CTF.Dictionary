using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Janda.CTF
{
    public class DictionaryFileService : IDictionaryFileService
    {
        private readonly ILogger<DictionaryFileService> _logger;

        public DictionaryFileService(ILogger<DictionaryFileService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> GetWords(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
