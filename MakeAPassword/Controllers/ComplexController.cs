using MakeAPassword;
using Microsoft.AspNetCore.Mvc;

namespace MakeAPassword;

[ApiController]
[Route("api/[controller]")]

public class ComplexController : ControllerBase
{
    private const int maxLength = 256;
    private const int minLength = 8;

    private readonly ComplexPasswordService _generator;

    public ComplexController(ComplexPasswordService generator)
    {
        _generator = generator;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new APIResponse(_generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,64)));
    }

    [HttpGet("{length}")]
    public IActionResult Get(int length)
    {
        int actualLength = length;
        if (length > maxLength) { actualLength = maxLength; }
        if (length < minLength) { actualLength = minLength; }

        return Ok(new APIResponse(_generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,actualLength)));
    }
}