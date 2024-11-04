using Microsoft.AspNetCore.Mvc;
using CustomerService.Models;
using CustomerService.Services;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManagementService _customerService;

        public CustomerController(CustomerManagementService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers() => _customerService.GetAllCustomers();

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(string id)
        {
            var customer = _customerService.GetCustomerById(new MongoDB.Bson.ObjectId(id));
            return customer == null ? NotFound() : customer;
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id.ToString() }, customer);
        }
    }
}
