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
        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customers customers)
        {
            _repo.AddCustomer(customers);
            return Ok();
        }
    }
}
