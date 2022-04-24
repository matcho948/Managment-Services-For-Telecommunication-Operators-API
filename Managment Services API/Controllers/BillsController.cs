using Managment_Services_API.Data;
using Managment_Services_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Managment_Services_API.Controllers
{
    public class BillsController : ControllerBase
    {
        private readonly IManagmentServicesRepo _repo; 
        public BillsController(IManagmentServicesRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("/GetBills/{idService}")]
        public async Task<ActionResult<IEnumerable<Bills>>> GetBillsForService(int idService)
        {
            var bills = await _repo.GetBills(idService);
            if (bills == null)
                return NotFound();
            return Ok(bills);
        }
        [HttpPut("/ChangePaidToTrue/{idBill}")]
        public async  Task<ActionResult> ChangePaidToTrue(int idBill, [FromBody]Bills bill)
        {
            if(idBill != bill.Id)
                return BadRequest();
            var billUpdate = await _repo.GetBill(idBill);
            if (billUpdate == null)
                return NotFound();
            _repo.ChangePaidToTrue(bill);
            return Ok();
        }
    }
}
