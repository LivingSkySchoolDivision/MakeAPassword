using PasswordGenerator.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        private string getWord()
        {
            string word = string.Empty;

            if ((_random.Next() % 2) == 0)
            {
                word = GetRandomNoun();
            } else
            {
                word = GetRandomAdjective();
            }

            // Randomly capitalize the word
            /*
            if (_random.Next() % 3 == 0)
            {
                word = word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1); 
            }*/

            // Return the word
            return word;
        }

        private string capitalize(string word)
        {
            return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
        }


        public string GetRandomPassword(int minLength)
        {            
            string separator = this.GetRandomSeparator();
            string password = string.Empty;


            if (_random.Next() % 5 == 0)
            {
                password = capitalize(this.GetRandomAdjective()) + capitalize(this.getWord()) + capitalize(this.getWord());
            }
            else
            {
                password = this.getWord() + separator + this.getWord();
                if (password.Length < minLength)
                {
                    password += separator + this.getWord();
                }
            }

            
            return password;
        }

    }
}