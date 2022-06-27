namespace DuckCoin.Dto
{
    public class TransactionDto
    {
        public string? TransactionId { get; private set; }

        public List<OperationDto> Operations { get; private set; }

        public long Nonce { get; set; }

        public bool IsBlockhainTransaction { get; set; }
    }
}
