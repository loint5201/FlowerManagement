using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderDetailManagement
    {
        private OrderDetailManagement() { }
        private static OrderDetailManagement instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailManagement();
                    }
                    return instance;
                }
            }
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            OrderDetail od = null;
            var c = new FUFlowerBouquetManagementContext();
            try
            {
                od = c.OrderDetails.SingleOrDefault(c => c.OrderId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return od;
        }

        public void RemoveOrderDetail(OrderDetail od)
        {
            try
            {
                OrderDetail _od = GetOrderDetailById(od.OrderId);
                if (od != null)
                {
                    var c = new FUFlowerBouquetManagementContext();
                    c.OrderDetails.Remove(od);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail does not already Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> list = new List<OrderDetail>();
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                list = DbContext.OrderDetails.ToList();

            }
            catch (Exception)
            {
                throw new Exception("Get list Orders Detail unsuccessfully");
            }
            return list;
        }

        public void AddNewOrderDetail(OrderDetail od)
        {
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                DbContext.OrderDetails.Add(od);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Add a new OrderDetails unsuccessfully ");
            }
        }
    }
}
