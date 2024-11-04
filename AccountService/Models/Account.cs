using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AccountService.Models
{
    public class Account
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public required string AccountNumber { get; set; }
        public required string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
        public required string AccountType { get; set; } // e.g., Savings, Checking
    }
}
