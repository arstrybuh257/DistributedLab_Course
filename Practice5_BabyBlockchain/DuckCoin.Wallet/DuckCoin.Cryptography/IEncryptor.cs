namespace DuckCoin.Cryptography
{
    public record KeyPair(string PublicKey, string PrivateKey);

    public interface IEncryptor
    {
        KeyPair GenerateKeys();
    }
}
