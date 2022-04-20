using MakeAPassword;
using Microsoft.AspNetCore.Mvc;

namespace MakeAPassword;

[ApiController]
[Route("api/[controller]")]

public class NumericController : ControllerBase
{
    private const int maxLength = 16;
    private const int minLength = 6;

    private readonly ComplexPasswordService _generator;

    public NumericController(ComplexPasswordService generator)
    {
        _generator = generator;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new APIResponse(_generator.Generate(ComplexCharacterSets.JustNumbers,minLength)));
    }

    [HttpGet("{length}")]
    public IActionResult Get(int length)
    {
        int actualLength = length;
        if (length > maxLength) { actualLength = maxLength; }
        if (length < minLength) { actualLength = minLength; }

        return Ok(new APIResponse(_generator.Generate(ComplexCharacterSets.JustNumbers,actualLength)));
    }
}