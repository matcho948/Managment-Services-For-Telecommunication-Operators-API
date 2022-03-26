using Managment_Services_API.Models;
using Microsoft.EntityFrameworkCore;

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
            var customer = await _context.Customers.FirstOrDefaultAsync(p => p.Id == idCustomer);
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            customer.Services.Add(service);
            _context.SaveChanges();
        }

        public async Task<Customers> GetCustomer(int idCustomer)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(p => p.Id == idCustomer);
            return customer;
        }
        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task CreateBills(Services service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            for (int i=0;i<service.Type.Duration;i++)
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

        public async Task<IEnumerable<Bills>> GetBills(int idService)
        {
         var bills = await _context.Bills.Where(p=>p.Service.Id == idService).ToListAsync();
         return bills;
        }

        public async Task<Bills> GetBill(int id)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(p => p.Id == id);
            return bill;
        }

        public bool ChangePaidToTrue(Bills bill)
        {
            bill.Paid = true;
            _context.SaveChanges();
            if (bill.Paid)
                return true;
            return false;
        }
    }
}
