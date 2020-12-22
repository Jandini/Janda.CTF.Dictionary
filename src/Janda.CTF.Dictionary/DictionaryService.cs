using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace Janda.CTF
{
    public class DictionaryService : IDictionaryService
    {

        private readonly ILogger<DictionaryService> _logger;


        public DictionaryService(ILogger<DictionaryService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> GetWords()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var directory = new EmbeddedFileProvider(assembly, typeof(DictionaryService).Namespace)
                .GetDirectoryContents(string.Empty);
            
            foreach (var file in directory)
            {
                _logger.LogTrace("Reading embedded {dictionary}", file.Name);
                using var gzip = new GZipStream(file.CreateReadStream(), CompressionMode.Decompress);

                var bytes = 0;
                var sb = new StringBuilder();
                var buffer = new byte[65536];

                do
                {
                    bytes = gzip.Read(buffer, 0, buffer.Length);

                    for (var i = 0; i < bytes; i++)
                    {
                        switch (buffer[i])
                        {
                            case (byte)'\r':
                                break;

                            case (byte)'\n':
                                yield return sb.ToString();
                                sb.Clear();
                                break;

                            default:
                                sb.Append((char)buffer[i]);
                                break;
                        }
                    }
                } while (bytes > 0);
            };
        }        
    }
}
