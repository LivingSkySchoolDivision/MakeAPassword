﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LSSDPasswordGenerators.Generators
{
    public class ComplexPasswordGenerator
    {
        private readonly CryptoRandom _random = new CryptoRandom();

        
        public string GeneratePassword(int length, PasswordComplexity complexity)
        {
            switch(complexity)
            {             
                case PasswordComplexity.Medium:
                    return generateMediumComplexityPassword(length);
                case PasswordComplexity.High:
                    return generateHighComplexityPassword(length);
                default:
                    return generateHighComplexityPassword(length);
            }
        }
        
        private string generateMediumComplexityPassword(int length)
        {
            StringBuilder password = new StringBuilder();

            for (int x = 0; x < length; x++)
            {
                password.Append(allowedCharacters_low[_random.Next(0, allowedCharacters_low.Length)]);
            }

            return password.ToString();
        }

        private string generateHighComplexityPassword(int length)
        {
            StringBuilder password = new StringBuilder();

            for (int x = 0; x < length; x++)
            {
                password.Append(allowedCharacters_high[_random.Next(0, allowedCharacters_high.Length)]);
            }

            return password.ToString();
        }
        
        private string generateCiscoSafePassword(int length)
        {
            StringBuilder password = new StringBuilder();

            for (int x = 0; x < length; x++)
            {
                password.Append(allowedCharacters_ciscosafe[_random.Next(0, allowedCharacters_ciscosafe.Length)]);
            }

            return password.ToString();
        }
    }
}
