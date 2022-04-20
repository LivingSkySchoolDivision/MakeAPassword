namespace MakeAPassword;

public class RandomNumberService 
{
    private readonly CryptoRandom _random = new CryptoRandom();

    public int Next() 
    {
        return _random.Next();
    }
    
    public int Next(int Max) 
    {
        return _random.Next(Max);
    }
    
    public int Next(int Min, int Max) 
    {
        return _random.Next(Min, Max);
    }

}