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
        private List<string> Separators = new List<string>();

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
                                string parsedValue = dataReader["val"].ToString().Trim();
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
                                string parsedValue = dataReader["val"].ToString().Trim();
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

                    // Separators
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = connection;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "SELECT * FROM separators";
                        sqlCommand.Connection.Open();
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string parsedValue = dataReader["val"].ToString().Trim();
                                if (!string.IsNullOrEmpty(parsedValue))
                                {
                                    if (!Separators.Contains(parsedValue))
                                    {
                                        Separators.Add(parsedValue);
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


        private string getWord(bool forceAdjective)
        {
            if (forceAdjective)
            {
                return this.GetRandomAdjective();
            }            

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
            return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
        }


        public string GetRandomPassword(int minLength, bool splitWithSpecialCharacters, bool simpleSeparators)
        {            
            string separator = splitWithSpecialCharacters ? this.GetRandomSeparator() : string.Empty;
            if (simpleSeparators && splitWithSpecialCharacters)
            {
                separator = "-";
            }

            List<string> words = new List<string>();
            int characterCount = 0;
            int wordCount = 0;
            do
            {
                string word = this.getWord(characterCount == 0);
                wordCount++;
                characterCount += word.Length;
                words.Add(word);

                if (splitWithSpecialCharacters)
                {
                    words.Add(separator);
                    characterCount++;
                }
            }
            while ((characterCount < minLength) && (wordCount < 2));

            // Remove the last separater if using separators
            if (splitWithSpecialCharacters)
            {
                words.RemoveAt(words.Count-1);
            }

            // Assemble the password
            StringBuilder assembledPassword = new StringBuilder();
            foreach(string word in words)
            {
                if (splitWithSpecialCharacters)
                {
                    assembledPassword.Append(word);
                } else
                {
                    assembledPassword.Append(capitalize(word));
                }
            }

            return assembledPassword.ToString();
        }

    }
}