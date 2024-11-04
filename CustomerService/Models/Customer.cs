using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerService.Models
{
    public class Customer
    {
        [BsonId]
        
        public ObjectId Id { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
    }
}
