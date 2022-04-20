using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakeAPassword.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public readonly ComplexPasswordService ComplexPasswordGenerator;
    public readonly WordPasswordService WordPasswordGenerator;

    public IndexModel(ILogger<IndexModel> logger, ComplexPasswordService complexService, WordPasswordService wordService)
    {
        _logger = logger;
        this.ComplexPasswordGenerator = complexService;
        this.WordPasswordGenerator = wordService;
    }

    public void OnGet()
    {

    }
}
