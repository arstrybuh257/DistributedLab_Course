namespace DuckCoin.Wallet.DomainModels
{
    public class TransactionValidationResult
    {
        public bool IsValid { get; set; }

        public string? Error { get; set; }
    }
}
