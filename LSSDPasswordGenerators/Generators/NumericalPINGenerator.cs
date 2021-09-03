using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSSDPasswordGenerators.Generators
{
    public class NumericalPINGenerator
    {
        private readonly CryptoRandom _random = new CryptoRandom();
        private string allowedCharacters = "9876543210";        

        public string GeneratePassword(int length)
        {
            StringBuilder password = new StringBuilder();

            for (int x = 0; x < length; x++)
            {
                password.Append(allowedCharacters[_random.Next(0, allowedCharacters.Length)]);
            }

            return password.ToString();
        }
        
    }
}
