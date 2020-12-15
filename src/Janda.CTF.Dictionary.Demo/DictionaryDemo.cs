namespace Janda.CTF.Dictionary.Demo
{
    internal class DictionaryDemo : IDictionaryDemo
    {
        readonly IDictionaryService _dictionary;

        public DictionaryDemo(IDictionaryService dictionary)
        {
            _dictionary = dictionary;
        }

        public void Run()
        {
            var words = _dictionary.GetWords();    

            foreach (var word in words)
            {

            }
        }
    }
}