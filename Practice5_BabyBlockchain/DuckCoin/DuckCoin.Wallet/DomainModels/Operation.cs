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
        }

        public string SenderPublicKey { get; set;}

        public string SenderAddress { get; set; }

        public string ReceiverAddress { get; set; }

        public double Amount { get; set; }
    }
}
