using MongoDB.Driver;
using TransactionService.Models;
using System.Threading.Tasks;

namespace TransactionService.Services
{
    public class TransactionManagementService
    {
        private readonly IMongoCollection<Transaction> _transactions;
        private readonly AccountClient _accountClient;

        public TransactionManagementService(IMongoClient client, AccountClient accountClient)
        {
            var database = client.GetDatabase("BankingDB");
            _transactions = database.GetCollection<Transaction>("Transactions");
            _accountClient = accountClient;
        }

        public List<Transaction> GetAllTransactions() => _transactions.Find(transaction => true).ToList();

        public async Task ProcessTransaction(Transaction transaction)
        {
            var sourceAccount = await _accountClient.GetAccountByNumberAsync(transaction.SourceAccount);
            var destinationAccount = await _accountClient.GetAccountByNumberAsync(transaction.DestinationAccount);

            if (sourceAccount == null)
            {
                throw new Exception("Source account not found");
            }

            if (destinationAccount == null)
            {
                throw new Exception("Destination account not found");
            }

            if (sourceAccount.Balance < transaction.Amount)
            {
                throw new Exception("Insufficient balance");
            }

            // Ajuste os saldos nas contas de origem e destino
            sourceAccount.Balance -= transaction.Amount;
            destinationAccount.Balance += transaction.Amount;

            // Salva a transação no MongoDB
            _transactions.InsertOne(transaction);
        }

    }
}
