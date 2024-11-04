using Microsoft.AspNetCore.Mvc;
using TransactionService.Models;
using TransactionService.Services;

namespace TransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionManagementService _transactionService;

        public TransactionController(TransactionManagementService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult<List<Transaction>> GetAllTransactions() => _transactionService.GetAllTransactions();

        [HttpPost]
        public async Task<IActionResult> ProcessTransaction(Transaction transaction)
        {
            try
            {
                await _transactionService.ProcessTransaction(transaction);
                return Ok("Transaction processed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
