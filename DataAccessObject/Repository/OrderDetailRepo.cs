using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        public OrderDetail GetOrderDetailById(int id) => OrderDetailManagement.Instance?.GetOrderDetailById(id);
        public void RemoveOrderDetail(OrderDetail od) => OrderDetailManagement.Instance.RemoveOrderDetail(od);
        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailManagement.Instance.GetOrderDetails();
        public void AddNewOrderDetail(OrderDetail od) => OrderDetailManagement.Instance.AddNewOrderDetail(od);
    }
}
