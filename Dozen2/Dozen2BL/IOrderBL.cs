using Dozen2Models;
using System.Collections.Generic;

namespace Dozen2BL
{
    public interface IOrderBL
    {
         List<Order> GetOrders();
         void AddOrder (Order newOrder);
         Order FindOrder(int orderID);
         Order FindOrder(double totalAmount);
         List<Order> GetCustomerOrders(int customerID);
         List<Order> GetLocationOrder(int locationID);
         List <Order> GetLocationOrderTotal(int locationID);
         List<Order> GetCustomerOrderTotal(int customerID);
    }
}