using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dozen2Models;

namespace Dozen2DL
{
    public interface IOrderRepo
    {
        List<Order> GetOrders();
      
    }
}
