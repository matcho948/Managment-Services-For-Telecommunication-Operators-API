using Managment_Services_API.Data;
using Managment_Services_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Managment_Services_API.Controllers
{
    [Route("/api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IManagmentServicesRepo _repo;
        public CustomerController(IManagmentServicesRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("/AddCustomer")]
        public async Task<ActionResult> AddCustomer(Customers customers)
        {
            await _repo.AddCustomer(customers);
            return CreatedAtRoute(nameof(GetCustomerById),new { Id = customers.Id},customers);
        }
        [HttpPost("/AddService")]
        public async Task<ActionResult> AddService(int idCustomer, Services service)
        {
            var customer = await _repo.GetCustomer(idCustomer);
            if (customer == null)
                return NotFound();
            await _repo.AddService(idCustomer, service);
            await _repo.CreateBills(service);
            return Ok();
        }
        [HttpGet("/GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customers>>> GetAllCustomers()
        {
            var customers = await _repo.GetAllCustomers();
            if (customers == null)
                return NotFound();
            return Ok(customers);
        }
        [HttpGet("GetCustomer/{id}", Name = "GetCustomerById")]
        public async Task<ActionResult<Customers>> GetCustomerById(int id)
        {
            var customer = await _repo.GetCustomer(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
    }
}
