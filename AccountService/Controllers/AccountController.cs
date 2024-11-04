using AccountService.Models;
using AccountService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountManagementService _accountService;

        public AccountController(AccountManagementService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<List<Account>> GetAllAccounts() => _accountService.GetAllAccounts();

        [HttpGet("{accountNumber}")]
        public ActionResult<Account> GetAccountByNumber(string accountNumber)
        {
            var account = _accountService.GetAccountByNumber(accountNumber);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount(Account account)
        {
            _accountService.CreateAccount(account);
            return CreatedAtAction(nameof(GetAccountByNumber), new { accountNumber = account.AccountNumber }, account);
        }

        [HttpPut("{accountNumber}/balance")]
        public IActionResult UpdateAccountBalance(string accountNumber, decimal newBalance)
        {
            _accountService.UpdateAccountBalance(accountNumber, newBalance);
            return NoContent();
        }
    }
}
