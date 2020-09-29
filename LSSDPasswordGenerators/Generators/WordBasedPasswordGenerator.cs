using LSSDPasswordGenerators.WordLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSSDPasswordGenerators.Generators
{
    public class WordBasedPasswordGenerator
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        private readonly List<string> _separators = new List<string>() { "#", "&", ";", "!", ":", "_", "-", "--", "!!", "?", "?!", "*", "#", "+", ".", ",", ",SoI", ",And", ",The", ",WithThe", ",With", ",Without", ",But", ",ButWith", ",ButAlso", ",InsteadOf", ",Then", ",ThenA", ",AlongA", ",Because", ",AlongWith", ",AlongThe", ",OverThe", ",OverA", ",BecauseOf", ",BecauseOfThe", "More-Than", "Less-Than", ",Also", ",UntilThe", ",Plus", ",At", ",AtThe", ",AlongSideA", ",BesideThe", ",SaidThe", ",AsLongAs", ",AsSoonAs", ",OnlyIf", ",IfOnly", ",NowThat", ",SoThat", ",AsIf", ",AsThough", ",RatherThan", ",Whenever", ",Until", ",While", "YouSay?"};

        private readonly List<string> _wordlistMedium;
        private readonly List<string> _wordlistHigh;

        // Brackets MUST be two characters long or things will crash
        // Put sets in multiple times for higher chance to pick them
        private readonly List<string> _brackets = new List<string>()
        {
            "()","()","()","()","{}","[]","<>", "--"
        };

        private readonly int _separatorCount = 0;
        private readonly int _wordCountMedium = 0;
        private readonly int _wordCountHigh = 0;

        public WordBasedPasswordGenerator()
        {
            MediumComplexityWordList mediumWordList = new MediumComplexityWordList();
            HighComplexityWordList highWordList = new HighComplexityWordList();

            this._wordlistMedium = mediumWordList.Words;
            this._wordlistHigh = highWordList.Words;

            this._wordCountMedium = _wordlistMedium.Count();
            this._wordCountHigh = _wordlistHigh.Count();
            this._separatorCount = _separators.Count();

            // Scramble up the random number generator a little more just for kicks
            for (int x = 0; x < DateTime.Now.Second; x++)
            {
                _random.Next(0, 1);
            }
        }

        public int SeparatorCount()
        {
            return _separatorCount;
        }

        public int WordsInWordList(PasswordComplexity complexity)
        {
            if (complexity == PasswordComplexity.Medium)
            {
                return _wordCountMedium;
            }
            else
            {
                return _wordCountHigh;
            }
        }

        public double PotentialCombinations(PasswordComplexity complexity, int words)
        {
            return Math.Pow(WordsInWordList(complexity), words) * Math.Pow(_separatorCount, words - 1);
        }

        public string GeneratePassword(int length, PasswordComplexity complexity)
        {
            switch (complexity)
            {
                case PasswordComplexity.Medium:
                    return genPasswordFromWordlist(_wordlistMedium, length);
                case PasswordComplexity.High:
                    return genPasswordFromWordlist(_wordlistHigh, length);
                default:
                    return genPasswordFromWordlist(_wordlistHigh, length);
            }
        }

        // Low complexity = No separators
        // High copmlexity = Special character separators
        // Random numbers injected

        private string getRandomWord(List<string> wordlist)
        {
            if (_random.Next(0,50) == 0) 
            {
                return bracketize(capitalize(wordlist[_random.Next(0, wordlist.Count)]));
            } else
            {
                return wordlist[_random.Next(0, wordlist.Count)];
            }
        }

        private string getRandomSpacer()
        {
            return _separators[_random.Next(0, _separators.Count)];
        }

        private string capitalize(string word)
        {
            if (word.Length < 1)
            {
                return word;
            }

            return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
        }

        private string bracketize(string word)
        {
            int randBrackeType = _random.Next(0, _brackets.Count - 1);

            return (_brackets[randBrackeType][0] + word + _brackets[randBrackeType][1]);

        }
        
        private string genPasswordFromWordlist(List<string> wordlist, int length)
        {
            // Basically throw random words together until the length requirement is met
            List<string> words = new List<string>();

            // Add a starting word            
            words.Add(getRandomWord(wordlist));
            int characterCount = words[0].Length;
            
            // Add more words
            do
            {
                string spacerCharacter = getRandomSpacer();

                // Add a special character as a spacer between words
                words.Add(spacerCharacter);
                characterCount += spacerCharacter.Length;

                // Add the word
                string word = this.getRandomWord(wordlist);
                characterCount += word.Length;
                words.Add(word);
            }
            while (characterCount < length);

            // Once we have enough words, assemble the password
            StringBuilder assembledPassword = new StringBuilder();
            foreach (string word in words)
            {
                assembledPassword.Append(capitalize(word));
            }

            return assembledPassword.ToString();
        }

       
    }
}
