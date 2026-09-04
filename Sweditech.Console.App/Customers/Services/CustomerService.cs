using Sweditech.ConsoleApp.Customers.Interfaces;
using Sweditech.ConsoleApp.Customers.Models;

namespace Sweditech.ConsoleApp.Customers.Services
{
    internal class CustomerService : ICustomerService
    {
        public List<Customer> _customerList = new List<Customer>();

        public Customer AddCustomer(string name, string email)
        {
            Customer newcustomer = new Customer
            {
                Name = name,
                Email = email
            };

            _customerList.Add(newcustomer);

            return newcustomer;
        }

        public IReadOnlyList<Customer> GetAllCustomers()
        {
            return _customerList.AsReadOnly();
        }
    }
}
