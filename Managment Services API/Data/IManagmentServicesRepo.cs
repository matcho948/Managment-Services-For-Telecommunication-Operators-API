using Managment_Services_API.Models;

namespace Managment_Services_API.Data
{
    public interface IManagmentServicesRepo
    {
        public Task AddCustomer(Customers customer);
    }
}
