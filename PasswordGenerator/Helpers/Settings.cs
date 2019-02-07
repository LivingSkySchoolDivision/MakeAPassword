using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PasswordGenerator.Helpers
{
    public static class Settings
    {
        public static string dbConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["Internal"].ConnectionString;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}