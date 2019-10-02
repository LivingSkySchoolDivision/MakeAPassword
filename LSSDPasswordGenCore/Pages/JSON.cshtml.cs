using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSSDPasswordGenerators.Generators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSSDPasswordGenCore.Pages
{
    public class JSONModel : PageModel
    {
        readonly ComplexPasswordGenerator complexGen = new ComplexPasswordGenerator();
        readonly WordBasedPasswordGenerator wordGen = new WordBasedPasswordGenerator();

        public JsonResult OnGet()
        {
            var output = new 
            { 
                WordShort = wordGen.GeneratePassword(12, PasswordComplexity.High),
                WordLong = wordGen.GeneratePassword(20, PasswordComplexity.High),
                ComplexShort = complexGen.GeneratePassword(12, PasswordComplexity.Medium),
                ComplexLoong = complexGen.GeneratePassword(18, PasswordComplexity.Medium),
                Complex2Short = complexGen.GeneratePassword(12, PasswordComplexity.High),
                Complex2Long = complexGen.GeneratePassword(18, PasswordComplexity.High)
            };

            return new JsonResult(output);
        }
    }
}