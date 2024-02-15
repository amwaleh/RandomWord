namespace Game
{

    public class RandomWordGame()
    {

        private readonly List<string> _words = [];

        public RandomWordGame(List<string> words) : this()
        {
            _words = words;
        }


        public string GetWord()
        {
            Random randomWord = new();
            if(_words.Count == 0)
            {
                return "No words available";
            }
            int index = randomWord.Next(_words.Count);
            return _words[index];
        }



    }
}