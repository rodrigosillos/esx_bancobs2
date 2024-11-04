using MongoDB.Driver;
using LoanService.Models;

namespace LoanService.Services
{
    public class LoanManagementService
    {
        private readonly IMongoCollection<Loan> _loans;

        public LoanManagementService(IMongoClient client)
        {
            var database = client.GetDatabase("BankingDB");
            _loans = database.GetCollection<Loan>("Loans");
        }

        public List<Loan> GetAllLoans() => _loans.Find(loan => true).ToList();

        public Loan GetLoanByAccount(string accountNumber) => 
            _loans.Find(loan => loan.AccountNumber == accountNumber).FirstOrDefault();

        public Loan ApplyForLoan(Loan loan)
        {
            _loans.InsertOne(loan);
            return loan;
        }

        public decimal CalculateMonthlyPayment(decimal loanAmount, decimal interestRate, int termInMonths)
        {
            var monthlyRate = (double)(interestRate / 12 / 100); 
            var denominator = 1 - (decimal)Math.Pow(1 + monthlyRate, -termInMonths);
            return loanAmount * (decimal)monthlyRate / denominator;
        }

    }
}
