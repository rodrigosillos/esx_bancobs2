using AccountService.Models;
using MongoDB.Driver;

namespace AccountService.Services
{
    public class AccountManagementService
    {
        private readonly IMongoCollection<Account> _accounts;

        public AccountManagementService(IMongoClient client)
        {
            var database = client.GetDatabase("BankingDB");
            _accounts = database.GetCollection<Account>("Accounts");
        }

        public List<Account> GetAllAccounts() => _accounts.Find(account => true).ToList();

        public Account GetAccountByNumber(string accountNumber) =>
            _accounts.Find(account => account.AccountNumber == accountNumber).FirstOrDefault();

        public Account CreateAccount(Account account)
        {
            _accounts.InsertOne(account);
            return account;
        }

        public void UpdateAccountBalance(string accountNumber, decimal newBalance)
        {
            var filter = Builders<Account>.Filter.Eq(a => a.AccountNumber, accountNumber);
            var update = Builders<Account>.Update.Set(a => a.Balance, newBalance);
            _accounts.UpdateOne(filter, update);
        }
    }
}
