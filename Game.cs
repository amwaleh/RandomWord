namespace Game
{

    public class RandomWordGame(){

        private readonly List<string> _words = [];

        public RandomWordGame(List<string> words) : this()
        {
            _words = words;
        }
                    

        public string GetWord()
        {
            Random randomWord = new Random();
            int index = randomWord.Next(_words.Count);
            string word = _words[index];
            return word;
        }
        
            
        
    }
}