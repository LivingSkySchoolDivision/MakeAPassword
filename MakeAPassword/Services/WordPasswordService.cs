using System.Text;
using System.Security.Cryptography;

namespace MakeAPassword;

public class WordPasswordService 
{
    public string Generate(List<string> wordlist, List<string> separators, int minLength)
    {
        // Basically throw random words together until the length requirement is met
        List<string> words = new List<string>();

        // Add a starting word            
        words.Add(getRandomWord(wordlist));
        int characterCount = words[0].Length;


        // Add more words until length requirement is met
        do
        {
            string spacerCharacter = getRandomWord(separators);

            // Add a special character as a spacer between words
            words.Add(spacerCharacter);
            characterCount += spacerCharacter.Length;

            // Add the word
            string word = this.getRandomWord(wordlist);
            characterCount += word.Length;
            words.Add(word);
        }
        while (characterCount < minLength);


        // Once we have enough words, assemble the password
        StringBuilder assembledPassword = new StringBuilder();
        foreach (string word in words)
        {
            assembledPassword.Append(capitalize(word));
        }
        return assembledPassword.ToString();        
    }
    
    private string capitalize(string word)
    {
        if (word.Length < 1)
        {
            return word;
        }

        return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
    }

    private string getRandomWord(List<string> wordlist)
    {
        if (wordlist.Count > 0) {
            return wordlist[RandomNumberGenerator.GetInt32(0, wordlist.Count)];
        } else {
            return string.Empty;
        }
    }

}