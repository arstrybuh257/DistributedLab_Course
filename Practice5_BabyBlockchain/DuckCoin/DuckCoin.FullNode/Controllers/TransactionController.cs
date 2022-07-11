using AutoMapper;
using DuckCoin.Dto;
using DuckCoin.FullNode.Core;
using DuckCoin.FullNode.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace DuckCoin.FullNode.Controllers
{
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITransactionValidator _transactionValidator;
 
        public TransactionController(IMapper mapper, ITransactionValidator transactionValidator)
        {
            _mapper = mapper;
            _transactionValidator = transactionValidator;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransactionAsync([FromBody] TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            if (transaction == null)
            {
                return BadRequest("Transaction had invalid format");
            }

            var isTransactionValid = await _transactionValidator.ValidateTransactionAsync(transaction);

            if (!isTransactionValid)
            {
                return BadRequest("Transaction is invalid");
            }
            
            MemPool.AddTransaction(transaction);
            return NoContent();
        }
    }
}
