using DuckCoin.FullNode.DomainModels;
using DuckCoin.FullNode.Services;
using DuckCoin.FullNode.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DuckCoin.FullNode.Controllers;

[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAccountAsync(string? accountAddress)
    {
        var account = new Account(accountAddress);

        if (await _accountService.ExistsAsync(accountAddress))
        {
            return BadRequest($"Account with address {accountAddress} already exists");
        }
        
        await _accountService.AddAccountAsync(account);
        return NoContent();
    }
}