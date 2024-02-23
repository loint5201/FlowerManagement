using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface IOrderDetailRepo
    {
        void RemoveOrderDetail(OrderDetail od);
        OrderDetail GetOrderDetailById(int id);
        IEnumerable<OrderDetail> GetOrderDetails();
        void AddNewOrderDetail(OrderDetail od);
    }
}
