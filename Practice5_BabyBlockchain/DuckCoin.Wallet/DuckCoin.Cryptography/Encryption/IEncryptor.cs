namespace DuckCoin.Cryptography.Encryption
{
    public record KeyPair(string PublicKey, string PrivateKey);

    public interface IEncryptor
    {
        KeyPair GenerateKeys();
    }
}
