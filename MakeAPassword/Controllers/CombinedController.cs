using MakeAPassword;
using Microsoft.AspNetCore.Mvc;

namespace MakeAPassword;

[ApiController]
[Route("API/[controller]")]

public class CombinedController : ControllerBase
{
    private readonly ComplexPasswordService _complexGenerator;
    private readonly WordPasswordService _wordGenerator;

    public CombinedController(ComplexPasswordService complex, WordPasswordService word)
    {
        _complexGenerator = complex;
        _wordGenerator = word;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new 
            {
                numeric4 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,4),
                numeric6 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,6),
                numeric8 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,8),
                numeric12 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,12),
                numeric16 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,16),
                numeric20 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,20),
                numeric24 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,24),
                numeric29 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,29),
                numeric32 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,32),
                numeric128 = _complexGenerator.Generate(ComplexCharacterSets.JustNumbers,128),
                complexSpecial8 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,8),
                complexSpecial12 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,12),
                complexSpecial20 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,20),
                complexSpecial25 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,25),
                complexSpecial32 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,32),
                complexSpecial64 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,64),
                complexSpecial128 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,128),
                complexAlphaNumeric8 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumeric,8),
                complexAlphaNumeric12 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumeric,12),
                complexAlphaNumeric20 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumeric,20),
                complexAlphaNumeric25 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumeric,25),
                complexAlphaNumeric32 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumeric,32),
                complexAlphaNumeric64 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumeric,64),
                complexAlphaNumeric128 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumeric,128),
                complexCiscoSafe8 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,8),
                complexCiscoSafe12 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,12),
                complexCiscoSafe20 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,20),
                complexCiscoSafe25 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,25),
                complexCiscoSafe32 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,32),
                complexCiscoSafe64 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,64),
                complexCiscoSafe128 = _complexGenerator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,128),
                ShortNoSpace = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.None, 16),
                ShortSpace = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.Spaces, 20),
                ShortSpecial = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.JustSpecialChars, 16),
                ShortSpecialComplex = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.Complex, 16),
                SimplifiedShortNoSpace = _wordGenerator.Generate(WordList.MediumComplexity, WordSeparators.None, 16),
                SimplifiedShortSpace = _wordGenerator.Generate(WordList.MediumComplexity, WordSeparators.Spaces, 20),
                SimplifiedShortSpecial = _wordGenerator.Generate(WordList.MediumComplexity, WordSeparators.JustSpecialChars, 16),
                SimplifiedShortSpecialComplex = _wordGenerator.Generate(WordList.MediumComplexity, WordSeparators.Complex, 16),
                MediumNoSpace = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.None, 20),
                MediumSpace = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.Spaces, 30),
                MediumSpecial = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.JustSpecialChars, 20),
                MediumSpecialComplex = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.Complex, 20),
                LongNoSpace = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.None, 30),
                LongSpace = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.Spaces, 36),
                LongSpecial = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.JustSpecialChars, 30),
                LongSpecialComplex = _wordGenerator.Generate(WordList.HighComplexity, WordSeparators.Complex, 30)
            });
    }

}