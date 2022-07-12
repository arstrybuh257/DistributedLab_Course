using AutoMapper;
using DuckCoin.Dto;
using DuckCoin.FullNode.Core;
using DuckCoin.FullNode.DomainModels;
using DuckCoin.FullNode.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DuckCoin.FullNode.Controllers
{
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITransactionManager _transactionManager;
        private readonly IApprovedTransactionService _transactionService;
 
        public TransactionController(IMapper mapper, ITransactionManager transactionManager, IApprovedTransactionService transactionService)
        {
            _mapper = mapper;
            _transactionManager = transactionManager;
            _transactionService = transactionService;
        }

        [HttpGet("getOperationsByAccount/{accountId}")]
        public async Task<IActionResult> GetAllOperationsByAccountIdAsync(string accountId)
        {
            var operations = await _transactionService.GetOperationsByAccountIdAsync(accountId);

            if (operations.Any())
            {
                var operationsDto = _mapper.Map<IEnumerable<OperationDto>>(operations);
                return Ok(operations);
            }

            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> PostTransactionAsync([FromBody] TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            if (transaction == null)
            {
                return BadRequest("Transaction had invalid format");
            }

            var isTransactionValid = await _transactionManager.ValidateTransactionAsync(transaction);

            if (!isTransactionValid)
            {
                return BadRequest("Transaction is invalid");
            }
            
            MemPool.AddTransaction(transaction);
            return NoContent();
        }
    }
}
