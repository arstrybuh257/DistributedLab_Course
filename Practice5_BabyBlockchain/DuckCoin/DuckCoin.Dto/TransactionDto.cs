namespace DuckCoin.Dto
{
    public class TransactionDto
    {
        public string? TransactionId { get; set; }

        public List<OperationDto> Operations { get; set; }

        public long Nonce { get; set; }

        public bool IsBlockhainTransaction { get; set; }
    }
}
