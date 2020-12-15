using System.IO;
using System.IO.Compression;
using Xunit;

namespace Janda.CTF.Dictionary.Tests
{
    public class DictonaryCompression
    {       
        const string COMPRESSED_DICTIONARY_TARGET_DIR = @"..\..\..\..\Janda.CTF.Dictionary";


        /// <summary>
        /// This test is designed to create compressed version of the dictionary.
        /// </summary>
        [Fact]
        public void Dictonary_WriteCompressed()
        {
            const int BUFFER_SIZE = 65536;

            var buffer = new byte[BUFFER_SIZE];

            const string DICTIONARY_FILE_NAME = "directory-list-2.3-big.txt";

            using var input = File.OpenRead(DICTIONARY_FILE_NAME);
            using var output = File.Open(Path.Combine(COMPRESSED_DICTIONARY_TARGET_DIR, Path.ChangeExtension(DICTIONARY_FILE_NAME, "gz")), FileMode.Create);
            using var gzip = new GZipStream(output, CompressionLevel.Fastest);

            int bytes;

            do
            {
                bytes = input.Read(buffer, 0, buffer.Length);
                gzip.Write(buffer, 0, bytes);

            } while (bytes > 0);
        }
    }
}
