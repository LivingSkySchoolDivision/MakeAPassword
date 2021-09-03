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
        private RNGCryptoServiceProvider _rngprovider = new RNGCryptoServiceProvider();
        
        private string allowedCharacters_low = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private string allowedCharacters_high = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+=-?][{}|,.:;`~";

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

        private int nextRandomInt() 
        {   
            byte[] oneByte = new byte[1];                     
            _rngprovider.GetBytes();
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
    }
}
