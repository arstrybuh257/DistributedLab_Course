namespace DuckCoin.Cryptography.Encryption
{
    public record KeyPair(string PublicKey, string PrivateKey);

    public interface IEncryptor
    {
        bool VerifySign(string publicKey, string data, string sign);
        string Sign(string data, string privateKey);
        KeyPair GenerateKeys();
    }
}
