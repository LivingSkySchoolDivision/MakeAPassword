using PasswordGenerator.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace PasswordGenerator
{
    public class WordRepository
    {

        private Random _random = new Random(Guid.NewGuid().GetHashCode());
        private List<string> Adjectives = new List<string>();
        private List<string> Nouns = new List<string>();
        private List<string> Separators = new List<string>() { "-", " ", "!", "~", "@", "$", "%", "*", "^", "?", ".", ";", "" };

        public WordRepository()
        {            
            try
            {                
                // Load list of adjectives, nouns, and separators
                using (SqlConnection connection = new SqlConnection(Settings.dbConnectionString))
                {
                    // Adjectives
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = connection;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "SELECT * FROM adjectives";
                        sqlCommand.Connection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string parsedValue = dataReader["val"].ToString().Trim().ToLower();
                                if (!string.IsNullOrEmpty(parsedValue))
                                {
                                    if (!Adjectives.Contains(parsedValue))
                                    {
                                        Adjectives.Add(parsedValue);
                                    }
                                }
                            }
                        }
                        sqlCommand.Connection.Close();
                    }

                    // Nouns
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = connection;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "SELECT * FROM nouns";
                        sqlCommand.Connection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string parsedValue = dataReader["val"].ToString().Trim().ToLower();
                                if (!string.IsNullOrEmpty(parsedValue))
                                {
                                    if (!Nouns.Contains(parsedValue))
                                    {
                                        Nouns.Add(parsedValue);
                                    }
                                }
                            }
                        }
                        sqlCommand.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to connect to internal database.\nException was: " + ex.Message);
            }


        }

        private string GetRandomAdjective()
        {
            return Adjectives[_random.Next(0, Adjectives.Count)];
        }

        private string GetRandomNoun()
        {
            return Nouns[_random.Next(0, Nouns.Count)];
        }

        private string GetRandomSeparator()
        {
            return Separators[_random.Next(0, Separators.Count)];
        }


        private string getWord()
        {
            if ((_random.Next() % 2) == 0)
            {
                return GetRandomAdjective();
            } else
            {
                return GetRandomNoun();
            }            
        }

        private string capitalize(string word)
        {
            if (word.Length < 1)
            {
                return word;
            }

            return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
        }


        public string GetRandomPassword(int minLength, bool splitWithSpecialCharacters, bool simpleSeparators, bool Capitalize)
        {            
            string separator = splitWithSpecialCharacters ? this.GetRandomSeparator() : string.Empty;
            if (simpleSeparators && splitWithSpecialCharacters)
            {
                separator = "-";
            }

            List<string> words = new List<string>();

            // Start with one word, so when we add one in the loop, it has at least two words
            string firstWord = GetRandomAdjective();
            words.Add(firstWord);
            int characterCount = firstWord.Length;

            // Add more words
            do
            {
                if (splitWithSpecialCharacters)
                {
                    words.Add(separator);
                    characterCount += separator.Length;
                }

                string word = this.getWord();
                characterCount += word.Length;
                words.Add(word);                
            }
            while (characterCount < minLength);
                                    
            // Assemble the password
            StringBuilder assembledPassword = new StringBuilder();
            foreach(string word in words)
            {
                if (!splitWithSpecialCharacters || Capitalize)
                {
                    assembledPassword.Append(capitalize(word));
                }
                else
                {
                    assembledPassword.Append(word);
                }                
            }

            return assembledPassword.ToString();
        }

    }
}