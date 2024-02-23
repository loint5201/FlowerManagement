using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class OrderRepo : IOrderRepo
    {
        public IEnumerable<Order> GetOrders() => OrderManagement.Instance.GetOrders();
        public void AddNewOrder(Order od) => OrderManagement.Instance.AddNewOrder(od);
        public void UpdateOrder(Order od) => OrderManagement.Instance.UpdateOrder(od);
        public Order GetOrderById(int id) => OrderManagement.Instance?.GetOrderById(id);
        public void RemoveOrder(Order od) => OrderManagement.Instance.RemoveOrder(od);
    }
}
