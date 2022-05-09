using AutoMapper;
using Managment_Services_API.Data;
using Managment_Services_API.Dtos;
using Managment_Services_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Managment_Services_API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IManagmentServicesRepo _repo;
        private readonly IMapper _mapper;
        public CustomerController(IManagmentServicesRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpPost("/AddCustomer")]
        public async Task<ActionResult> AddCustomer(AddCustomerDto customersDto)
        {
            var customer = _mapper.Map<Customers>(customersDto);
            await _repo.AddCustomer(customer);
            return CreatedAtRoute(nameof(GetCustomerById),new { Id = customer.Id},customer);
        }
        [HttpPost("/AddService")]
        public async Task<ActionResult> AddService(int idCustomer, AddServiceDto serviceDto)
        {
            var type = _mapper.Map<TypeOfServices>(serviceDto.Type);
            ServicesDto serviceDtos = new ServicesDto(type,serviceDto.StartServices,serviceDto.EndServices);
            var service = _mapper.Map<Services>(serviceDtos);
            service.Type = type;
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
