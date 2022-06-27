using DuckCoin.Dto;
using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Helpers
{
    public static class MappingHelper
    {
        public static TransactionDto MapTransactionToDto(Transaction transaction)
        {
            var operationsDto = transaction.Operations.Select(MapOperationToDto).ToList();

            return new TransactionDto()
            {
                TransactionId = transaction.TransactionId,
                Nonce = transaction.Nonce,
                IsBlockhainTransaction = transaction.IsBlockhainTransaction,
                Operations = operationsDto,
            };
        }

        private static OperationDto MapOperationToDto(Operation operation)
        {
            return new OperationDto()
            {
                SenderAddress = operation.SenderAddress,
                SenderPublicKey = operation.SenderPublicKey,
                Amount = operation.Amount,
                Signature = operation.Signature,
                ReceiverAddress = operation.ReceiverAddress,
            };
        }
    }
}
