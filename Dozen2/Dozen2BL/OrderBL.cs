using Dozen2DL;
using Dozen2Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2BL
{
    public class OrderBL : IOrderBL
    {
        private OrderRepositoryDB orderRepoDB;

        public OrderBL(OrderRepositoryDB orderRepoDB)
        {
            this.orderRepoDB = orderRepoDB;
        }

        public void AddOrder(Order newOrder)
        {
            orderRepoDB.AddOrder(newOrder);
        }

        public Order FindOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public Order FindOrder(double totalAmount)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrderTotal(int customerID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrder(int locationID)
        {
            return orderRepoDB.GetLocationOrder(locationID);
        }

        public List<Order> GetLocationOrderTotal(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrders(int customerId)
        {
            return orderRepoDB.GetCustomerOrders(customerId);
        }
    }
}
