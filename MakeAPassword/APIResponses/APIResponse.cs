namespace MakeAPassword;

public class APIResponse 
{
    public string Value { get; set; }

    public APIResponse(string value) 
    {
        this.Value = value;
    }
}