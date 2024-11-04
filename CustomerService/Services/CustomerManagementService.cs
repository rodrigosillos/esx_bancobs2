using MongoDB.Driver;
using MongoDB.Bson;
using CustomerService.Models;

namespace CustomerService.Services
{
    public class CustomerManagementService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerManagementService(IMongoClient client)
        {
            var database = client.GetDatabase("BankingDB");
            _customers = database.GetCollection<Customer>("Customers");
        }

        public List<Customer> GetAllCustomers() => _customers.Find(customer => true).ToList();

        public Customer GetCustomerById(ObjectId id) => _customers.Find(customer => customer.Id == id).FirstOrDefault();

        public Customer CreateCustomer(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }
    }
}
