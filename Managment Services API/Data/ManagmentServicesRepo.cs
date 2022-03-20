using Managment_Services_API.Models;

namespace Managment_Services_API.Data
{
    public class ManagmentServicesRepo : IManagmentServicesRepo
    {
        private readonly AppDbContext _context;
        public ManagmentServicesRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddCustomer(Customers customer)
        {
            if(customer == null)
                throw new ArgumentNullException(nameof(customer));
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
