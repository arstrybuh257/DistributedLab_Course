using AutoMapper;
using DuckCoin.Dto;
using DuckCoin.FullNode.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace DuckCoin.FullNode.Controllers
{
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMapper _mapper;

        public TransactionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostTransactionAsync([FromBody] TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            if (transaction == null)
            {
                return BadRequest("Transaction had invalid format.");
            }

            MemPool.AddTransaction(transaction);
            return NoContent();
        }
    }
}
