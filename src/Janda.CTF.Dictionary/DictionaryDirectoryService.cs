using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Janda.CTF
{
    public class DictionaryDirectoryService : IDictionaryDirectoryService
    {
        private readonly ILogger<DictionaryFileService> _logger;

        public DictionaryDirectoryService(ILogger<DictionaryFileService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> GetWords(string path, string pattern = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
