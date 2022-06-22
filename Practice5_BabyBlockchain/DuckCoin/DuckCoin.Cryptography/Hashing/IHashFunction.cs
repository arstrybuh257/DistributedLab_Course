namespace DuckCoin.Cryptography.Hashing
{
    public interface IHashFunction
    {
        string GetHash(string data);
    }
}
