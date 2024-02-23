using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetOrders();
        void AddNewOrder(Order od);
        void UpdateOrder(Order od);
        Order GetOrderById(int id);
        void RemoveOrder(Order od);
    }
}
