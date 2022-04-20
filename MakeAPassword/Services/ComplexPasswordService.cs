using System.Text;
using System.Security.Cryptography;

namespace MakeAPassword;

public class ComplexPasswordService 
{

    public string Generate(string charset, int length)
    {
        StringBuilder password = new StringBuilder();

        for (int x = 0; x < length; x++)
        {
            password.Append(charset[RandomNumberGenerator.GetInt32(0, charset.Length)]);
        }

        return password.ToString();
    }

}