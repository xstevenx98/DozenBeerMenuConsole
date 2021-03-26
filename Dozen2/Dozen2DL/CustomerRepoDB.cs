using Dozen2Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class CustomerRepoDB : ICustomerRepository
    {
        private Entities.DBSteveIP0Context context;
        private IMapper _mapper;
        public CustomerRepoDB(Entities.DBSteveIP0Context context, Mapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            var entityCustomer = _mapper.ParseCustomer(newCustomer);
            context.Customers.Add(entityCustomer);
            context.SaveChanges();
            return _mapper.ParseCustomer(entityCustomer);
        }

        public List<Customer> GetCustomers()
        {
            var entityCustomers = context.Customers.ToList();
            var customers = _mapper.ParseCustomers(entityCustomers);
            return customers;
        }

        public List<Customer> GetCustomersByName(string name)
        {
            var entityCustomers = context.Customers.Where(i => i.Name.Contains(name)).ToList();
            var customers = _mapper.ParseCustomers(entityCustomers);
            return customers;
        }
    }
}
