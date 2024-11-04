using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoanService.Models
{
    public class Loan
    {
        [BsonId]

        public ObjectId Id { get; set; }

        public required string AccountNumber { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermInMonths { get; set; }
        public DateTime StartDate { get; set; }
    }
}
