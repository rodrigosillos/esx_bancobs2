using Microsoft.AspNetCore.Mvc;
using LoanService.Models;
using LoanService.Services;

namespace LoanService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LoanManagementService _loanService;

        public LoanController(LoanManagementService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public ActionResult<List<Loan>> GetAllLoans() => _loanService.GetAllLoans();

        [HttpGet("{accountNumber}")]
        public ActionResult<Loan> GetLoanByAccount(string accountNumber)
        {
            var loan = _loanService.GetLoanByAccount(accountNumber);
            return loan == null ? NotFound() : loan;
        }

        [HttpPost]
        public ActionResult<Loan> ApplyForLoan(Loan loan)
        {
            _loanService.ApplyForLoan(loan);
            return CreatedAtAction(nameof(GetLoanByAccount), new { accountNumber = loan.AccountNumber }, loan);
        }

        [HttpGet("calculate")]
        public ActionResult<decimal> CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int termInMonths)
        {
            var payment = _loanService.CalculateMonthlyPayment(loanAmount, interestRate, termInMonths);
            return Ok(payment);
        }
    }
}
