using Microsoft.AspNetCore.Mvc;

namespace DuckCoin.FullNode.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("DuckCoin.FullNode is up and running.");
        }
    }
}
