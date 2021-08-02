using System.Collections.Generic;

namespace Janda.CTF
{
    public interface IDictionaryDirectoryService
    {
        IEnumerable<string> GetWords(string path, string pattern = null);
    }
}
