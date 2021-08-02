using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Janda.CTF.Dictionary.Demo
{
    public class B001 : IChallenge
    {
        private readonly ILogger<B001> _logger;

        public B001(ILogger<B001> logger)
        {
            _logger = logger;
        }        


        public void Run()
        {
            var words = new HashSet<string>();

            const string COMPRESSED_DICTIONARY_TARGET_DIR = @"..\..\..\src\Janda.CTF.Dictionary";
            const string COMPRESSED_DICTIONARY_FILE_NAME = "embedded.gz";

            var path = Path.Combine(COMPRESSED_DICTIONARY_TARGET_DIR, COMPRESSED_DICTIONARY_FILE_NAME);
            var counter = 0;

            _logger.LogInformation("Building compressed {name}", COMPRESSED_DICTIONARY_FILE_NAME);

            using var gzip = new GZipStream(File.Open(path, FileMode.Create), CompressionLevel.Fastest);

            foreach (var file in Directory.GetFiles(Path.Combine("Challenges", nameof(B001)), "*.txt")) 
            {
                _logger.LogInformation("Reading {file}", new FileInfo(file).Name);

                using var input = File.OpenRead(file);               
                using var reader = new StreamReader(input);

                foreach (var word in ReadWords(reader))
                {
                    if (words.Add(word))
                    {
                        gzip.Write(Encoding.UTF8.GetBytes(word));
                        counter++;
                    }
                }
            }

            _logger.LogInformation("{count} words written to {file}", counter, path);
        }


        private IEnumerable<string> ReadWords(StreamReader reader)
        {
            string word;

            while ((word = reader.ReadLine()) != null)
                if (!string.IsNullOrEmpty(word) && !word.StartsWith("#"))
                    yield return (word + '\n');
        }
    }
}
