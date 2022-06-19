namespace DuckCoin.Wallet.DomainModels
{
    public class SignedOperation
    {
        public Operation Data { get; set; }

        public string Signature { get; set; }
    }
}
