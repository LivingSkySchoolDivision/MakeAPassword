using MakeAPassword;
using Microsoft.AspNetCore.Mvc;

namespace MakeAPassword;

[ApiController]
[Route("api/[controller]")]

public class WordsController : ControllerBase
{
    private const int maxLength = 128;
    private const int minLength = 8;

    private readonly WordPasswordService _generator;

    public WordsController(WordPasswordService generator)
    {
        _generator = generator;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new APIResponse(_generator.Generate(WordList.HighComplexity, WordSeparators.JustSpecialChars, minLength)));
    }

    [HttpGet("{length}")]
    public IActionResult Get(int length)
    {
        int actualLength = length;
        if (length > maxLength) { actualLength = maxLength; }
        if (length < minLength) { actualLength = minLength; }

        
        return Ok(new APIResponse(_generator.Generate(WordList.HighComplexity, WordSeparators.Spaces, actualLength)));
    }
}