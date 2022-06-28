using DuckCoin.Cryptography.Encryption;

namespace DuckCoin.Wallet.DomainModels
{
    public class Operation
    {

        public Operation(string senderAddress, string receiverAddress, double amount, string senderPublicKey)
        {
            SenderAddress = senderAddress;
            SenderPublicKey = senderPublicKey;
            ReceiverAddress = receiverAddress;
            Amount = amount;
            Signature = null;
        }

        public string SenderPublicKey { get; set;}

        public string SenderAddress { get; set; }

        public string ReceiverAddress { get; set; }

        public double Amount { get; set; }

        public string? Signature { get; set; }

        public void SignOperation(IEncryptor encryptor, string privateKey)
        {     
            Signature = encryptor.Sign(GetOperationString(), privateKey);
        }

        public bool VerifySignature(IEncryptor encryptor, string publicKey)
        {
            return encryptor.VerifySign(publicKey, GetOperationString(), Signature);
        }

        public string GetOperationString()
        {
            return SenderPublicKey + SenderAddress + ReceiverAddress + Amount.ToString();
        }
    }
}
