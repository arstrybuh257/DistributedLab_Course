namespace DuckCoin.Dto
{
    public class OperationDto
    {
        public string SenderPublicKey { get; set; }

        public string SenderAddress { get; set; }

        public string ReceiverAddress { get; set; }

        public double Amount { get; set; }

        public string? Signature { get; set; }
    }
}