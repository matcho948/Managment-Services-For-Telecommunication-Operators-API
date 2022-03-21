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
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
        }

        public async Task AddService(int idCustomer, Services service)
        {
            var customer = _context.Customers.FirstOrDefault(p => p.Id == idCustomer);
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            customer.Services.Add(service);
            _context.SaveChanges();
        }

        public async Task<Customers> GetCustomer(int idCustomer)
        {
            var customer = _context.Customers.FirstOrDefault(p => p.Id == idCustomer);
            return customer;
        }
        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        public async Task CreateBills(Services service)
        {
            for(int i=0;i<service.Type.Duration;i++)
            {
                var time = DateTime.Now;
                var newDate = time.AddMonths(i);
                var bill = new Bills();
                bill.Amount = service.Type.Cost;
                bill.Service = service;
                bill.Paid = false;
                bill.Time = newDate;
                _context.Bills.Add(bill);
                _context.SaveChanges();
            }
        }
    }
}
