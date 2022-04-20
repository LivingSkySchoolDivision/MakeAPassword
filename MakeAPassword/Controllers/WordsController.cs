using MakeAPassword;
using Microsoft.AspNetCore.Mvc;

namespace MakeAPassword;

[ApiController]
[Route("api/[controller]")]

public class WordsController : ControllerBase
{
    private readonly WordPasswordService _generator;

    public WordsController(WordPasswordService generator)
    {
        _generator = generator;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(
            new {
                ShortNoSpace = _generator.Generate(WordList.HighComplexity, WordSeparators.None, 16),
                ShortSpace = _generator.Generate(WordList.HighComplexity, WordSeparators.Spaces, 20),
                ShortSpecial = _generator.Generate(WordList.HighComplexity, WordSeparators.JustSpecialChars, 16),
                ShortSpecialComplex = _generator.Generate(WordList.HighComplexity, WordSeparators.Complex, 16),
                SimplifiedShortNoSpace = _generator.Generate(WordList.MediumComplexity, WordSeparators.None, 16),
                SimplifiedShortSpace = _generator.Generate(WordList.MediumComplexity, WordSeparators.Spaces, 20),
                SimplifiedShortSpecial = _generator.Generate(WordList.MediumComplexity, WordSeparators.JustSpecialChars, 16),
                SimplifiedShortSpecialComplex = _generator.Generate(WordList.MediumComplexity, WordSeparators.Complex, 16),
                MediumNoSpace = _generator.Generate(WordList.HighComplexity, WordSeparators.None, 20),
                MediumSpace = _generator.Generate(WordList.HighComplexity, WordSeparators.Spaces, 30),
                MediumSpecial = _generator.Generate(WordList.HighComplexity, WordSeparators.JustSpecialChars, 20),
                MediumSpecialComplex = _generator.Generate(WordList.HighComplexity, WordSeparators.Complex, 20),
                LongNoSpace = _generator.Generate(WordList.HighComplexity, WordSeparators.None, 30),
                LongSpace = _generator.Generate(WordList.HighComplexity, WordSeparators.Spaces, 36),
                LongSpecial = _generator.Generate(WordList.HighComplexity, WordSeparators.JustSpecialChars, 30),
                LongSpecialComplex = _generator.Generate(WordList.HighComplexity, WordSeparators.Complex, 30),
            });
    }

}