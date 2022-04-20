using System.Text;

namespace MakeAPassword;

public class ComplexPasswordService 
{    
    private readonly RandomNumberService _random;

    public ComplexPasswordService(RandomNumberService randomService) 
    {
        this._random = randomService;
    }

    public string Generate(string charset, int length)
    {
        StringBuilder password = new StringBuilder();

        for (int x = 0; x < length; x++)
        {
            password.Append(charset[_random.Next(0, charset.Length)]);
        }

        return password.ToString();
    }

}