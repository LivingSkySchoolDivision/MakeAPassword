using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LSSDPasswordGenerators.Generators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSSDPasswordGenCore.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> PasswordsWordsLow { get; set; }
        public List<string> PasswordsWordsMedium { get; set; }
        public List<string> PasswordsWordsHigh { get; set; }
        public List<string> PasswordsComplexLow { get; set; }
        public List<string> PasswordsComplexHigh { get; set; }
        public List<string> PasswordsYubikeyLow { get; set; }
        public List<string> PasswordsYubikeyHigh { get; set; }
        public List<string> PasswordsTwentyNine { get; set; }
        public List<string> PasswordsPin4 { get; set; }
        public List<string> PasswordsPin6 { get; set; }
        public List<string> PasswordsPin8 { get; set; }
        public Stopwatch stopwatch = new Stopwatch();
        private const int _numPasswordsToGenerate = 7;

        public void OnGet()
        {
            stopwatch.Reset();
            stopwatch.Start();
            ComplexPasswordGenerator complexGen = new ComplexPasswordGenerator();
            WordBasedPasswordGenerator wordGen = new WordBasedPasswordGenerator();
            NumericalPINGenerator pinGen = new NumericalPINGenerator();
            this.PasswordsComplexHigh = new List<string>();
            this.PasswordsComplexLow = new List<string>();
            this.PasswordsWordsHigh = new List<string>();
            this.PasswordsWordsMedium = new List<string>();
            this.PasswordsWordsLow = new List<string>();
            this.PasswordsYubikeyLow = new List<string>();
            this.PasswordsYubikeyHigh = new List<string>();
            this.PasswordsTwentyNine = new List<string>();
            this.PasswordsPin4 = new List<string>();
            this.PasswordsPin6 = new List<string>();
            this.PasswordsPin8 = new List<string>();

            for (int x = 0; x < _numPasswordsToGenerate; x++)
            {
                PasswordsWordsHigh.Add(wordGen.GeneratePassword(18, PasswordComplexity.High));
                PasswordsWordsMedium.Add(wordGen.GeneratePassword(16, PasswordComplexity.Medium));
                PasswordsWordsLow.Add(wordGen.GeneratePassword(12, PasswordComplexity.Medium));
                PasswordsComplexHigh.Add(complexGen.GeneratePassword(64, PasswordComplexity.High));
                PasswordsComplexLow.Add(complexGen.GeneratePassword(64, PasswordComplexity.Medium));
                PasswordsPin4.Add(pinGen.GeneratePassword(4));
                PasswordsPin6.Add(pinGen.GeneratePassword(6));
                PasswordsPin8.Add(pinGen.GeneratePassword(8));
            }

            // So passwords are sorted strongest on bottom
            for (int x = 0; x < _numPasswordsToGenerate; x++)
            {
                PasswordsYubikeyHigh.Add(complexGen.GeneratePassword(32, PasswordComplexity.High));
                PasswordsYubikeyLow.Add(complexGen.GeneratePassword(32, PasswordComplexity.Medium));
                PasswordsTwentyNine.Add(complexGen.GeneratePassword(29, PasswordComplexity.Medium));
                PasswordsWordsHigh.Add(wordGen.GeneratePassword(18, PasswordComplexity.High));
                PasswordsWordsMedium.Add(wordGen.GeneratePassword(16, PasswordComplexity.Medium));
                PasswordsWordsLow.Add(wordGen.GeneratePassword(12, PasswordComplexity.Medium));
            }
            stopwatch.Stop();
        }
    }
}