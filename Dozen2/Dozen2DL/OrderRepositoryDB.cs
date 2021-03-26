using Dozen2Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class OrderRepositoryDB : IOrderRepo
    {

        private IMapper _mapper;
        private Entities.DBSteveIP0Context _context;

        public OrderRepositoryDB (Entities.DBSteveIP0Context context, Mapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public void AddOrder(Order newOrder)
        {
            Entities.Order entityOrder = _mapper.ParseOrder(newOrder);
            _context.Orders.Add(entityOrder);
            _context.SaveChanges();
            var inventory = _context.Inventories.Where(i => i.DrinkId == entityOrder.DrinkId && i.LocationId == entityOrder.LocationId).FirstOrDefault();
            if(inventory != null)
            {
                inventory.Quantity = inventory.Quantity - entityOrder.Quantity;
                _context.SaveChanges();

            }
        }


        public Order FindOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrder(int locationID)
        {
            var entityOrders = _context.Orders
                .Include("Customer")
                .Include("Drink")
                .Include("Location")
                .Where(i => i.LocationId == locationID)
                .ToList();

            var orders = _mapper.ParseOrders(entityOrders);

            return orders;
        }

        public Order FindOrder(double totalCost)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrders(int customerId)
        {
            var entityOrders = _context.Orders
                .Include("Customer")
                .Include("Drink")
                .Include("Location")
                .Where(i => i.CustomerId == customerId)
                .ToList();

            var orders = _mapper.ParseOrders(entityOrders);

            return orders;
        }

        public List<Order> GetCustomerOrdersASC(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersASCTotal(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersDESC(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersDESCTotal(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderASC(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderASCTotal(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderDESC(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderDESCTotal(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
