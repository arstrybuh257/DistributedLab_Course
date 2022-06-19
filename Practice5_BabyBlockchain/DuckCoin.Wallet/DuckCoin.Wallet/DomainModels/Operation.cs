namespace DuckCoin.Wallet.DomainModels
{
    public class Operation
    {

        public Operation(string senderAddress, string receiverAddress, string amount)
        {
            SenderAddress = senderAddress;
            ReceiverAddress = receiverAddress;
            Amount = amount;
        }

        public string SenderAddress { get; set; }

        public string ReceiverAddress { get; set; }

        public string Amount { get; set; }
    }
}
