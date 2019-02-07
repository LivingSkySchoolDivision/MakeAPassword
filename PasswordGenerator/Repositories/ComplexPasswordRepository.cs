using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PasswordGenerator
{
    public class ComplexPasswordRepository
    {
        private Random _random = new Random(Guid.NewGuid().GetHashCode());
        private string allowedCharacters_justAlpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private string allowedCharacters_all = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+=-?][{}|,.";

        public string GetRandomPassword(int Length)
        {
            StringBuilder password = new StringBuilder();
            string allowedCharacters = "";

            if (_random.Next() % 2 == 0)
            {
                allowedCharacters = allowedCharacters_all;
            } else
            {
                allowedCharacters = allowedCharacters_justAlpha;
            }

            for(int x = 0; x < Length; x++)
            {
                password.Append(allowedCharacters[_random.Next(0,allowedCharacters.Length)]);
            }

            return password.ToString();
        }

    }
}