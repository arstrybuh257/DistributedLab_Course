namespace DuckCoin.Wallet.DomainModels
{
    public class SignedOperation
    {
        public SignedOperation(Operation data, string signature)
        {
            Data = data;
            Signature = signature;
        }

        public Operation Data { get; set; }

        public string Signature { get; set; }
    }
}
