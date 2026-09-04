using Sweditech.ConsoleApp.Customers.Models;

namespace Sweditech.ConsoleApp.Customers.Interfaces
{
    internal interface ICustomerService
    {
        public Customer AddCustomer(string name, string email);
        IReadOnlyList<Customer> GetAllCustomers();
    }


}
