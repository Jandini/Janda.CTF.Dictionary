using System.Collections.Generic;

namespace Janda.CTF
{
    public interface IDictionaryFileService
    {
        IEnumerable<string> GetWords(string path);
    }
}
