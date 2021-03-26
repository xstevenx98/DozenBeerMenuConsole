using Dozen2Models;
using System.Collections.Generic;

namespace Dozen2DL
{
    public interface ICustomerRepository
    {
         List <Customer> GetCustomers();
         Customer AddCustomer (Customer newCustomer);
        List<Customer> GetCustomersByName(string name);
    }
}