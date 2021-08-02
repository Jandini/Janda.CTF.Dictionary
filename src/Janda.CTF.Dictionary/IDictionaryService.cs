using System.Collections.Generic;

namespace Janda.CTF
{
    public interface IDictionaryService
    {
        IEnumerable<string> GetWords();
    }
}
