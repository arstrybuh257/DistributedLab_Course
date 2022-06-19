namespace DuckCoin.Cryptography
{
    public interface IHashFunction
    {
        string GetHash(string data);
    }
}
