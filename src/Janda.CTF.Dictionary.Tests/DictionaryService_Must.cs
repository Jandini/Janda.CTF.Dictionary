using Janda.Xunit.Logging;
using Xunit;
using Xunit.Abstractions;

namespace Janda.CTF.Dictionary.Tests
{
    public class DictionaryService_Must
    {
        private readonly XunitLogger<DictionaryService> _logger;

        public DictionaryService_Must(ITestOutputHelper output)
        {
            _logger = new XunitLogger<DictionaryService>(output);
        }


        [Fact]
        public void GetWords_Return_Words()
        {
            var dictionary = new DictionaryService(_logger);
            var words = dictionary.GetWords();

            Assert.NotNull(words);
        }



        [Fact]
        public void GetWords_Enumerate_Words()
        {
            const int EXPECTED_WORD_COUNT = 1273820;
            var dictionary = new DictionaryService(_logger);
            var words = dictionary.GetWords();
            var wordCount = 0;

            foreach (var word in words)
                if (!word.StartsWith('#'))
                    wordCount++;

            Assert.Equal(EXPECTED_WORD_COUNT, wordCount);
        }
    }
}