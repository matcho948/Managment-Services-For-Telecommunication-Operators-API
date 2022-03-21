using Managment_Services_API.Models;

namespace Managment_Services_API.Data
{
    public interface IManagmentServicesRepo
    {
        public Task AddCustomer(Customers customer);
        public Task<Customers> GetCustomer (int idCustomer);
        public Task AddService(int idCustomer, Services service);
        public Task<IEnumerable<Customers>> GetAllCustomers();
        public Task CreateBills(Services service);
        
    }
}
