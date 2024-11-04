using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TransactionService.Models
{
    public class Transaction
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public required string SourceAccount { get; set; }
        public required string DestinationAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public required string TransactionType { get; set; } // e.g., Transfer, Deposit
    }
}
