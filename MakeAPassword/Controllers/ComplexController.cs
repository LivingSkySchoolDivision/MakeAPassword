using MakeAPassword;
using Microsoft.AspNetCore.Mvc;

namespace MakeAPassword;

[ApiController]
[Route("API/[controller]")]

public class ComplexController : ControllerBase
{
    private readonly ComplexPasswordService _generator;

    public ComplexController(ComplexPasswordService generator)
    {
        _generator = generator;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new 
        {
            complexSpecial8 = _generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,8),
            complexSpecial12 = _generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,12),
            complexSpecial20 = _generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,20),
            complexSpecial25 = _generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,25),
            complexSpecial32 = _generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,32),
            complexSpecial64 = _generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,64),
            complexSpecial128 = _generator.Generate(ComplexCharacterSets.AlphaNumericWithSpecialChars,128),
            complexAlphaNumeric8 = _generator.Generate(ComplexCharacterSets.AlphaNumeric,8),
            complexAlphaNumeric12 = _generator.Generate(ComplexCharacterSets.AlphaNumeric,12),
            complexAlphaNumeric20 = _generator.Generate(ComplexCharacterSets.AlphaNumeric,20),
            complexAlphaNumeric25 = _generator.Generate(ComplexCharacterSets.AlphaNumeric,25),
            complexAlphaNumeric32 = _generator.Generate(ComplexCharacterSets.AlphaNumeric,32),
            complexAlphaNumeric64 = _generator.Generate(ComplexCharacterSets.AlphaNumeric,64),
            complexAlphaNumeric128 = _generator.Generate(ComplexCharacterSets.AlphaNumeric,128),
            complexCiscoSafe8 = _generator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,8),
            complexCiscoSafe12 = _generator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,12),
            complexCiscoSafe20 = _generator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,20),
            complexCiscoSafe25 = _generator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,25),
            complexCiscoSafe32 = _generator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,32),
            complexCiscoSafe64 = _generator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,64),
            complexCiscoSafe128 = _generator.Generate(ComplexCharacterSets.AlphaNumericCiscoSafe,128),
        });
    }
}