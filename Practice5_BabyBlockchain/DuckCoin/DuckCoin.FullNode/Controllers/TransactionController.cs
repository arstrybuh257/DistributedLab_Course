using Microsoft.AspNetCore.Mvc;

namespace DuckCoin.FullNode.Controllers
{
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostTransactionAsync([FromBody] Transaction transaction)
        {
            return Ok();
        }

    }
}
