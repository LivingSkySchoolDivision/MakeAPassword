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
        private int minPasswordLength = 10;

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

        public string GetRandomAdjective()
        {
            return Adjectives[_random.Next(0, Adjectives.Count)];
        }

        public string GetRandomNoun()
        {
            return Nouns[_random.Next(0, Nouns.Count)];
        }

        public string GetRandomSeparator()
        {
            return Separators[_random.Next(0, Separators.Count)];
        }

        public string GetRandomPassword()
        {            
            string separator = this.GetRandomSeparator();
            string password = string.Empty;

            // Use a different method sometimes
            if ((_random.Next() % 3) == 0)
            {
                password = this.GetRandomNoun() + separator + this.GetRandomNoun();
                if (password.Length < minPasswordLength)
                {
                    password += separator + this.GetRandomNoun();
                }
            }
            else
            {
                password = this.GetRandomAdjective() + separator + this.GetRandomNoun();
                if (password.Length < minPasswordLength)
                {
                    password += separator + this.GetRandomNoun();
                }
            }
            return password;
        }

    }
}