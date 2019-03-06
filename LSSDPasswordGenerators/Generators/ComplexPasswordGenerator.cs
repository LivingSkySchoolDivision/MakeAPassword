using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSSDPasswordGenerators.Generators
{
    public class ComplexPasswordGenerator
    {
        private Random _random = new Random(Guid.NewGuid().GetHashCode());
        private string allowedCharacters_low = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private string allowedCharacters_high = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+=-?][{}|,.:;`~";

        public string GeneratePassword(int Length, PasswordComplexity complexity)
        {
            switch(complexity)
            {             
                case PasswordComplexity.Medium:
                    return generateMediumComplexityPassword(Length);
                case PasswordComplexity.High:
                    return generateHighComplexityPassword(Length);
                default:
                    return generateHighComplexityPassword(Length);
            }
        }
        
        private string generateMediumComplexityPassword(int Length)
        {
            StringBuilder password = new StringBuilder();

            for (int x = 0; x < Length; x++)
            {
                password.Append(allowedCharacters_low[_random.Next(0, allowedCharacters_low.Length)]);
            }

            return password.ToString();
        }

        private string generateHighComplexityPassword(int Length)
        {
            StringBuilder password = new StringBuilder();

            for (int x = 0; x < Length; x++)
            {
                password.Append(allowedCharacters_high[_random.Next(0, allowedCharacters_high.Length)]);
            }

            return password.ToString();
        }
    }
}
