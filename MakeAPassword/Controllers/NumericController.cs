using MakeAPassword;
using Microsoft.AspNetCore.Mvc;

namespace MakeAPassword;

[ApiController]
[Route("API/[controller]")]

public class NumericController : ControllerBase
{
    private readonly ComplexPasswordService _generator;

    public NumericController(ComplexPasswordService generator)
    {
        _generator = generator;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new 
            {
                numeric4 = _generator.Generate(ComplexCharacterSets.JustNumbers,4),
                numeric6 = _generator.Generate(ComplexCharacterSets.JustNumbers,6),
                numeric8 = _generator.Generate(ComplexCharacterSets.JustNumbers,8),
                numeric12 = _generator.Generate(ComplexCharacterSets.JustNumbers,12),
                numeric16 = _generator.Generate(ComplexCharacterSets.JustNumbers,16),
                numeric20 = _generator.Generate(ComplexCharacterSets.JustNumbers,20),
                numeric24 = _generator.Generate(ComplexCharacterSets.JustNumbers,24),
                numeric29 = _generator.Generate(ComplexCharacterSets.JustNumbers,29),
                numeric32 = _generator.Generate(ComplexCharacterSets.JustNumbers,32),
                numeric128 = _generator.Generate(ComplexCharacterSets.JustNumbers,128)
            });
    }

}