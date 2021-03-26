using Dozen2Models;
using System.Collections.Generic;

namespace Dozen2BL
{
    public interface ICustomerBL
    {
         List <Customer> GetCustomers();
        Customer AddCustomer(Customer newCustomer);
        List<Customer> GetCustomersByName(string name);
    }
}