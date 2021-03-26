using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public interface IMapper
    {
        public Entities.Customer ParseCustomer(Dozen2Models.Customer customer);
        public List<Dozen2Models.Customer> ParseCustomers(List<Entities.Customer> entityCustomers);
        //   public Entities.Order ParseOrder(Dozen2Models.Order entityOrder);
        public Dozen2Models.Customer ParseCustomer(Entities.Customer entityCustomer);
        public List<Dozen2Models.Order> ParseOrders(List<Entities.Order> entityOrders);
        Entities.Order ParseOrder(Dozen2Models.Order newOrder);
    }
}
